using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect4New
{
    internal class Connect4Board
    {

        #region Public Fields

        public const int TotalColumns = 7;

        public const int TotalLines = 6;

        #endregion Public Fields

        #region Public Constructors

        public Connect4Board()  
        {
            InitGrid();
        }

        #endregion Public Constructors

        #region Public Properties

        public List<List<Connect4Cell>> Grid { get; set; }

        #endregion Public Properties

        #region Private Methods
        private void InitGrid()
        {
            Grid = new List<List<Connect4Cell>>();
            for (int columnIndex = 0; columnIndex < Connect4Board.TotalColumns; columnIndex++)
            {
                var column = new List<Connect4Cell>();
                for (int lineIndex = 0; lineIndex < Connect4Board.TotalLines; lineIndex++)
                {
                    var cell = new Connect4Cell(columnIndex, lineIndex);
                    column.Add(cell);
                }

                Grid.Add(column);
            }
        }
        #endregion Private Methods
    }
}
