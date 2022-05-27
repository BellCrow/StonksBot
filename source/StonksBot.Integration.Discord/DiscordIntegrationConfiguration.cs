namespace StonksBot.Integration.Discord;

public class DiscordIntegrationConfiguration
{
    private const string ApiTokenFilePath = "DiscordApi.token";

    public DiscordIntegrationConfiguration()
    {
        ApiToken = LoadToken(ApiTokenFilePath);
    }

    public string ApiToken { get; }

    public string SaveGamePath { get; } = "DemoSaveGame.json";

    private static string LoadToken(string tokenFileName)
    {
        return File.ReadAllText(tokenFileName);
    }
}