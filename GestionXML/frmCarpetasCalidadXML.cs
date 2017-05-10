using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace GestionXML
{
    public partial class frmCarpetasCalidadXML : Form
    {
        public int _id_usuarios;

        public frmCarpetasCalidadXML()
        {
            InitializeComponent();
        }



        private void frmCarpetasCalidadXML_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(cbm_proyectos, "id_proyectos", "nombre_proyectos", "proyectos");
        }




        private void btnCargar_Click(object sender, EventArgs e)
        {
            int _id_proyectos = Convert.ToInt32(cbm_proyectos.SelectedValue.ToString());
            string _parametro = "id_proyectos = '" + _id_proyectos + "' GROUP BY caminos.nombre_caminos, caminos.path_caminos  ";
            llenar_grid(_parametro);
        }

        

        private void llenar_grid(string _parametro)
        {
            //clases.Funciones.CargarGridView(dataGridView1, "caminos.id_caminos AS Id, caminos.nombre_caminos, caminos.path_caminos, usuarios.nombre_usuarios, proyectos.nombre_proyectos, caminos.creado, caminos.modificado", "public.caminos, public.usuarios, public.proyectos", _parametro, "Id?Nombre Camino?Path?Usuario Registra?Nombre Proyecto?Creado?Modificado");

            ///leer los caminos
            int _counter_caminos = 0;

            int _counter_xml = 0;
            int _counter_dif = 0;
            

            string _nombre_caminos;
            string _path_caminos;
            int _creados;
            int _editado;
            int _diferencia;

            
            dataGridView1.Rows.Clear();

            DataTable dtCaminos = AccesoLogica.Select("caminos.nombre_caminos, caminos.path_caminos, SUM(produccion_cabeza.xml_creados_produccion_cabeza) AS creados, SUM(produccion_cabeza.xml_editados_produccion_cabeza) AS editado, SUM(produccion_cabeza.xml_creados_produccion_cabeza) - SUM(produccion_cabeza.xml_editados_produccion_cabeza) AS diferencia", "public.caminos, public.produccion_cabeza", _parametro);
            int reg = dtCaminos.Rows.Count;
            if (reg > 0)
            {
                foreach (DataRow renglon in dtCaminos.Rows)
                {
                    _nombre_caminos = Convert.ToString(renglon["nombre_caminos"].ToString());
                    _path_caminos = Convert.ToString(renglon["path_caminos"].ToString());
                    _creados = Convert.ToInt32(renglon["creados"].ToString());
                    _editado = Convert.ToInt32(renglon["editado"].ToString());
                    _diferencia = Convert.ToInt32(renglon["diferencia"].ToString());
                    
                    ///leo los camino
                    DirectoryInfo directory = new DirectoryInfo(@_path_caminos);
                    FileInfo[] filesXML = directory.GetFiles("*.XML");
                    DirectoryInfo[] directories = directory.GetDirectories();


                    for (int i = 0; i < filesXML.Length; i++)
                    {
                        _counter_xml++;

                    }

                    _counter_dif =  _counter_xml;
                    dataGridView1.Rows.Insert(_counter_caminos, _counter_caminos + 1, _nombre_caminos, _path_caminos, _creados, _editado, _diferencia);
                    _counter_caminos++;
                    
                }


            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;
            string _nombre_camino = Convert.ToString(fila.Cells[1].Value); //obtengo el valor de la primer columna
            string _camino = Convert.ToString(fila.Cells[2].Value); //obtengo el valor de la primer columna
            string _parametros = " nombre_caminos = '" + _nombre_camino + "'     ";
            int _id_caminos = 0;
            DataTable dtCaminos = null;


            try
            {
                dtCaminos = AccesoLogica.Select("id_caminos, nombre_caminos, path_caminos, id_usuarios, id_proyectos", "caminos", _parametros);
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Error Al Consultar Camino->" + Ex.Message);
            }


            int reg2 = dtCaminos.Rows.Count;
            if (reg2 > 0)
            {

                foreach (DataRow renglon in dtCaminos.Rows)
                {
                    _id_caminos = Convert.ToInt32(renglon["id_caminos"].ToString());

                }
            }


            DialogResult result = MessageBox.Show("Deseas Crear XML en esta Carpeta?", "Crear nuevos XML", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                

                frmListaPendienteTXT Crea = new frmListaPendienteTXT();
                Crea._path_camino = _camino;
                Crea._id_camino = _id_caminos;
                Crea._id_usuarios = _id_usuarios;

                Crea.Show();
            }
            if (result == DialogResult.No)
            {
            }
        }

        private void cbm_proyectos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
