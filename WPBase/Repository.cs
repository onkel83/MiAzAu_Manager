using System.Text.Json;

namespace WPBase
{
    public class Repository<T>(string? fileName = null)
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };
        private string _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName??"data.json");

        // Speichert die Liste in eine JSON-Datei
        public void SaveToFile(List<T> data)
        {
            try
            {
                string? directoryPath = Path.GetDirectoryName(_fileName);

                // Prüfen, ob das Verzeichnis existiert
                if (directoryPath != null && !Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Serialisierung und Schreiben in die Datei
                string jsonString = JsonSerializer.Serialize(data, _jsonSerializerOptions);
                File.WriteAllText(_fileName, jsonString);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Fehler beim Speichern der Datei '{_fileName}': {ex.Message}", ex);
            }
        }

        // Lädt die Liste aus einer JSON-Datei
        public List<T> LoadFromFile()
        {
            try
            {
                if (!File.Exists(_fileName))
                {
                    throw new FileNotFoundException($"Die Datei '{_fileName}' existiert nicht.");
                }

                // Lesen und Deserialisierung der Datei
                string jsonString = File.ReadAllText(_fileName);
                var data = JsonSerializer.Deserialize<List<T>>(jsonString);

                // Falls die Deserialisierung fehlschlägt
                return data ?? throw new InvalidOperationException($"Fehler beim Laden der Datei '{_fileName}'.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Fehler beim Laden der Datei '{_fileName}': {ex.Message}", ex);
            }
        }

        // Ändern des Dateinamens
        public void ChangeFileName(string newFileName)
        {
            _fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", newFileName);
        }
    }
}

