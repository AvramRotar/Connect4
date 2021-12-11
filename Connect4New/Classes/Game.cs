using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class Game
    {
        public List<List<Cell>> Grid { get; set; }//O lista de coloane, nu de linii
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public int Turn { get; set; }

        public Game(Player P1, Player P2)
        {
            player1 = P1;
            player2 = P2;
            Turn = 1;
            InitGrid();
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
                return State.draw;
            }
            return Referee.NextTurn(Turn *= -1);
        }
        private int FindCorrectLine(int columnIndex)
        {
            int lineIndex = Grid[0].Count - 1;
            while (lineIndex >= 0 && Grid[columnIndex][lineIndex].State != 0)
            {
                lineIndex--;
            }
            return lineIndex;
        }
        private void PlayerWinUpdate()
        {
            if (Turn == 1)
                player1.Victories++;
            else
                player2.Victories++;
            IncreaseMatches();
        }
        private void IncreaseMatches()
        {
            player1.Matches++;
            player2.Matches++;
        }
        private void InitGrid()
        {
            Grid = new List<List<Cell>>();
            for (int columnIndex = 0; columnIndex < GameBoard.totalColumns; columnIndex++)
            {
                List<Cell> column = new List<Cell>();
                for (int lineIndex = 0; lineIndex < GameBoard.totalLines; lineIndex++)
                {
                    Cell cell = new Cell(columnIndex, lineIndex);
                    column.Add(cell);
                }
                Grid.Add(column);
            }
        }
    }
}
