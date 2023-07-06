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
    }
}