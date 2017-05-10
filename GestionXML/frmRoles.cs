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
    public partial class frmRoles : Form
    {
        public frmRoles()
        {
            InitializeComponent();
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string _error = "";
            string _nombre_roles = txt_roles.Text;
           

            if (_nombre_roles.Length == 0)
            {
                _error = "Debe Indicar un nombre de rol";
            }
            


            if (_error.Length == 0)
            {
                string datos = _nombre_roles;
                string columnas = "_nombre_roles";
                string tipodatos = "NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_rol");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Rol se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_rol > 0");
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

        private void frmRoles_Load(object sender, EventArgs e)
        {

            llenar_grid("id_rol > 0");
        }


        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewRoles, "rol.id_rol AS Id, rol.nombre_rol, rol.creado, rol.modificado", "rol", _parametro, "Id?Nombre Rol?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_roles.Text = "";


        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow fila = dataGridViewRoles.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_roles.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string _nombre_rol = txt_roles.Text;
            

            if (_nombre_rol.Length == 0)
            {
                _nombre_rol = "%";
            }
           

            llenar_grid("rol.nombre_rol LIKE '" + _nombre_rol + "'");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_roles.Text.Length == 0)
            {
                _error = "EL nombre rol no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                 "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _rol = txt_roles.Text;
                    int resul = AccesoLogica.Delete("nombre_rol = '" + _rol + "' ", "rol");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Rol se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_rol > 0");
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

        private void frmRoles_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
