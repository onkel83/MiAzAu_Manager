namespace MiVaFo
{
    partial class ArVaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConWT_Main = new ConWorTimeList();
            menuStrip1 = new MenuStrip();
            TSMC_File = new ToolStripMenuItem();
            TSMC_File_Save = new ToolStripMenuItem();
            TSMC_File_Load = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            TSMC_File_Close = new ToolStripMenuItem();
            TSMC_WT = new ToolStripMenuItem();
            TSMC_WT_Add = new ToolStripMenuItem();
            TSMC_WT_Update = new ToolStripMenuItem();
            TSMC_WT_Delete = new ToolStripMenuItem();
            mitarbeiterHinzufügenToolStripMenuItem = new ToolStripMenuItem();
            mitarbeiterLöschenToolStripMenuItem = new ToolStripMenuItem();
            TSMC_About = new ToolStripMenuItem();
            Con_WT_Details = new ConWorkTime();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ConWT_Main
            // 
            ConWT_Main.Location = new Point(10, 30);
            ConWT_Main.Margin = new Padding(5);
            ConWT_Main.Name = "ConWT_Main";
            ConWT_Main.Size = new Size(260, 300);
            ConWT_Main.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { TSMC_File, TSMC_WT, TSMC_About });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(617, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // TSMC_File
            // 
            TSMC_File.DropDownItems.AddRange(new ToolStripItem[] { TSMC_File_Save, TSMC_File_Load, toolStripSeparator1, TSMC_File_Close });
            TSMC_File.Name = "TSMC_File";
            TSMC_File.Size = new Size(37, 20);
            TSMC_File.Text = "File";
            // 
            // TSMC_File_Save
            // 
            TSMC_File_Save.Name = "TSMC_File_Save";
            TSMC_File_Save.Size = new Size(120, 22);
            TSMC_File_Save.Text = "Save";
            TSMC_File_Save.Click += TSMC_File_Save_Click;
            // 
            // TSMC_File_Load
            // 
            TSMC_File_Load.Name = "TSMC_File_Load";
            TSMC_File_Load.Size = new Size(120, 22);
            TSMC_File_Load.Text = "Load";
            TSMC_File_Load.Click += TSMC_File_Load_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(117, 6);
            // 
            // TSMC_File_Close
            // 
            TSMC_File_Close.Name = "TSMC_File_Close";
            TSMC_File_Close.Size = new Size(120, 22);
            TSMC_File_Close.Text = "Beenden";
            TSMC_File_Close.Click += TSMC_File_Close_Click;
            // 
            // TSMC_WT
            // 
            TSMC_WT.DropDownItems.AddRange(new ToolStripItem[] { TSMC_WT_Add, TSMC_WT_Update, TSMC_WT_Delete, mitarbeiterHinzufügenToolStripMenuItem, mitarbeiterLöschenToolStripMenuItem });
            TSMC_WT.Name = "TSMC_WT";
            TSMC_WT.Size = new Size(71, 20);
            TSMC_WT.Text = "Worktime";
            // 
            // TSMC_WT_Add
            // 
            TSMC_WT_Add.Name = "TSMC_WT_Add";
            TSMC_WT_Add.Size = new Size(195, 22);
            TSMC_WT_Add.Text = "Add";
            TSMC_WT_Add.Click += TSMC_WT_Add_Click;
            // 
            // TSMC_WT_Update
            // 
            TSMC_WT_Update.Name = "TSMC_WT_Update";
            TSMC_WT_Update.Size = new Size(195, 22);
            TSMC_WT_Update.Text = "Update";
            TSMC_WT_Update.Click += TSMC_WT_Update_Click;
            // 
            // TSMC_WT_Delete
            // 
            TSMC_WT_Delete.Name = "TSMC_WT_Delete";
            TSMC_WT_Delete.Size = new Size(195, 22);
            TSMC_WT_Delete.Text = "Delete";
            TSMC_WT_Delete.Click += TSMC_WT_Delete_Click;
            // 
            // mitarbeiterHinzufügenToolStripMenuItem
            // 
            mitarbeiterHinzufügenToolStripMenuItem.Name = "mitarbeiterHinzufügenToolStripMenuItem";
            mitarbeiterHinzufügenToolStripMenuItem.Size = new Size(195, 22);
            mitarbeiterHinzufügenToolStripMenuItem.Text = "Mitarbeiter hinzufügen";
            // 
            // mitarbeiterLöschenToolStripMenuItem
            // 
            mitarbeiterLöschenToolStripMenuItem.Name = "mitarbeiterLöschenToolStripMenuItem";
            mitarbeiterLöschenToolStripMenuItem.Size = new Size(195, 22);
            mitarbeiterLöschenToolStripMenuItem.Text = "Mitarbeiter Löschen";
            // 
            // TSMC_About
            // 
            TSMC_About.Name = "TSMC_About";
            TSMC_About.Size = new Size(52, 20);
            TSMC_About.Text = "About";
            TSMC_About.Click += TSMC_About_Click;
            // 
            // Con_WT_Details
            // 
            Con_WT_Details.Location = new Point(278, 124);
            Con_WT_Details.Name = "Con_WT_Details";
            Con_WT_Details.Size = new Size(320, 198);
            Con_WT_Details.TabIndex = 3;
            // 
            // ArVaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 334);
            ControlBox = false;
            Controls.Add(Con_WT_Details);
            Controls.Add(ConWT_Main);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ArVaForm";
            ShowInTaskbar = false;
            Text = "ArVaForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ConWorTimeList ConWT_Main;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem TSMC_File;
        private ToolStripMenuItem TSMC_File_Save;
        private ToolStripMenuItem TSMC_File_Load;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem TSMC_File_Close;
        private ToolStripMenuItem TSMC_WT;
        private ToolStripMenuItem TSMC_About;
        private ToolStripMenuItem TSMC_WT_Add;
        private ToolStripMenuItem TSMC_WT_Update;
        private ToolStripMenuItem TSMC_WT_Delete;
        private ToolStripMenuItem mitarbeiterHinzufügenToolStripMenuItem;
        private ToolStripMenuItem mitarbeiterLöschenToolStripMenuItem;
        private ConWorkTime Con_WT_Details;
    }
}