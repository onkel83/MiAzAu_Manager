using ArbeitszeitVerwaltung;

namespace MiVaFo
{
    public partial class ConWorTimeList : UserControl
    {
        private readonly ArbeitszeitManager _AV = ArbeitszeitManager.Instance;
        public ConWorTimeList()
        {
            InitializeComponent();
            _AV.ValuesChanged += OnValuesChanged;
        }

        private void OnValuesChanged(object? sender, EventArgs e)
        {
            Lb_WT.Items.Clear();
            foreach (var item in _AV.Values)
            {
                Lb_WT.Items.Add(item);
            }
            Lb_WT.DisplayMember = "ToListEntry";

        }

        private void Lb_WT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lb_WT.SelectedIndex != -1)
            {
                _AV.SetValue(_AV.Values[Lb_WT.SelectedIndex]);
            }
        }
    }
}
