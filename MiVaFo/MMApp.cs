using ArbeitszeitVerwaltung;
using MitarbeiterVerwaltung;

namespace MiVaFo
{
    public partial class MMApp : Form
    {
        private readonly MiVaForm _MiVa = new();
        private readonly ArVaForm _ArVa = new();
        public MMApp()
        {
            InitializeComponent();
        }

        private void Cmd_Close_Click(object sender, EventArgs e)
        {
            ArbeitszeitManager.Instance.Save();
            MitarbeiterManager.Instance.Save();
            this.Close();
        }

        private void Cmd_MiVa_Click(object sender, EventArgs e)
        {
            _MiVa.Show();
            _ArVa.Hide();
        }

        private void Cmd_ArVa_Click(object sender, EventArgs e)
        {
            _ArVa.Show();
            _MiVa.Hide();
        }
    }
}
