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
    public partial class contProyectos : Form
    {
        public contProyectos()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            datas.dtProyectos dtProyectos = new datas.dtProyectos();

            NpgsqlDataAdapter daProyectos = new NpgsqlDataAdapter();
            daProyectos = AccesoLogica.Select_reporte("proyectos.id_proyectos, proyectos.nombre_proyectos, proyectos.observaciones_proyectos, proyectos.creado, proyectos.modificado ", "public.proyectos", "proyectos.id_proyectos>0");

            daProyectos.Fill(dtProyectos, "proyectos");
            int reg = dtProyectos.Tables[1].Rows.Count;
            reportes.rptProyectos ObjRep = new reportes.rptProyectos();
            ObjRep.SetDataSource(dtProyectos.Tables[1]);
            ReportViewerProyectos.ReportSource = ObjRep;
           // llena_documento.Dispose();



            /*
           datas.dtParticipantes dtParticipantes = new datas.dtParticipantes();

           NpgsqlDataAdapter daParticipantes = new NpgsqlDataAdapter();
           daParticipantes = AccesoLogica.Select_reporte("participantes.id_participantes, participantes.ci_participantes, participantes.primer_nombre_participantes, participantes.segundo_nombre_participantes, participantes.primer_apellido_participantes,   participantes.segundo_apellido_participantes, participantes.correo_participantes, participantes.telefono_participantes, participantes.celular_participantes, participantes.id_tag", "public.participantes", "ci_participantes LIKE '%' ");

           daParticipantes.Fill(dtParticipantes, "participantes");
           int reg = dtParticipantes.Tables[1].Rows.Count;
           reportes.repParticipantes ObjRep = new reportes.repParticipantes();
           ObjRep.SetDataSource(dtParticipantes.Tables[1]);
           crystalReportViewer1.ReportSource = ObjRep;
           //llena_documento.Dispose();
           */





        }
    }
}
