using Microsoft.Extensions.Hosting;

namespace StonksBotProject
{
    internal class GameService : BackgroundService
    {
        private readonly Game _game;

        public GameService(Game game)
        {
            _game = game;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
