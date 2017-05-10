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

namespace GestionXML.reportes
{
    public partial class FiltroCaminos : Form
    {
        public FiltroCaminos()
        {
            InitializeComponent();
        }

        private void FiltroCaminos_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_proyectos, "id_proyectos", "nombre_proyectos", "proyectos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _id_proyectos =  Convert.ToInt32( cbm_proyectos.SelectedValue.ToString());


            DataTable daCaminos = AccesoLogica.Select("caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, usuarios.nombre_usuarios, proyectos.nombre_proyectos, caminos.creado, caminos.modificado", "public.caminos, public.usuarios, public.proyectos", "usuarios.id_usuarios = caminos.id_usuarios AND   proyectos.id_proyectos = caminos.id_proyectos AND   proyectos.id_proyectos = '" + _id_proyectos + "'  ");
            int registro = daCaminos.Rows.Count;

            if (registro > 0)
            {
                reportes.contCaminos frm = new reportes.contCaminos();
                frm._id_proyectos = _id_proyectos;
                frm.Show();

            }
            else {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }







        }

        private void cbm_proyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbm_proyectos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
