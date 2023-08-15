using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Stonksbot.Communication.Interface;
using Stonksbot.GameModel.Commands;

namespace Stonksbot.Communication.Console;

internal class ConsoleStonksCommandSource : IStonksCommandSource
{
    private readonly IHostApplicationLifetime _appLifeTime;

    private readonly ILogger<string> _logger;

    private Task _receiveTask;

    public ConsoleStonksCommandSource(IHostApplicationLifetime appLifeTime, ILogger<string> logger)
    {
        _appLifeTime = appLifeTime ?? throw new ArgumentNullException(nameof(appLifeTime));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _appLifeTime.ApplicationStarted.Register(() => StartReceiving());
    }

    public event EventHandler<IStonksCommand> CommandReceived;

    private Task StartReceiving()
    {
        if (_receiveTask != null)
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
            while (!_appLifeTime.ApplicationStopping.IsCancellationRequested)
            {
                System.Console.Write("Please enter a command:");
                var commandText = System.Console.ReadLine();
                if (commandText == null)
                {
                    _logger.LogInformation("\nApplication shutdown request registered. Shutting down...");
                    break;
                }
                else if (!string.IsNullOrWhiteSpace(commandText))
                {
                    CommandReceived?.Invoke(this, CommandCreation.Create(commandText,new ConsoleCommandResultCommunicator()));
                }
            }
        });
        return _receiveTask;
    }
}