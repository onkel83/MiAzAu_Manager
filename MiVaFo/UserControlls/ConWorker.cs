using MitarbeiterVerwaltung;
using WPBase;

namespace MiVaFo
{
    public partial class ConWorker : UserControl
    {
        public bool Editable = false;
        private Mitarbeiter _LastMitarbeiter = new();
        public MitarbeiterManager MV { get; set; } = MitarbeiterManager.Instance;
        private readonly LanguageManager LM = LanguageManager.Instance;

        public ConWorker()
        {
            InitializeComponent();
            MV.ValueChanged += OnValueChanged;
            SetText();
            EnableTextBox(false, false, false);
            ShowTextBox(false, false, false);
            EnableCmd(false, false);
            ShowCmd(false, false);
            SetLanguage();
        }
        private void SetLanguage()
        {
            LbID.Text = $"{LM.Get("UCW_LbID_Text", "Mitarbeiter ID")} :";
            LbVorname.Text = $"{LM.Get("UCW_LbVN_Text", "Vorname")} :";
            lbNachname.Text = $"{LM.Get("UCW_LbNN_Text", "Nachname")} :";

            CmdSave.Text = $"{LM.Get("UCW_Add_Text", "Speichern")} :";
            CmdCancel.Text = $"{LM.Get("UCW_Canel_Text", "Abbrechen")} :";
        }
        private void OnValueChanged(object? sender, EventArgs e)
        {
            if (_LastMitarbeiter != MV.Value)
            {
                _LastMitarbeiter = MV.Value;
                if (MV.Value != null)
                {
                    ShowData(MV.Value);
                }
            }
        }
        public void ShowData(Mitarbeiter? Value = null)
        {

            if (Value == null)
            {
                SetText(string.Empty, string.Empty, string.Empty);
                SetTSSL($"{LM.Get("UCW_TSSL_Status", "Modus")} : {LM.Get("UCW_Show", "Anzeigen")}", string.Empty);

                ShowTextBox(false, false, false);
            }
            else
            {
                MV.SetValue(Value);
                SetText(MV.Value.ID, MV.Value.Vorname, MV.Value.Nachname);
                SetTSSL($"{LM.Get("UCW_TSSL_Status", "Modus")} : {LM.Get("UCW_Show", "Anzeigen")}", $"{LM.Get("UCW_Name", "Name")} : {MV.Value.Name}");

                ShowTextBox(true, true, true);
            }

            EnableTextBox(false, false, false);
            EnableCmd(false, false);
            ShowCmd(false, false);
            ShowTSSL(true, true);


        }
        public void AddData()
        {
            Editable = false;
            SetText();
            SetTSSL($"{LM.Get("UCW_TSSL_Status", "Modus")} : {LM.Get("UCW_Add", "Hinzufügen")}", string.Empty);

            EnableTextBox(true, true, true);
            EnableCmd(true, true);

            ShowTextBox(true, true, true);
            ShowCmd(true, true);
            ShowTSSL(true, true);
            Refresh();
        }
        public void UpdateData(Mitarbeiter worker)
        {
            Editable = true;
            SetText(worker.ID, worker.Vorname, worker.Nachname);
            SetTSSL($"{LM.Get("UCW_TSSL_Status", "Modus")} : {LM.Get("UCW_Update", "Bearbeiten")}", string.Empty);
            EnableTextBox(false, true, true);
            EnableCmd(true, true);

            ShowTextBox(true, true, true);
            ShowCmd(true, true);
            ShowTSSL(true, true);
            Refresh();
        }

        private void EnableTextBox(bool id = false, bool vn = false, bool nn = false)
        {
            if (id) { TBID.Enabled = true; } else { TBID.Enabled = false; }
            if (vn) { TBVorname.Enabled = true; } else { TBVorname.Enabled = false; }
            if (nn) { TBNachname.Enabled = true; } else { TBNachname.Enabled = false; }
        }
        private void EnableCmd(bool save = false, bool cancel = false)
        {
            if (save) { CmdSave.Enabled = true; } else { CmdSave.Enabled = false; }
            if (cancel) { CmdCancel.Enabled = true; } else { CmdCancel.Enabled = false; }
        }
        private void ShowTextBox(bool id = false, bool vn = false, bool nn = false)
        {
            if (!id) { TBID.Hide(); } else { TBID.Show(); }
            if (!vn) { TBVorname.Hide(); } else { TBVorname.Show(); }
            if (!nn) { TBNachname.Hide(); } else { TBNachname.Show(); }
        }
        private void ShowCmd(bool save = false, bool cancel = false)
        {
            if (save) { CmdSave.Show(); } else { CmdSave.Hide(); }
            if (cancel) { CmdCancel.Show(); } else { CmdCancel.Hide(); }
        }
        private void ShowTSSL(bool label = false, bool data = false)
        {
            if (label) { TSSLName.Visible = true; } else { TSSLName.Visible = false; }
            if (data) { TSSTBName.Visible = true; } else { TSSTBName.Visible = false; }
        }
        private void SetText(string? id = null, string? vn = null, string? nn = null)
        {
            TBID.Text = id??string.Empty;
            TBVorname.Text = vn??string.Empty;
            TBNachname.Text = nn??string.Empty;
        }
        private void SetTSSL(string? label = null, string? data = null)
        {
            TSSLName.Text = string.IsNullOrEmpty(label) ? string.Empty : label;
            TSSTBName.Text = string.IsNullOrEmpty(data) ? string.Empty : data;
        }

        public void CmdSave_Clicked(object sender, EventArgs e)
        {
            var worker = new Mitarbeiter()
            {
                ID = TBID.Text,
                Vorname = TBVorname.Text,
                Nachname = TBNachname.Text,
            };

            SetText(worker.ID, worker.Vorname, worker.Nachname);
            SetTSSL($"{LM.Get("UCW_TSSL_Status", "Modus")} : {LM.Get("UCW_Show", "Anzeigen")}", string.Empty);

            EnableTextBox(false, false, false);
            EnableCmd(false, false);

            ShowTextBox(true, true, true);
            ShowCmd(false, false);
            ShowTSSL(true, true);
            if (Helper.ShowUserQuestion(
                    $"Möchten sie den Mitarbeiter : \r\n"+
                    $"ID : {worker.ID}\r\n"+
                    $"Name : {worker.Name}\r\n"+
                    $"{(Editable ? LM.Get("UCW_Update_Text", " bearbeiten?") : LM.Get("UCW_Add_Text", " hinzufügen?"))}",
                    Editable ? LM.Get("UCW_Update_Titel", "Bearbeiten") : LM.Get("UCW_Add_Titel", "Hinzufügen"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, true))
            {
                MV.SetValue(new());
                MV.SetValue(worker);
                if (!Editable) { MV.Add(worker); } else { MV.Update(worker); }
                Refresh();
            }
            else
            {
                MV.SetValue(new());
                CmdCancel_Clicked(sender, e);
            }
            Editable = false;
        }
        public void CmdCancel_Clicked(object sender, EventArgs e)
        {
            Helper.ShowUserQuestion(
                LM.Get("UCW_DLG_Cancel_Text", "Abbruch durch Benutzer!"),
                LM.Get("UCW_DLG_Cancel_Titel", "Abbruch"),
                MessageBoxButtons.OK, MessageBoxIcon.Warning, false);
            ShowData(MV.Value);
            Refresh();
        }
    }
}
