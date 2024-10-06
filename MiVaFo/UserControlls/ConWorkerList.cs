using MitarbeiterVerwaltung;
using WPBase;

namespace MiVaFo
{

    public partial class ConWorkerList : UserControl
    {
        private readonly MitarbeiterManager _MV = MitarbeiterManager.Instance;

        public ConWorkerList()
        {
            InitializeComponent();
            _MV.ValuesChanged += OnValuesChanged;
            TSSL_LastLabel.Text = $"{LanguageManager.Instance.Get("UCWL_TSSL_Text", "zu letzt gewählt")}";
        }

        private void OnValuesChanged(object? sender, EventArgs e)
        {
            LiBoWorker.Items.Clear();
            foreach (var item in _MV.Values)
            {
                LiBoWorker.Items.Add(item);
            }
            LiBoWorker.DisplayMember = "Name";

        }

        private void LiBoWorker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LiBoWorker.SelectedIndex != -1)
            {
                _MV.SetValue(_MV.Values[LiBoWorker.SelectedIndex]);
                TSSL_Last.Text = _MV.Value.Name;
            }
        }
    }
}
