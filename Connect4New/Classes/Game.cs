using System.Collections.Generic;

namespace Connect4New
{
    internal class Game
    {
        #region Public Constructors

        public Game(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;
            Turn = 1;
            InitGrid();
        }

        #endregion Public Constructors

        #region Public Properties

        public List<List<Cell>> Grid { get; set; }//O lista de coloane, nu de linii

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public int Turn { get; set; }

        #endregion Public Properties

        #region Public Methods

        public State GetNextState(Cell cell)
        {
            if (Referee.CheckWinner(Grid, cell))
            {
                PlayerWinUpdate();
                return Referee.WhoWon(Turn);
            }
            if (Referee.CheckDraw(Grid))
            {
                IncreaseMatches();
                return State.Draw;
            }

            return Referee.NextTurn(Turn *= -1);
        }

        public int UpdateGrid(int columnIndex)
        {
            if (Grid[columnIndex][0].State == 0)
            {
                int lineIndex = FindCorrectLine(columnIndex);
                Grid[columnIndex][lineIndex].State = Turn;
                return lineIndex;
            }
            return -1;
        }

        #endregion Public Methods

        #region Private Methods

        private int FindCorrectLine(int columnIndex)
        {
            var lineIndex = Grid[0].Count - 1;
            while (lineIndex >= 0 && Grid[columnIndex][lineIndex].State != 0)
            {
                lineIndex--;
            }

            return lineIndex;
        }

        private void IncreaseMatches()
        {
            Player1.Matches++;
            Player2.Matches++;
        }

        private void InitGrid()
        {
            Grid = new List<List<Cell>>();
            for (int columnIndex = 0; columnIndex < GameBoard.TotalColumns; columnIndex++)
            {
                var column = new List<Cell>();
                for (int lineIndex = 0; lineIndex < GameBoard.TotalLines; lineIndex++)
                {
                    var cell = new Cell(columnIndex, lineIndex);
                    column.Add(cell);
                }

                Grid.Add(column);
            }
        }

        private void PlayerWinUpdate()
        {
            if (Turn == 1)
            {
                Player1.Victories++;
            }
            else
            {
                Player2.Victories++;
            }

            IncreaseMatches();
        }

        #endregion Private Methods
    }
}