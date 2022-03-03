namespace Connect4New
{
    internal class Connect4Cell
    {
        #region Public Constructors

        public Connect4Cell(int column, int line)  
        {
            ColumnIndex = column;
            LineIndex = line;
            State = 0;
        }

        #endregion Public Constructors

        #region Public Properties

        public int ColumnIndex { get; } 

        public int LineIndex { get; }

        public int State { get; set; } // ar trebui sa fie un enum.

        #endregion Public Properties
    }
}