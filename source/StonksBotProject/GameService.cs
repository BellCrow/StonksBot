using Microsoft.Extensions.Hosting;
using StonksBotProject.GameModel;

namespace StonksBotProject
{
    internal class GameService : BackgroundService
    {
        #region Private Fields

        private readonly WorldInterface _game;
        private readonly WorldEventScheduler _eventScheduler;

        #endregion Private Fields

        #region Public Constructors

        public GameService(WorldInterface game, WorldEventScheduler eventScheduler)
        {
            _game = game;
            _eventScheduler = eventScheduler;
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