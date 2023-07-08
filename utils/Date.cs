using System;

namespace LavaBot.utils {
    public class Date {
        public static string DateToString(int? time) {
            int curentTime = DateTime.MinValue.Second;

            if (time != null)
                curentTime = (int)time;

            DateTime dt = DateTimeOffset.FromUnixTimeSeconds(curentTime).DateTime;
            return dt.ToString("dd.MM.yyyy HH:mm");
        }
    }
}