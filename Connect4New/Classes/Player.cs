namespace Connect4New
{
    internal class Player
    {
        #region Public Constructors

        public Player(string name)
        {
            Name = name;
            Statistics = new PlayerStatistics();
        }

        #endregion Public Constructors

        #region Public Properties


        public string Name { get; set; }

        public PlayerStatistics Statistics { get; set; }

        #endregion Public Properties
    }
}