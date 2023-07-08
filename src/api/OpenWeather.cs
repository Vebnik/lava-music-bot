using System.Text.Json;

namespace LavaBot.src.api {

    public class Coord {
        public double? lon {get; set;}
        public double? lat {get; set;}
    }

    public class Weather {
        public int? id {get; set;}
        public string? main {get; set;}
        public string? description {get; set;}
        public string? icon {get; set;}
    }

    public class Main {
        public double? temp {get; set;}
        public double? feels_like {get; set;}
        public double? temp_min {get; set;}
        public double? temp_max {get; set;}
        public int? pressure {get; set;}
        public int? humidity {get; set;}
    }

    public class Wind {
        public dynamic? speed {get; set;}
        public int? deg {get; set;}
    }

    public class Sys {
        public int? type {get; set;}
        public string? country {get; set;}
        public int? sunrise {get; set;}
        public int? sunset {get; set;}
    }

    public class WeatherObject {
        public Coord? coord {get; set;}
        public IList<Weather>? weather {get; set;}
        public Main? main {get; set;}
        public Wind? wind {get; set;}
        public Sys? sys {get; set;}
        public int? timezone {get; set;}
        public string? name {get; set;}
        public int? cod {get; set;}

    }

    public class OpenWeather {
        public static string baseUrl = "https://api.openweathermap.org/data/2.5/";
        public static string? apiKey = Environment.GetEnvironmentVariable("OW_KEY");
        public static HttpClient client = new HttpClient();

        public static async Task<WeatherObject?> GetWeatherByCity (string city) {
            try {
                var reponse = await client.GetStringAsync(
                    $"{baseUrl}/weather/?q={city}&units=metric&lang=ru&appid={apiKey}");

                return JsonSerializer.Deserialize<WeatherObject>(reponse);
            } catch (System.Exception error) {
                throw error;
            }
        }
    }
}