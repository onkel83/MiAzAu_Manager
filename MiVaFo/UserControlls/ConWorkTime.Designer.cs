namespace MiVaFo
{
    partial class ConWorkTime
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            La_ArID = new Label();
            Tb_ArID = new TextBox();
            Tb_Start = new TextBox();
            La_Start = new Label();
            TB_Ende = new TextBox();
            Lb_Ende = new Label();
            Tb_Pause = new TextBox();
            Lb_Pause = new Label();
            Tb_Worktime = new TextBox();
            Lb_Worktime = new Label();
            Cmd_Cancel = new Button();
            Cmd_Save = new Button();
            SuspendLayout();
            // 
            // La_ArID
            // 
            La_ArID.Location = new Point(5, 5);
            La_ArID.Margin = new Padding(5);
            La_ArID.Name = "La_ArID";
            La_ArID.Size = new Size(150, 23);
            La_ArID.TabIndex = 0;
            La_ArID.Text = "Arbeitszeit ID";
            La_ArID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Tb_ArID
            // 
            Tb_ArID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tb_ArID.Enabled = false;
            Tb_ArID.Location = new Point(165, 6);
            Tb_ArID.Margin = new Padding(5);
            Tb_ArID.Name = "Tb_ArID";
            Tb_ArID.Size = new Size(150, 23);
            Tb_ArID.TabIndex = 1;
            Tb_ArID.TextAlign = HorizontalAlignment.Right;
            // 
            // Tb_Start
            // 
            Tb_Start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tb_Start.Enabled = false;
            Tb_Start.Location = new Point(165, 38);
            Tb_Start.Margin = new Padding(5);
            Tb_Start.Name = "Tb_Start";
            Tb_Start.Size = new Size(150, 23);
            Tb_Start.TabIndex = 3;
            Tb_Start.TextAlign = HorizontalAlignment.Right;
            // 
            // La_Start
            // 
            La_Start.Location = new Point(5, 38);
            La_Start.Margin = new Padding(5);
            La_Start.Name = "La_Start";
            La_Start.Size = new Size(150, 23);
            La_Start.TabIndex = 2;
            La_Start.Text = "Start Zeit/Datum";
            La_Start.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TB_Ende
            // 
            TB_Ende.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TB_Ende.Enabled = false;
            TB_Ende.Location = new Point(165, 72);
            TB_Ende.Margin = new Padding(5);
            TB_Ende.Name = "TB_Ende";
            TB_Ende.Size = new Size(150, 23);
            TB_Ende.TabIndex = 5;
            // 
            // Lb_Ende
            // 
            Lb_Ende.Location = new Point(5, 71);
            Lb_Ende.Margin = new Padding(5);
            Lb_Ende.Name = "Lb_Ende";
            Lb_Ende.Size = new Size(150, 23);
            Lb_Ende.TabIndex = 4;
            Lb_Ende.Text = "Ende Zeit/Datum";
            Lb_Ende.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Tb_Pause
            // 
            Tb_Pause.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tb_Pause.Enabled = false;
            Tb_Pause.Location = new Point(165, 105);
            Tb_Pause.Margin = new Padding(5);
            Tb_Pause.Name = "Tb_Pause";
            Tb_Pause.Size = new Size(150, 23);
            Tb_Pause.TabIndex = 7;
            // 
            // Lb_Pause
            // 
            Lb_Pause.Location = new Point(5, 104);
            Lb_Pause.Margin = new Padding(5);
            Lb_Pause.Name = "Lb_Pause";
            Lb_Pause.Size = new Size(150, 23);
            Lb_Pause.TabIndex = 6;
            Lb_Pause.Text = "Pausenzeit (decimal)";
            Lb_Pause.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Tb_Worktime
            // 
            Tb_Worktime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Tb_Worktime.Enabled = false;
            Tb_Worktime.Location = new Point(165, 137);
            Tb_Worktime.Margin = new Padding(5);
            Tb_Worktime.Name = "Tb_Worktime";
            Tb_Worktime.Size = new Size(150, 23);
            Tb_Worktime.TabIndex = 9;
            Tb_Worktime.TextAlign = HorizontalAlignment.Right;
            // 
            // Lb_Worktime
            // 
            Lb_Worktime.Location = new Point(5, 137);
            Lb_Worktime.Margin = new Padding(5);
            Lb_Worktime.Name = "Lb_Worktime";
            Lb_Worktime.Size = new Size(150, 23);
            Lb_Worktime.TabIndex = 8;
            Lb_Worktime.Text = "Arbeitszeit";
            Lb_Worktime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Cmd_Cancel
            // 
            Cmd_Cancel.Location = new Point(215, 168);
            Cmd_Cancel.Name = "Cmd_Cancel";
            Cmd_Cancel.Size = new Size(100, 23);
            Cmd_Cancel.TabIndex = 10;
            Cmd_Cancel.Text = "Abbrechen";
            Cmd_Cancel.UseVisualStyleBackColor = true;
            Cmd_Cancel.Click += Cmd_Cancel_Click;
            // 
            // Cmd_Save
            // 
            Cmd_Save.Location = new Point(5, 168);
            Cmd_Save.Name = "Cmd_Save";
            Cmd_Save.Size = new Size(100, 23);
            Cmd_Save.TabIndex = 11;
            Cmd_Save.Text = "Speichern";
            Cmd_Save.UseVisualStyleBackColor = true;
            Cmd_Save.Click += Cmd_Save_Click;
            // 
            // ConWorkTime
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Cmd_Save);
            Controls.Add(Cmd_Cancel);
            Controls.Add(Tb_Worktime);
            Controls.Add(Lb_Worktime);
            Controls.Add(Tb_Pause);
            Controls.Add(Lb_Pause);
            Controls.Add(TB_Ende);
            Controls.Add(Lb_Ende);
            Controls.Add(Tb_Start);
            Controls.Add(La_Start);
            Controls.Add(Tb_ArID);
            Controls.Add(La_ArID);
            Name = "ConWorkTime";
            Size = new Size(320, 198);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label La_ArID;
        private TextBox Tb_ArID;
        private TextBox Tb_Start;
        private Label La_Start;
        private TextBox TB_Ende;
        private Label Lb_Ende;
        private TextBox Tb_Pause;
        private Label Lb_Pause;
        private TextBox Tb_Worktime;
        private Label Lb_Worktime;
        private Button Cmd_Cancel;
        private Button Cmd_Save;
    }
}
