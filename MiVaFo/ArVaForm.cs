using ArbeitszeitVerwaltung;
using WPBase;

namespace MiVaFo
{
    public partial class ArVaForm : Form
    {
        private ArbeitszeitManager _AV = ArbeitszeitManager.Instance;
        private readonly ConfigManager<string> _Config = ConfigManager<string>.Instance("ArVa.con");
        private readonly LanguageManager _LM = LanguageManager.Instance;
        public ArVaForm()
        {
            InitializeComponent();
            Con_WT_Details.AV = _AV;
            _AV.Load();
            ShowElements(true, true, true);
            EnableMainMenue(true, true, true);
            SetLanguage();
        }

        private void SetLanguage()
        {
            TSMC_File.Text = _LM.Get("ArVa_TSMC_File_Titel", "Program");
            TSMC_WT.Text = _LM.Get("ArVa_TSMC_WT_Titel", "Arbeitszeit");
            TSMC_About.Text = _LM.Get("ArVa_TSMC_About_Titel", "Über");

            TSMC_File_Save.Text = _LM.Get("ArVa_TSMC_FileSave_Titel", "Speichern");
            TSMC_File_Load.Text = _LM.Get("ArVa_TSMC_FileLoad_Titel", "Laden");
            TSMC_File_Close.Text = _LM.Get("ArVa_TSMC_FileClose_Titel", "Beenden");

            TSMC_WT_Add.Text = _LM.Get("ArVa_TSMC_WTAdd", "Hinzufügen");
            TSMC_WT_Delete.Text = _LM.Get("ArVa_TSMC_WTDelete", "Löschen");
            TSMC_WT_Update.Text = _LM.Get("ArVa_TSMC_WTUpdate", "Bearbeiten");
        }
        private void ShowElements(bool mm = false, bool wtl = false, bool wtd = false)
        {
            menuStrip1.Visible = mm;
            Con_WT_Details.Visible = wtd;
            ConWT_Main.Visible = wtl;
        }

        private void EnableMainMenue(bool file = false, bool wt = false, bool about = false)
        {
            TSMC_File.Enabled = file;
            TSMC_WT.Enabled = wt;
            TSMC_About.Enabled = about;

            EnableShowFile(true, true, true);
            EnableShowWT(true, true, true);
        }
        private void EnableShowFile(bool save = false, bool load = false, bool close = true)
        {
            TSMC_File_Save.Enabled = save;
            TSMC_File_Load.Enabled = load;
            TSMC_File_Close.Enabled = close;

            TSMC_File_Save.Visible = save;
            TSMC_File_Load.Visible = load;
            TSMC_File_Close.Visible= close;
        }
        private void EnableShowWT(bool add = false, bool update = false, bool delete = false)
        {
            TSMC_WT_Add.Enabled = add;
            TSMC_WT_Update.Enabled = update;
            TSMC_WT_Delete.Enabled = delete;

            TSMC_WT_Add.Visible = add;
            TSMC_WT_Update.Visible = update;
            TSMC_WT_Delete.Visible = delete;
        }

        private void TSMC_File_Close_Click(object sender, EventArgs e)
        {
            if (Helper.ShowUserQuestion(
                    _LM.Get("ArVa_DLG_Close_Text", $"Sind Sie Sicher das sie die Anwendung beenden möchten ?"),
                    _LM.Get("ArVa_TSMC_Close_Title", "Beenden"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _AV.Save();
                this.Hide();
            }
        }
        private void TSMC_File_Load_Click(object sender, EventArgs e)
        {
            if (Helper.ShowUserQuestion(
                    _LM.Get("ArVa_DLG_Load_Text", "Möchten sie die Daten erneut Laden?"),
                    _LM.Get("ArVa_TSMC_Load_Title", "Laden"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _AV.Load();
                Refresh();
            }
        }
        private void TSMC_File_Save_Click(object sender, EventArgs e)
        {
            if (Helper.ShowUserQuestion(
                    _LM.Get("ArVa_DLG_Save_Text", "Möchten sie die Daten speichern?"),
                    _LM.Get("ArVa_TSMC_Save_Title", "Speichern"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
            {
                _AV.Save();
            }
        }

        private void TSMC_WT_Add_Click(object sender, EventArgs e)
        {
            Con_WT_Details.AddData();
            Refresh();
        }

        private void TSMC_WT_Update_Click(object sender, EventArgs e)
        {
            if (_AV.Value != null)
            {
                Con_WT_Details.UpdateData(_AV.Value);
            }
        }

        private void TSMC_WT_Delete_Click(object sender, EventArgs e)
        {
            if (_AV.Value != null)
            {
                if (Helper.ShowUserQuestion(
                        $"Sind Sie Sicher das sie die Arbeitszeit :\r\n"+
                        $"ID : {_AV.Value.ID}\r\n"+
                        $"Details : {_AV.Value.ToListEntry}\r\n"+
                        $"Löschen möchten ?",
                        _LM.Get("ArVa_TSMC_Delete_Title", "Löschen"),
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
                {
                    _AV.Delete(_AV.Value);
                }
            }
        }

        private void TSMC_About_Click(object sender, EventArgs e)
        {
            Helper.ShowUserQuestion(
                $"{_LM.Get("ArVa_DLG_About_Text", $"Herzlich Willkommen bei {_Config.Get("ArVa", "AppName")}!\r\n"+
                $"App : {_Config.Get("ArVa", "AppName")}\r\n"+
                $"Version : {_Config.Get("ArVa", "AppVersion")}\r\n"+
                $"Versions Hinweiße : {_Config.Get("ArVa", "AppVH")}\r\n")}"+
                $"\r\nAuthor : winemp83",
                $"{_LM.Get("ArVa_TSMC_About_Title", "Über")} {_Config.Get("ArVa", "AppName")}",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information, false);
        }
    }
}
