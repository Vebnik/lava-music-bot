

namespace LavaBot.utils {

    public class DotEnv {

        public static void Load(string filePath) {
            if (!File.Exists(filePath))
                return;

            string root = Directory.GetCurrentDirectory();
            string dotenv = Path.Combine(root, filePath);

            foreach (string line in File.ReadAllLines(dotenv)) {
                string[]? parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}