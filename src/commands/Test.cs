using Discord;
using Discord.Interactions;

namespace LavaBot.src.commands
{
    public class Test
    {
        public static SlashCommandProperties Build() {
            var testCommand = new SlashCommandBuilder();

            testCommand.WithName("test-commands");
            testCommand.WithDescription("Only for test");

            return testCommand.Build();
        }
    }
}