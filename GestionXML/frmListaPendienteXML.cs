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
    public partial class frmListaPendienteXML : Form
    {
        public  string _path_camino = "";
        public int _id_camino;
        public int _id_usuarios;

        public frmListaPendienteXML()
        {
            InitializeComponent();
        }

        private void frmCreaXML_Load(object sender, EventArgs e)
        {
            //cmbEquipos.SelectedIndex = 0;
            

            lblCamino.Text = _path_camino;


            //cargo los pdf
            CargaGrid(0);
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridView1.CurrentRow;
            string _camino = Convert.ToString(fila.Cells[2].Value); //obtengo el valor de la primer columna


            ////busco el id del indice cabeza
            string _parametros = " id_caminos = '" + _id_camino + "'   ";
            
            int _id_indice_cabeza = 0;

            DataTable dtCaminos = AccesoLogica.Select("id_indice_cabeza", "indice_cabeza", _parametros);
            int reg = dtCaminos.Rows.Count;
            if (reg > 0)
            {
                foreach (DataRow renglon in dtCaminos.Rows)
                {
                    _id_indice_cabeza = Convert.ToInt32(renglon["id_indice_cabeza"].ToString());
                }
            }


            DialogResult result = MessageBox.Show("Deseas Crear XML de este PDF?", "Crear nuevo XML", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                CreadorXML Crea = new CreadorXML();   
                Crea.nombre_pdf = _camino;
                Crea._id_indice_cabeza = _id_indice_cabeza;
                Crea._id_usuarios = _id_usuarios;
                Crea._id_camino = _id_camino;
                Crea.Show();
            }
            if (result == DialogResult.No)
            {
            }

        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
                CargaGrid(1);
           
        }


        public void CargaGrid(int _tipo)
        {
            dataGridView1.Rows.Clear();

            DirectoryInfo directory = new DirectoryInfo(@_path_camino);
            FileInfo[] filesPDF = directory.GetFiles("*.PDF");
            FileInfo[] filesXML = directory.GetFiles("*.XML");

            DataTable dtXML = new DataTable();
            dtXML.Columns.Add("nombre");

            string _nombre_xml = "";
            int _cantidadXMLCrear = 0;

            for (int ii = 0; ii < filesXML.Length; ii++)
            {
                _nombre_xml = ((FileInfo)filesXML[ii]).FullName;
            
                dtXML.Rows.Add(_nombre_xml);
                _cantidadXMLCrear++;

            }

            DirectoryInfo[] directories = directory.GetDirectories();
            string _nombre_pdf = "";
            DateTime _date_creado_pdf = DateTime.Now;
            string _nombre_pdf_name = "";
            int _agregados = 0;
            string _equipo = "";
            for (int i = 0; i < filesPDF.Length; i++)
            {
                
                _nombre_pdf = ((FileInfo)filesPDF[i]).FullName;
                _date_creado_pdf = File.GetLastWriteTime(filesPDF[i].FullName);
                _nombre_pdf_name = ((FileInfo)filesPDF[i]).Name;
           
                DataRow[] foundRows = null;
                try
                {
                    foundRows = dtXML.Select("nombre = '" + _nombre_pdf.Replace(".pdf", ".XML") + "'   ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Archivo: ----  "+ _nombre_pdf );
                }

                
                if (foundRows.Length == 0)
                {


                    if (_tipo == 0)
                    {
                        
                            dataGridView1.Rows.Insert(_agregados, _agregados + 1, _date_creado_pdf, _nombre_pdf);
                            _agregados++;
                        
                    }
                    



                    /* 
                    if (_tipo == 1)
                    {
                    
                        _equipo = cmbEquipos.SelectedItem.ToString();

                        if (_equipo == "TODOS")
                        {

                            dataGridView1.Rows.Insert(_agregados, _agregados + 1, _date_creado_pdf , _nombre_pdf);
                            _agregados++;
                        }
                        else if (_equipo == _nombre_pdf_name.Substring(0, 7))
                        {
                            dataGridView1.Rows.Insert(_agregados, _agregados + 1, _date_creado_pdf , _nombre_pdf);
                            _agregados++;
                        }

                    }
                    */

                    if (_tipo == 2)
                    {
                        

                        _equipo = txtNombreArchivo.Text.ToString()  ;
                        
                        bool b = _nombre_pdf_name.Contains(_equipo);

                        if (_equipo == "TODOS")
                        {

                            dataGridView1.Rows.Insert(_agregados, _agregados + 1, _date_creado_pdf, _nombre_pdf);
                            _agregados++;
                        }
                        else if (b)
                        {
                            dataGridView1.Rows.Insert(_agregados, _agregados + 1, _date_creado_pdf, _nombre_pdf);
                            _agregados++;

                        }
                    }



                   
                    
                }
                


            }

            //_path_completo.Replace(".XML", ".pdf")


        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {

        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {

        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {

            CargaGrid(1);

        }

        private void txtNombreArchivo_TextChanged(object sender, EventArgs e)
        {
            
           CargaGrid(2);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //cargo los pdf
            CargaGrid(0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
