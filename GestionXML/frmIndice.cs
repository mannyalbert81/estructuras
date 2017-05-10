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
using Npgsql;

namespace GestionXML
{
    public partial class frmIndice : Form
    {
        public frmIndice()
        {
            InitializeComponent();
        }

        private void frmIndice_Load(object sender, EventArgs e)
        {

                llenar_combomanual();

                clases.Funciones.CargarCombo(cbm_caminos, "id_caminos", "nombre_caminos", "caminos");
                clases.Funciones.CargarCombo(cbm_tipo_indice, "id_tipo_indice", "nombre_tipo_indice", "tipo_indice");
                
                llenar_grid("tipo_indice.id_tipo_indice = temp_indice.id_tipo_indice");

            
        }
        private void llenar_grid(string _parametro)
        {
            clases.Funciones.CargarGridView(dataGridIndice, "temp_indice.id_temp_indice AS Id, tipo_indice.nombre_tipo_indice, temp_indice.nombre_indice_detalle, temp_indice.min_indice_detalle, temp_indice.max_indice_detalle, temp_indice.orden_indice_detalle", "public.temp_indice, public.tipo_indice", _parametro, "Id?Tipo?Nombre Indice?Min?Max?Orden");


        }

        private void llenar_combomanual()
        {

            int valor = 0;
            for (valor = 0; valor < 13; valor++)
            {
                if (valor == 0)
                {
                    comboBox1.Items.Insert(valor, "Seleccione ..");
                }
                else
                {
                    comboBox1.Items.Insert(valor, valor);
                }

            }
            comboBox1.SelectedIndex = 0;
        }

        public void limpiar()
        {

            txt_nombre_indice_detalle.Text = "";
            txt_min.Text = "";
            txt_max.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        public void limpiar1()
        {

            txt_nombre_indice.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int _id_tipo_indice = 0;
            string _nombre_indice_detalle = "";
            int _min_indice_detalle = 0;
            int _max_indice_detalle = 0;
            int _orden_indice_detalle = 0;
            int _id_indice_cabeza1 = 0;
            int _id_indice_cabeza = 0;
            int _id_cam = 0;
            int numeros = 0;
            int registros = 0;
            int _orden_temporal = 0;
            int _orden_detalle = 0;
            string _error = "";
            string _nombre_indice_cabeza = txt_nombre_indice.Text;
            int _id_caminos = Convert.ToInt16(cbm_caminos.SelectedValue.ToString());

            //CONSULTO INDICE CABEZA

            string columnas3 = "indice_cabeza.id_indice_cabeza";
            string tablas3 = "public.indice_cabeza";
            string where3 = "indice_cabeza.nombre_indice_cabeza = '" + _nombre_indice_cabeza + "' AND indice_cabeza.id_caminos = '" + _id_caminos + "'";

            DataTable dtCabeza = AccesoLogica.Select(columnas3, tablas3, where3);

            foreach (DataRow renglon in dtCabeza.Rows)
            {
                _id_indice_cabeza1 = Convert.ToInt32(renglon["id_indice_cabeza"].ToString());
            }



            //CONSULTO TABLA TEMPORAL

            string columnas1 = "temp_indice.id_temp_indice, tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, temp_indice.nombre_indice_detalle, temp_indice.min_indice_detalle, temp_indice.max_indice_detalle, temp_indice.orden_indice_detalle";
            string tablas = "public.tipo_indice,  public.temp_indice";
            string where = "temp_indice.id_tipo_indice = tipo_indice.id_tipo_indice";
            DataTable dtTemporal1 = AccesoLogica.Select(columnas1, tablas, where);
            registros = dtTemporal1.Rows.Count;

            foreach (DataRow renglon in dtTemporal1.Rows)
            {
                _orden_temporal = Convert.ToInt32(renglon["orden_indice_detalle"].ToString());
            }

            //CONSULTO INDICE DETALLE

            string columnas8 = "indice_detalle.orden_indice_detalle";
            string tablas8 = " public.indice_detalle, public.tipo_indice";
            string where8 = "tipo_indice.id_tipo_indice = indice_detalle.id_tipo_indice AND indice_detalle.id_indice_cabeza = '" + _id_indice_cabeza1 + "'";
            DataTable dtDetalle = AccesoLogica.Select(columnas8, tablas8, where8);

            foreach (DataRow renglon8 in dtDetalle.Rows)
            {
                _orden_detalle = Convert.ToInt32(renglon8["orden_indice_detalle"].ToString());
            }

            //CONSULTO INDICE CABEZA

            string columnas50 = "indice_cabeza.nombre_indice_cabeza, caminos.id_caminos";
            string tablas50 = " public.indice_cabeza, public.caminos";
            string where50 = "caminos.id_caminos = indice_cabeza.id_caminos AND indice_cabeza.id_caminos = '" + _id_caminos + "'";
            DataTable dtCabeza50 = AccesoLogica.Select(columnas50, tablas50, where50);

            foreach (DataRow renglon50 in dtCabeza50.Rows)
            {
                _id_cam = Convert.ToInt32(renglon50["id_caminos"].ToString());
            }

            

            if (registros <= 0)
            {
                MessageBox.Show("No existe datos para Guardar", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
             if (registros > 0)
            {

               

                if (_nombre_indice_cabeza.Length == 0)
                {
                    _error = "Debe Indicar un Nombre de Indice Cabeza";
                }

                if (_error.Length == 0)

                {

                    if (_orden_temporal == _orden_detalle) {

                        MessageBox.Show("Ya existe un indice con el Orden " + _orden_detalle, " Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (_id_cam == _id_caminos) {

                        MessageBox.Show("Ya existe un indice con el Camino Seleccionado", " Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {

                        string datos = _nombre_indice_cabeza + "?" + _id_caminos;
                        string columnas = "_nombre_indice_cabeza?_id_caminos";
                        string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Integer";


                        try
                        {
                            int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_indice_cabeza");

                            string columnas15 = "indice_cabeza.id_indice_cabeza";
                            string tablas15 = "public.indice_cabeza";
                            string where15 = "indice_cabeza.nombre_indice_cabeza = '" + _nombre_indice_cabeza + "' AND indice_cabeza.id_caminos = '" + _id_caminos + "'";

                            DataTable dtCabeza15 = AccesoLogica.Select(columnas15, tablas15, where15);

                            foreach (DataRow renglon in dtCabeza15.Rows)
                            {
                                _id_indice_cabeza = Convert.ToInt32(renglon["id_indice_cabeza"].ToString());
                            }

                            foreach (DataRow renglon in dtTemporal1.Rows)
                            {


                                _id_tipo_indice = Convert.ToInt32(renglon["id_tipo_indice"].ToString());
                                _nombre_indice_detalle = Convert.ToString(renglon["nombre_indice_detalle"].ToString());
                                _min_indice_detalle = Convert.ToInt32(renglon["min_indice_detalle"].ToString());
                                _max_indice_detalle = Convert.ToInt32(renglon["max_indice_detalle"].ToString());
                                _orden_indice_detalle = Convert.ToInt32(renglon["orden_indice_detalle"].ToString());

                                string datos2 = _id_indice_cabeza + "?" + _id_tipo_indice + "?" + _nombre_indice_detalle + "?" + _min_indice_detalle + "?" + _max_indice_detalle + "?" + _orden_indice_detalle;
                                string columnas2 = "_id_indice_cabeza?_id_tipo_indice?_min_indice_detalle?_max_indice_detalle?_orden_indice_detalle?_nombre_indice_detalle";
                                string tipodatos2 = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar";


                                try
                                {

                                    int result = AccesoLogica.Insert(datos2, columnas2, tipodatos2, "ins_indice_detalle");

                                    try
                                    {
                                        numeros = numeros + 1;
                                        int resulT = AccesoLogica.Delete("nombre_indice_detalle = '" + _nombre_indice_detalle + "' ", "temp_indice");
                                        llenar_grid("tipo_indice.id_tipo_indice = temp_indice.id_tipo_indice");
                                        limpiar();
                                        limpiar1();
                                    }
                                    catch (NpgsqlException)
                                    {

                                        MessageBox.Show("No se Pudo Sumar", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }



                                }
                                catch (NpgsqlException errores) {

                                    MessageBox.Show(errores.Message, "Error");
                                }



                            }


                        }
                        catch (NpgsqlException)
                        {
                            MessageBox.Show("No se Pudo Guardar el registro en la Base de Datos", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (numeros > 0)
                        {

                            MessageBox.Show("Se ha Registrado Correctamente " + numeros + " Registros", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                }
                else
                {
                    MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            {
                {
                    string _nombre_indice_detalle = txt_nombre_indice_detalle.Text;

                    if (_nombre_indice_detalle.Length == 0)
                    {
                        _nombre_indice_detalle = "%";
                    }

                    llenar_grid("tipo_indice.id_tipo_indice = temp_indice.id_tipo_indice AND temp_indice.nombre_indice_detalle LIKE '" + _nombre_indice_detalle + "'");

                }
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string _error = "";
            if (txt_nombre_indice_detalle.Text.Length == 0)
            {
                _error = "EL nombre de indice detalle no Puede estar Vacio";
            }
            if (_error.Length == 0)
            {
                DialogResult dialogo = MessageBox.Show("¿Seguro desea eliminar este registro?",
                 "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogo == DialogResult.Yes)
                {
                    try
                {
                    string _nombre_indice_detalle = txt_nombre_indice_detalle.Text;
                    int resul = AccesoLogica.Delete("nombre_indice_detalle = '" + _nombre_indice_detalle + "' ", "temp_indice");

                    if (resul == 1)
                    {
                        MessageBox.Show("El Detalle se ha Eliminado Correctamente", "Eliminado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("tipo_indice.id_tipo_indice = temp_indice.id_tipo_indice");
                        
                        limpiar();
                    }
                }
                catch (NpgsqlException)
                {
                    MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
                else
                {
                    
                }
            }
            else
            {
                MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
        private void frmIndice_FormClosing(object sender, FormClosingEventArgs e)
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



        private void button1_Click(object sender, EventArgs e)
        {

            string _error = "";
            string _nombre_indice_detalle = txt_nombre_indice_detalle.Text;
            string _min_indice_detalle = txt_min.Text;
            string _max_indice_detalle = txt_max.Text;
            string _orden_indice_detalle = comboBox1.Text; 
            int _id_tipo_indice = Convert.ToInt32(cbm_tipo_indice.SelectedValue.ToString());
            string _orden = "";
           
            

            if (_nombre_indice_detalle.Length == 0)
            {
                _error = "Debe Indicar un Nombre de Indice Detalle";
            }

            if (_min_indice_detalle.Length == 0)
            {
                _error = "Debe Indicar un Min";
            }

            if (_max_indice_detalle.Length == 0)
            {
                _error = "Debe Indicar un Max";
            }
            if (_orden_indice_detalle == "Seleccione ..")
            {
                _error = "Debe Seleccionar un Orden";
            }
            if (_orden_indice_detalle.Length == 0)
            {
                _error = "Debe Seleccionar un Orden";
            }

            if (_error.Length == 0)
            {

            string columnas1 = "temp_indice.id_temp_indice, tipo_indice.id_tipo_indice, tipo_indice.nombre_tipo_indice, temp_indice.nombre_indice_detalle, temp_indice.min_indice_detalle, temp_indice.max_indice_detalle, temp_indice.orden_indice_detalle";
            string tablas = "public.tipo_indice,  public.temp_indice";
            string where = "temp_indice.id_tipo_indice = tipo_indice.id_tipo_indice";


            DataTable dtTemporal = AccesoLogica.Select(columnas1, tablas, where);
            int registros = dtTemporal.Rows.Count;

            foreach (DataRow renglon in dtTemporal.Rows)
            {
                _orden = Convert.ToString(renglon["orden_indice_detalle"].ToString());
            }

                if (_orden_indice_detalle == _orden)
                {

                    MessageBox.Show("Ya existe un registro con ese Orden", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {

                string datos = _id_tipo_indice + "?" + _nombre_indice_detalle + "?" + _min_indice_detalle + "?" + _max_indice_detalle + "?" + _orden_indice_detalle;
                string columnas = "_id_tipo_indice?_nombre_indice_detalle?_min_indice_detalle?_max_indice_detalle?_orden_indice_detalle";
                string tipodatos = "NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer";


                try
                {
                    int resul = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_temp_indice");
                    if (resul < 0)
                    {
                        MessageBox.Show("El Detalle se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        llenar_grid("tipo_indice.id_tipo_indice = temp_indice.id_tipo_indice");
                        limpiar();
                    }
                }
                catch (NpgsqlException)
                {
                    MessageBox.Show("No se Pudo Guardar el registro en la Base de Datos", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            else
            {
                MessageBox.Show(_error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridIndice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridIndice.CurrentRow; // obtengo la fila actualmente seleccionada en el dataGridView
            txt_nombre_indice_detalle.Text = Convert.ToString(fila.Cells[2].Value);
            cbm_tipo_indice.Text = Convert.ToString(fila.Cells[1].Value);
            txt_min.Text = Convert.ToString(fila.Cells[3].Value);
            txt_max.Text = Convert.ToString(fila.Cells[4].Value);
            comboBox1.Text = Convert.ToString(fila.Cells[5].Value);
        }

        private void min(object sender, KeyPressEventArgs e)
        {
           // MessageBox.Show("Solo se permiten Números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           // e.Handled = true;
           // return;
        }

        private void max(object sender, KeyPressEventArgs e)
        {
          //  MessageBox.Show("Solo se permiten Números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           // e.Handled = true;
           // return;
        }

        private void orden(object sender, KeyPressEventArgs e)
        {
           // MessageBox.Show("Solo se permiten Números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           // e.Handled = true;
           // return;
        }
    }
}
    

