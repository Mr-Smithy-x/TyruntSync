using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TyruntSync.Models;

namespace TyruntSync.Callbacks
{
    interface ITyruntListener
    {
        void OnTorrentLaunched(Torrent torrent);
        void OnTorrentSaved(Torrent torrent);
        void OnTorrentFailed(String title, String message, Torrent torrent);
        void OnDeviceConnected(DeviceInfo deviceInfo);
        void OnDeviceAlive(TcpClient tcpClient);
        void OnDeviceDisconnected(TcpClient tcpClient);
    }
}
