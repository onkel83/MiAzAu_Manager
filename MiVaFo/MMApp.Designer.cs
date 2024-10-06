namespace MiVaFo
{
    partial class MMApp
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
            Cmd_MiVa = new Button();
            Cmd_ArVa = new Button();
            Cmd_Close = new Button();
            SuspendLayout();
            // 
            // Cmd_MiVa
            // 
            Cmd_MiVa.Location = new Point(12, 12);
            Cmd_MiVa.Name = "Cmd_MiVa";
            Cmd_MiVa.Size = new Size(170, 25);
            Cmd_MiVa.TabIndex = 0;
            Cmd_MiVa.Text = "Mitarbeiter Verwaltung";
            Cmd_MiVa.UseVisualStyleBackColor = true;
            Cmd_MiVa.Click += Cmd_MiVa_Click;
            // 
            // Cmd_ArVa
            // 
            Cmd_ArVa.Location = new Point(12, 43);
            Cmd_ArVa.Name = "Cmd_ArVa";
            Cmd_ArVa.Size = new Size(170, 25);
            Cmd_ArVa.TabIndex = 1;
            Cmd_ArVa.Text = "Arbeitszeit Verwaltung";
            Cmd_ArVa.UseVisualStyleBackColor = true;
            Cmd_ArVa.Click += Cmd_ArVa_Click;
            // 
            // Cmd_Close
            // 
            Cmd_Close.Location = new Point(12, 95);
            Cmd_Close.Name = "Cmd_Close";
            Cmd_Close.Size = new Size(170, 25);
            Cmd_Close.TabIndex = 2;
            Cmd_Close.Text = "Beenden";
            Cmd_Close.UseVisualStyleBackColor = true;
            Cmd_Close.Click += Cmd_Close_Click;
            // 
            // MMApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(192, 127);
            ControlBox = false;
            Controls.Add(Cmd_Close);
            Controls.Add(Cmd_ArVa);
            Controls.Add(Cmd_MiVa);
            Name = "MMApp";
            Text = "MMApp";
            ResumeLayout(false);
        }

        #endregion

        private Button Cmd_MiVa;
        private Button Cmd_ArVa;
        private Button Cmd_Close;
    }
}