namespace GestionXML.reportes
{
    partial class contCartonDocumentos
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
            this.ReportViewerCartonDocumentos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewerCartonDocumentos
            // 
            this.ReportViewerCartonDocumentos.ActiveViewIndex = -1;
            this.ReportViewerCartonDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerCartonDocumentos.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerCartonDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerCartonDocumentos.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerCartonDocumentos.Name = "ReportViewerCartonDocumentos";
            this.ReportViewerCartonDocumentos.Size = new System.Drawing.Size(876, 415);
            this.ReportViewerCartonDocumentos.TabIndex = 0;
            this.ReportViewerCartonDocumentos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ReportViewerCartonDocumentos.Load += new System.EventHandler(this.ReportViewerCartonDocumentos_Load);
            // 
            // contCartonDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 415);
            this.Controls.Add(this.ReportViewerCartonDocumentos);
            this.Name = "contCartonDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "contCartonDocumentos";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerCartonDocumentos;
    }
}