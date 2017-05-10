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
    public partial class FiltroLicencias : Form
    {
        public FiltroLicencias()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _descripcion_licencias = AccesoLogica.cifrar(cmb_licencias.Text);
            int _id_Licencias = 0;

            DataTable dtLicencias = AccesoLogica.Select("*", "licencias", "descripcion_licencias = '"+ _descripcion_licencias + "'");
            foreach (DataRow renglon in dtLicencias.Rows)
            {
                _id_Licencias = Convert.ToInt32(renglon["id_licencias"].ToString());
            }
            
            reportes.contLicencias frm = new reportes.contLicencias();
            frm._id_Licencias = _id_Licencias;
            frm.Show();
        }

        private void FiltroLicencias_Load(object sender, EventArgs e)
        {

            llenar_combomanual();

        }
        

        private void llenar_combomanual()
        {
            int _id_licencias = 0;
            string _descripcion_licencias = "";

            DataTable dtLicencias = AccesoLogica.Select("*", "licencias", "licencias.id_licencias > 0");
            foreach (DataRow renglon in dtLicencias.Rows)
            {
             
                _id_licencias = Convert.ToInt32(renglon["id_licencias"].ToString());
                _descripcion_licencias = AccesoLogica.descifrar(Convert.ToString(renglon["descripcion_licencias"].ToString()));

                cmb_licencias.Items.Add(_descripcion_licencias);

            }
 
        }
    }
}
