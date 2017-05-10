namespace GestionXML.reportes
{
    partial class contIndice
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
            this.ReportViewerIndice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewerIndice
            // 
            this.ReportViewerIndice.ActiveViewIndex = -1;
            this.ReportViewerIndice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerIndice.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerIndice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerIndice.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerIndice.Name = "ReportViewerIndice";
            this.ReportViewerIndice.Size = new System.Drawing.Size(971, 447);
            this.ReportViewerIndice.TabIndex = 0;
            this.ReportViewerIndice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ReportViewerIndice.Load += new System.EventHandler(this.ReportViewerIndice_Load);
            // 
            // contIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 447);
            this.Controls.Add(this.ReportViewerIndice);
            this.Name = "contIndice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "contIndice";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerIndice;
    }
}