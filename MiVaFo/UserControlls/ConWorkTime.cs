using ArbeitszeitVerwaltung;
using WPBase;

namespace MiVaFo
{
    public partial class ConWorkTime : UserControl
    {
        bool _IsEditable = false;
        private Arbeitszeit _WT = new();

        public ArbeitszeitManager AV { get; set; } = ArbeitszeitManager.Instance;
        private readonly LanguageManager LM = LanguageManager.Instance;

        public ConWorkTime()
        {
            InitializeComponent();
            AV.ValueChanged +=OnValueChanged;
            SetLanguage();
            EnableCmd();
            EnableTextbox();
            ShowTextbox();
        }

        private void SetLanguage()
        {
            Tb_ArID.Text = LM.Get("UCWT_ArID.Text", "Arbeitszeit ID");
            Tb_Start.Text = LM.Get("UCWT_ArSt.Text", "Startzeitpunkt");
            TB_Ende.Text = LM.Get("UCWT_ArEn.Text", "Endzeitpunkt");
            Tb_Pause.Text = LM.Get("UCWT_ArPa.Text", "Pausenzeit (decimal)");
            Tb_Worktime.Text = LM.Get("UCWT_ArWT.Text", "Arbeitszeit");

            Cmd_Save.Text = LM.Get("UCWT_CmdSave.Text", "Speichern");
            Cmd_Cancel.Text = LM.Get("UCWT_CmdCancel.Text", "Abbrechen");
        }
        private void OnValueChanged(object? sender, EventArgs e)
        {
            if (_WT != AV.Value)
            {
                _WT = AV.Value;
                if (AV.Value != null)
                {
                    ShowData(AV.Value);
                }
            }
        }
        public void ShowData(Arbeitszeit? Value = null)
        {

            if (Value == null)
            {
                SetText(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);

                ShowTextbox(false, false, false, false, false);
            }
            else
            {
                AV.SetValue(Value);
                SetText(AV.Value.ID, AV.Value.Start.ToString("HH:mm dd.MM.yyyy"), AV.Value.Ende.ToString("HH:mm dd.MM.yyyy"), $"{AV.Value.Pause}", $"{AV.Value.Worktime}");

                ShowTextbox(true, true, true, true, true);
            }
            EnableTextbox(false, false, false, false, false);
            EnableCmd(false, false);
            ShowCmd(false, false);
        }
        public void AddData()
        {
            _IsEditable = false;
            SetText();
            EnableTextbox(false, true, true, true, false);
            EnableCmd(true, true);

            ShowTextbox(true, true, true, true, true);
            ShowCmd(true, true);
            Refresh();
        }
        public void UpdateData(Arbeitszeit worker)
        {
            _IsEditable = true;
            SetText(worker.ID, worker.Start.ToString("HH:mm dd.MM.yyyy"), worker.Ende.ToString("HH:mm dd.MM.yyyy"), $"{worker.Pause}", $"{worker.Worktime}");
            EnableTextbox(false, true, true, true, false);
            EnableCmd(true, true);

            ShowTextbox(true, true, true, true, true);
            ShowCmd(true, true);
            Refresh();
        }


        private void SetText(string? id = null, string? start = null, string? ende = null, string? pause = null, string? wt = null)
        {
            Tb_ArID.Text = id??string.Empty;
            Tb_Start.Text = start??string.Empty;
            TB_Ende.Text = ende??string.Empty;
            Tb_Pause.Text = pause??string.Empty;
            Tb_Worktime.Text = wt??string.Empty;
        }
        private void ShowCmd(bool showSave = false, bool showCancel = false)
        {
            if (showSave) Cmd_Save.Show(); else Cmd_Save.Hide();
            if (showCancel) Cmd_Cancel.Show(); else Cmd_Cancel.Hide();
        }
        private void ShowTextbox(bool showID = false, bool showStart = false, bool showEnde = false, bool showPause = false, bool showWorktime = false)
        {
            if (showID) Tb_ArID.Show(); else Tb_ArID.Hide();
            if (showStart) Tb_Start.Show(); else Tb_Start.Hide();
            if (showEnde) TB_Ende.Show(); else TB_Ende.Hide();
            if (showPause) Tb_Pause.Show(); else Tb_Pause.Hide();
            if (showWorktime) Tb_Worktime.Show(); else Tb_Worktime.Hide();
        }
        private void EnableCmd(bool canSave = false, bool canCancel = false)
        {
            ShowCmd(canSave, canCancel);
            Cmd_Save.Enabled = canSave; ;
            Cmd_Cancel.Enabled = canCancel;
        }
        private void EnableTextbox(bool id = false, bool start = false, bool ende = false, bool pause = false, bool worktime = false)
        {
            Tb_ArID.Enabled = id;
            Tb_Start.Enabled = start;
            TB_Ende.Enabled = ende;
            Tb_Pause.Enabled = pause;
            Tb_Worktime.Enabled = worktime;
        }

        private void Cmd_Save_Click(object sender, EventArgs e)
        {
            var worker = new Arbeitszeit()
            {
                ID = $"{AV.Values.Count}",
                Start = ArbeitszeitManager.ParseDateTime(Tb_Start.Text)??DateTime.Now,
                Ende = ArbeitszeitManager.ParseDateTime(TB_Ende.Text)??DateTime.Now.AddHours(8),
                Pause = Convert.ToDouble(Tb_Pause.Text),
            };

            SetText(worker.ID, worker.Start.ToString("HH:mm dd.MM.yyyy"), worker.Ende.ToString("HH:mm dd.MM.yyyy"), $"{worker.Pause}", $"{worker.Worktime}");

            EnableTextbox(false, false, false, false, false);
            EnableCmd(false, false);

            ShowTextbox(true, true, true, true, true);
            ShowCmd(false, false);
            if (Helper.ShowUserQuestion(
                    $"Möchten sie den Mitarbeiter : \r\n"+
                    $"ID : {worker.ID}\r\n"+
                    $"Daten :\r\n"+
                    $"Start :{worker.Start:HH:mm dd.MM.yyyy}\r\n"+
                    $"Ende :{worker.Ende:HH:mm dd.MM.yyyy}\r\n"+
                    $"Pause :{worker.Pause}\r\n"+
                    $"Arbeitszeit :{worker.Worktime}\r\n"+
                    $"{(_IsEditable ? LM.Get("UCWT_Update_Text", " bearbeiten?") : LM.Get("UCWT_Add_Text", " hinzufügen?"))}",
                    _IsEditable ? LM.Get("UCWT_Update_Titel", "Bearbeiten") : LM.Get("UCWT_Add_Titel", "Hinzufügen"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, true))
            {
                AV.SetValue(new());
                AV.SetValue(worker);
                if (!_IsEditable) { AV.Add(worker); } else { AV.Update(worker); }
                Refresh();
            }
            else
            {
                AV.SetValue(new());
                Cmd_Cancel_Click(sender, e);
            }
            _IsEditable = false;
        }

        private void Cmd_Cancel_Click(object sender, EventArgs e)
        {
            Helper.ShowUserQuestion(
                LM.Get("UCWT_DLG_Cancel_Text", "Abbruch durch Benutzer!"),
                LM.Get("UCWT_DLG_Cancel_Titel", "Abbruch"),
                MessageBoxButtons.OK, MessageBoxIcon.Warning, false);
            ShowData(AV.Value);
            Refresh();
        }
    }
}
