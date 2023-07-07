using Discord;
using Discord.WebSocket;

namespace LavaBot.src {

    public class Events {
        public static Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public static Task Ready(DiscordSocketClient client) {
            SlashCommand.GlobalRegister(client);
            return Task.CompletedTask;
        }

        public static async Task SlashCommandHandler(SocketSlashCommand command) {

            switch (command.CommandName) {
                case("weather"):
                    await api.OpenWeather.GetWeatherByCity("Irkutsk");
                    await command.RespondAsync("Weather", embed: misc.EmbedsBuilder.WeatherEmbed());
                    break;
                default:
                    await command.RespondAsync("Not found right handler");
                    break;
            }

            await Task.CompletedTask;
        }
    }
}