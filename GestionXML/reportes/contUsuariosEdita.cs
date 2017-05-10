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
    public partial class contUsuariosEdita: Form
    {

        public int _id_usuario = 0;
        public DateTime _inicio;
        public DateTime _final;
        public contUsuariosEdita()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            datas.dtUsuarioEdita dtUsuarioEdita = new datas.dtUsuarioEdita();

            NpgsqlDataAdapter daUsuarioEdita = new NpgsqlDataAdapter();
            daUsuarioEdita = AccesoLogica.Select_reporte("produccion_detalle.id_produccion_detalle, produccion_cabeza.id_produccion_cabeza, produccion_cabeza.xml_editados_produccion_cabeza, caminos.id_caminos, caminos.nombre_caminos, caminos.path_caminos, proyectos.id_proyectos, proyectos.nombre_proyectos, produccion_detalle.nombre_produccion_detalle, produccion_detalle.inicio_produccion_detalle, produccion_detalle.fin_produccion_detalle, usuarios.id_usuarios, usuarios.nombre_usuarios, usuarios.telefono_usuarios, produccion_detalle.creado, produccion_detalle.modificado", "  public.produccion_detalle, public.usuarios, public.produccion_cabeza, public.caminos, public.proyectos", "  produccion_detalle.id_produccion_cabeza = produccion_cabeza.id_produccion_cabeza AND usuarios.id_usuarios = produccion_detalle.id_usuarios_edita AND caminos.id_caminos = produccion_detalle.id_caminos AND proyectos.id_proyectos = caminos.id_proyectos AND usuarios.id_usuarios = '" + _id_usuario + "' AND produccion_detalle.modificado BETWEEN '" + _inicio + "' AND '" + _final + "'");
          
            daUsuarioEdita.Fill(dtUsuarioEdita, "produccion_detalle");
            int reg = dtUsuarioEdita.Tables[1].Rows.Count;

           

                reportes.rptUsuarioEdita ObjRep = new reportes.rptUsuarioEdita();
                ObjRep.SetDataSource(dtUsuarioEdita.Tables[1]);
                crystalReportViewer1.ReportSource = ObjRep;
                // llena_documento.Dispose();

             
            
        }
    }
}
