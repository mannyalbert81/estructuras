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
    public partial class frmCiudad : Form
    {
        public frmCiudad()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _codigo_ciudad = txt_codigo.Text;
            string _nombre_ciudad = txt_Nombre_Ciudad.Text;

            if (_codigo_ciudad.Length == 0)
            {
                _error = "Debe Indicar un Código de Ciudad";
            }


            if (_nombre_ciudad.Length == 0)
            {
                _error = "Debe Indicar un Nombre de Ciudad";
            }




            if (_error.Length == 0)
            {
                string datos = _codigo_ciudad + "?" + _nombre_ciudad;
                string columnas = "_codigo_ciudad?_nombre_ciudad";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_ciudad");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Formulario se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_ciudad > 0");
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

        private void frmCiudad_Load(object sender, EventArgs e)
        {
            llenar_grid("id_ciudad > 0");
        }
        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewCiudad, "ciudad.id_ciudad AS Id, ciudad.codigo_ciudad, ciudad.nombre_ciudad, ciudad.creado, ciudad.modificado", "ciudad", _parametro, "Id?Codigo?Nombre Ciudad?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_Nombre_Ciudad.Text = "";


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _codigo_ciudad = txt_codigo.Text;
            string _nombre_ciudad = txt_Nombre_Ciudad.Text;


            if (_codigo_ciudad.Length == 0)
            {
                _codigo_ciudad = "%";
            }

            if (_nombre_ciudad.Length == 0)
            {
                _nombre_ciudad = "%";
            }


            llenar_grid("ciudad.codigo_ciudad LIKE '" + _codigo_ciudad + "' AND ciudad.nombre_ciudad LIKE '" + _nombre_ciudad + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)

        {

            string _error = "";
            if (txt_Nombre_Ciudad.Text.Length == 0)
            {
                _error = "EL nombre ciudad no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                try
                {
                    string _nombre_ciudad = txt_Nombre_Ciudad.Text;
                    int resul = AccesoLogica.Delete("nombre_ciudad = '" + _nombre_ciudad + "' ", "ciudad");

                    if (resul == 1)
                    {
                        MessageBox.Show("La Ciudad se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_ciudad > 0");
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

        