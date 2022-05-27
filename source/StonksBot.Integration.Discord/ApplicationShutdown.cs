namespace StonksBot.Integration.Discord;

public class ApplicationShutdown
{
    private readonly CancellationTokenSource _applicationShutdownCancellationTokenSource;

    public ApplicationShutdown()
    {
        _applicationShutdownCancellationTokenSource = new CancellationTokenSource();
        ApplicationShutdownToken = _applicationShutdownCancellationTokenSource.Token;
    }

    public CancellationToken ApplicationShutdownToken { get; }

    public event EventHandler ApplicationShutdownEvent;

    public void ShutdownApplication()
    {
        _applicationShutdownCancellationTokenSource.Cancel();
        ApplicationShutdownEvent?.Invoke(this, EventArgs.Empty);
    }
}