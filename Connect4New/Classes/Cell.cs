namespace Connect4New
{
    internal class Cell
    {
        #region Public Constructors

        public Cell(int column, int line)  //Connect4Cell
        {
            ColumnIndex = column;
            LineIndex = line;
            State = 0;
        }

        #endregion Public Constructors

        #region Public Properties

        public int ColumnIndex { get; }  

        public int LineIndex { get; }

        public int State { get; set; } // sa fie enum

        #endregion Public Properties
    }
}