namespace StonksBotProject.GameModel
{
    internal class PlayerBase
    {
        #region Private Fields

        private List<Player> _player = new List<Player>
        {
            new Player("tim", 2000),
            new Player("eve", 2500),
            new Player("liz", 1500),
        };

        #endregion Private Fields

        #region Public Constructors

        public PlayerBase()
        {/*placeholder for tests*/}

        public PlayerBase(IEnumerable<Player> player) => _player = player.ToList();

        #endregion Public Constructors

        #region Public Properties

        public IEnumerable<Player> Player => _player;

        #endregion Public Properties
    }
}