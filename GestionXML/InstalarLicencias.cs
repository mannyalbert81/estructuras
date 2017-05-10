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
    public partial class InstalarLicencias : Form
    {
        public InstalarLicencias()
        {
            InitializeComponent();
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            DataTable dtLicencias = AccesoLogica.Select("*", "licencias", "id_licencias > 0");
            int registro = dtLicencias.Rows.Count;
            
            string _error = "";
            string _descripcion_licencias = txt_entidad.Text;
            string _cantidad_licencias = txt_cantidad_licencias.Text;
            string _licencias_disponibles = txt_disponibles.Text;
            string _numero_licencias_registradas = txt_licencias_asignadas.Text; 
            

            if (_descripcion_licencias.Length == 0)
            {
                _error = "Debe Indicar una Entidad";
            }
            if (_cantidad_licencias.Length == 0)
            {
                _error = "Debe Indicar # de Licencias Compradas";
            }
            if (_numero_licencias_registradas.Length == 0)
            {
                _error = "Debe Indicar # de Licencias Registradas";
            }
            if (_licencias_disponibles.Length == 0)
            {
                _error = "Debe Indicar # Licencias Disponibles";
            }
            
                if (_error.Length == 0)
            {
                string descripcion = AccesoLogica.cifrar(_descripcion_licencias);
                string cantidad = AccesoLogica.cifrar(_cantidad_licencias);
                string numero = AccesoLogica.cifrar(_numero_licencias_registradas);
                string disponibilidad = AccesoLogica.cifrar(_licencias_disponibles);


                string datos = descripcion + "?" + disponibilidad + "?" + numero + "?" + cantidad;
                string columnas = "descripcion?disponibilidad?numero?cantidad";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_licencias");
                    if (resul < 0)
                    {
                        MessageBox.Show("La Licencia se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiar();
                            llenar_grid("id_licencias > 0");

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {

            txt_entidad.Text = "";
            txt_cantidad_licencias.Text = "";
            txt_disponibles.Text = "";
            txt_licencias_asignadas.Text = "";


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void InstalarLicencias_FormClosing(object sender, FormClosingEventArgs e)
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

        private void InstalarLicencias_Load(object sender, EventArgs e)
        {


            llenar_grid("id_licencias > 0");
            

            }

        private void dataGridViewLicencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow fila = dataGridViewLicencias.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_entidad.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            txt_cantidad_licencias.Text = Convert.ToString(fila.Cells[2].Value);
            txt_disponibles.Text = Convert.ToString(fila.Cells[3].Value);
            txt_licencias_asignadas.Text = Convert.ToString(fila.Cells[4].Value);

        }

        private void llenar_grid(string _parametro)
        {
            int _id_licencias = 0;
            string _numero_licencias_registradas = "";
            string _cantidad_licencias = "";
            string _entidad = "";
            string _total_licencias_compradas = "";


            DataTable dtLicencias = AccesoLogica.Select("licencias.id_licencias, licencias.numero_licencias_registradas, licencias.total_licencias_compradas, licencias.cantidad_licencias, licencias.descripcion_licencias", "licencias", "licencias.id_licencias > 0");
            foreach (DataRow renglon_li in dtLicencias.Rows)
            {
                _id_licencias = Convert.ToInt32(renglon_li["id_licencias"].ToString());
                _numero_licencias_registradas = AccesoLogica.descifrar(Convert.ToString(renglon_li["numero_licencias_registradas"].ToString()));
                _cantidad_licencias = AccesoLogica.descifrar(Convert.ToString(renglon_li["cantidad_licencias"].ToString()));
                _entidad = AccesoLogica.descifrar(Convert.ToString(renglon_li["descripcion_licencias"].ToString()));
                _total_licencias_compradas = AccesoLogica.descifrar(Convert.ToString(renglon_li["total_licencias_compradas"].ToString()));

            }

            clases.Funciones.CargarGridView(dataGridViewLicencias, "'" + _id_licencias + "' AS Id, '" + _entidad + "', '" + _total_licencias_compradas + "', '" + _cantidad_licencias + "', '" + _numero_licencias_registradas + "'", "licencias", _parametro, "Id?Nombre Entidad?Licencias Compradas?Disponibles?Licencias Asignadas");

        }
    }
}
