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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_rol, "id_rol", "nombre_rol", "rol");
            clases.Funciones.CargarCombo(cbm_estado, "id_estado", "nombre_estado", "estado");
            clases.Funciones.CargarCombo(cbm_ciudad, "id_ciudad", "nombre_ciudad", "ciudad");
            llenar_grid("usuarios.id_rol  = rol.id_rol AND usuarios.id_estado = estado.id_estado AND usuarios.id_ciudad = ciudad.id_ciudad");
        }

        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridViewUsuarios, "usuarios.nombre_usuarios AS Nombre, usuarios.telefono_usuarios, usuarios.celular_usuarios, usuarios.correo_usuarios, rol.nombre_rol, estado.nombre_estado, ciudad.nombre_ciudad, usuarios.usuario_usuarios, usuarios.creado, usuarios.modificado", "usuarios, rol, estado, ciudad", _parametro, "Nombre?Telefono?Celular?Correo?Rol?Estado?Ciudad?Usuario?Creado?Modificado");

        }


        public void limpiar()
        {

            txt_nombres_apellidos.Text = "";
            txt_usuario.Text = "";
            txt_clave.Text = "";
            txt_confirme_clave.Text = "";
            txt_telefono.Text = "";
            txt_celular.Text = "";
            txt_correo.Text = "";
            
        }



        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewUsuarios.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombres_apellidos.Text = Convert.ToString(fila.Cells[0].Value); //obtengo el valor de la primer columna
            txt_telefono.Text = Convert.ToString(fila.Cells[1].Value);
            txt_celular.Text = Convert.ToString(fila.Cells[2].Value);
            txt_correo.Text = Convert.ToString(fila.Cells[3].Value);
            cbm_rol.Text = Convert.ToString(fila.Cells[4].Value);
            cbm_estado.Text = Convert.ToString(fila.Cells[5].Value);
            cbm_ciudad.Text = Convert.ToString(fila.Cells[6].Value);
            txt_usuario.Text = Convert.ToString(fila.Cells[7].Value);
            


        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string _error = "";
            string _nombre_usuarios = txt_nombres_apellidos.Text;
            string _usuario_usuarios = txt_usuario.Text;
            string _clave_usuarios = txt_clave.Text;
            string _confirme_clave_usuarios = txt_confirme_clave.Text;
            string _telefono_usuarios = txt_telefono.Text;
            string _celular_usuarios = txt_celular.Text;
            string _correo_usuarios = txt_correo.Text;

            int _id_rol = Convert.ToInt16(cbm_rol.SelectedValue.ToString());
            int _id_estado = Convert.ToInt16(cbm_estado.SelectedValue.ToString());
            int _id_ciudad = Convert.ToInt16(cbm_ciudad.SelectedValue.ToString());

           

            Boolean valida_email = false;



            if (_nombre_usuarios.Length == 0)
            {
                _error = "Debe Indicar un nombre y apellido del usuario";
            }
            if (_usuario_usuarios.Length == 0)
            {
                _error = "Debe Indicar un usuario";
            }
            if (txt_correo.Text.Length > 0)
            {
                valida_email = clases.Funciones.email_bien_escrito(txt_correo.Text);
            }
            if (valida_email == false)
            {
                _error = "Introduzca un correo electrónico válido";
            }

            if (_clave_usuarios.Length == 0)
            {
                _error = "Debe Indicar una Clave";
            }

            if (_confirme_clave_usuarios.Length == 0)
            {
                _error = "Debe Confirmar la Clave";
            }

            if (_clave_usuarios != _confirme_clave_usuarios)
            {
                _error = "Claves No Coinciden";
            }

            if (_telefono_usuarios.Length == 0)
            {
                _error = "Introduzca un # Telefonico";
            }
            if (_celular_usuarios.Length == 0)
            {
                _error = "Introduzca un # Celular";
            }


            if (_error.Length == 0)
            {
                string clave = AccesoLogica.cifrar(_clave_usuarios);
              
                string datos = _nombre_usuarios + "?" + clave + "?" + _telefono_usuarios + "?" + _celular_usuarios + "?" + _correo_usuarios + "?" + _id_rol + "?" + _id_estado + "?" + _usuario_usuarios + "?" + _id_ciudad;
                string columnas = "_nombre_usuarios?clave?_telefono_usuarios?_celular_usuarios?_correo_usuarios?_id_rol?_id_estado?_usuario_usuarios?_id_ciudad";
                string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar? NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_usuarios");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Usuario se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("usuarios.id_rol  = rol.id_rol AND usuarios.id_estado = estado.id_estado AND usuarios.id_ciudad = ciudad.id_ciudad");
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
            string _nombre_usuarios = txt_nombres_apellidos.Text;
            string _usuario_usuarios = txt_usuario.Text;
            string _telefono_usuarios = txt_telefono.Text;
            string _celular_usuarios = txt_celular.Text;
            string _correo_usuarios = txt_correo.Text;

            if (_nombre_usuarios.Length == 0)
            {
                _nombre_usuarios = "%";
            }
            if (_usuario_usuarios.Length == 0)
            {
                _usuario_usuarios = "%";
            }
            if (_telefono_usuarios.Length == 0)
            {
                _telefono_usuarios = "%";
            }
            if (_celular_usuarios.Length == 0)
            {
                _celular_usuarios = "%";
            }
            if (_correo_usuarios.Length == 0)
            {
                _correo_usuarios = "%";
            }

            llenar_grid("usuarios.id_rol  = rol.id_rol AND usuarios.id_estado = estado.id_estado AND usuarios.id_ciudad = ciudad.id_ciudad AND usuarios.nombre_usuarios LIKE '" + _nombre_usuarios + "' AND usuarios.telefono_usuarios LIKE '" + _telefono_usuarios + "' AND usuarios.celular_usuarios LIKE '" + _celular_usuarios + "' AND usuarios.correo_usuarios LIKE '" + _correo_usuarios + "' AND usuarios.usuario_usuarios LIKE '" + _usuario_usuarios + "'   ");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_nombres_apellidos.Text.Length == 0)
            {
                _error = "EL nombre no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {


                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                    {
                        string _usuario = txt_nombres_apellidos.Text;
                        int resul = AccesoLogica.Delete("nombre_usuarios = '" + _usuario + "' ", "usuarios");

                        if (resul == 1)
                        {
                            MessageBox.Show("El Usuario se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            llenar_grid("usuarios.id_rol  = rol.id_rol AND usuarios.id_estado = estado.id_estado AND usuarios.id_ciudad = ciudad.id_ciudad");
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

        private void frmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
