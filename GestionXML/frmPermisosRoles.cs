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
    public partial class frmPermisosRoles : Form
    {
        public frmPermisosRoles()
        {
            InitializeComponent();
        }

      

        private void frmPermisosRoles_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_roles, "id_rol", "nombre_rol", "rol");
            clases.Funciones.CargarCombo(cbm_controladores, "id_controladores", "nombre_controladores", "controladores");
            llenar_grid("controladores.id_controladores = permisos_rol.id_controladores AND rol.id_rol = permisos_rol.id_rol");
            llenar_combomanual();
        }


        private void llenar_combomanual()
        {

            int i = 0;

            for (i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    cbm_ver.Items.Insert(i, "Seleccione ..");
                    cbm_editar.Items.Insert(i, "Seleccione ..");
                    cbm_borrar.Items.Insert(i, "Seleccione ..");

                }
                else if (i == 1)
                {
                    cbm_ver.Items.Insert(i, "True");
                    cbm_editar.Items.Insert(i, "True");
                    cbm_borrar.Items.Insert(i, "True");


                }
                else if (i == 2)
                {
                    cbm_ver.Items.Insert(i, "False");
                    cbm_editar.Items.Insert(i, "False");
                    cbm_borrar.Items.Insert(i, "False");

                }

            }
            cbm_ver.SelectedIndex = 0;
            cbm_editar.SelectedIndex = 0;
            cbm_borrar.SelectedIndex = 0;

        }

        

        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewPermisosRoles, "permisos_rol.id_permisos_rol AS Id, permisos_rol.nombre_permisos_rol, controladores.nombre_controladores, rol.nombre_rol, permisos_rol.ver_permisos_rol, permisos_rol.editar_permisos_rol, permisos_rol.borrar_permisos_rol, permisos_rol.creado, permisos_rol.modificado", "public.permisos_rol, public.controladores, public.rol", _parametro, "Id?Nombre Permisos?Controlador?Rol?Ver?Editar?Borar?Creado?Modificado");

        }


        public void limpiar()
        {

            txt_nombre_permisos_roles.Text = "";
            cbm_ver.SelectedIndex = 0;
            cbm_editar.SelectedIndex = 0;
            cbm_borrar.SelectedIndex = 0;

        }

        private void dataGridViewPermisosRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            DataGridViewRow fila = dataGridViewPermisosRoles.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_permisos_roles.Text = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            cbm_controladores.Text = Convert.ToString(fila.Cells[2].Value);
            cbm_roles.Text = Convert.ToString(fila.Cells[3].Value);
            cbm_ver.Text = Convert.ToString(fila.Cells[4].Value);
            cbm_editar.Text = Convert.ToString(fila.Cells[5].Value);
            cbm_borrar.Text = Convert.ToString(fila.Cells[6].Value);


           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _ver = "";
            string _editar = "";
            string _borrar = "";
            string _nombre_permisos_rol = txt_nombre_permisos_roles.Text;
            
            int _id_rol = Convert.ToInt16(cbm_roles.SelectedValue.ToString());
            int _id_controladores = Convert.ToInt16(cbm_controladores.SelectedValue.ToString());
            string _ver_1 = cbm_ver.Text;
            string _editar_1 = cbm_editar.Text;
            string _borrar_1 = cbm_borrar.Text;


            

            if (_nombre_permisos_rol.Length == 0)
            {
                _error = "Debe Indicar un nombre del permiso";
            }

            if (_ver_1.Length == 0)
            {
                _error = "Debe seleccionar una opcion en Ver";
            }

            if (_editar_1.Length == 0)
            {
                _error = "Debe seleccionar una opcion en Editar";
            }

            if (_borrar_1.Length == 0)
            {
                _error = "Debe seleccionar una opcion en Borrar";
            }
            if (_ver_1 == "Seleccione ..")
            {
                _error = "Debe seleccionar una opcion en Ver";
            }

            if (_editar_1 == "Seleccione ..")
            {
                _error = "Debe seleccionar una opcion en Editar";
            }

            if (_borrar_1 == "Seleccione ..")
            {
                _error = "Debe seleccionar una opcion en Borrar";
            }




            if (_error.Length == 0)
            {
                if (cbm_ver.Text == "True")
                {
                    _ver = "true";
                }
                if (cbm_ver.Text == "False")
                {
                    _ver = "false";
                }
                if (cbm_editar.Text == "True")
                {
                    _editar = "true";
                }
                if (cbm_editar.Text == "False")
                {
                    _editar = "false";
                }
                if (cbm_borrar.Text == "True")
                {
                    _borrar = "true";
                }
                if (cbm_borrar.Text == "False")
                {
                    _borrar = "false";
                }



                string datos = _nombre_permisos_rol + "?" + _id_controladores + "?" + _ver + "?" + _editar + "?" + _borrar + "?" + _id_rol;
                string columnas = "_nombre_permisos_rol?_id_controladores?_ver?_editar?_borrar?_id_rol";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Boolean?NpgsqlDbType.Boolean?NpgsqlDbType.Boolean?NpgsqlDbType.Integer";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_permisos_rol");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Permiso se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("controladores.id_controladores = permisos_rol.id_controladores AND rol.id_rol = permisos_rol.id_rol");
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
            string _nombre_permisos = txt_nombre_permisos_roles.Text;
           
            if (_nombre_permisos.Length == 0)
            {
                _nombre_permisos = "%";
            }
            llenar_grid("controladores.id_controladores = permisos_rol.id_controladores AND rol.id_rol = permisos_rol.id_rol AND permisos_rol.nombre_permisos_rol LIKE '" + _nombre_permisos + "'");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_nombre_permisos_roles.Text.Length == 0)
            {
                _error = "EL nombre del permiso no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {

                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
               "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                    {
                        string _nombre_permisos_rol = txt_nombre_permisos_roles.Text;
                        int resul = AccesoLogica.Delete("nombre_permisos_rol = '" + _nombre_permisos_rol + "' ", "permisos_rol");

                        if (resul == 1)
                        {
                            MessageBox.Show("El Permiso se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            llenar_grid("controladores.id_controladores = permisos_rol.id_controladores AND rol.id_rol = permisos_rol.id_rol");
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

        private void frmPermisosRoles_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txt_nombre_permisos_roles_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
