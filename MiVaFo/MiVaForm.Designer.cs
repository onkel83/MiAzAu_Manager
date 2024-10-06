namespace MiVaFo
{
    partial class MiVaForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CW_Main = new ConWorker();
            MeStMiVa = new MenuStrip();
            TSMI_Dati = new ToolStripMenuItem();
            TSMC_Load = new ToolStripMenuItem();
            TSMC_Save = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            TSMC_Beenden = new ToolStripMenuItem();
            TSMC_Worker = new ToolStripMenuItem();
            TSMC_Add = new ToolStripMenuItem();
            TSMC_Update = new ToolStripMenuItem();
            TSMC_Delete = new ToolStripMenuItem();
            TSMC_Info = new ToolStripMenuItem();
            conWL_Main = new ConWorkerList();
            MeStMiVa.SuspendLayout();
            SuspendLayout();
            // 
            // CW_Main
            // 
            CW_Main.Location = new Point(270, 173);
            CW_Main.Margin = new Padding(5);
            CW_Main.Name = "CW_Main";
            CW_Main.Size = new Size(215, 145);
            CW_Main.TabIndex = 0;
            // 
            // MeStMiVa
            // 
            MeStMiVa.Items.AddRange(new ToolStripItem[] { TSMI_Dati, TSMC_Worker, TSMC_Info });
            MeStMiVa.Location = new Point(0, 0);
            MeStMiVa.Name = "MeStMiVa";
            MeStMiVa.Size = new Size(494, 24);
            MeStMiVa.TabIndex = 2;
            // 
            // TSMI_Dati
            // 
            TSMI_Dati.DropDownItems.AddRange(new ToolStripItem[] { TSMC_Load, TSMC_Save, toolStripSeparator1, TSMC_Beenden });
            TSMI_Dati.Name = "TSMI_Dati";
            TSMI_Dati.Size = new Size(46, 20);
            TSMI_Dati.Text = "Datei";
            // 
            // TSMC_Load
            // 
            TSMC_Load.Name = "TSMC_Load";
            TSMC_Load.Size = new Size(126, 22);
            TSMC_Load.Text = "Laden";
            TSMC_Load.Click += TSMC_Load_Click;
            // 
            // TSMC_Save
            // 
            TSMC_Save.Name = "TSMC_Save";
            TSMC_Save.Size = new Size(126, 22);
            TSMC_Save.Text = "Speichern";
            TSMC_Save.Click += TSMC_Save_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(123, 6);
            // 
            // TSMC_Beenden
            // 
            TSMC_Beenden.Name = "TSMC_Beenden";
            TSMC_Beenden.Size = new Size(126, 22);
            TSMC_Beenden.Text = "Beenden";
            TSMC_Beenden.Click += TSMC_Beenden_Click;
            // 
            // TSMC_Worker
            // 
            TSMC_Worker.DropDownItems.AddRange(new ToolStripItem[] { TSMC_Add, TSMC_Update, TSMC_Delete });
            TSMC_Worker.Name = "TSMC_Worker";
            TSMC_Worker.Size = new Size(77, 20);
            TSMC_Worker.Text = "Mitarbeiter";
            // 
            // TSMC_Add
            // 
            TSMC_Add.Name = "TSMC_Add";
            TSMC_Add.Size = new Size(130, 22);
            TSMC_Add.Text = "Neu";
            TSMC_Add.Click += TSMC_Add_Click;
            // 
            // TSMC_Update
            // 
            TSMC_Update.Name = "TSMC_Update";
            TSMC_Update.Size = new Size(130, 22);
            TSMC_Update.Text = "Bearbeiten";
            TSMC_Update.Click += TSMC_Update_Click;
            // 
            // TSMC_Delete
            // 
            TSMC_Delete.Name = "TSMC_Delete";
            TSMC_Delete.Size = new Size(130, 22);
            TSMC_Delete.Text = "Löschen";
            TSMC_Delete.Click += TSMC_Delete_Click;
            // 
            // TSMC_Info
            // 
            TSMC_Info.Name = "TSMC_Info";
            TSMC_Info.Size = new Size(82, 20);
            TSMC_Info.Text = "Information";
            TSMC_Info.Click += TSMC_Info_Click;
            // 
            // conWL_Main
            // 
            conWL_Main.Location = new Point(0, 27);
            conWL_Main.Name = "conWL_Main";
            conWL_Main.Size = new Size(250, 291);
            conWL_Main.TabIndex = 3;
            // 
            // MiVaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 331);
            ControlBox = false;
            Controls.Add(conWL_Main);
            Controls.Add(CW_Main);
            Controls.Add(MeStMiVa);
            MainMenuStrip = MeStMiVa;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "MiVaForm";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            MeStMiVa.ResumeLayout(false);
            MeStMiVa.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ConWorker CW_Main;
        private MenuStrip MeStMiVa;
        private ToolStripMenuItem TSMI_Dati;
        private ToolStripMenuItem TSMC_Worker;
        private ToolStripMenuItem TSMC_Info;
        private ToolStripMenuItem TSMC_Load;
        private ToolStripMenuItem TSMC_Save;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem TSMC_Beenden;
        private ToolStripMenuItem TSMC_Add;
        private ToolStripMenuItem TSMC_Update;
        private ToolStripMenuItem TSMC_Delete;
        private ConWorkerList conWL_Main;
    }
}
