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
    public partial class frmControladores : Form
    {
        public frmControladores()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_controladores = txt_controladores.Text;
            string _descripcion_controladores = txt_descripcion_controladores.Text;
            string _orden_controladores = cmb_orden_controladores.Text;
            string _nivel_controladores = cmb_nivel_controladores.Text;
            int _id_formulario = Convert.ToInt16(cbm_formulario.SelectedValue.ToString());



            if (_nombre_controladores.Length == 0)
            {
                _error = "Debe Indicar un nombre de Controladores";
            }

            if (_descripcion_controladores.Length == 0)
            {
                _error = "Debe Indicar una Descripción de Controladores";
            }

            if (_orden_controladores.Length == 0)
            {
                _error = "Debe Seleccionar un orden de controladores";
            }

            if (_nivel_controladores.Length == 0)
            {
                _error = "Debe Seleccionar un nivel de controladores";
            }
            if (_orden_controladores == "Seleccione ..")
            {
                _error = "Debe Seleccionar un orden de controladores";
            }

            if (_nivel_controladores == "Seleccione ..")
            {
                _error = "Debe Seleccionar un nivel de controladores";
            }





            if (_error.Length == 0)
            {
                string datos = _nombre_controladores + "?" +_descripcion_controladores + "?" + _orden_controladores + "?" + _nivel_controladores + "?" + _id_formulario;
                string columnas = "_nombre_controladores?_descripcion_controladores?_orden_controladores?_nivel_controladores?_id_formulario";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_controladores");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Controlador se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("formularios.id_formularios = controladores.id_formularios");

                        limpiar();


                    }
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

        private void frmControladores_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_formulario, "id_formularios", "nombre_formularios", "formularios");
            llenar_grid("formularios.id_formularios = controladores.id_formularios");
            llenar_combomanual();


        }

        private void llenar_combomanual()
        {

            int valor = 0;
            for (valor = 0; valor < 6; valor++)
            {
                if (valor == 0)
                {
                    cmb_nivel_controladores.Items.Insert(valor, "Seleccione ..");
                    cmb_orden_controladores.Items.Insert(valor, "Seleccione ..");
                }
                else
                {
                    cmb_nivel_controladores.Items.Insert(valor, valor);
                    cmb_orden_controladores.Items.Insert(valor, valor);
                }

            }
            cmb_nivel_controladores.SelectedIndex = 0;
            cmb_orden_controladores.SelectedIndex = 0;
        }



        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewControladores, "controladores.id_controladores AS Id, controladores.nombre_controladores, controladores.descripcion_controladores, controladores.orden_controladores, controladores.nivel_controladores, formularios.nombre_formularios, controladores.creado, controladores.modificado", "controladores, formularios", _parametro, "Id?Nombre Controlador?Descripcion Controlador?Orden?Nivel?Formulario?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_controladores.Text = "";
            txt_descripcion_controladores.Text = "";
            cmb_nivel_controladores.SelectedIndex = 0;
            cmb_orden_controladores.SelectedIndex = 0;


        }

        private void dataGridViewControladores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewControladores.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_controladores.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            txt_descripcion_controladores.Text = Convert.ToString(fila.Cells[2].Value);
            cmb_orden_controladores.Text = Convert.ToString(fila.Cells[3].Value);
            cmb_nivel_controladores.Text = Convert.ToString(fila.Cells[4].Value);
            cbm_formulario.Text = Convert.ToString(fila.Cells[5].Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _nombre_controladores = txt_controladores.Text;


            if (_nombre_controladores.Length == 0)
            {
                _nombre_controladores = "%";
            }


            llenar_grid("formularios.id_formularios = controladores.id_formularios AND controladores.nombre_controladores LIKE '" + _nombre_controladores + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_controladores.Text.Length == 0)
            {
                _error = "EL nombre controladores no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {

                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _controladores = txt_controladores.Text;
                    int resul = AccesoLogica.Delete("nombre_controladores = '" + _controladores + "' ", "controladores");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Controlador se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("formularios.id_formularios = controladores.id_formularios");
                        limpiar();
                    }
                }
                catch (NpgsqlException)
                {
                    MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
                else
                {
                   
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

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void frmControladores_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmb_orden_controladores_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}
