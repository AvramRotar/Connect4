using System.Windows.Forms;

namespace Connect4New
{
    internal class PictureBoxWithLocation : PictureBox
    {
        #region Public Properties

        public int ColumnIndex { get; set; }

        public int LineIndex { get; set; }

        #endregion Public Properties
    }
}