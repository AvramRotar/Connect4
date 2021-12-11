namespace Connect4New
{
    internal class Cell
    {
        #region Public Constructors

        public Cell(int column, int line)
        {
            ColumnIndex = column;
            LineIndex = line;
            State = 0;
        }

        #endregion Public Constructors

        #region Public Properties

        public int ColumnIndex { get; set; }

        public int LineIndex { get; set; }

        public int State { get; set; }

        #endregion Public Properties
    }
}