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
    public partial class frmProyectos : Form
    {
        public frmProyectos()
        {
            InitializeComponent();
        }

        private void frmProyectos_Load(object sender, EventArgs e)
        {
            llenar_grid("id_proyectos > 0");
        }


        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewProyectos, "proyectos.id_proyectos AS Id, proyectos.nombre_proyectos, proyectos.observaciones_proyectos, proyectos.creado, proyectos.modificado", "public.proyectos", _parametro, "Id?Nombre Proyecto?Observaciones?Creado?Modificado");

        }

        public void limpiar()
        {
            txt_nombre_proyecto.Text = "";
            txt_obsevaciones.Text = "";


        }

        private void dataGridViewProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewProyectos.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_proyecto.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            txt_obsevaciones.Text = Convert.ToString(fila.Cells[2].Value); //obtengo el valor de la primer columna

        }

        private void frmProyectos_FormClosing(object sender, FormClosingEventArgs e)
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
            string _nombre_proyecto = txt_nombre_proyecto.Text;
            string _observaciones = txt_obsevaciones.Text;


            if (_nombre_proyecto.Length == 0)
            {
                _error = "Debe Indicar un nombre de Proyecto";
            }
            if (_observaciones.Length == 0)
            {
                _error = "Debe Indicar las Observaciones";
            }



            if (_error.Length == 0)
            {
                string datos = _nombre_proyecto + "?" + _observaciones;
                string columnas = "_nombre_proyecto?_observaciones";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_proyectos");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Proyecto se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_proyectos > 0");
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
            string _nombre_protecto = txt_nombre_proyecto.Text;
            string _observaciones = txt_obsevaciones.Text;


            if (_nombre_protecto.Length == 0)
            {
                _nombre_protecto = "%";
            }

            if (_observaciones.Length == 0)
            {
                _observaciones = "%";
            }


            llenar_grid("proyectos.nombre_proyectos LIKE '" + _nombre_protecto + "' AND proyectos.observaciones_proyectos LIKE '" + _observaciones + "'");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            string _error = "";
            if (txt_nombre_proyecto.Text.Length == 0)
            {
                _error = "EL nombre proyecto no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                  "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _nombre_proyectos = txt_nombre_proyecto.Text;
                    int resul = AccesoLogica.Delete("nombre_proyectos = '" + _nombre_proyectos + "' ", "proyectos");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Proyecto se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("id_proyectos > 0");
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
