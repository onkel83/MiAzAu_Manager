namespace MiVaFo
{
    partial class ConWorTimeList
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
            Lb_WT = new ListBox();
            SuspendLayout();
            // 
            // Lb_WT
            // 
            Lb_WT.FormattingEnabled = true;
            Lb_WT.ItemHeight = 15;
            Lb_WT.Location = new Point(5, 5);
            Lb_WT.Margin = new Padding(5);
            Lb_WT.Name = "Lb_WT";
            Lb_WT.Size = new Size(250, 289);
            Lb_WT.TabIndex = 0;
            Lb_WT.SelectedIndexChanged += Lb_WT_SelectedIndexChanged;
            // 
            // ConWorTimeList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Lb_WT);
            Name = "ConWorTimeList";
            Size = new Size(260, 300);
            ResumeLayout(false);
        }

        #endregion

        private ListBox Lb_WT;
    }
}
