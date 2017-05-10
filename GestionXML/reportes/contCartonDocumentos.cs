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
    public partial class contCartonDocumentos : Form
    {
        public contCartonDocumentos()
        {
            InitializeComponent();
        }

        private void ReportViewerCartonDocumentos_Load(object sender, EventArgs e)
        {
            datas.dtCartonDocumentos dtCartonDocumentos = new datas.dtCartonDocumentos();

            NpgsqlDataAdapter daCartonDocumentos = new NpgsqlDataAdapter();
            daCartonDocumentos = AccesoLogica.Select_reporte("carton_documentos.id_carton_documentos, carton_documentos.numero_carton_documentos, carton_documentos.estado_carton_documentos, carton_documentos.creado, carton_documentos.modificado ", "public.carton_documentos", "carton_documentos.id_carton_documentos>0");

            daCartonDocumentos.Fill(dtCartonDocumentos, "carton_documentos");
            int reg = dtCartonDocumentos.Tables[1].Rows.Count;
            reportes.rptCartonDocuementos ObjRep = new reportes.rptCartonDocuementos();
            ObjRep.SetDataSource(dtCartonDocumentos.Tables[1]);
            ReportViewerCartonDocumentos.ReportSource = ObjRep;
            // llena_documento.Dispose();
        }
    }
}
