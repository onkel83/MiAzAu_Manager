namespace MiVaFo
{
    partial class ConWorkerList
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
            LiBoWorker = new ListBox();
            toolStrip1 = new ToolStrip();
            TSSL_LastLabel = new ToolStripLabel();
            TSSL_Last = new ToolStripLabel();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // LiBoWorker
            // 
            LiBoWorker.FormattingEnabled = true;
            LiBoWorker.ItemHeight = 15;
            LiBoWorker.Location = new Point(3, 3);
            LiBoWorker.Name = "LiBoWorker";
            LiBoWorker.Size = new Size(244, 304);
            LiBoWorker.TabIndex = 0;
            LiBoWorker.SelectedIndexChanged += LiBoWorker_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { TSSL_LastLabel, TSSL_Last, toolStripSeparator1 });
            toolStrip1.Location = new Point(3, 316);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(293, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // TSSL_LastLabel
            // 
            TSSL_LastLabel.AutoSize = false;
            TSSL_LastLabel.Name = "TSSL_LastLabel";
            TSSL_LastLabel.Size = new Size(100, 22);
            TSSL_LastLabel.Text = "Auswahl : ";
            TSSL_LastLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TSSL_Last
            // 
            TSSL_Last.Alignment = ToolStripItemAlignment.Right;
            TSSL_Last.AutoSize = false;
            TSSL_Last.Name = "TSSL_Last";
            TSSL_Last.Size = new Size(100, 22);
            TSSL_Last.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.AutoSize = false;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(50, 25);
            // 
            // ConWorkerList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip1);
            Controls.Add(LiBoWorker);
            Name = "ConWorkerList";
            Size = new Size(250, 341);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LiBoWorker;
        private ToolStrip toolStrip1;
        private ToolStripLabel TSSL_LastLabel;
        private ToolStripLabel TSSL_Last;
        private ToolStripSeparator toolStripSeparator1;
    }
}
