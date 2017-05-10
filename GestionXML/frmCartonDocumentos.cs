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
    public partial class frmCartonDocumentos : Form
    {
        public frmCartonDocumentos()
        {
            InitializeComponent();
        }
        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewCartonDocumentos, "carton_documentos.id_carton_documentos AS Id, carton_documentos.numero_carton_documentos, carton_documentos.estado_carton_documentos, carton_documentos.creado, carton_documentos.modificado", "public.carton_documentos", _parametro, "Id?Numero Carton?Estado Carton?Creado?Modificado");

        }
        public void limpiar()
        {
            txt_numero_carton_documentos.Text = "";
            cbm_estado_carton_documentos.Text = "";


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _numero_carton_documentos = txt_numero_carton_documentos.Text;
            string _estado_carton_documentos = cbm_estado_carton_documentos.Text;
           


            if (_numero_carton_documentos.Length == 0)
            {
                _error = "Debe Indicar un numero de Carton";
            }
            if (_estado_carton_documentos.Length == 0)
            {
                _error = "Debe Indicar un Estado de Carton";
            }

            if (_error.Length == 0)

            {
                string datos = _numero_carton_documentos + "?" + _estado_carton_documentos;
                string columnas = "_numero_carton_documentos?_estado_carton_documentos?";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Boolean";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_carton_documentos");
                  
                    if (resul < 0)
                    {
                        MessageBox.Show("El Carton se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_carton_documentos > 0");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                string _numero_carton_documentos = txt_numero_carton_documentos.Text;
                


                if (_numero_carton_documentos.Length == 0)
                {
                    _numero_carton_documentos = "%";
                }



                llenar_grid("carton_documentos.numero_carton_documentos LIKE '" + _numero_carton_documentos + "'");
            }
        }

        

       

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmCartonDocumentos_Load(object sender, EventArgs e)
        {
            
            llenar_grid("id_carton_documentos > 0");
        }

        private void dataGridViewCartonDocumentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewCartonDocumentos.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_numero_carton_documentos.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            cbm_estado_carton_documentos.Text = Convert.ToString(fila.Cells[2].Value);
         
        }

        private void frmCartonDocumentos_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_numero_carton_documentos.Text.Length == 0)
            {
                _error = "EL nombre caminos no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                try
                {
                    string _numero_carton_documentos = txt_numero_carton_documentos.Text;
                    int resul = AccesoLogica.Delete("numero_carton_documentos = '" + _numero_carton_documentos + "' ", "carton_documentos");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Carton se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_carton_documentos > 0");
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
                MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
