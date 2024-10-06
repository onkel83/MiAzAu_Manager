namespace WPBase
{
    public class LanguageManager
    {
        private static LanguageManager? _instance;

        private readonly Repository<Language> _Repo = new("lng.dat");
        private readonly ConfigManager<string> _Config = ConfigManager<string>.Instance("MiVa.con");
        private readonly ErrorHandler _Error;

        private List<Language> _Values = [];
        public Language _Value = new();

        public LanguageManager()
        {
            _Error = ErrorHandler.GetInstance(_Config.Get("MiVa", "AppName"), false);
            _Repo.ChangeFileName("lng.dat");
            Load(); // Initiales Laden der Werte
        }

        public static LanguageManager Instance
        {
            get => _instance ??= new LanguageManager();
            private set => _instance = value;
        }

        public void Load(string? lng = null)
        {
            try
            {
                if (_Config.Contains("MiVa", "Lng"))
                {
                    _Values = _Repo.LoadFromFile();
                    foreach (var items in _Values)
                    {
                        if (items.Lng == (lng??_Config.Get("MiVa", "Lng")))
                        {
                            _Value = items;
                            return;
                        }
                    }
                    var item = _Values.Find(X => X.Lng == "default");
                    if (item != null)
                    {
                        return;
                    }
                }

                Install();
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }
        public string Get(string key, string? defaultValue = null)
        {
            if (_Value.Values.TryGetValue(key, out var item))
            {
                return item;
            }
            if (string.IsNullOrEmpty(defaultValue))
            {
                throw new Exception($"Wert in der Language Datei nicht Enthalten KEY:{key}");
            }
            _Value.Values.Add(key, defaultValue);
            Save();
            return defaultValue;
        }
        private void Save()
        {
            _Repo.SaveToFile(_Values);
        }

        private void Install()
        {
            _Values = [];
            Language Default = new()
            {
                Lng = "default",
                Values = []
            };

            _Value = Default;
            _Values.Add(_Value);
            Save();
        }
    }
}
