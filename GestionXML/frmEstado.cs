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
    public partial class frmEstado : Form
    {
        public frmEstado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_estado = txt_estado.Text;


            if (_nombre_estado.Length == 0)
            {
                _error = "Debe Indicar un nombre del estado";
            }



            if (_error.Length == 0)
            {
                string datos = _nombre_estado;
                string columnas = "_nombre_estado";
                string tipodatos = "NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_estado");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Formulario se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_estado > 0");
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

        private void frmEstado_Load(object sender, EventArgs e)
        {
            llenar_grid("id_estado > 0");
        }
        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewEstado, "estado.id_estado AS Id, estado.nombre_estado, estado.creado, estado.modificado", "estado", _parametro, "Id?Nombre Estado?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_estado.Text = "";


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _nombre_estado = txt_estado.Text;


            if (_nombre_estado.Length == 0)
            {
                _nombre_estado = "%";
            }


            llenar_grid("estado.nombre_estado LIKE '" + _nombre_estado + "'");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_estado.Text.Length == 0)
            {
                _error = "EL nombre estado no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _estado = txt_estado.Text;
                    int resul = AccesoLogica.Delete("nombre_estado = '" + _estado + "' ", "estado");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Estado se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_estado > 0");
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

        private void dataGridViewEstado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewEstado.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_estado.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
        }
    }
}
