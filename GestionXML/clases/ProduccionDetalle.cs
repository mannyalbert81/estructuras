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
    public class ProduccionDetalle
    {
        public static void InsertaProduccionDetalle(int _id_produccion_cabeza, int _id_caminos, string _nombre_produccion_detalle, DateTime _inicio_produccion_detalle, DateTime _fin_produccion_detalle, int _id_usuarios_crea)
        {
           
            string datos = _id_produccion_cabeza + "?" + _id_caminos + "?" + _nombre_produccion_detalle + "?" + _inicio_produccion_detalle + "?" + _fin_produccion_detalle + "?" + _id_usuarios_crea;
            string columnas = "_id_produccion_cabeza?_id_caminos?_nombre_produccion_detalle?_inicio_produccion_detalle?_fin_produccion_detalle?_id_usuarios_crea";
            string tipodatos = "NpgsqlDbType.Integer?NpgsqlDbType.Integer?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.DateTime?NpgsqlDbType.Integer";
            //hola
            try
            {
                int result = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_produccion_detalle");

               // HOLA
            }
            catch (NpgsqlException Ex)
            {
                MessageBox.Show(Ex.Message,"No se Pudo Guardar el registro en la Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            MessageBox.Show("Se ha Registrado Correctamente", "Guardado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}