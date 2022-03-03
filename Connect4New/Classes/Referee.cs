using System.Collections.Generic;

namespace Connect4New
{
    internal class Referee
    {
        #region Public Methods

        public static bool CheckDraw(List<List<Connect4Cell>> grid)
        {
            return Rules.Draw(grid);
        }

        public static bool CheckWinner(List<List<Connect4Cell>> grid, Connect4Cell cell)
        {
            if (Rules.MainDiagonalWin(grid, cell))
            {
                return true;
            }
            if (Rules.SecondaryDiagonalWin(grid, cell))
            {
                return true;
            }
            if (Rules.LineWin(grid, cell))
            {
                return true;
            }
            if (Rules.ColumnWin(grid, cell))
            {
                return true;
            }

            return false;
        }

        public static bool ColumnNotFull(List<List<Connect4Cell>> grid, int column)
        {
            return Rules.ValidColumn(grid, column);
        }

        public static State NextTurn(int Turn)
        {
            return Turn == 1 ? State.TurnPlayer1 : State.TurnPlayer2;
        }

        public static State WhoWon(int Turn)
        {
            return Turn == 1 ? State.WinPlayer1 : State.WinPlayer2;
        }

        #endregion Public Methods
    }
}