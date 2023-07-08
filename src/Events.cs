using Discord;
using Discord.WebSocket;
using Discord.Interactions;

namespace LavaBot.src {

    public class Events {
        public static Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public static async Task Ready(DiscordSocketClient client) {
            await SlashCommand.GlobalRegister(client);
            await Task.CompletedTask;
        }

        public static async Task SlashCommandHandler(SocketSlashCommand command) {

            switch (command.CommandName) {
                case("weather"):
                    await commands.weather.Logic.Execute(command); break;
                default:
                    await command.RespondAsync("Not found right handler"); break;
            }

            await Task.CompletedTask;
        }

        public static async Task AutocompleteHandler (SocketAutocompleteInteraction arg, DiscordSocketClient client) {
            var ctx = new InteractionContext(client, arg, arg.Channel);
            var interaction = (ctx.Interaction as SocketAutocompleteInteraction);
            var commandName = interaction.Data.CommandName;

            switch (commandName) {
                case("weather"):
                    await commands.weather.Logic.Autocomplete(interaction); break;
                default:
                    break;
            }
        }
    }
}