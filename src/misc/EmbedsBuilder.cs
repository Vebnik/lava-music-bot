using Discord;

namespace LavaBot.src.misc {

    public class EmbedsBuilder {
        
        public static Embed WeatherEmbed() {
            EmbedBuilder embed = new EmbedBuilder {
                Title = "Weather - Irkutsk",
                Description = "",
                Color = 0x00FFFF,
                ThumbnailUrl = "https://i.pinimg.com/originals/b1/46/fd/b146fd9f85ae5e6db71ae33184d56412.jpg",
                Footer = new EmbedFooterBuilder {
                    Text = "LavaBot",
                },
                Fields = new List<EmbedFieldBuilder> {
                    new EmbedFieldBuilder {
                        Name = "\u200B",
                        Value = "`Temp  ` ➜ `32^C`",
                        IsInline = false,
                    },
                    new EmbedFieldBuilder {
                        Name = "\u200B",
                        Value = "`Press ` ➜ `1800 rtp`",
                        IsInline = false,
                    },
                    new EmbedFieldBuilder {
                        Name = "\u200B",
                        Value = "`Wind  ` ➜ `31 m/s`",
                        IsInline = false,
                    },
                    new EmbedFieldBuilder {
                        Name = "\u200B",
                        Value = "`Water ` ➜ `88%`",
                        IsInline = false,
                    },
                },
            };

            return embed.Build();
        }
    }
}