using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class GameBoard
    {

        public Game Game { get; set; }
        private List<Player> players1;
        public const int totalLines = 6;
        public const int totalColumns = 7;
        private Random rnd;
        public GameBoard()
        {
            players1 = new List<Player>();
            rnd = new Random();
        }

        public void StartGame(string p1, string p2)
        {
            Game = new Game(GetOrAddPlayer(p1), GetOrAddPlayer(p2));
        }

        public Player GetOrAddPlayer(string nameToAdd)
        {
            if (string.IsNullOrEmpty(nameToAdd))
                nameToAdd = GetRandomName(0, 100);

            var player = players1.FirstOrDefault(p => p.Name == nameToAdd);
            if (player == null)
            {
                player = new Player(nameToAdd);
                players1.Add(player);
            }

            return player;
        }

        private string GetRandomName(int start, int end)//creaza un nume nou pentru lista de jucatori
        {
            return "Player" + Convert.ToString(rnd.Next(start, end));
        }
    }
}
