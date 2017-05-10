namespace GestionXML.reportes
{
    partial class contEstado
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
            this.ReportViewerEstado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewerEstado
            // 
            this.ReportViewerEstado.ActiveViewIndex = -1;
            this.ReportViewerEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerEstado.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerEstado.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerEstado.Name = "ReportViewerEstado";
            this.ReportViewerEstado.Size = new System.Drawing.Size(906, 375);
            this.ReportViewerEstado.TabIndex = 0;
            this.ReportViewerEstado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ReportViewerEstado.Load += new System.EventHandler(this.ReportViewerEstado_Load);
            // 
            // contEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 375);
            this.Controls.Add(this.ReportViewerEstado);
            this.Name = "contEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "contEstado";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerEstado;
    }
}