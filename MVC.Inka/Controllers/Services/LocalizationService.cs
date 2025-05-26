using System.Text.Json;

namespace NaskaInsaat.Controllers.Services
{
    public class LocalizationService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations;

        public LocalizationService(IWebHostEnvironment env)
        {
            var path = Path.Combine(env.ContentRootPath, "Models", "MenuItems.json");
            var json = File.ReadAllText(path);
            _translations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(json);
        }

        public string Translate(string key, string culture)
        {

            if (_translations.TryGetValue(culture, out var values))
            {
                if (values.TryGetValue(key, out var value))
                    return value;
            }

            return key; // fallback to key itself if not found
        }
    }
}
