using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect4New
{
    internal class Game
    {
        #region Public Constructors

        public Game()
        {
            _players = new List<Player>();
            _rnd = new Random();
            _board = new Connect4Board();
        }

        #endregion Public Constructors

        #region Public Properties
     
        public List<List<Connect4Cell>> Grid { get { return _board.Grid; } }

        public Player Player1 { get; set; } 

        public Player Player2 { get; set; }

        public int Turn { get; private set; }

        #endregion Public Properties

        private List<Player> _players;
       
        private Random _rnd;
       
        private Connect4Board _board;

        #region Public Methods

        public void InitGame(Player p1, Player p2)
        {
            Player1 = p1;
            Player2 = p2;
            Turn = 1;
        }

        public State GetNextState(Connect4Cell cell)  
        {
            if (Referee.CheckWinner(Grid, cell))
            {
                if (Turn == 1)
                {
                    Player1.Statistics.Victories++;
                }
                else
                {
                    Player2.Statistics.Victories++;
                }

                Player1.Statistics.Matches++;
                Player2.Statistics.Matches++;
                return Referee.WhoWon(Turn);
            }
            if (Referee.CheckDraw(Grid))
            {
                Player1.Statistics.Matches++;
                Player2.Statistics.Matches++;
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

        public Player GetOrAddPlayer(string nameToAdd) 
        {
            if (string.IsNullOrEmpty(nameToAdd))
            {
                nameToAdd = GetRandomName(0, 100);
            }

            var player = _players.FirstOrDefault(p => p.Name == nameToAdd);
            if (player == null)
            {
                player = new Player(nameToAdd);
                _players.Add(player);
            }

            return player;
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

        private string GetRandomName(int start, int end)
        {
            return "Player" + Convert.ToString(_rnd.Next(start, end));
        }
        #endregion Private Methods
    }
}