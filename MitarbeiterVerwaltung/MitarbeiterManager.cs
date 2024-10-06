using WPBase;

namespace MitarbeiterVerwaltung
{
    public class MitarbeiterManager
    {
        private static MitarbeiterManager? _instance;
        private static readonly object _lock = new();

        private readonly Repository<Mitarbeiter> _Repo = new("Mitarbeiter");
        private readonly ConfigManager<string> _Config = ConfigManager<string>.Instance("MiVa.con");
        private readonly ErrorHandler _Error;

        private List<Mitarbeiter> _Values = [];
        private Mitarbeiter _Value = new();

        // Event, das ausgelöst wird, wenn sich die Liste Values ändert
        public event EventHandler? ValuesChanged;
        public event EventHandler? ValueChanged;

        public List<Mitarbeiter> Values
        {
            get => _Values;
            private set
            {
                _Values = value;
                OnValuesChanged(); // Event auslösen
            }
        }

        public Mitarbeiter Value
        {
            get => _Value;
            private set
            {
                _Value = value;
                OnValueChanged();
            }
        }

        // Privater Konstruktor für Singleton
        private MitarbeiterManager()
        {
            Init();
            _Error = ErrorHandler.GetInstance(_Config.Get("MiVa", "AppName"), false);
            _Repo.ChangeFileName(_Config.Get("MiVa", "RepoName"));
            Load(); // Initiales Laden der Werte
        }

        // Singleton Instanzzugriff
        public static MitarbeiterManager Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new MitarbeiterManager();
                    return _instance;
                }
            }
        }

        public void SetValue(Mitarbeiter item)
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


        public void Add(Mitarbeiter worker)
        {
            try
            {
                Value = worker;
                if (Mitarbeiter.CheckInsert(Value, ref _Values))
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

        public void Delete(Mitarbeiter Worker)
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

        public void Update(Mitarbeiter Worker)
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

        public Mitarbeiter Get(Predicate<Mitarbeiter> search)
        {
            var m = _Values.Find(search);
            return m ?? new Mitarbeiter();
        }

        public List<Mitarbeiter> GetMore(Predicate<Mitarbeiter> search)
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
            if (!_Config.Contains("MiVa", "FirstStart") || !_Config.Get("MiVa", "FirstStart").Equals($"{false}"))
            {
                _Config.AddOrUpdate("MiVa", "FirstStart", $"{false}");
                _Config.AddOrUpdate("MiVa", "AppName", "MiVa");
                _Config.AddOrUpdate("MiVa", "AppVersion", "00|00|01 (a)");
                _Config.AddOrUpdate("MiVa", "RepoName", "MiVa.dat");
                _Config.AddOrUpdate("MiVa", "Lng", "default");
                _Config.AddOrUpdate("MiVa", "VH",
                    @"Diese Version befindet sich in einen sehr frühen
                     Alpha Stadium bitte bedenken sie dies bei der Nutzung!");
            }
        }
    }
}
