using Negocio;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionXML.reportes
{
    public partial class contLicencias : Form
    {

        public int _id_Licencias = 0;
        public contLicencias()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            datas.dtLicencias dtLicencias = new datas.dtLicencias();
            NpgsqlDataAdapter daLicencias = new NpgsqlDataAdapter();
            daLicencias = AccesoLogica.Select_reporte("licencias.id_licencias, licencias.descripcion_licencias, licencias.cantidad_licencias, licencias.numero_licencias_registradas, licencias.total_licencias_compradas, licencias_detalle.id_licencias_detalle, licencias_detalle.mac_adres_maquina, licencias_detalle.nombre_sesion_maquina, licencias_detalle.ip_maquina, licencias_detalle.numero_licencias, licencias.creado, licencias.modificado", "public.licencias, public.licencias_detalle ", " licencias_detalle.id_licencias = licencias.id_licencias AND  licencias.id_licencias = '" + _id_Licencias + "' ");

           
            daLicencias.Fill(dtLicencias, "licencias");
            int reg = dtLicencias.Tables[1].Rows.Count;
            reportes.rptLicencias ObjRep = new reportes.rptLicencias();
            ObjRep.SetDataSource(dtLicencias.Tables[1]);
            crystalReportViewer1.ReportSource = ObjRep;
            //llena_documento.Dispose();
        }
    }
}
