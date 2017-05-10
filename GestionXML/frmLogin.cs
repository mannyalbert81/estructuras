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
using System.Net;
using System.Net.NetworkInformation;



namespace GestionXML
{
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string _usuario_usuarios = txt_usuario.Text;
            string _clave_usuarios =  txt_password.Text;
            string _nombre_usuarios = "";
            int _id_rol = 0;
            int _id_licencias = 0;
            int _id_usuarios = 0;
            string _numero_licencias_registradas = "";
            string _cantidad_licencias = "";
            string _mac_adres_maquina = "";
            string _nombre_sesion_maquina = "";
            string _ip_maquina = "";
            string _mac = "";
            string _mac1 = "";
            
            //maycol
            _mac1 = AccesoLogica.cifrar(HardwareInfo.GetMACAddress());
            _nombre_sesion_maquina = AccesoLogica.cifrar(HardwareInfo.GetComputerName());

            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    _ip_maquina = AccesoLogica.cifrar(ip.ToString());
                }
            }


            // CONSULTO USUARIO Y CLAVE

            string clave = AccesoLogica.cifrar(_clave_usuarios);
            DataTable dtUsuario = AccesoLogica.Select("nombre_usuarios, id_rol, id_usuarios", "usuarios", "usuario_usuarios = '" + _usuario_usuarios + "' AND clave_usuarios = '" + clave + "'  ");
            foreach (DataRow renglon in dtUsuario.Rows)
            {
                _id_usuarios = Convert.ToInt32(renglon["id_usuarios"].ToString());
                _nombre_usuarios = Convert.ToString(renglon["nombre_usuarios"].ToString());
                _id_rol = Convert.ToInt32(renglon["id_rol"].ToString());

            }
            int registro = dtUsuario.Rows.Count;

            // CONSULTO NUMERO DE LICENCIAS

            DataTable dtLicencias = AccesoLogica.Select("licencias.id_licencias, licencias.numero_licencias_registradas, licencias.cantidad_licencias", "licencias", "licencias.id_licencias > 0");
            foreach (DataRow renglon_li in dtLicencias.Rows)
            {
                _id_licencias = Convert.ToInt32(renglon_li["id_licencias"].ToString());
                _numero_licencias_registradas = Convert.ToString(renglon_li["numero_licencias_registradas"].ToString());
                _cantidad_licencias = AccesoLogica.descifrar(Convert.ToString(renglon_li["cantidad_licencias"].ToString()));
            }


            ///consulto licencias detalle
            DataTable dtLicencias_detalle1 = AccesoLogica.Select("mac_adres_maquina", "licencias_detalle", "licencias_detalle.mac_adres_maquina= '" + _mac1 + "'");
            foreach (DataRow renglon_de1 in dtLicencias_detalle1.Rows)
            {
                _mac = Convert.ToString(renglon_de1["mac_adres_maquina"].ToString());
            }


            if (registro > 0)
            {
                
                if (Convert.ToInt32(_cantidad_licencias) > 0 )
                {

                    if (_mac == _mac1)
                    {
                        frmMenucs frm = new frmMenucs();
                        frm._nombre_usuarios = _nombre_usuarios;
                        frm._id_rol = _id_rol;
                        frm._id_usuarios = _id_usuarios;
                        
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        _mac_adres_maquina = AccesoLogica.cifrar(HardwareInfo.GetMACAddress());
                        string numero = AccesoLogica.descifrar(_numero_licencias_registradas);
                        int nu = Convert.ToInt32(numero) + 1;
                        string nume_cifrado = AccesoLogica.cifrar(Convert.ToString(nu));


                        string datos = _id_licencias + "?" + _mac_adres_maquina + "?" + _nombre_sesion_maquina + "?" + _ip_maquina + "?" + nume_cifrado;
                        string columnas = "_id_licencias?_mac_adres_maquina?_nombre_sesion_maquina?_ip_maquina?_numero_licencias_registradas";
                        string tipodatos = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar? NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

                        int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_licencias_detalle");


                        try
                        {
                            string can_numero = _cantidad_licencias;
                            int can_nu = Convert.ToInt32(can_numero) - 1;
                            string can_nu_cifrado = AccesoLogica.cifrar(Convert.ToString(can_nu));

                            

                            int result = AccesoLogica.Update("licencias", "cantidad_licencias = '" + can_nu_cifrado + "', numero_licencias_registradas = '" + nume_cifrado + "'", "id_licencias= '" + _id_licencias + "'");

                            DataTable dtLicencias_detalle = AccesoLogica.Select("mac_adres_maquina", "licencias_detalle", "licencias_detalle.mac_adres_maquina= '" + _mac_adres_maquina + "'");
                            foreach (DataRow renglon_de in dtLicencias_detalle.Rows)
                            {
                                _mac = Convert.ToString(renglon_de["mac_adres_maquina"].ToString());

                            }

                            if (_mac_adres_maquina == _mac)
                            {

                                frmMenucs frm = new frmMenucs();
                                frm._nombre_usuarios = _nombre_usuarios;
                                frm._id_rol = _id_rol;
                                frm._id_usuarios = _id_usuarios;
                                frm.Show();
                                this.Hide();

                            }
                            else
                            {
                                MessageBox.Show("Maquina No Registrada", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txt_usuario.Text = "";
                                txt_password.Text = "";
                            }

                        }
                        catch (NpgsqlException errores)
                        {

                            MessageBox.Show(errores.Message, "Error");

                        }
                    }

                    
              } else if (Convert.ToInt32(_cantidad_licencias) <= 0 )
                {

                    if (_mac == _mac1)
                    {

                        frmMenucs frm = new frmMenucs();
                        frm._nombre_usuarios = _nombre_usuarios;
                        frm._id_rol = _id_rol;
                        frm._id_usuarios = _id_usuarios;
                        frm.Show();
                        this.Hide();
                    }else
                    {
                        MessageBox.Show("Maquina  no Registrada", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        txt_usuario.Text = "";
                        txt_password.Text = "";

                    }
                 
                }
                
            }

            else 
            {

                MessageBox.Show("Usuario o Clave Incorrecta", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txt_usuario.Text = "";
                txt_password.Text = "";
            }
            
        }
        //maycol

        private void btnSalir_Click(object sender, EventArgs e)
        {

            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?",
             "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
               
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
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