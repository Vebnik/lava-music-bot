using Discord.WebSocket;
using Discord.Interactions;
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
                // logging 
                client.Log += Events.Log;                
                // slash command interaction
                client.SlashCommandExecuted += Events.SlashCommandHandler;
                // on ready posy logic
                client.Ready += async () => {
                    await Events.Ready(this.client);
                };
                // on slash command autocomplete
                client.AutocompleteExecuted += async (SocketAutocompleteInteraction arg) => {
                    await Events.AutocompleteHandler(arg, this.client);
                };
            }
        }
    }
}
