using StonksBot.Integration.Discord.Interfaces;

namespace StonksBot.Integration.Discord.Implementations;

public class ConsoleLogger : ILogger
{
    public void Info(string message)
    {
        Console.WriteLine($"Info: {message}");
    }

    public void Warning(string message)
    {
        Console.WriteLine($"Warning: {message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"Error: {message}");
    }

    public void Debug(string message)
    {
        Console.WriteLine($"Debug: {message}");
    }
}