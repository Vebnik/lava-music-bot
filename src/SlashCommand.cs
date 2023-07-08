using Discord;
using Discord.WebSocket;

namespace LavaBot.src
{
    public class SlashCommand
    {
        public static async Task GlobalRegister(DiscordSocketClient client) {
            List<ApplicationCommandProperties> appCommandProperties = new();

            // commands
            appCommandProperties.Add(commands.test.Test.Build());
            appCommandProperties.Add(commands.weather.Weather.Build());

            // bulk register
            await client.BulkOverwriteGlobalApplicationCommandsAsync(appCommandProperties.ToArray());
        }

        public static async Task GuildRegister(DiscordSocketClient client, ulong guildId) {
            List<ApplicationCommandProperties> appCommandProperties = new();
            SocketGuild guild = client.GetGuild(guildId);

            // commands
            appCommandProperties.Add(commands.test.Test.Build());
            appCommandProperties.Add(commands.weather.Weather.Build());

            // bulk register with guild
            await guild.BulkOverwriteApplicationCommandAsync(appCommandProperties.ToArray());
        }
    }
}