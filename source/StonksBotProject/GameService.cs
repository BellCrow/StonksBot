using Microsoft.Extensions.Hosting;
using StonksBotProject.GameModel;

namespace StonksBotProject
{
    internal class GameService : BackgroundService
    {
        #region Private Fields

        private readonly WorldInterface _game;

        #endregion Private Fields

        #region Public Constructors

        public GameService(WorldInterface game)
        {
            _game = game;
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        #endregion Protected Methods
    }
}