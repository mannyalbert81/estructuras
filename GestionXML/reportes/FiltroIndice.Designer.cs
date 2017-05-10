namespace GestionXML.reportes
{
    partial class FiltroIndice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroIndice));
            this.label1 = new System.Windows.Forms.Label();
            this.cbm_proyectos = new System.Windows.Forms.ComboBox();
            this.cmb_Caminos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Proyectos:";
            // 
            // cbm_proyectos
            // 
            this.cbm_proyectos.FormattingEnabled = true;
            this.cbm_proyectos.Location = new System.Drawing.Point(181, 53);
            this.cbm_proyectos.Name = "cbm_proyectos";
            this.cbm_proyectos.Size = new System.Drawing.Size(157, 21);
            this.cbm_proyectos.TabIndex = 1;
            this.cbm_proyectos.SelectedIndexChanged += new System.EventHandler(this.cbm_proyectos_SelectedIndexChanged);
            // 
            // cmb_Caminos
            // 
            this.cmb_Caminos.FormattingEnabled = true;
            this.cmb_Caminos.Location = new System.Drawing.Point(181, 98);
            this.cmb_Caminos.Name = "cmb_Caminos";
            this.cmb_Caminos.Size = new System.Drawing.Size(157, 21);
            this.cmb_Caminos.TabIndex = 2;
            this.cmb_Caminos.SelectedIndexChanged += new System.EventHandler(this.cmb_Caminos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Subcategoría:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::GestionXML.Properties.Resources.firma_del_contrato;
            this.button1.Location = new System.Drawing.Point(200, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 68);
            this.button1.TabIndex = 3;
            this.button1.Text = "Generar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FiltroIndice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Caminos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbm_proyectos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FiltroIndice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FiltroIndice";
            this.Load += new System.EventHandler(this.FiltroIndice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbm_proyectos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_Caminos;
        private System.Windows.Forms.Label label2;
    }
}