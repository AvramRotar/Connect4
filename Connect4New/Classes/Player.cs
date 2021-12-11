using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class Player
    {
        public string Name { get; set; }
        public int Victories { get; set; }
        public int Matches { get; set; }
        public Player(string name)
        {
            Name = name;
            Victories = 0;
            Matches = 0;
        }
        public Player() { }
    }
}
