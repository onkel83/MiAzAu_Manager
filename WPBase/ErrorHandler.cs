namespace WPBase
{
    public class ErrorHandler
    {
        private static ErrorHandler? _instance;
        private static readonly object _lock = new();
        private readonly string _appName;
        private readonly bool _logToConsole;

        // Privater Konstruktor für Singleton
        private ErrorHandler(string appName, bool logToConsole)
        {
            _appName = appName;
            _logToConsole = logToConsole;
        }

        // Singleton-Instanzzugriff
        public static ErrorHandler GetInstance(string? appName = null, bool logToConsole = false)
        {
            lock (_lock)
            {
                _instance ??= new ErrorHandler(!string.IsNullOrEmpty(appName) ? appName : "Debug_Test", logToConsole);
                return _instance;
            }
        }

        // Speichert eine Exception in die Log-Datei und optional auf der Konsole
        public void LogException(Exception ex)
        {
            string currentDateTime = DateTime.Now.ToString("yyyy.MM.dd");
            string logFileName = $"{_appName}_{currentDateTime}.log";

            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFilePath = Path.Combine(logDirectory, logFileName);

            string logEntry = $"[{DateTime.Now}] - Fehler: {ex.Message}";

            // Fehler in Datei schreiben
            using (StreamWriter sw = new(logFilePath, true))
            {
                sw.WriteLine(logEntry);

                // Stack Trace hinzufügen, falls vorhanden
                if (ex.StackTrace != null)
                {
                    sw.WriteLine($"Stack Trace: {ex.StackTrace}");
                }

                sw.WriteLine("--------------------------------------------------");
            }

            // Optional auf der Konsole ausgeben
            if (_logToConsole)
            {
                Console.WriteLine(logEntry);
                if (ex.StackTrace != null)
                {
                    Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}
