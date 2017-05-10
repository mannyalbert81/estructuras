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
    public partial class contProduccion : Form
    {

        public int _id_usuario = 0;
        public DateTime _inicio;
        public DateTime _final;
        public contProduccion()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            datas.ProduccionXml ProduccionXml = new datas.ProduccionXml();

            NpgsqlDataAdapter daProduccion = new NpgsqlDataAdapter();
            daProduccion = AccesoLogica.Select_reporte("  produccion_detalle.id_produccion_detalle, produccion_detalle.nombre_produccion_detalle, produccion_detalle.inicio_produccion_detalle, produccion_detalle.fin_produccion_detalle, usuarios.id_usuarios, usuarios.nombre_usuarios, caminos.id_caminos, caminos.nombre_caminos, produccion_detalle.creado, produccion_detalle.modificado ", " public.produccion_detalle, public.usuarios, public.caminos", " usuarios.id_usuarios = produccion_detalle.id_usuarios_crea AND caminos.id_caminos = produccion_detalle.id_caminos AND usuarios.id_usuarios = '" + _id_usuario + "' AND produccion_detalle.creado BETWEEN '" + _inicio + "' AND '" + _final + "'");

            daProduccion.Fill(ProduccionXml, "produccion_detalle");
            int reg = ProduccionXml.Tables[1].Rows.Count;
            reportes.rptProduccion2 ObjRep = new reportes.rptProduccion2();
            ObjRep.SetDataSource(ProduccionXml.Tables[1]);
            crystalReportViewer1.ReportSource = ObjRep;
            // llena_documento.Dispose();
        }
    }
}
