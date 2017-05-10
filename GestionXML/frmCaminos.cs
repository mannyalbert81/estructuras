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
    public partial class frmCaminos : Form
    {
        public frmCaminos()
        {
            InitializeComponent();
        }
       
        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewCaminos, "caminos.id_caminos AS Id, caminos.nombre_caminos, caminos.path_caminos, usuarios.nombre_usuarios, proyectos.nombre_proyectos, caminos.creado, caminos.modificado", "public.caminos, public.usuarios, public.proyectos", _parametro, "Id?Nombre Camino?Path?Usuario Registra?Nombre Proyecto?Creado?Modificado");

        }
       

        private void frmCaminos_Load_1(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_usuarios, "id_usuarios", "nombre_usuarios", "usuarios");
            clases.Funciones.CargarCombo(cbm_proyectos, "id_proyectos", "nombre_proyectos", "proyectos");
            llenar_grid(" usuarios.id_usuarios = caminos.id_usuarios AND proyectos.id_proyectos = caminos.id_proyectos");
        }

        public void limpiar()
        {
            txt_nombre_caminos.Text = "";
            txt_path_caminos.Text = "";


        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {//hj
            string _error = "";
            string _nombre_caminos = txt_nombre_caminos.Text;
            string _path_caminos = txt_path_caminos.Text;
            int _id_usuarios = Convert.ToInt16(cbm_usuarios.SelectedValue.ToString());
            int _id_proyectos = Convert.ToInt16(cbm_proyectos.SelectedValue.ToString());
            

            if (_nombre_caminos.Length == 0)
            {
                _error = "Debe Indicar un nombre de Camino";
            }
            if (_path_caminos.Length == 0)
            {
                _error = "Debe Indicar un camino";
            }
           
            if (_error.Length == 0)

            {
                string datos = _nombre_caminos + "?" + _path_caminos + "?" + _id_usuarios + "?" + _id_proyectos;
                string columnas = "_nombre_caminos?_path_caminos?_id_usuarios?_id_proyectos";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_caminos");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Camino se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("usuarios.id_usuarios = caminos.id_usuarios AND proyectos.id_proyectos = caminos.id_proyectos");
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
                string _nombre_caminos = txt_nombre_caminos.Text;
                string _path_caminos = txt_path_caminos.Text;


                if (_nombre_caminos.Length == 0)
                {
                    _nombre_caminos = "%";
                }

                if (_path_caminos.Length == 0)
                {
                    _path_caminos = "%";
                }


                llenar_grid("usuarios.id_usuarios = caminos.id_usuarios AND proyectos.id_proyectos = caminos.id_proyectos AND caminos.nombre_caminos LIKE '" + _nombre_caminos + "' AND caminos.path_caminos LIKE '" + _path_caminos + "'");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            string _error = "";
            if (txt_nombre_caminos.Text.Length == 0)
            {
                _error = "EL nombre caminos no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {

                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
               "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                    {
                        string _nombre_caminos = txt_nombre_caminos.Text;
                        int resul = AccesoLogica.Delete("nombre_caminos = '" + _nombre_caminos + "' ", "caminos");

                        if (resul == 1)
                        {
                            MessageBox.Show("El Camino se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            llenar_grid("usuarios.id_usuarios = caminos.id_usuarios AND proyectos.id_proyectos = caminos.id_proyectos");
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

        private void dataGridViewCaminos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewCaminos.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_caminos.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            txt_path_caminos.Text = Convert.ToString(fila.Cells[2].Value);
            cbm_usuarios.Text = Convert.ToString(fila.Cells[3].Value);
            cbm_proyectos.Text = Convert.ToString(fila.Cells[4].Value);
        }

        private void frmCaminos_FormClosing(object sender, FormClosingEventArgs e)
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
        //manuel
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    }

     

