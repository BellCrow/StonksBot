// See https://aka.ms/new-console-template for more information


using Discord;
using Discord.WebSocket;

public class MainClass
{
    //tutorial for this code is here https://discordnet.dev/guides/getting_started/first-bot.html
    public static async Task Main(string[] args)
    {
        var discordApiToken = LoadToken("DiscordApi.token");
        var client = new DiscordSocketClient();
        client.Log += Log;

        await client.LoginAsync(TokenType.Bot, discordApiToken);
        await client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage message)
    {
        Console.WriteLine(message.ToString());
        return Task.CompletedTask;
    }

    private static string LoadToken(string tokenFileName)
    {
        return File.ReadAllText(tokenFileName);
    }
}

