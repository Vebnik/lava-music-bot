using Discord;

namespace LavaBot.src.commands
{
    public class Weather
    {
        public static SlashCommandProperties Build() {

            var option = new SlashCommandOptionBuilder()
                .WithName("city")
                .WithDescription("City name")
                .WithType(ApplicationCommandOptionType.Integer)
                .WithRequired(true);

            foreach ((string city, int index) in Weather.GetCitys())
                option.AddChoice(city, (index+1));

            var command = new SlashCommandBuilder()
                .WithName("weather")
                .WithDescription("Get weather by country -> city")
                .AddOption(option);

            return command.Build();
        }

        public static IEnumerable<(string name, int index)> GetCitys() {
            return new string[] {
                "Irkutsk", "Chelny", "Bryansk", 
                "GermanyCity", "Other", 
            }.Select((name, index) => (name, index));
        }

        
    }
}