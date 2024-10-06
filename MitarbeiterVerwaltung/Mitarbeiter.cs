namespace MitarbeiterVerwaltung
{
    public class Mitarbeiter
    {
        public string ID { get; set; } = string.Empty;
        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public string Name { get => $"{Nachname}, {Vorname}"; }

        public static bool CheckInsert(Mitarbeiter worker, ref List<Mitarbeiter> workers)
        {
            if (string.IsNullOrEmpty(worker.ID) || string.IsNullOrEmpty(worker.Vorname) || string.IsNullOrEmpty(worker.Nachname)) { return false; }
            foreach (Mitarbeiter m in workers)
            {
                if (worker.ID == m.ID) { return false; }
                if (worker.Vorname == m.Vorname && worker.Nachname == m.Nachname) { return false; }
                if (worker.Nachname == m.Vorname && worker.Nachname == m.Vorname) { return false; }
            }
            workers.Add(worker);
            return true;
        }
    }
}
