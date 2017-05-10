namespace GestionXML
{
    partial class InstalarLicencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstalarLicencias));
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txt_entidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewLicencias = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_licencias_asignadas = new System.Windows.Forms.TextBox();
            this.txt_disponibles = new System.Windows.Forms.TextBox();
            this.txt_cantidad_licencias = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicencias)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.Location = new System.Drawing.Point(456, 259);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 82);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpiar.Location = new System.Drawing.Point(338, 259);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 82);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(220, 259);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 82);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txt_entidad
            // 
            this.txt_entidad.Location = new System.Drawing.Point(198, 60);
            this.txt_entidad.Name = "txt_entidad";
            this.txt_entidad.Size = new System.Drawing.Size(541, 22);
            this.txt_entidad.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Entidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Licencias Compradas:";
            // 
            // dataGridViewLicencias
            // 
            this.dataGridViewLicencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLicencias.Location = new System.Drawing.Point(69, 408);
            this.dataGridViewLicencias.Name = "dataGridViewLicencias";
            this.dataGridViewLicencias.RowTemplate.Height = 24;
            this.dataGridViewLicencias.Size = new System.Drawing.Size(667, 204);
            this.dataGridViewLicencias.TabIndex = 24;
            this.dataGridViewLicencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLicencias_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Licencias Disponibles:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Licencias Asignadas:";
            // 
            // txt_licencias_asignadas
            // 
            this.txt_licencias_asignadas.Location = new System.Drawing.Point(198, 211);
            this.txt_licencias_asignadas.Name = "txt_licencias_asignadas";
            this.txt_licencias_asignadas.Size = new System.Drawing.Size(179, 22);
            this.txt_licencias_asignadas.TabIndex = 28;
            // 
            // txt_disponibles
            // 
            this.txt_disponibles.Location = new System.Drawing.Point(198, 159);
            this.txt_disponibles.Name = "txt_disponibles";
            this.txt_disponibles.Size = new System.Drawing.Size(179, 22);
            this.txt_disponibles.TabIndex = 26;
            // 
            // txt_cantidad_licencias
            // 
            this.txt_cantidad_licencias.Location = new System.Drawing.Point(198, 113);
            this.txt_cantidad_licencias.Name = "txt_cantidad_licencias";
            this.txt_cantidad_licencias.Size = new System.Drawing.Size(179, 22);
            this.txt_cantidad_licencias.TabIndex = 19;
            // 
            // InstalarLicencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 651);
            this.Controls.Add(this.txt_licencias_asignadas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_disponibles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewLicencias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_cantidad_licencias);
            this.Controls.Add(this.txt_entidad);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "InstalarLicencias";
            this.Text = "InstalarLicencias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstalarLicencias_FormClosing);
            this.Load += new System.EventHandler(this.InstalarLicencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txt_entidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewLicencias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_licencias_asignadas;
        private System.Windows.Forms.TextBox txt_disponibles;
        private System.Windows.Forms.TextBox txt_cantidad_licencias;
    }
}