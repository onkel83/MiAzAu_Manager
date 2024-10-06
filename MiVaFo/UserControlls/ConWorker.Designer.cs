namespace MiVaFo
{
    partial class ConWorker
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
            LbID = new Label();
            TBID = new TextBox();
            TBVorname = new TextBox();
            LbVorname = new Label();
            TBNachname = new TextBox();
            lbNachname = new Label();
            CmdSave = new Button();
            CmdCancel = new Button();
            statusStrip1 = new StatusStrip();
            TSSLName = new ToolStripStatusLabel();
            TSSTBName = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // LbID
            // 
            LbID.BorderStyle = BorderStyle.FixedSingle;
            LbID.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbID.Location = new Point(5, 5);
            LbID.Margin = new Padding(5);
            LbID.Name = "LbID";
            LbID.Size = new Size(100, 20);
            LbID.TabIndex = 0;
            LbID.Text = "Mitarbeiter ID: ";
            // 
            // TBID
            // 
            TBID.Enabled = false;
            TBID.Location = new Point(110, 5);
            TBID.Name = "TBID";
            TBID.Size = new Size(100, 23);
            TBID.TabIndex = 1;
            TBID.Text = "000000";
            TBID.TextAlign = HorizontalAlignment.Right;
            // 
            // TBVorname
            // 
            TBVorname.Enabled = false;
            TBVorname.Location = new Point(112, 34);
            TBVorname.Name = "TBVorname";
            TBVorname.Size = new Size(100, 23);
            TBVorname.TabIndex = 3;
            TBVorname.TextAlign = HorizontalAlignment.Right;
            // 
            // LbVorname
            // 
            LbVorname.BorderStyle = BorderStyle.FixedSingle;
            LbVorname.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbVorname.Location = new Point(7, 34);
            LbVorname.Margin = new Padding(5);
            LbVorname.Name = "LbVorname";
            LbVorname.Size = new Size(100, 20);
            LbVorname.TabIndex = 2;
            LbVorname.Text = "Vorname :";
            // 
            // TBNachname
            // 
            TBNachname.Enabled = false;
            TBNachname.Location = new Point(110, 63);
            TBNachname.Name = "TBNachname";
            TBNachname.Size = new Size(100, 23);
            TBNachname.TabIndex = 5;
            TBNachname.TextAlign = HorizontalAlignment.Right;
            // 
            // lbNachname
            // 
            lbNachname.BorderStyle = BorderStyle.FixedSingle;
            lbNachname.Font = new Font("Palatino Linotype", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNachname.Location = new Point(5, 63);
            lbNachname.Margin = new Padding(5);
            lbNachname.Name = "lbNachname";
            lbNachname.Size = new Size(100, 20);
            lbNachname.TabIndex = 4;
            lbNachname.Text = "Nachname :";
            // 
            // CmdSave
            // 
            CmdSave.Enabled = false;
            CmdSave.Location = new Point(3, 91);
            CmdSave.Name = "CmdSave";
            CmdSave.Size = new Size(102, 23);
            CmdSave.TabIndex = 6;
            CmdSave.Text = "Speichern";
            CmdSave.UseVisualStyleBackColor = true;
            CmdSave.Click += CmdSave_Clicked;
            // 
            // CmdCancel
            // 
            CmdCancel.Enabled = false;
            CmdCancel.Location = new Point(110, 91);
            CmdCancel.Name = "CmdCancel";
            CmdCancel.Size = new Size(102, 23);
            CmdCancel.TabIndex = 7;
            CmdCancel.Text = "Abbrechen";
            CmdCancel.UseVisualStyleBackColor = true;
            CmdCancel.Click += CmdCancel_Clicked;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { TSSLName, TSSTBName });
            statusStrip1.Location = new Point(0, 122);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(215, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // TSSLName
            // 
            TSSLName.Name = "TSSLName";
            TSSLName.Size = new Size(45, 17);
            TSSLName.Text = "Name :";
            // 
            // TSSTBName
            // 
            TSSTBName.Name = "TSSTBName";
            TSSTBName.Size = new Size(0, 17);
            // 
            // ConWorker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(statusStrip1);
            Controls.Add(CmdCancel);
            Controls.Add(CmdSave);
            Controls.Add(TBNachname);
            Controls.Add(lbNachname);
            Controls.Add(TBVorname);
            Controls.Add(LbVorname);
            Controls.Add(TBID);
            Controls.Add(LbID);
            Margin = new Padding(5);
            Name = "ConWorker";
            Size = new Size(215, 144);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbID;
        private TextBox TBID;
        private TextBox TBVorname;
        private Label LbVorname;
        private TextBox TBNachname;
        private Label lbNachname;
        private Button CmdSave;
        private Button CmdCancel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel TSSLName;
        private ToolStripStatusLabel TSSTBName;
    }
}
