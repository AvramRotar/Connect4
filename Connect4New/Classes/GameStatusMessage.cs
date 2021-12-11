using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4New
{
    class GameStatusMessage
    {
        private static string invalidMove = "Invalid move";

        private static string draw = "Draw";

        private static string win = "Win by ";

        public static string GetInvalidMoveMessage()
        {
            return invalidMove;
        }

        public static string GetWin(string player)
        {
            return win + player;
        }

        public static string GetDraw()
        {
            return draw;
        }
    }
}
