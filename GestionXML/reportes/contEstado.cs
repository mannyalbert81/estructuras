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
    public partial class contEstado : Form
    {
        public contEstado()
        {
            InitializeComponent();
        }

        private void ReportViewerEstado_Load(object sender, EventArgs e)
        {
            datas.dtEstado dtEstado = new datas.dtEstado();

            NpgsqlDataAdapter daEstado = new NpgsqlDataAdapter();
            daEstado = AccesoLogica.Select_reporte("estado.id_estado, estado.nombre_estado, estado.creado, estado.modificado ", "public.estado", "estado.id_estado>0");

            daEstado.Fill(dtEstado, "estado");
            int reg = dtEstado.Tables[1].Rows.Count;
            reportes.rptEstado ObjRep = new reportes.rptEstado();
            ObjRep.SetDataSource(dtEstado.Tables[1]);
            ReportViewerEstado.ReportSource = ObjRep;
            // llena_documento.Dispose();

        }
    }
}
