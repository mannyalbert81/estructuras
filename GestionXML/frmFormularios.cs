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
    public partial class frmFormularios : Form
    {
        public frmFormularios()
        {
            InitializeComponent();
        }

        private void frmFormularios_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_formulario = txt_nombre_formulario.Text;


            if (_nombre_formulario.Length == 0)
            {
                _error = "Debe Indicar un nombre de formulario";
            }



            if (_error.Length == 0)
            {
                string datos = _nombre_formulario;
                string columnas = "_nombre_formulario";
                string tipodatos = "NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_formularios");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Formulario se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_formularios > 0");
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

        private void frmFormularios_Load(object sender, EventArgs e)
        {
            llenar_grid("id_formularios > 0");
        }

        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewFormularios, "formularios.id_formularios AS Id, formularios.nombre_formularios, formularios.creado, formularios.modificado", "formularios", _parametro, "Id?Nombre Formulario?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_nombre_formulario.Text = "";


        }

        private void dataGridViewFormularios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewFormularios.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_formulario.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _nombre_formulario = txt_nombre_formulario.Text;


            if (_nombre_formulario.Length == 0)
            {
                _nombre_formulario = "%";
            }


            llenar_grid("formularios.nombre_formularios LIKE '" + _nombre_formulario + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_nombre_formulario.Text.Length == 0)
            {
                _error = "EL nombre formulario no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {

                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _formulario = txt_nombre_formulario.Text;
                    int resul = AccesoLogica.Delete("nombre_formularios = '" + _formulario + "' ", "formularios");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Formulario se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_formularios > 0");
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

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
