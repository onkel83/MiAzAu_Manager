using System.Text.Json;

namespace WPBase
{
    public class DictionaryManager<T>
    {
        private readonly Dictionary<string, Dictionary<string, T>> _dictionaries = [];
        private readonly JsonSerializerOptions _JsonSerializerOptions = new() { WriteIndented = true };
        private readonly string _FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", $"main.json");

        // Fügt ein neues Dictionary hinzu
        public void AddDictionary(string name, Dictionary<string, T> dictionary)
        {
            if (_dictionaries.ContainsKey(name))
            {
                throw new ArgumentException($"A dictionary with the name '{name}' already exists.");
            }
            _dictionaries.Add(name, dictionary);
        }

        // Speichert ein spezifisches Dictionary in eine JSON-Datei
        public void SaveDictionaryToFile(string name, string? filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = _FileName;
            }

            string? directoryPath = Path.GetDirectoryName(filePath);

            if (directoryPath != null)
            {
                // Prüfe, ob das Verzeichnis existiert
                if (!Directory.Exists(directoryPath))
                {
                    // Verzeichnis existiert nicht, also erstelle es
                    Directory.CreateDirectory(directoryPath);
                }
                if (!_dictionaries.TryGetValue(name, out Dictionary<string, T>? value))
                {
                    throw new KeyNotFoundException($"No dictionary found with the name '{name}'.");
                }

                var dictionary = value;
                string jsonString = JsonSerializer.Serialize(dictionary, _JsonSerializerOptions);

                File.WriteAllText(filePath, jsonString);
            }
        }

        // Lädt ein Dictionary aus einer JSON-Datei
        public void LoadDictionaryFromFile(string name, string? filePath = null)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = _FileName;
            }
            string? directoryPath = Path.GetDirectoryName(filePath);

            if (directoryPath != null)
            {
                // Prüfe, ob das Verzeichnis existiert
                if (!Directory.Exists(directoryPath))
                {
                    // Verzeichnis existiert nicht, also erstelle es
                    Directory.CreateDirectory(directoryPath);
                    throw new FileNotFoundException($"The directory '{directoryPath}' does not exist.");
                }
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file '{filePath}' does not exist.");
                }

                string jsonString = File.ReadAllText(filePath);
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, T>>(jsonString)??throw new InvalidOperationException($"Failed to deserialize the JSON file '{filePath}'.");
                _dictionaries[name] = dictionary;
            }
        }

        // Konvertiert ein spezifisches Dictionary in eine Liste von KeyValuePair
        public List<KeyValuePair<string, T>> DictionaryToList(string name)
        {
            if (!_dictionaries.TryGetValue(name, out Dictionary<string, T>? value))
            {
                throw new KeyNotFoundException($"No dictionary found with the name '{name}'.");
            }

            var dictionary = value;
            return new List<KeyValuePair<string, T>>(dictionary);
        }

        // Holt ein Dictionary anhand des Namens
        public Dictionary<string, T> GetDictionary(string name)
        {
            if (!_dictionaries.TryGetValue(name, out Dictionary<string, T>? value))
            {
                throw new KeyNotFoundException($"No dictionary found with the name '{name}'.");
            }

            return value;
        }
    }
}