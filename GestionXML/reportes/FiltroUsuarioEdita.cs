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
    public partial class FiltroUsuarioEdita : Form
    {
        public FiltroUsuarioEdita()
        {
            InitializeComponent();
        }
        private void FiltroUsuarioEdita_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_usuario, "id_usuarios", "nombre_usuarios", "usuarios");
        }
        private void cbm_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_usuario.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _id_usuario = Convert.ToInt32(cbm_usuario.SelectedValue.ToString());
            DateTime _inicio = dateTimePicker1.Value;
            DateTime _final = dateTimePicker2.Value;

            DataTable daUsuarioEdita = AccesoLogica.Select("produccion_detalle.id_produccion_detalle, produccion_cabeza.id_produccion_cabeza, produccion_cabeza.xml_editados_produccion_cabeza, caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, proyectos.id_proyectos, proyectos.nombre_proyectos, produccion_detalle.nombre_produccion_detalle, produccion_detalle.inicio_produccion_detalle, produccion_detalle.fin_produccion_detalle, usuarios.id_usuarios, usuarios.nombre_usuarios, usuarios.telefono_usuarios, produccion_detalle.creado, produccion_detalle.modificado", "  public.produccion_detalle, public.usuarios, public.produccion_cabeza, public.caminos, public.proyectos", "  produccion_detalle.id_produccion_cabeza = produccion_cabeza.id_produccion_cabeza AND usuarios.id_usuarios = produccion_detalle.id_usuarios_edita AND caminos.id_caminos = produccion_detalle.id_caminos AND proyectos.id_proyectos = caminos.id_proyectos AND usuarios.id_usuarios = '" + _id_usuario + "' AND produccion_detalle.modificado BETWEEN '" + _inicio + "' AND '" + _final + "'");
            int registro = daUsuarioEdita.Rows.Count;

            if (registro > 0)
            {
                if (_inicio > _final)
                {
                    MessageBox.Show("Fecha Inicio no puede ser Mayor a fecha final", "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                else
                {
                    reportes.contUsuariosEdita frm = new reportes.contUsuariosEdita();
                    frm._id_usuario = _id_usuario;
                    frm._inicio = _inicio;
                    frm._final = _final;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("No existe datos en el rango de fechas seleccionadas", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
