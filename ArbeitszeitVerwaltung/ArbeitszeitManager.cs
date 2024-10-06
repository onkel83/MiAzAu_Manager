using System.Globalization;
using WPBase;

namespace ArbeitszeitVerwaltung
{
    public class ArbeitszeitManager
    {
        private static ArbeitszeitManager? _instance;
        private static readonly object _lock = new();

        private readonly Repository<Arbeitszeit> _Repo = new("Arbeitszeit");
        private readonly ConfigManager<string> _Config = ConfigManager<string>.Instance("ArVa.con");
        private readonly ErrorHandler _Error;

        private List<Arbeitszeit> _Values = [];
        private Arbeitszeit _Value = new();

        // Event, das ausgelöst wird, wenn sich die Liste Values ändert
        public event EventHandler? ValuesChanged;
        public event EventHandler? ValueChanged;

        public List<Arbeitszeit> Values
        {
            get => _Values;
            private set
            {
                _Values = value;
                OnValuesChanged(); // Event auslösen
            }
        }

        public Arbeitszeit Value
        {
            get => _Value;
            private set
            {
                _Value = value;
                OnValueChanged();
            }
        }

        // Privater Konstruktor für Singleton
        private ArbeitszeitManager()
        {
            Init();
            _Error = ErrorHandler.GetInstance(_Config.Get("ArVa", "AppName"), false);
            _Repo.ChangeFileName(_Config.Get("ArVa", "RepoName"));
            Load(); // Initiales Laden der Werte
        }

        // Singleton Instanzzugriff
        public static ArbeitszeitManager Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new();
                    return _instance;
                }
            }
        }

        public void SetValue(Arbeitszeit item)
        {
            Value = item;
        }

        // Methode, um das Event auszulösen
        protected virtual void OnValuesChanged()
        {
            ValuesChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }


        public void Add(Arbeitszeit worker)
        {
            try
            {
                Value = worker;
                if (Arbeitszeit.CheckInsert(Value, ref _Values))
                {
                    Save();
                    Load();
                }
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }

        public void Delete(Arbeitszeit Worker)
        {
            try
            {
                Value = Worker;
                _Values.Remove(Value);
                Save();
                Load();
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }

        public void Update(Arbeitszeit Worker)
        {
            try
            {
                Value = Worker;
                _Values.Remove(_Values.First(x => x.ID.Equals(Value.ID)));
                _Values.Add(Value);
                Save();
                Load();
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }

        public void Save()
        {
            try
            {
                _Repo.SaveToFile(_Values);
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }

        public void Load()
        {
            try
            {
                _Values = _Repo.LoadFromFile();
                OnValuesChanged(); // Event nach dem Laden auslösen
            }
            catch (Exception ex)
            {
                _Error.LogException(ex);
            }
        }

        public Arbeitszeit Get(Predicate<Arbeitszeit> search)
        {
            var m = _Values.Find(search);
            return m ?? new();
        }

        public List<Arbeitszeit> GetMore(Predicate<Arbeitszeit> search)
        {
            return _Values.FindAll(search);
        }

        /* Preparment for Socket using
        public string ProcessJson(string data)
        {
            var jd = JsonSerializer.Deserialize<JsonData<Mitarbeiter>>(data);
            if (jd != null && !string.IsNullOrEmpty(jd.Command))
            {
                Value = jd.Value ?? new();
                switch (jd.Command)
                {
                    case "add":
                        Add(new());
                        jd.Response = $"{Value.Name} hinzugefügt";
                        break;
                    case "delete":
                        Delete(new());
                        jd.Response = $"{Value.Name} gelöscht";
                        break;
                    case "update":
                        Update(new());
                        jd.Response = $"{Value.Name} aktualisiert";
                        break;
                    default:
                        jd.Response = string.Empty;
                        break;
                }
                Value = new();
            }
            return JsonSerializer.Serialize(jd);
        }
        */

        private void Init()
        {
            if (!_Config.Contains("ArVa", "FirstStart") || !_Config.Get("ArVa", "FirstStart").Equals($"{false}"))
            {
                _Config.AddOrUpdate("ArVa", "FirstStart", $"{false}");
                _Config.AddOrUpdate("ArVa", "AppName", "ArVa");
                _Config.AddOrUpdate("ArVa", "AppVersion", "00|00|01 (a)");
                _Config.AddOrUpdate("ArVa", "RepoName", "ArVa.dat");
                _Config.AddOrUpdate("ArVa", "Lng", "default");
                _Config.AddOrUpdate("ArVa", "AppVH",
                    @"Diese Version befindet sich in einen sehr frühen
                     Alpha Stadium bitte bedenken sie dies bei der Nutzung!");
            }
        }

        public static DateTime? ParseDateTime(string input)
        {
            // Liste der unterstützten Formate
            string[] formats = [
            "dd.MM.yyyy HH.mm",    // z.B. "06.10.2024 12.30"
            "HH:mm dd.MM.yyyy",    // z.B. "12:30 06.10.2024"
            "dd.MM HH:mm",         // z.B. "06.10 12:30"
            "HH:mm dd.MM"          // z.B. "12:30 06.10"
        ];

            // Versuche, das Datum zu parsen
            if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return result;
            }
            else
            {
                // Rückgabe null, falls das Parsen fehlschlägt
                return null;
            }
        }
    }
}
