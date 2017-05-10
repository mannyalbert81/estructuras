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
    public partial class contIndice : Form
    {
        public int _id_proyectos = 0;

        public int _id_caminos = 0;


        public contIndice()
        {
            InitializeComponent();
        }
           
        private void ReportViewerIndice_Load(object sender, EventArgs e)
        {
            datas.dtIndice dtIndice = new datas.dtIndice();

            NpgsqlDataAdapter daIndice = new NpgsqlDataAdapter();
            daIndice = AccesoLogica.Select_reporte("caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, proyectos.id_proyectos, proyectos.nombre_proyectos, proyectos.observaciones_proyectos, indice_cabeza.id_indice_cabeza, indice_cabeza.nombre_indice_cabeza, indice_detalle.id_indice_detalle, tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, indice_detalle.nombre_indice_detalle, indice_detalle.min_indice_detalle, indice_detalle.max_indice_detalle, indice_detalle.orden_indice_detalle ", "public.proyectos, public.caminos, public.indice_cabeza, public.indice_detalle, public.tipo_indice", "caminos.id_proyectos = proyectos.id_proyectos AND indice_cabeza.id_indice_cabeza = indice_detalle.id_indice_cabeza AND tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND   proyectos.id_proyectos = '" + _id_proyectos + "' AND caminos.id_caminos = '" + _id_caminos + "' ");

            daIndice.Fill(dtIndice, "indice_cabeza");
            int reg = dtIndice.Tables[1].Rows.Count;
            reportes.rptIndice ObjRep = new reportes.rptIndice();
            ObjRep.SetDataSource(dtIndice.Tables[1]);
            ReportViewerIndice.ReportSource = ObjRep;
            // llena_documento.Dispose();





        }
    }
}
