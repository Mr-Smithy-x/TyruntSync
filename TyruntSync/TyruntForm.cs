using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TyruntSync.Callbacks;
using TyruntSync.Models;
using TyruntSync.Server;

namespace TyruntSync
{
    public partial class TyruntForm : Form, ITyruntListener
    {
        #region Fields
        private List<DeviceInfo> connectedDevices = new List<DeviceInfo>();
        private List<Torrent> launchedTorrents = new List<Torrent>();
        private List<Torrent> savedTorrents = new List<Torrent>();
        private delegate void SetOnTorrentFailedCallback(string title, string message, Torrent torrent);
        private delegate void SetOnDeviceConnectedCallback(DeviceInfo deviceInfo);
        private delegate void SetOnTorrentLaunchedCallback(Torrent torrent);
        private delegate void SetOnTorrentSavedCallback(Torrent torrent);
        private delegate void SetOnClientCheckCallback(ListViewItem deviceInfo);
        private delegate void OnDisplayNotifcation(String title, String message, ToolTipIcon icon);
        private delegate void SetOnDeviceRemovedCallback(int index);
        private delegate void SetOnLoopListCallback();
        private TyruntServer server;
        private Thread connectedStatus;
        private bool checkConnectedEnd = false;
        private const int PING_PONG_TIME = 10000;
        #endregion
        public TyruntForm()
        {
            InitializeComponent();
            restoreState();
            displayNotification("Tyrunt Running", "Starting Server", ToolTipIcon.Info);
            server = new TyruntServer(4711);
            server.addTyruntListener(this);
            CheckConnectedStatus();
           
        }
        public void displayNotification(String title, String message, ToolTipIcon icon)
        {
            if (this.InvokeRequired)
            {
                OnDisplayNotifcation odn = new OnDisplayNotifcation(displayNotification);
                this.Invoke(odn, new object[] { title, message, icon });
            }
            else
            {
                mNotify.BalloonTipTitle = title;
                mNotify.BalloonTipText = message;
                mNotify.Text = message;
                mNotify.BalloonTipIcon = icon;
                mNotify.Visible = true;
                mNotify.ShowBalloonTip(2000, title, message, icon);
            }
        }

        #region Closing App
        private void endCheckingThread()
        {
            checkConnectedEnd = !checkConnectedEnd;
        }
        private void OnTyruntFormClosing(object sender, FormClosingEventArgs e)
        {
            saveState();
            server.endServer();
            endCheckingThread();
        }
        #endregion

        #region List<>
        public List<DeviceInfo> getDevices()
        {
            return connectedDevices;
        }
        public List<Torrent> getSavedTorrents()
        {
            return savedTorrents;
        }
        public List<Torrent> getLaunchedTorrents()
        {
            return launchedTorrents;
        }
        #endregion

        #region InputOutput
        private void restoreState()
        {
            if (File.Exists("saved.json") && File.Exists("launched.json"))
            {
                String saved = File.ReadAllText("saved.json");
                String launched = File.ReadAllText("launched.json");
                savedTorrents = JsonConvert.DeserializeObject<List<Torrent>>(saved);
                launchedTorrents = JsonConvert.DeserializeObject<List<Torrent>>(launched);
                foreach (Torrent l in launchedTorrents) OnTorrentLaunched(l);
                foreach (Torrent l in savedTorrents) OnTorrentSaved(l);
            }
        }
        private void saveState()
        {
            string savedTorrents = JsonConvert.SerializeObject(getSavedTorrents(), Formatting.Indented);
            string launchedTorrents = JsonConvert.SerializeObject(getLaunchedTorrents(), Formatting.Indented);
            FileStream saved = new FileStream("saved.json", FileMode.Create);
            saved.Write(ASCIIEncoding.UTF8.GetBytes(savedTorrents), 0, savedTorrents.Length);
            saved.Flush();
            saved.Close();
            FileStream launched = new FileStream("launched.json", FileMode.Create);
            launched.Write(ASCIIEncoding.UTF8.GetBytes(launchedTorrents), 0, launchedTorrents.Length);
            launched.Flush();
            launched.Close();
        }
        #endregion

        #region List Functions
        private void CheckConnectedStatus()
        {
            if (connectedStatus == null)
            {

                connectedStatus = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        if (checkConnectedEnd) break;
                        try
                        {
                            Thread.Sleep(5000);
                            LoopList();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }));

                connectedStatus.Start();
            }
        }
        private void LoopList()
        {
            if (connectedDeviceListView.InvokeRequired)
            {
                SetOnLoopListCallback sollc = new SetOnLoopListCallback(LoopList);
                this.Invoke(sollc, new object[] { });
            }
            else {
                foreach (ListViewItem item in connectedDeviceListView.Items)
                {
                    CheckDevice(item);
                }
            }
        }
        private void CheckDevice(ListViewItem item)
        {
            if (connectedDeviceListView.InvokeRequired)
            {
                SetOnClientCheckCallback soccc = new SetOnClientCheckCallback(CheckDevice);
                this.Invoke(soccc, new object[] { item });
            }
            else {
                int index = connectedDeviceListView.Items.IndexOf(item);
                if (server.sendPing(connectedDevices[index]))
                {
                    Console.WriteLine("Pinging Device: " + connectedDevices[index].model + ", " + connectedDevices[index].tcpClient.Client.RemoteEndPoint);
                }
                else
                {
                    OnRemoveDevice(index);
                }
            }
        }
        public void OnRemoveDevice(int index)
        {
            if (connectedDeviceListView.InvokeRequired)
            {
                SetOnDeviceRemovedCallback sodrc = new SetOnDeviceRemovedCallback(OnRemoveDevice);
                this.Invoke(sodrc, new object[] { index });
            }
            else {
                if (connectedDevices.Count > 0)
                {
                    connectedDevices.RemoveAt(index);
                }
                if (connectedDeviceListView.Items.Count > 0)
                {
                    connectedDeviceListView.Items.RemoveAt(index);
                }
            }
        }
        private int findIndex(TcpClient tcpClient)
        {
            foreach (DeviceInfo deviceInfo in connectedDevices)
            {
                if (deviceInfo.tcpClient.Client.RemoteEndPoint == tcpClient.Client.RemoteEndPoint)
                {
                    return connectedDevices.IndexOf(deviceInfo);
                }
            }
            return -1;
        }
        #endregion

        #region Events
        public void OnTorrentFailed(string title, string message, Torrent torrent)
        {
            if (this.InvokeRequired)
            {
                SetOnTorrentFailedCallback sotdcb = new SetOnTorrentFailedCallback(OnTorrentFailed);
                this.Invoke(sotdcb, new object[] { title, message, torrent });
            }
            else
            {
                displayNotification(title, message, ToolTipIcon.None);
            }
       }
        public void OnTorrentLaunched(Torrent torrent)
        {
            if (this.torrentLogListView.InvokeRequired)
            {
                SetOnTorrentLaunchedCallback sotdcb = new SetOnTorrentLaunchedCallback(OnTorrentLaunched);
                this.Invoke(sotdcb, new object[] { torrent });
            }
            else
            {
                if(!launchedTorrents.Contains(torrent))
                    launchedTorrents.Add(torrent);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = torrent.author;
                lvi.SubItems.Add(torrent.title);
                lvi.SubItems.Add(torrent.size);
                lvi.SubItems.Add(torrent.seeds);
                lvi.SubItems.Add(torrent.time);
                torrentLogListView.Items.Add(lvi);
            }
        }
        public void OnTorrentSaved(Torrent torrent)
        {
            if (this.torrentLogListView.InvokeRequired)
            {
                SetOnTorrentSavedCallback sotdcb = new SetOnTorrentSavedCallback(OnTorrentSaved);
                this.Invoke(sotdcb, new object[] { torrent });
            }
            else
            {
                if (!savedTorrents.Contains(torrent))
                    savedTorrents.Add(torrent);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = torrent.author;
                lvi.SubItems.Add(torrent.title);
                lvi.SubItems.Add(torrent.size);
                lvi.SubItems.Add(torrent.seeds);
                lvi.SubItems.Add(torrent.time);
                favoriteTorrentListView.Items.Add(lvi);
            }
        }
        public void OnDeviceConnected(DeviceInfo deviceInfo)
        {
            if (this.torrentLogListView.InvokeRequired)
            {
                SetOnDeviceConnectedCallback sotdcb = new SetOnDeviceConnectedCallback(OnDeviceConnected);
                this.Invoke(sotdcb, new object[] {deviceInfo});
            }
            else
            {
                connectedDevices.Add(deviceInfo);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = deviceInfo.device;
                lvi.SubItems.Add(deviceInfo.version);
                lvi.SubItems.Add(deviceInfo.model);
                lvi.SubItems.Add(deviceInfo.tcpClient.Client.RemoteEndPoint.ToString());
                lvi.SubItems.Add(deviceInfo.tcpClient.Connected.ToString());
                connectedDeviceListView.Items.Add(lvi);
                displayNotification(deviceInfo.model, "Connected", ToolTipIcon.None);
            }
        }
        public void OnDeviceAlive(TcpClient tcpClient)
        {
            int i = findIndex(tcpClient);
            DeviceInfo info = connectedDevices[i];
            Console.WriteLine("Connected Device: " + info.model + ", " + tcpClient.Client.RemoteEndPoint + " - " + tcpClient.Client.Connected);
        }
        public void OnDeviceDisconnected(TcpClient tcpClient)
        {
            int i = findIndex(tcpClient);
            if (i > -1)
            {
                DeviceInfo d = connectedDevices[i];

                displayNotification(d.model, "Disconnected", ToolTipIcon.Info);
                Console.WriteLine("Disconnected Device: " + d.model + ", " + tcpClient.Client.RemoteEndPoint + " - " +tcpClient.Client.Connected);
                try { OnRemoveDevice(i);
                }catch(Exception ex) { Console.WriteLine(ex); }
            }
        }
        #endregion

        #region ListViewIndices
        public int getIndex(ListView.SelectedIndexCollection indices)
        {
            if (indices.Count > 0)
                return indices[0];
            else return -1;
        }

        #endregion

        #region ListViewClickOptions

        #region Favorites
        private void copyMagnetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = getIndex(favoriteTorrentListView.SelectedIndices);
            if(index > -1)
            {
                Torrent t = savedTorrents[index];
                Clipboard.SetText(t.magnet, TextDataFormat.Text);
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getIndex(favoriteTorrentListView.SelectedIndices);
            if (index > -1)
            {
                Torrent t = savedTorrents[index];
                Process.Start(t.magnet);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getIndex(favoriteTorrentListView.SelectedIndices);
            if (index > -1)
            {
                favoriteTorrentListView.Items.RemoveAt(index);
                savedTorrents.RemoveAt(index);
            }
        }

        #endregion

        #region ConnectedDevices
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getIndex(connectedDeviceListView.SelectedIndices);
            if (index > -1)
            {
                connectedDevices[index].tcpClient.Close();
            }
        }

        #endregion

        #region launchedTorrents
        private void copyMagnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getIndex(torrentLogListView.SelectedIndices);
            if (index > -1)
            {
                Torrent t = launchedTorrents[index];
                Clipboard.SetText(t.magnet, TextDataFormat.Text);
            }
        }

        private void downloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int index = getIndex(torrentLogListView.SelectedIndices);
            if (index > -1)
            {
                Torrent t = launchedTorrents[index];
                Process.Start(t.magnet);
            }
        }
        #endregion

        #endregion
    }
}
