using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace GestionXML.reportes
{
    public partial class FiltroUsuarios : Form
    {
        public FiltroUsuarios()
        {
            InitializeComponent();
        }

        private void FiltroProduccion_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_usuarios, "id_usuarios", "nombre_usuarios", "usuarios");
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _id_usuario = Convert.ToInt32(cbm_usuarios.SelectedValue.ToString());
            DateTime _inicio = dateTimePicker1.Value;
            DateTime _final = dateTimePicker2.Value;

            DataTable daProduccion = AccesoLogica.Select("  produccion_detalle.id_produccion_detalle, produccion_detalle.nombre_produccion_detalle, produccion_detalle.inicio_produccion_detalle, produccion_detalle.fin_produccion_detalle, usuarios.id_usuarios, usuarios.nombre_usuarios, caminos.id_caminos, caminos.nombre_caminos, produccion_detalle.creado, produccion_detalle.modificado ", " public.produccion_detalle, public.usuarios, public.caminos", " usuarios.id_usuarios = produccion_detalle.id_usuarios_crea AND caminos.id_caminos = produccion_detalle.id_caminos AND usuarios.id_usuarios = '" + _id_usuario + "' AND produccion_detalle.creado BETWEEN '" + _inicio + "' AND '" + _final + "'");
             int registro = daProduccion.Rows.Count;

            if (registro > 0)
            {
                if (_inicio > _final)
                {
                    MessageBox.Show("Fecha Inicio no puede ser Mayor a fecha final", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    reportes.contProduccion frm = new reportes.contProduccion();
                    frm._id_usuario = _id_usuario;
                    frm._inicio = _inicio;
                    frm._final = _final;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbm_usuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_usuarios.DropDownStyle = ComboBoxStyle.DropDownList;
        }

       
    }
}
