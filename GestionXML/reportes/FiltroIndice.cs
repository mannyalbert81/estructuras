using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionXML.reportes
{
    public partial class FiltroIndice : Form
    {



        public FiltroIndice()
        {
            InitializeComponent();
        }

        private void FiltroIndice_Load(object sender, EventArgs e)
     

        {

            
            clases.Funciones.CargarCombo(cbm_proyectos, "id_proyectos", "nombre_proyectos", "proyectos");

            int _id_proyectos = Convert.ToInt32(cbm_proyectos.SelectedValue.ToString());
            
            clases.Funciones.CargarComboWhere(cmb_Caminos, "id_caminos", "nombre_caminos", "public.proyectos, public.caminos", "caminos.id_proyectos = proyectos.id_proyectos AND proyectos.id_proyectos = '" + _id_proyectos + "' ");


        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            int _id_proyectos = Convert.ToInt32(cbm_proyectos.SelectedValue.ToString());
            int _id_caminos = Convert.ToInt32(cmb_Caminos.SelectedValue.ToString());

            DataTable daIndice = AccesoLogica.Select("caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, proyectos.id_proyectos, proyectos.nombre_proyectos, proyectos.observaciones_proyectos, indice_cabeza.id_indice_cabeza, indice_cabeza.nombre_indice_cabeza, indice_detalle.id_indice_detalle, tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, indice_detalle.nombre_indice_detalle, indice_detalle.min_indice_detalle, indice_detalle.max_indice_detalle, indice_detalle.orden_indice_detalle ", "public.proyectos, public.caminos, public.indice_cabeza, public.indice_detalle, public.tipo_indice", "caminos.id_proyectos = proyectos.id_proyectos AND indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND   proyectos.id_proyectos = '" + _id_proyectos + "' AND caminos.id_caminos = '" + _id_caminos + "' ");
            int registro = daIndice.Rows.Count;

            if (registro > 0)
            {
                reportes.contIndice frm = new reportes.contIndice();
                frm._id_proyectos = _id_proyectos;
                frm._id_caminos = _id_caminos;
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            

        }

        private void cbm_proyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_proyectos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        

        private void cmb_Caminos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_Caminos.DropDownStyle = ComboBoxStyle.DropDownList;
            int _id_proyectos = Convert.ToInt32(cbm_proyectos.SelectedValue.ToString());

            clases.Funciones.CargarComboWhere(cmb_Caminos, "id_caminos", "nombre_caminos", "public.proyectos, public.caminos", "caminos.id_proyectos = proyectos.id_proyectos AND proyectos.id_proyectos = '" + _id_proyectos + "' ");

           
        }
    }
}
