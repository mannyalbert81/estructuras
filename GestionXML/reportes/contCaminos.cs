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
    public partial class contCaminos : Form
    {
        public int _id_proyectos = 0;

        public int _id_caminos = 0;

        public contCaminos()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            
          
            datas.dtCaminos dtCaminos = new datas.dtCaminos();

            NpgsqlDataAdapter daCaminos = new NpgsqlDataAdapter();
            daCaminos = AccesoLogica.Select_reporte("caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, usuarios.nombre_usuarios, proyectos.nombre_proyectos, caminos.creado, caminos.modificado", "public.caminos, public.usuarios, public.proyectos", "usuarios.id_usuarios = caminos.id_usuarios AND   proyectos.id_proyectos = caminos.id_proyectos AND   proyectos.id_proyectos = '" + _id_proyectos+"'  ");

            daCaminos.Fill(dtCaminos, "proyectos");
            int reg = dtCaminos.Tables[1].Rows.Count;
            reportes.rptCaminos ObjRep = new reportes.rptCaminos();
            ObjRep.SetDataSource(dtCaminos.Tables[1]);
            crystalReportViewer1.ReportSource = ObjRep;
            //llena_documento.Dispose();
         




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
