using System;
using System.Collections.Generic;
using System.Linq;

namespace Connect4New
{
    internal class GameBoard
    {

        #region Public Fields

        public const int TotalColumns = 7;

        public const int TotalLines = 6;

        #endregion Public Fields

        #region Private Fields

        private List<Player> _players;

        private Random _rnd;

        #endregion Private Fields

        #region Public Constructors

        public GameBoard()
        {
            _players = new List<Player>();
            _rnd = new Random();
        }

        #endregion Public Constructors

        #region Public Properties

        public Game Game { get; set; }

        #endregion Public Properties

        #region Public Methods

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

        public void StartGame(string p1, string p2)
        {
            Game = new Game(GetOrAddPlayer(p1), GetOrAddPlayer(p2));
        }

        #endregion Public Methods

        #region Private Methods

        private string GetRandomName(int start, int end)
        {
            return "Player" + Convert.ToString(_rnd.Next(start, end));
        }

        #endregion Private Methods
    }
}
