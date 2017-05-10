namespace GestionXML.reportes
{
    partial class contProyectos
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
            this.ReportViewerProyectos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportViewerProyectos
            // 
            this.ReportViewerProyectos.ActiveViewIndex = -1;
            this.ReportViewerProyectos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewerProyectos.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportViewerProyectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerProyectos.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerProyectos.Name = "ReportViewerProyectos";
            this.ReportViewerProyectos.Size = new System.Drawing.Size(901, 471);
            this.ReportViewerProyectos.TabIndex = 0;
            this.ReportViewerProyectos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.ReportViewerProyectos.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // contProyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 471);
            this.Controls.Add(this.ReportViewerProyectos);
            this.Name = "contProyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "conProyectos";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewerProyectos;
    }
}