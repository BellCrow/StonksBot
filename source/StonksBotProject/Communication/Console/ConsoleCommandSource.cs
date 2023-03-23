﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StonksBotProject.Communication.Interface;

namespace StonksBotProject.Communication.Console
{
    internal class ConsoleStonksCommandSource : IStonksCommandSource
    {
        #region Private Fields

        private readonly IHostApplicationLifetime _appLifeTime;

        private readonly ILogger<ConsoleStonksCommand> _logger;

        private Task _receiveTask;

        #endregion Private Fields

        #region Public Constructors

        public ConsoleStonksCommandSource(IHostApplicationLifetime appLifeTime, ILogger<ConsoleStonksCommand> logger)
        {
            _appLifeTime = appLifeTime ?? throw new ArgumentNullException(nameof(appLifeTime));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appLifeTime.ApplicationStarted.Register(() => StartReceiving());
        }

        #endregion Public Constructors

        #region Public Events

        public event EventHandler<IStonksCommand> CommandReceived;

        #endregion Public Events

        #region Private Methods

        private Task StartReceiving()
        {
            if(_receiveTask != null)
            {
                return _receiveTask;
            }

            _receiveTask = Task.Run(() =>
            {
                /*TODO:
                 * this is just here so that the logging on the console during the
                 * initialization does not interfere with the game loop. This is Not a good solution.
                */
                Task.Delay(1000).ConfigureAwait(false).GetAwaiter().GetResult();
                while(!_appLifeTime.ApplicationStopping.IsCancellationRequested)
                {
                    System.Console.Write("Please enter a command:");
                    var commandText = System.Console.ReadLine();
                    if(commandText == null)
                    {
                        _logger.LogInformation("\nApplication shutdown request registered. Shutting down...");
                        break;
                    }
                    else if(!string.IsNullOrWhiteSpace(commandText))
                    {
                        CommandReceived?.Invoke(this, new ConsoleStonksCommand(commandText));
                    }
                }
            });
            return _receiveTask;
        }

        #endregion Private Methods
    }
}