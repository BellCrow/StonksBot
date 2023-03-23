namespace StonksBotProject.GameModel
{
    internal class PlayerBase
    {
        List<Player> _player = new List<Player>
        {
            new Player("tim", 2000),
            new Player("eve", 2500),
            new Player("liz", 1500),
        };

        public IEnumerable<Player> Player => _player;

        public PlayerBase() {/*placeholder for tests*/}

        public PlayerBase(IEnumerable<Player> player) => _player = player.ToList();
    }
}
