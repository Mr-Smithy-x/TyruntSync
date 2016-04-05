using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TyruntSync.Models
{
    public class DeviceInfo
    {
        public String device, version, model;
        public TcpClient tcpClient;
    }
}
