using Microsoft.Extensions.Hosting;
using StonksBotProject.GameModel;

namespace StonksBotProject
{
    internal class GameService : BackgroundService
    {
        private readonly WorldInterface _game;

        public GameService(WorldInterface game)
        {
            _game = game;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
