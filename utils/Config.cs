using Discord.WebSocket;
using Discord;

namespace LavaBot.utils {

    public class Config {

        public string? Token { get; set; }
        public DiscordSocketConfig? ClientConfig { get; set; }

        public Config() {
            Token = Environment.GetEnvironmentVariable("TOEKN");
            ClientConfig = new DiscordSocketConfig {
                GatewayIntents = GatewayIntents.All
            };
        }

    }
}
