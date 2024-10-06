namespace ArbeitszeitVerwaltung
{
    public class Arbeitszeit
    {
        public string ID { get; set; } = string.Empty;
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime Ende { get; set; } = DateTime.Now.AddHours(8);
        public double Pause { get; set; } = 0f;
        public decimal Worktime { get => (decimal)((Ende-Start).TotalHours - Pause); }
        public List<string> Mitarbeiter { get; set; } = [];

        public string ToListEntry { get => $"{Mitarbeiter.Count} {Worktime} {Start:HH.mm dd.MM.yyyy} - {Ende:HH.mm dd.MM.yyyy}"; }


        public static bool CheckInsert(Arbeitszeit worker, ref List<Arbeitszeit> workers)
        {
            if (string.IsNullOrEmpty(worker.ID)) { return false; }

            foreach (Arbeitszeit m in workers)
            {
                if (worker.ID == m.ID) { return false; }
                if (((worker.Start == m.Start && worker.Ende == m.Ende) && worker.Pause == m.Pause) ||
                    (worker.Start == m.Start && worker.Ende == m.Ende) && worker.Pause == m.Pause) { return false; }
            }
            workers.Add(worker);
            return true;
        }
    }
}
