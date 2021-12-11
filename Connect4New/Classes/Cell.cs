using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class Cell
    {
        public int State { get; set; }
        public int ColumnIndex { get; set; }
        public int LineIndex { get; set; }
       
        public Cell(int column, int line)
        {
            ColumnIndex = column;
            LineIndex = line;
            State = 0;
        }
    }
}
