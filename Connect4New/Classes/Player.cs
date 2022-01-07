namespace Connect4New
{
    internal class Player
    {
        #region Public Constructors

        public Player(string name)
        {
            Name = name;
            Victories = 0;
            Matches = 0;
        }

        public Player()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public int Matches { get; set; }

        public string Name { get; set; }

        public int Victories { get; set; }

        #endregion Public Properties
    }
}