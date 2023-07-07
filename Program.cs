using Discord.WebSocket;
using Discord;
using LavaBot.utils;
using LavaBot.src;


namespace LavaBot {

    public class Program {

        private DiscordSocketClient? client;

        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync() {
            // load .env
            DotEnv.Load(".env");
            // create config
            Config config = new Config();
            // entry app
            await this.StartApp(config);
            // dont complete this task
            await Task.Delay(-1);
        }

        public async Task StartApp(Config cfg) {
            client = new DiscordSocketClient(cfg.ClientConfig);

            this.InitEvent();

            await client.LoginAsync(TokenType.Bot, cfg.Token);
            await client.StartAsync();

            await Task.CompletedTask;
        }

        private void InitEvent() {
            if (client != null) {
                client.Log += Events.Log;
                client.SlashCommandExecuted += Events.SlashCommandHandler;
                client.Ready += () => {
                    Events.Ready(this.client);
                    return Task.CompletedTask;
                };
            }
        }
    }
}
