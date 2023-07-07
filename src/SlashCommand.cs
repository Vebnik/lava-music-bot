using Discord;
using Discord.WebSocket;

namespace LavaBot.src
{
    public class SlashCommand
    {
        public static async void GlobalRegister(DiscordSocketClient client) {
            List<ApplicationCommandProperties> appCommandProperties = new();

            // commands
            appCommandProperties.Add(commands.Test.Build());
            appCommandProperties.Add(commands.Weather.Build());

            // bulk register
            await client.BulkOverwriteGlobalApplicationCommandsAsync(appCommandProperties.ToArray());
        }
    }
}