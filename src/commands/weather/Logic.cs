using Discord;
using Discord.WebSocket;
using System.Text.Json;
using Discord.Interactions;

namespace LavaBot.src.commands.weather {

    public class Countries {
        public int? id {get; set;}
        public string? name {get; set;}
        public string? capital {get; set;}
        public string? currency_name {get; set;}
        public string? region {get; set;}
        public string? latitude {get; set;}
        public string? longitude {get; set;}
    }

    public class City {
        public int? id {get; set;}
        public string? name {get; set;}
        public string? country_name {get; set;}
        public string? latitude {get; set;}
        public string? longitude {get; set;}
    }

    public class Logic {
        /* logic command */

        public static async Task Execute(SocketSlashCommand command) {
            var options = command.Data.Options.ToArray();
            var isEphemeral = (bool)options[2].Value;

            await command.DeferAsync(ephemeral: isEphemeral);

            var country = (string)options[0].Value;
            var city = (string)options[1].Value;

            api.WeatherObject? weatherData = await api.OpenWeather.GetWeatherByCity(city);
            Embed weatherEmbed = misc.EmbedsBuilder.WeatherEmbed(weatherData);

            await command.FollowupAsync(embed: weatherEmbed);
        }

        public static async Task Autocomplete(SocketAutocompleteInteraction interaction) {

            switch (interaction.Data.Current.Name)
            {
                case("country"):
                    await Logic.AutocompleteCountry(interaction); break;
                case("city"):
                    await Logic.AutocompleteCity(interaction); break;
                default:
                    break;
            }
        }

        public static async Task AutocompleteCountry(SocketAutocompleteInteraction interaction) {
            string? input = interaction.Data.Current.Value.ToString();

            string fileName = "data/weather/countries.json";
            string jsonString = File.ReadAllText(fileName);
        
            var filterCountries = JsonSerializer.Deserialize<IList<Countries>>(jsonString)
                .Where(el => el.name.StartsWith(input, StringComparison.InvariantCultureIgnoreCase))
                .Select(el => new AutocompleteResult(el.name, el.name.ToLower()));

            await interaction.RespondAsync(filterCountries.Take(10));
        }

        public static async Task AutocompleteCity(SocketAutocompleteInteraction interaction) {

            string? input = interaction.Data.Current.Value.ToString();
            string? countryInput = interaction.Data.Options.ToList()[0].Value.ToString();
            
            if (countryInput.Length < 1) {
                await interaction.RespondAsync(new[] {new AutocompleteResult("Country is required", "error")});
            } else {
                string fileName = "data/weather/cities.json";
                string jsonString = File.ReadAllText(fileName);

                Console.WriteLine(countryInput);

                var filterCities = JsonSerializer.Deserialize<IList<City>>(jsonString)
                    .Where(el => el.name.StartsWith(input, StringComparison.InvariantCultureIgnoreCase) && el.country_name.ToLower() == countryInput)
                    .Select(el => new AutocompleteResult(el.name, el.name.ToLower()));

                await interaction.RespondAsync(filterCities.Take(10));
            }
        }
    }
}