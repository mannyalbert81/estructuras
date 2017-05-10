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
    public partial class contTipoIndice : Form
    {
        public contTipoIndice()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            datas.dtTipoIndice dtTipoIndice = new datas.dtTipoIndice();

            NpgsqlDataAdapter daTipoIndice = new NpgsqlDataAdapter();
            daTipoIndice = AccesoLogica.Select_reporte("tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, tipo_indice.creado, tipo_indice.modificado ", "public.tipo_indice", "tipo_indice.id_tipo_indice>0");

            daTipoIndice.Fill(dtTipoIndice, "tipo_indice");
            int reg = dtTipoIndice.Tables[1].Rows.Count;
            reportes.rptTipoIndice ObjRep = new reportes.rptTipoIndice();
            ObjRep.SetDataSource(dtTipoIndice.Tables[1]);
            ReportViewerTipoIndice.ReportSource = ObjRep;
            // llena_documento.Dispose();

        }
    }
}
