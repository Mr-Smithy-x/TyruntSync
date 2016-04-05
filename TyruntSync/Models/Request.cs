using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyruntSync.Models
{
    class Request<T>
    {

        public Request(int code, String message, T data)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }

        public int code;
        public String message;
        public T data;
    }
}
