using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TyruntSync.Callbacks;
using TyruntSync.Models;
using TyruntSync.Utils;

namespace TyruntSync.Server
{
    class TyruntServer
    {
        #region Fields
        private TcpListener tcp;
        private int port;
        private Dictionary<String, List<String>> torrents = new Dictionary<String, List<String>>();
        private Thread serverLoop;
        private bool end = false;
        private ITyruntListener tyruntListener;
        #endregion
        public TyruntServer(int port = 4711)
        {
            this.port = port;
            startServer();
        }
        public void startServer()
        {
            end = false;
            if (tcp == null) tcp = new TcpListener(IPAddress.Any, 4711);
            if (serverLoop == null)
                serverLoop = new Thread(new ThreadStart(() =>
                {
                    Console.WriteLine("Started");
                    tcp.Start();
                    while (true)
                    {
                        if (end) break;
                        if (tcp.Pending())
                            handleClient(tcp.AcceptTcpClient());
                    }
                }));
            if (!serverLoop.IsAlive)
            {
                serverLoop.Start();
            }

        }
        internal void endServer()
        {
            end = true;
        }
        public void addTyruntListener(ITyruntListener tyruntListener)
        {
            this.tyruntListener = tyruntListener;
        }
        private void handleClient(TcpClient tcpClient)
        {
            Console.WriteLine("Client Connected: " + tcpClient.Client.RemoteEndPoint);
            while (tcpClient.Connected)
            {

                if (end) break;
                if (tcpClient.GetStream().DataAvailable)
                    try
                    {
                        byte[] buffer = new byte[1024];
                        int k = tcpClient.Client.Receive(buffer);
                        char cc = ' ';
                        string test = null;
                        Console.WriteLine("Recieved...");
                        for (int i = 0; i < k; i++)
                        {
                            cc = Convert.ToChar(buffer[i]);
                            test += cc.ToString();
                        }
                //        Console.WriteLine(test);
                        try {
                            JObject j = (JObject)JsonConvert.DeserializeObject(test);
                            int code = int.Parse(j["code"].ToString());
                            switch (code)
                            {
                                case 0:
                                    OnDeviceConnected(tcpClient, j);
                                    break;
                                case 1:

                                    break;
                                case 2:
                                    if (launchTorrent(JsonConvert.DeserializeObject<Request<Torrent>>(test)))
                                        sendData(200, "SUCCESS", "Downloading Torrent!", tcpClient);
                                    else
                                        sendData(500, "FAILED", "This torrent is in your history already", tcpClient);
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    if (saveTorrent(JsonConvert.DeserializeObject<Request<Torrent>>(test)))
                                        sendData(200, "SUCCESS", "Saving Torrent!", tcpClient);
                                    else
                                        sendData(500, "FAILED", "This torrent is in your history already", tcpClient);
                                    break;
                                case 10:
                                    parsePong(tcpClient, j);
                                    break;
                                case 99:
                                    tcpClient.Close();
                                    break;
                                case 100:
                                    String user_name = Environment.UserName;
                                    String pc_name = Environment.MachineName;
                                    String pc_version = SystemInfo.getOperatingSystemInfo();
                                    String pc_processor = SystemInfo.getProcessorInfo();
                                    PCInfo pc = new PCInfo();
                                    pc.pc_name = pc_name;
                                    pc.pc_user = user_name;
                                    pc.pc_version = pc_version;
                                    pc.pc_processor = pc_processor;
                                    if (sendData(100, "PC_INFO", pc, tcpClient))
                                    {
                                        Console.WriteLine("Sent PC Info");
                                    }
                                    break;
                            }
                        }catch
                        {
                            
                            if(test == "TYRUNT?")
                            {
                                tcpClient.Client.Send(ASCIIEncoding.ASCII.GetBytes("YES"));
                                tcpClient.Close();
                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Client {0} Disconnected?", tcpClient.Client.RemoteEndPoint);
                        tyruntListener.OnDeviceDisconnected(tcpClient);
                    }
                // Request<To> request = new Request<T>();
            }
        }
        private bool saveTorrent(Request<Torrent> request)
        {
            Torrent t = request.data;
            if (!torrents.Keys.Contains(t.author))
            {
                torrents.Add(t.author, new List<String>());
            }
            if (!torrents[t.author].Contains(t.magnet))
            {
                if (tyruntListener != null)
                {
                    tyruntListener.OnTorrentSaved(t);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        private void parsePong(TcpClient tcpClient, JObject j)
        {
            String response = j["data"].ToString();
            if (response == "pong")
            {
                tyruntListener.OnDeviceAlive(tcpClient);
            }
            else tyruntListener.OnDeviceDisconnected(tcpClient);
        }
        public bool sendPing(DeviceInfo device)
        {
            return sendData(10, "CHECK_CONNECTED", "ping", device.tcpClient);
        }
        private bool sendData(DeviceInfo device, String data)
        {
            try
            {
                StreamWriter sw = new StreamWriter(device.tcpClient.GetStream());
                sw.WriteLine(data);
                sw.Flush();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }   
        private void OnDeviceConnected(TcpClient tcpClient, JObject json)
        {
            DeviceInfo d = new DeviceInfo();
            d.device = json["data"]["device"].ToString();
            d.model = json["data"]["model"].ToString();
            d.version = json["data"]["version"].ToString();
            d.tcpClient = tcpClient;
            tyruntListener.OnDeviceConnected(d);
        }
        public bool sendData(int code, String message, PCInfo data, TcpClient tcpClient)
        {
            try
            {
                String s = JsonConvert.SerializeObject(new Request<PCInfo>(code, message, data), Formatting.Indented);
                Console.WriteLine(s);
                int res = tcpClient.Client.Send(ASCIIEncoding.UTF8.GetBytes(s));
                if (res > 0)
                {
                    Console.WriteLine("Sent!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Response not sent");
                    return false;
                }
            }
            catch
            {
                tyruntListener.OnDeviceDisconnected(tcpClient);
                return false;
            }
        }
        public bool sendData(int code, String message, String data, TcpClient tcpClient)
        {
            try {
                int res = tcpClient.Client.Send(ASCIIEncoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Request<String>(code, message, data), Formatting.Indented)));
                if (res > 0)
                {
                    Console.WriteLine("Sent!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Response not sent");
                    return false;
                }
            }catch
            {
                tyruntListener.OnDeviceDisconnected(tcpClient);
                return false;
            }
        }
        private bool launchTorrent(Request<Torrent> request)
        {
            Torrent t = request.data;
            if (!torrents.Keys.Contains(t.author))
            {
                torrents.Add(t.author, new List<String>());
            }
            if (!torrents[t.author].Contains(t.magnet))
            {
                Console.WriteLine("Downloading: {0} , {1}", t.title, t.magnet);
                Process.Start(t.magnet);
                if (tyruntListener != null)
                {
                    tyruntListener.OnTorrentLaunched(t);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
