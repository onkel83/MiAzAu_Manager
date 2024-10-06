using MitarbeiterVerwaltung;
using WPBase;

namespace MiVaFo
{
    public partial class MiVaForm : Form
    {
        private readonly MitarbeiterManager _MV = MitarbeiterManager.Instance;
        private readonly ConfigManager<string> _Config = ConfigManager<string>.Instance("MiVa.con");
        private readonly LanguageManager _LM = LanguageManager.Instance;
        public MiVaForm()
        {
            InitializeComponent();
            CW_Main.MV = _MV;
            _MV.Load();
            ShowElements(true, true, true);
            EnableMainMenue(true, true, true);
            SetLanguage();
        }

        private void SetLanguage()
        {

            TSMC_Beenden.Text = _LM.Get("MIVA_TSMC_Close_Title", "Beenden");
            TSMC_Load.Text = _LM.Get("MIVA_TSMC_Load_Title", "Laden");
            TSMC_Save.Text = _LM.Get("MIVA_TSMC_Save_Title", "Speichern");

            TSMC_Update.Text = _LM.Get("MIVA_TSMC_Update_Title", "Bearbeiten");
            TSMC_Delete.Text = _LM.Get("MIVA_TSMC_Delete_Title", "Löschen");
            TSMC_Add.Text = _LM.Get("MIVA_TSMC_Add_Title", "Hinzufügen");

            TSMC_Info.Text = _LM.Get("MIVA_TSMC_About_Title", "Über");
            TSMC_Worker.Text = _LM.Get("MIVA_TSMC_Worker_Title", "Mitarbeiter");
            TSMI_Dati.Text = _LM.Get("MIVA_TSMC_File_Title", "Program");

        }

        private void ShowElements(bool ms = false, bool li = false, bool cw = false)
        {
            MeStMiVa.Visible = ms;
            conWL_Main.Visible = li;
            CW_Main.Visible = cw;
        }

        private void EnableFile(bool save = false, bool load = false, bool close = true)
        {
            TSMC_Save.Visible = save;
            TSMC_Load.Visible = load;
            TSMC_Beenden.Visible = close;

            TSMC_Save.Enabled = save;
            TSMC_Load.Enabled = load;
            TSMC_Beenden.Enabled = close;
        }
        private void EnableWorker(bool New = false, bool Update = false, bool Delete = false)
        {
            TSMC_Add.Visible = New;
            TSMC_Update.Visible = Update;
            TSMC_Delete.Visible = Delete;

            TSMC_Add.Enabled = New;
            TSMC_Update.Enabled = Update;
            TSMC_Delete.Enabled = Delete;
        }
        private void EnableMainMenue(bool file = false, bool worker = false, bool info = false)
        {
            TSMI_Dati.Visible = file;
            TSMC_Worker.Visible = worker;
            TSMC_Info.Visible = info;

            TSMI_Dati.Enabled = file;
            TSMC_Worker.Enabled = worker;
            TSMC_Info.Enabled = info;

            EnableFile(true, true, true);
            EnableWorker(true, true, true);
        }


        private void TSMC_Load_Click(object sender, EventArgs e)
        {

            if (Helper.ShowUserQuestion(
                    _LM.Get("MIVA_DLG_Load_Text", "Möchten sie die Daten erneut Laden?"),
                    _LM.Get("MIVA_TSMC_Load_Title", "Laden"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _MV.Load();
                Refresh();
            }

        }
        private void TSMC_Save_Click(object sender, EventArgs e)
        {
            if (Helper.ShowUserQuestion(
                    _LM.Get("MIVA_DLG_Save_Text", "Möchten sie die Daten speichern?"),
                    _LM.Get("MIVA_TSMC_Save_Title", "Speichern"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _MV.Save();
            }
        }
        private void TSMC_Beenden_Click(object sender, EventArgs e)
        {
            if (Helper.ShowUserQuestion(
                    _LM.Get("MIVA_DLG_Close_Text", $"Sind Sie Sicher das sie die Anwendung beenden möchten ?"),
                    _LM.Get("MIVA_TSMC_Close_Title", "Beenden"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _MV.Save();
                this.Hide();
            }
        }

        private void TSMC_Add_Click(object sender, EventArgs e)
        {
            CW_Main.AddData();
            Refresh();
        }
        private void TSMC_Update_Click(object sender, EventArgs e)
        {
            if (_MV.Value != null)
            {
                CW_Main.UpdateData(_MV.Value);
            }
        }
        private void TSMC_Delete_Click(object sender, EventArgs e)
        {

            if (_MV.Value != null)
            {
                if (Helper.ShowUserQuestion(
                        $"Sind Sie Sicher das sie Den Mitarbeiter :\r\n"+
                        $"ID : {_MV.Value.ID}\r\n"+
                        $"Name : {_MV.Value.Name}\r\n"+
                        $"Löschen möchten ?",
                        _LM.Get("MIVA_TSMC_Delete_Title", "Löschen"),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
                {
                    _MV.Delete(_MV.Value);
                }
            }
        }

        private void TSMC_Info_Click(object sender, EventArgs e)
        {
            Helper.ShowUserQuestion(
                $"{_LM.Get("MIVA_DLG_About_Text", $"Herzlich Willkommen bei {_Config.Get("MiVa", "AppName")}!\r\n"+
                $"App : {_Config.Get("MiVa", "AppName")}\r\n"+
                $"Version : {_Config.Get("MiVa", "AppVersion")}\r\n"+
                $"Versions Hinweiße : {_Config.Get("MiVa", "AppVH")}\r\n")}"+
                $"\r\nAuthor : winemp83",
                $"{_LM.Get("MIVA_TSMC_About_Title", "Über")} {_Config.Get("MiVa", "AppName")}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information, false);
        }


    }
}
