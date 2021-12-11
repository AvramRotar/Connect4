using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class Referee
    {
        public static bool ColumnNotFull(List<List<Cell>> grid, int column)
        {
            return Rules.ValidColumn(grid, column);
        }
        public static bool CheckWinner(List<List<Cell>> grid, Cell cell)
        {
            if (Rules.MainDiagonalWin(grid, cell))
                return true;
            if (Rules.SecondaryDiagonalWin(grid, cell))
                return true;
            if (Rules.LineWin(grid, cell))
                return true;
            if (Rules.ColumnWin(grid, cell))
                return true;
            return false;
        }

        public static bool CheckDraw(List<List<Cell>> grid)
        {
            if (Rules.Draw(grid) == false)
                return false;
            else
                return true;
        }
        public static State WhoWon(int Turn)
        {
            return Turn == 1 ? State.winPlayer1 : State.winPlayer2;
        }
        public static State NextTurn(int Turn)
        {
            return Turn == 1 ? State.turnPlayer1 : State.turnPlayer2;
        }
    }
}
