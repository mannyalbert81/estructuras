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
using Npgsql;

namespace GestionXML
{
    public partial class frmAsignar : Form
    {
        public frmAsignar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_indice_cabeza = txt_nombre_indice.Text;
            string _nombre_campo_indice_detalle = txt_nombre_campo.Text;
            string _nombre_tabla_indice_detalle = txt_nombre_tabla.Text;
            int _id_indice_detalle = Convert.ToInt16(cbm_caminos.SelectedValue.ToString());
           

            if (_nombre_indice_cabeza.Length == 0)
            {
                _error = "Debe Indicar un Indice";
            }
            if (_nombre_campo_indice_detalle.Length == 0)
            {
                _error = "Debe Indicar un Nombre Campo";
            }
            if (_nombre_tabla_indice_detalle.Length == 0)
            {
                _error = "Debe Indicar un Nombre Tabla";
            }
            if (_id_indice_detalle < 0)
            {
                _error = "Debe Seleccionar un Detalle";
            }

            if (_error.Length == 0)
            {
               

                try
                {
                    int resul = AccesoLogica.Update("indice_detalle", "relacionado_indice_detalle = 'true', nombre_campo_indice_detalle = '" + _nombre_campo_indice_detalle + "', nombre_tabla_indice_detalle = '" + _nombre_tabla_indice_detalle + "'", "indice_detalle.id_indice_detalle= '" + _id_indice_detalle + "'");
                    
                        MessageBox.Show("El registro se a Asignado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       clases.Funciones.CargarComboWhere(cbm_caminos, "indice_detalle.id_indice_detalle", "nombre_indice_detalle", "public.indice_cabeza, public.indice_detalle, public.tipo_indice", "indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.relacionado_indice_detalle = 'false' AND indice_detalle.id_indice_detalle<0");

                    limpiar();
                        


                }
                catch (NpgsqlException)
                {
                    MessageBox.Show("No se Pudo Guardar el registro en la Base de Datos", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAsignar_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            cbm_caminos.Enabled = false;
        }

        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewAsignar, "indice_detalle.id_indice_detalle AS Id, tipo_indice.nombre_tipo_indice, indice_detalle.nombre_indice_detalle, indice_detalle.min_indice_detalle, indice_detalle.max_indice_detalle, indice_detalle.orden_indice_detalle", "public.indice_cabeza, public.indice_detalle, public.tipo_indice", _parametro, "Id?Tipo Indice?Nombre?Minimo?Maximo?Orden");

        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string _error = "";
            if (txt_nombre_indice.Text.Length == 0)
            {
                _error = "EL nombre indice no puede estar vacio.";
            }
            if (_error.Length == 0)
            {

             
               string _nombre_indice_cabeza = txt_nombre_indice.Text;

           

                string columnas1 = "indice_detalle.id_indice_detalle, tipo_indice.nombre_tipo_indice, indice_detalle.nombre_indice_detalle, indice_detalle.min_indice_detalle, indice_detalle.max_indice_detalle, indice_detalle.orden_indice_detalle";
                string tablas = "public.indice_cabeza, public.indice_detalle, public.tipo_indice";
                string where = "indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.relacionado_indice_detalle = 'false' AND indice_cabeza.nombre_indice_cabeza LIKE '" + _nombre_indice_cabeza + "'";


                DataTable dtDetalle = AccesoLogica.Select(columnas1, tablas, where);
                int registros = dtDetalle.Rows.Count;
                if (registros <= 0)
                {

                    MessageBox.Show("No existen registros para Asignar", "Busqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    llenar_grid("indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.relacionado_indice_detalle = 'false' AND indice_cabeza.nombre_indice_cabeza LIKE '" + _nombre_indice_cabeza + "'");
                    clases.Funciones.CargarComboWhere(cbm_caminos, "indice_detalle.id_indice_detalle", "nombre_indice_detalle", "public.indice_cabeza, public.indice_detalle, public.tipo_indice", "indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.relacionado_indice_detalle = 'false' AND indice_cabeza.nombre_indice_cabeza LIKE '" + _nombre_indice_cabeza + "'");
                    btnGuardar.Enabled = true;
                    cbm_caminos.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
           

            limpiar();

        }

        public void limpiar()
        {

            txt_nombre_indice.Text = "";
            txt_nombre_campo.Text = "";
            txt_nombre_tabla.Text = "";
            cbm_caminos.DataSource = null;
            cbm_caminos.Enabled = false;
            llenar_grid("indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.id_indice_detalle<0");
            btnGuardar.Enabled = false;
           
        }


        

        private void frmAsignar_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?",
              "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
