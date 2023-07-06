using Discord.WebSocket;

namespace LavaBot.utils {

    public class Config {

        public string? Token { get; set; }
        public DiscordSocketConfig? ClientConfig { get; set; }

        public Config(string? token, DiscordSocketConfig? cfg) {
            Token = token;
            ClientConfig = cfg;
        }
    }
}
