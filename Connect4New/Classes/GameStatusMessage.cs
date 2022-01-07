namespace Connect4New
{
    internal class GameStatusMessage
    {
        #region Private Fields

        private static readonly string _draw = "Draw";

        private static readonly string _invalidMove = "Invalid move";

        private static readonly string _win = "Win by {0}";

        #endregion Private Fields

        #region Public Methods

        public static string GetDraw()
        {
            return _draw;
        }

        public static string GetInvalidMoveMessage()
        {
            return _invalidMove;
        }

        public static string GetWin(string player)
        {
            return string.Format(_win, player);
        }

        #endregion Public Methods
    }
}