using Discord;
using LavaBot.utils;

namespace LavaBot.src.misc {

    public class Color {
        public static string Blue {get; set;} = "fix";
        public static string NumBlue {get; set;} = "py";
        public static string Diff {get; set;} = "diff";
    }

    public class EmbedsBuilder {
        
        public static Embed WeatherEmbed(api.WeatherObject? data) {
            EmbedBuilder embed = new EmbedBuilder {
                Title = $"Weather - {data.name}",
                Description = "",
                Color = 0x00FFFF,
                ThumbnailUrl = $"https://openweathermap.org/img/wn/{data.weather[0].icon}@2x.png",
                Footer = new EmbedFooterBuilder {
                    Text = "LavaBot",
                },
                Fields = new List<EmbedFieldBuilder> {
                    new EmbedFieldBuilder {
                        Name = "Temp 🌡️",
                        Value = $"```{Color.Blue}\nMin ➜ {data.main.temp_min}°C\nMax ➜ {data.main.temp_max}°C\nCurrent ➜ {data.main.temp}°C\nFeels ➜ {data.main.feels_like}°C\n```",
                        IsInline = false,
                    },
                    new EmbedFieldBuilder {
                        Name = "Wind 💨",
                        Value = $"```{Color.Blue}\nSpeed ➜ {data.wind.speed} M/s\nDeg ➜ {data.wind.deg}°\n```",
                        IsInline = false,
                    },
                    new EmbedFieldBuilder {
                        Name = "Misc 🗃️",
                        Value = $"```{Color.Blue}\nSunrise ➜ {Date.DateToString(data.sys.sunrise)}\nSunset ➜ {Date.DateToString(data.sys.sunset)}\nCountry ➜ {data.sys.country}\n```",
                        IsInline = false,
                    },
                },
            };

            return embed.Build();
        }
    }
}