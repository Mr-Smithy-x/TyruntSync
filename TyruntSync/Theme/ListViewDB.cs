using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TyruntSync.Theme
{
    class ListViewDB : ListView
    {
        protected override void InitLayout()
        {
            this.DoubleBuffered = true;
            base.InitLayout();
        }
    }
}
