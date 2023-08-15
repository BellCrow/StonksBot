namespace Stonksbot.GameModel.PlayerClasses;

internal class Playerbase
{
    private List<Player> _player = new List<Player>
        {
            new Player("tim", 2000),
            new Player("eve", 2500),
            new Player("liz", 1500),
        };

    public Playerbase(IEnumerable<Player> player) => _player = player.ToList();

    public IEnumerable<Player> Player => _player;

}

