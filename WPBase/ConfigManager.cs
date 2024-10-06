using System.Text.Json;

namespace WPBase
{
    public class ConfigManager<T>
    {
        // Singleton-Instanz
        private static ConfigManager<T>? _instance;
        private static readonly object _lock = new();

        // Standard-Dateiname und JsonSerializer-Optionen
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
        private string _fileName;

        // Dictionary zum Speichern der Konfigurationen
        private readonly Dictionary<string, Dictionary<string, T>> _configurations = [];

        // Private Konstruktor, um den Singleton zu erzwingen
        private ConfigManager(string fileName = "conf.json")
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            LoadFromFile();  // Initiales Laden der Konfigurationen
        }

        // Zugriff auf die Singleton-Instanz
        public static ConfigManager<T> Instance(string fileName = "conf.json")
        {
            lock (_lock)
            {
                _instance ??= new ConfigManager<T>(fileName);
                return _instance;
            }
        }

        // Fügt eine neue Section und einen Key hinzu oder aktualisiert sie
        public void AddOrUpdate(string section, string key, T values)
        {
            if (!_configurations.TryGetValue(section, out Dictionary<string, T>? value))
            {
                value=([]);
                _configurations[section] = value;
            }

            var sectionDict = value;

            // Prüfe auf doppelte Keys innerhalb der Section
            if (!sectionDict.TryAdd(key, values))
            {
                sectionDict[key] = values;  // Key existiert, aktualisieren
            }

            SaveToFile();  // Automatisch speichern nach Update
        }

        // Holt den Wert einer Konfiguration
        public T Get(string section, string key)
        {
            if (_configurations.TryGetValue(section, out var sectionDict))
            {
                if (sectionDict.TryGetValue(key, out var value))
                {
                    return value;  // Wert gefunden
                }
                else
                {
                    throw new KeyNotFoundException($"Key '{key}' nicht in der Section '{section}' gefunden.");
                }
            }
            else
            {
                throw new KeyNotFoundException($"Section '{section}' nicht gefunden.");
            }
        }

        // Speichert die Konfigurationen manuell in die JSON-Datei
        public void SaveToFile()
        {
            string? directoryPath = Path.GetDirectoryName(_fileName);

            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string jsonString = JsonSerializer.Serialize(_configurations, _jsonSerializerOptions);
            File.WriteAllText(_fileName, jsonString);
        }

        // Lädt die Konfigurationen manuell aus der JSON-Datei
        public void LoadFromFile()
        {
            if (File.Exists(_fileName))
            {
                string jsonString = File.ReadAllText(_fileName);
                var loadedConfigurations = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, T>>>(jsonString);

                if (loadedConfigurations != null)
                {
                    _configurations.Clear();
                    foreach (var section in loadedConfigurations)
                    {
                        _configurations[section.Key] = section.Value;
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Fehler beim Laden der Konfigurationsdatei '{_fileName}'.");
                }
            }
        }

        // Überprüft, ob eine Section und ein Key vorhanden sind
        public bool Contains(string section, string key)
        {
            return _configurations.ContainsKey(section) && _configurations[section].ContainsKey(key);
        }

        // Ändert den Dateinamen (z.B. für unterschiedliche Konfigurationsdateien)
        public void ChangeFileName(string newFileName)
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", newFileName);
            SaveToFile();  // Speichert automatisch nach Änderung des Dateinamens
        }
    }
}
