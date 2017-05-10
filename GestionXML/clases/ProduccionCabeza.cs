using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using System.Data;
using System.Windows.Forms;
using Npgsql;


namespace GestionXML.clases
{
    public class ProduccionCabeza
    {
        public static void InsertaProduccionCabeza(int _id_usuarios, int _id_caminos, string _nombre_produccion_detalle, DateTime _inicio_produccion_detalle, DateTime _fin_produccion_detalle)
        {
           

            int _id_produccion_cabeza = 0;
            
            int xml_creados_produccion_cabeza = 0;
            int _xml_creados_produccion_cabeza = 0;

            DataTable dtProduccion = AccesoLogica.Select(" * ", "produccion_cabeza", "id_usuarios = '"+ _id_usuarios +"' AND id_caminos = '"+ _id_caminos+"'    ");

            foreach (DataRow renglon in dtProduccion.Rows)
            {
                try
                {
                    //_id_usuarios = Convert.ToInt32(renglon["id_usuarios"].ToString());
                    xml_creados_produccion_cabeza = Convert.ToInt32(renglon["xml_creados_produccion_cabeza"].ToString());
                    //_id_caminos = Convert.ToInt32(renglon["id_caminos"].ToString());

                   
                }
                catch
                {
                    MessageBox.Show("No reccorrio foreach", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            _xml_creados_produccion_cabeza = 1;

            string datos = _id_usuarios + "?" + _xml_creados_produccion_cabeza  + "?" + _id_caminos;
            string columnas = "_id_usuarios?_xml_creados_produccion_cabeza?_id_caminos";
            string tipodatos = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Integer";

            try
            {
                 int result = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_produccion_cabeza");

                DataTable dtProduccion1 = AccesoLogica.Select("id_produccion_cabeza", "produccion_cabeza", "id_usuarios = '" + _id_usuarios + "' AND id_caminos = '" + _id_caminos + "'   ");
                int regProd1 = dtProduccion1.Rows.Count;
                if (regProd1 > 0)
                {



                    foreach (DataRow renglon1 in dtProduccion1.Rows)
                    {

                        _id_produccion_cabeza = Convert.ToInt32(renglon1["id_produccion_cabeza"].ToString());
                    }
                    try
                    {
                        ProduccionDetalle.InsertaProduccionDetalle(_id_produccion_cabeza, _id_caminos, _nombre_produccion_detalle, _inicio_produccion_detalle, _fin_produccion_detalle, _id_usuarios);
                    }
                    catch (NpgsqlException Ex)
                    {
                        MessageBox.Show(Ex.Message, "No se Pudo Guardar el registro en la Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Usuario"+_id_usuarios+ "  Camino:"+_id_caminos);
                    MessageBox.Show("No se ejecuto la funcion del Detalle de la Produccion", "No se Pudo Guardar el registro en la Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }
            }
            catch (NpgsqlException Ex)
            {
                MessageBox.Show(Ex.Message, "No se Pudo Guardar el registro en la Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }
    }
}