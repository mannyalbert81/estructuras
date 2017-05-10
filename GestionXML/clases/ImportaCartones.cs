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
    public class ImportaCartones
    {
        public static void Inserta()
        {

            string numero_carton_documentos;
            bool estado_carton_documentos;

            DataTable dtCartonesOrigen = AccesoLogica.Select2(" * ", "carton_documentos", "id_carton_documentos > 0");
            int reg = dtCartonesOrigen.Rows.Count;
            
            if (reg > 0)
            {
                //hola
                foreach (DataRow renglon in dtCartonesOrigen.Rows)
                {
                    try
                    {
                        numero_carton_documentos = Convert.ToString(renglon["numero_carton_documentos"].ToString());
                        estado_carton_documentos = Convert.ToBoolean(renglon["estado_carton_documentos"].ToString());

                        string datos = numero_carton_documentos + "?" + estado_carton_documentos;
                        string columnas = "_numero_carton_documentos?_estado_carton_documentos?";
                        string tipodatos = "NpgsqlDbType.Varchar?NpgsqlDbType.Boolean";

                        try
                        {
                            int result = AccesoLogica.Insert(datos, columnas, tipodatos, "ins_carton_documentos");

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
            }
            else
            {
                MessageBox.Show("No encontre Registros", "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}