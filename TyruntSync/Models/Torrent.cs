using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyruntSync.Models
{
    public class Torrent
    {
        public enum ORDER{
            ODD,EVEN,NA
        };

        public String magnet, torrent, title,
        author, time, size,
        seeds, peers, files;
        public ORDER order;
    }
}
