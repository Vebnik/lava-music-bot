
namespace LavaBot.src.api {

    public class OpenWeather {
        public static string baseUrl = "https://api.openweathermap.org/data/2.5/";
        public static string? apiKey = Environment.GetEnvironmentVariable("OW_KEY");
        public static HttpClient client = new HttpClient();

        public static async Task GetWeatherByCity (string city) {
            string response = await client.GetStringAsync(
                $"{baseUrl}/weather/?q={city}&units=metric&lang=ru&appid={apiKey}");

            Console.WriteLine(response);
        }
    }
}