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

namespace GestionXML
{
    public partial class frmMenucs : Form
    {
        public static frmMenucs mdiobj;

        public string _nombre_usuarios = "";
        public int _id_rol;
        public int _id_usuarios;

        public frmMenucs()
        {
            InitializeComponent();
            
        }

        private void frmMenucs_Load(object sender, EventArgs e)
        {
            //MENU ADMINISTRACION

            administraciónToolStripMenuItem.Visible = false;
            usuariosToolStripMenuItem.Visible = false;
            rolesToolStripMenuItem.Visible = false;
            controladoresToolStripMenuItem.Visible = false;
            permisosRolesToolStripMenuItem.Visible = false;
            formulariosToolStripMenuItem.Visible = false;
            licenciasToolStripMenuItem.Visible = false;

            // MENU MANTENIMIENTO
            mantenimientoToolStripMenuItem.Visible = false;
            proyectosToolStripMenuItem.Visible = false;
            tipoIndiceToolStripMenuItem.Visible = false;
            caminosToolStripMenuItem.Visible = false;
            cartonDocumentosToolStripMenuItem.Visible = false;
            estadoToolStripMenuItem.Visible = false;
            indiceToolStripMenuItem.Visible = false;
            asignarToolStripMenuItem.Visible = false;

            // MENU GESTION XML

            gestionXMLToolStripMenuItem.Visible = false;
            crearXMLToolStripMenuItem.Visible = false;
            controlarCalidadXMLToolStripMenuItem.Visible = false;

            // ACCESOS RAPIDOS
            toolStripButton4.Visible = false;
            toolStripButton5.Visible = false;
            toolStripButton6.Visible = false;
            toolStripButton7.Visible = false;
            toolStripButton8.Visible = false;
            toolStripButton10.Visible = false;
            toolStripButton11.Visible = false;
            toolStripButton12.Visible = false;

            // ESPACIOS
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;
            toolStripSeparator4.Visible = false;
            toolStripSeparator5.Visible = false;
            toolStripSeparator7.Visible = false;
            toolStripSeparator8.Visible = false;
            toolStripSeparator9.Visible = false;


            label1.Text = "Bienvenido: " + _nombre_usuarios + "";
            label1.RightToLeft = 0;
            string _nombre_controladores = "";

            DataTable dtPermisos = AccesoLogica.Select("permisos_rol.nombre_permisos_rol, rol.id_rol, rol.nombre_rol, controladores.id_controladores, controladores.nombre_controladores, permisos_rol.id_permisos_rol", "public.permisos_rol, public.controladores, public.rol", "controladores.id_controladores = permisos_rol.id_controladores AND rol.id_rol = permisos_rol.id_rol AND permisos_rol.id_rol= '" + _id_rol + "'");
            int registro = dtPermisos.Rows.Count;
            foreach (DataRow renglon in dtPermisos.Rows)
            {
                _nombre_controladores = Convert.ToString(renglon["nombre_controladores"].ToString());


                if (registro > 0)
                {
                    //MENU ADMINISTRACION

                    if (_nombre_controladores == "MenuAdministracion")
                    {
                        administraciónToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmUsuarios")
                    {
                        usuariosToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmRoles")
                    {
                        rolesToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmControladores")
                    {
                        controladoresToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmPermisosRoles")
                    {
                        permisosRolesToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmFormularios")
                    {
                        formulariosToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "InstalarLicencias")
                    {
                        licenciasToolStripMenuItem.Visible = true;
                    }

                    // MENU MANTENIMIENTO
                    if (_nombre_controladores == "MenuMantenimiento")
                    {
                        mantenimientoToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmProyectos")
                    {
                        proyectosToolStripMenuItem.Visible = true;
                        toolStripSeparator1.Visible = true;
                    }
                    if (_nombre_controladores == "frmTipoIndice")
                    {
                        tipoIndiceToolStripMenuItem.Visible = true;
                        toolStripSeparator2.Visible = true;
                    }
                    if (_nombre_controladores == "frmCaminos")
                    {
                        caminosToolStripMenuItem.Visible = true;
                        toolStripSeparator3.Visible = true;
                    }
                    if (_nombre_controladores == "frmCartonDocumentos")
                    {
                        cartonDocumentosToolStripMenuItem.Visible = true;
                        toolStripSeparator4.Visible = true;
                    }
                    if (_nombre_controladores == "frmEstado")
                    {
                        estadoToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmIndice")
                    {
                        indiceToolStripMenuItem.Visible = true;
                        toolStripSeparator5.Visible = true;
                    }
                    if (_nombre_controladores == "frmAsignar")
                    {
                        asignarToolStripMenuItem.Visible = true;
                    }

                    // MENU GESTION XML

                    if (_nombre_controladores == "GestionXML")
                    {
                        gestionXMLToolStripMenuItem.Visible = true;
                    }
                    if (_nombre_controladores == "frmCarpetasCrea")
                    {
                        crearXMLToolStripMenuItem.Visible = true;
                        toolStripSeparator7.Visible = true;
                    }
                    if (_nombre_controladores == "frmCarpetasCalidadXML")
                    {
                        controlarCalidadXMLToolStripMenuItem.Visible = true;
                        toolStripSeparator8.Visible = true;
                        toolStripSeparator9.Visible = true;
                    }

                    // ACCESOS RAPIDOS

                    if (_nombre_controladores == "frmUsuarios")
                    {
                        toolStripButton4.Visible = true;
                    }
                    if (_nombre_controladores == "frmProyectos")
                    {
                        toolStripButton5.Visible = true;
                    }
                    if (_nombre_controladores == "frmTipoIndice")
                    {
                        toolStripButton6.Visible = true;
                    }
                    if (_nombre_controladores == "frmCaminos")
                    {
                        toolStripButton7.Visible = true;
                    }
                    if (_nombre_controladores == "frmCartonDocumentos")
                    {
                        toolStripButton8.Visible = true;
                    }
                    if (_nombre_controladores == "frmIndice")
                    {
                        toolStripButton10.Visible = true;
                    }
                    if (_nombre_controladores == "frmCarpetasCrea")
                    {
                        toolStripButton11.Visible = true;
                    }
                    if (_nombre_controladores == "frmCarpetasCalidadXML")
                    {
                        toolStripButton12.Visible = true;
                    }




                }
                else
                {

                    //MENU ADMINISTRACION

                    administraciónToolStripMenuItem.Visible = false;
                    usuariosToolStripMenuItem.Visible = false;
                    rolesToolStripMenuItem.Visible = false;
                    controladoresToolStripMenuItem.Visible = false;
                    permisosRolesToolStripMenuItem.Visible = false;
                    formulariosToolStripMenuItem.Visible = false;
                    licenciasToolStripMenuItem.Visible = false;

                    // MENU MANTENIMIENTO
                    mantenimientoToolStripMenuItem.Visible = false;
                    proyectosToolStripMenuItem.Visible = false;
                    tipoIndiceToolStripMenuItem.Visible = false;
                    caminosToolStripMenuItem.Visible = false;
                    cartonDocumentosToolStripMenuItem.Visible = false;
                    estadoToolStripMenuItem.Visible = false;
                    indiceToolStripMenuItem.Visible = false;
                    asignarToolStripMenuItem.Visible = false;

                    // MENU GESTION XML

                    gestionXMLToolStripMenuItem.Visible = false;
                    crearXMLToolStripMenuItem.Visible = false;
                    controlarCalidadXMLToolStripMenuItem.Visible = false;

                    // ACCESOS RAPIDOS

                    toolStripButton4.Visible = false;
                    toolStripButton5.Visible = false;
                    toolStripButton6.Visible = false;
                    toolStripButton7.Visible = false;
                    toolStripButton8.Visible = false;
                    toolStripButton10.Visible = false;
                    toolStripButton11.Visible = false;
                    toolStripButton12.Visible = false;
                    
                    //ESPACIOS
                    toolStripSeparator1.Visible = false;
                    toolStripSeparator2.Visible = false;
                    toolStripSeparator3.Visible = false;
                    toolStripSeparator4.Visible = false;
                    toolStripSeparator5.Visible = false;
                    toolStripSeparator7.Visible = false;
                    toolStripSeparator8.Visible = false;
                    toolStripSeparator9.Visible = false;
                }

            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crearXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidad frm = new frmCarpetasCalidad();
            frm._id_usuarios = _id_usuarios;
            frm.Show();


        }

        private void controlarCalidadXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidadXML frm = new frmCarpetasCalidadXML();
           // frm._id_usuarios = _id_usuarios;
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.Show();
        }

        private void frmMenucs_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Desea cerrar el programa?",
              "Cerrar el programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

       

        private void rolesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmRoles frm = new frmRoles();
            frm.Show();
        }

        private void controladoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmControladores frm = new frmControladores();
            frm.Show();
        }

        private void permisosRolesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPermisosRoles frm = new frmPermisosRoles();
            frm.Show();
        }

        private void proyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            frm.Show();
        }

        private void formulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormularios frm = new frmFormularios();
            frm.Show();
        }

        private void tipoIndiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoIndice frm = new frmTipoIndice();
            frm.Show();
        }

        private void caminosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCaminos frm = new frmCaminos();
            frm.Show();
        }

        private void cartonDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCartonDocumentos frm = new frmCartonDocumentos();
            frm.Show();
        }

        private void estadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstado frm = new frmEstado();
            frm.Show();
        }

        private void indiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIndice frm = new frmIndice();
            frm.Show();
        }

        private void caminosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable daProyectos = AccesoLogica.Select("proyectos.id_proyectos, proyectos.nombre_proyectos, proyectos.observaciones_proyectos, proyectos.creado, proyectos.modificado ", "public.proyectos", "proyectos.id_proyectos>0");
            int registro = daProyectos.Rows.Count;

            if (registro > 0)
            {
                reportes.contProyectos frm = new reportes.contProyectos();
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            
        }

        private void caminosToolStripMenuItem2_Click(object sender, EventArgs e)
        {


            DataTable daTipoIndice = AccesoLogica.Select("tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, tipo_indice.creado, tipo_indice.modificado ", "public.tipo_indice", "tipo_indice.id_tipo_indice>0");
            int registro = daTipoIndice.Rows.Count;

            if (registro > 0)
            {
                reportes.contTipoIndice frm = new reportes.contTipoIndice();
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void caminosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            reportes.FiltroCaminos frm = new reportes.FiltroCaminos();
            frm.Show();
        }

        private void cartónDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DataTable daCartonDocumentos = AccesoLogica.Select("carton_documentos.id_carton_documentos, carton_documentos.numero_carton_documentos, carton_documentos.estado_carton_documentos, carton_documentos.creado, carton_documentos.modificado ", "public.carton_documentos", "carton_documentos.id_carton_documentos>0");
            int registro = daCartonDocumentos.Rows.Count;

            if (registro > 0)
            {
                reportes.contCartonDocumentos frm = new reportes.contCartonDocumentos();
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void estadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataTable daEstado = AccesoLogica.Select("estado.id_estado, estado.nombre_estado, estado.creado, estado.modificado ", "public.estado", "estado.id_estado>0");
            int registro = daEstado.Rows.Count;

            if (registro > 0)
            {
                reportes.contEstado frm = new reportes.contEstado();
                frm.Show();

            }
            else
            {
                MessageBox.Show("No existe datos en el sistema", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void indiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reportes.FiltroIndice frm = new reportes.FiltroIndice();
            frm.Show();
        }

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            frm.Show();

            
        }

        private void btn_TipoIndice_Click(object sender, EventArgs e)
        {
            frmTipoIndice frm = new frmTipoIndice();
            frm.Show();
        }

        private void btn_Caminos_Click(object sender, EventArgs e)
        {
            frmCaminos frm = new frmCaminos();
            frm.Show();
        }

        private void btn_Caminos_Click_1(object sender, EventArgs e)
        {
            frmCaminos frm = new frmCaminos();
            frm.Show();
        }

        private void btn_Caminos_Click_2(object sender, EventArgs e)
        {
            frmCaminos frm = new frmCaminos();
            frm.Show();
        }

        private void btn_CartonDocumentos_Click(object sender, EventArgs e)
        {
            frmCartonDocumentos frm = new frmCartonDocumentos();
            frm.Show();
        }

        private void btn_Estado_Click(object sender, EventArgs e)
        {
            frmEstado frm = new frmEstado();
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmIndice frm = new frmIndice();
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidad frm = new frmCarpetasCalidad();
            frm._id_usuarios = _id_usuarios;
            frm.Show();

        }

       

        private void btn_control_calidad_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidadXML frm = new frmCarpetasCalidadXML();
            frm.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            frmProyectos frm = new frmProyectos();
            frm.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmTipoIndice frm = new frmTipoIndice();
            frm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            frmCaminos frm = new frmCaminos();
            frm.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            frmCartonDocumentos frm = new frmCartonDocumentos();
            frm.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmEstado frm = new frmEstado();
            frm.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            frmIndice frm = new frmIndice();
            frm.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidad frm = new frmCarpetasCalidad();
            frm._id_usuarios = _id_usuarios;
            frm.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            frmCarpetasCalidadXML frm = new frmCarpetasCalidadXML();
            frm._id_usuarios = _id_usuarios;
            frm.Show();
        }

        private void producciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportes.FiltroUsuarios frm = new reportes.FiltroUsuarios();
            frm.Show();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignar frm = new frmAsignar();
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("¿Seguro desea cerrar la sesion?",
                "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes)
            {
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Hide();
            }
            else
            {


            }
        }
     private void licenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstalarLicencias frm = new InstalarLicencias();
            frm.Show();
        }

        private void licenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reportes.FiltroLicencias frm = new reportes.FiltroLicencias();
            frm.Show();
        }
      private void edicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportes.FiltroUsuarioEdita frm = new reportes.FiltroUsuarioEdita();
            frm.Show();
        }
    }
}
