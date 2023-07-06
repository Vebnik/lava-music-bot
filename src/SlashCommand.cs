using Discord;
using Discord.WebSocket;
using Discord.Interactions;
using LavaBot.src;

namespace LavaBot.src
{
    public class SlashCommand
    {
        public static async void GlobalRegister(DiscordSocketClient client) {
            List<ApplicationCommandProperties> appCommandProperties = new();

            // commands
            appCommandProperties.Add(commands.Test.Build());

            // bulk register
            await client.BulkOverwriteGlobalApplicationCommandsAsync(appCommandProperties.ToArray());
        }
    }
}