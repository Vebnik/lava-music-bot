using Discord;
using Discord.WebSocket;

namespace LavaBot.src.commands.weather
{
    public class Weather {
        /* Build command */

        public static SlashCommandProperties Build() {

            // opt 1 //
            var countryOption = new SlashCommandOptionBuilder()
                .WithName("country")
                .WithDescription("Country name")
                .WithType(ApplicationCommandOptionType.String)
                .WithRequired(true)
                .WithAutocomplete(true);
  
            // opt 2 //
            var cityOption = new SlashCommandOptionBuilder()
                .WithName("city")
                .WithDescription("City name")
                .WithType(ApplicationCommandOptionType.String)
                .WithRequired(true)
                .WithAutocomplete(true);

            // opt 3 //
            var ephemeralOption = new SlashCommandOptionBuilder()
                .WithName("ephemeral")
                .WithDescription("Visibility you message")
                .WithType(ApplicationCommandOptionType.Boolean)
                .WithRequired(true);


            var command = new SlashCommandBuilder()
                .WithName("weather")
                .WithDescription("Get weather by country -> city")
                .AddOption(countryOption)
                .AddOption(cityOption)
                .AddOption(ephemeralOption);

            return command.Build();
        }
    }
}