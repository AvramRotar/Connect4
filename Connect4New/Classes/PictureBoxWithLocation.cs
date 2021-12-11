using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4New
{
    class PictureBoxWithLocation : PictureBox
    {
        public int ColumnIndex { get; set; }
        public int LineIndex { get; set; }
    }
}
