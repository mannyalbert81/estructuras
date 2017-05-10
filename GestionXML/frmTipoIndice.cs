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
    public partial class frmTipoIndice : Form
    {
        public frmTipoIndice()
        {
            InitializeComponent();
        }

        private void frmTipoIndice_Load(object sender, EventArgs e)
        {
            llenar_grid("id_tipo_indice > 0");
        }

        private void frmTipoIndice_FormClosing(object sender, FormClosingEventArgs e)
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

        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewTipoIndice, "tipo_indice.id_tipo_indice AS Id, tipo_indice.nombre_tipo_indice, tipo_indice.creado, tipo_indice.modificado", "tipo_indice", _parametro, "Id?Nombre Tipo Indice?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_nombre_tipo_indice.Text = "";


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_tipo_indice = txt_nombre_tipo_indice.Text;


            if (_nombre_tipo_indice.Length == 0)
            {
                _error = "Debe Indicar un nombre de Tipo Indice";
            }



            if (_error.Length == 0)
            {
                string datos = _nombre_tipo_indice;
                string columnas = "_nombre_tipo_indice";
                string tipodatos = "NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_tipo_indice");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Tipo Indice se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_tipo_indice > 0");
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

        private void dataGridViewTipoIndice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewTipoIndice.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_tipo_indice.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _nombre_tipo_indice= txt_nombre_tipo_indice.Text;


            if (_nombre_tipo_indice.Length == 0)
            {
                _nombre_tipo_indice = "%";
            }


            llenar_grid("tipo_indice.nombre_tipo_indice LIKE '" + _nombre_tipo_indice + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_nombre_tipo_indice.Text.Length == 0)
            {
                _error = "EL nombre Tipo Indice no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                  "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _nombre_tipo_indice = txt_nombre_tipo_indice.Text;
                    int resul = AccesoLogica.Delete("nombre_tipo_indice = '" + _nombre_tipo_indice + "' ", "tipo_indice");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Tipo Indice se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_tipo_indice > 0");
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
