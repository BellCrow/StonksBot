namespace Stonksbot.GameModel.PlayerClasses;

public class Playerbase
{
    private List<Player> _player = new List<Player>
        {
            new Player("tim", 2000),
            new Player("eve", 2500),
            new Player("liz", 1500),
        };

    public Playerbase(){}

    public IEnumerable<Player> Player => _player;

}

