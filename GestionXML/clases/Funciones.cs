using System;
using System.Collections.Generic;
using System.Linq;
using Negocio;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GestionXML.clases
{
    public class Funciones
    {
        public static void CargarCombo(System.Windows.Forms.ComboBox cmb, string id, string columna, string tabla)
        {
            
            try
            {
                    cmb.Items.Insert(0, "Seleccione..");
                    cmb.DataSource = AccesoLogica.Select(id + ", " + columna, tabla);
                    cmb.DisplayMember = columna;
                    cmb.ValueMember = id;
                    cmb.SelectedIndex = 0;
                
            }
            catch
            {

            }
           
        }

        

        public static void CargarComboWhere(System.Windows.Forms.ComboBox cmb, string id, string columna, string tabla, string where)
        {
         
            try
            {
                cmb.Items.Insert(0, "Seleccione..");
                cmb.DataSource = AccesoLogica.Select(id + ", " + columna, tabla, where);
                cmb.DisplayMember = columna;
                cmb.ValueMember = id;
                cmb.SelectedIndex = 0;

            }
            catch
            {

            }

        }


        public static void CargarCombo_inner(System.Windows.Forms.ComboBox cmb, string id, string columna, string tabla_uno, string tabla_dos, string parametro)
        {
            try
            {
                cmb.Items.Insert(0, "< Seleccione >");
                cmb.DataSource = AccesoLogica.Select_inner_join(id + ", " + columna, tabla_uno, tabla_dos, parametro);
                cmb.DisplayMember = columna;
                cmb.ValueMember = id;
                cmb.SelectedIndex = 0;

            }
            catch
            {

            }
        }
        


        public static void CargarGridView(System.Windows.Forms.DataGridView gridView, string columnas, string tabla, string titulos)
        {
            try
            {
                gridView.DataSource = AccesoLogica.Select(columnas, tabla);
                gridView.DataMember = tabla;

                int reg = Convert.ToInt32(gridView.Rows.Count);
                string[] vectorTitulos = Vector(titulos);
                for (int i = 1; i <= vectorTitulos.Length; i++)
                {
                    gridView.Columns[i].HeaderCell.Value = vectorTitulos[i - 1];
                }
            }
            catch
            {

            }
        }

        public static void CargarGridView(System.Windows.Forms.DataGridView gridView, string columnas, string tabla, string where, string titulos)
        {
            try
            {
                gridView.DataSource = AccesoLogica.Select(columnas, tabla, where);
                gridView.DataMember = "";
                int reg = Convert.ToInt32(gridView.Rows.Count);
                string[] vectorTitulos = Vector(titulos);
                for (int i = 1; i <= vectorTitulos.Length; i++)
                {
                    gridView.Columns[i].HeaderCell.Value = vectorTitulos[i];
                }
            }
            catch
            {

            }
        }





        public static Boolean vacio(string cadena)
        {
            if (cadena == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean letras(string cadena)
        {
            char[] aux = cadena.ToCharArray();

            for (int i = 0; i < aux.Length; i++)
            {
                if (char.IsLetter(aux[i] + "", 0) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean numeros(string cadena)
        {
            char[] aux = cadena.ToCharArray();

            for (int i = 0; i < aux.Length; i++)
            {
                if (char.IsNumber(aux[i] + "", 0) == false)
                {
                    return true;
                }
            }
            return false;
        }

        public static string validar_cedula(string cedula)
        {
            char[] ced;
            int sumat = 0, sumai = 0, sump = 0, resta = 0, id = 0;
            ced = cedula.ToArray();
            int valor;
            if (ced.Length == 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    valor = Convert.ToInt32((Convert.ToString(ced[i])));
                    if (i % 2 == 0)
                    {
                        valor = valor * 2;

                        if (valor > 9)
                        {
                            valor = valor - 9;
                            sumai = sumai + valor;

                        }
                        else
                        {
                            sumai = sumai + valor;

                        }
                    }
                    else
                    {
                        sump = sump + valor;
                    }

                    sumat = sump + sumai;
                }

                resta = sumat % 10;
                if (resta == 0)
                {
                    //return "";
                }
                else
                {
                    id = 10 - resta;
                }
                if (id == Convert.ToInt32(Convert.ToString(ced[9])))
                {
                    return "";
                }

                else
                {
                    return "Cédula Incorrecta";
                }
            }
            else
            {
                return "Cédula Incorrecta";
            }
        }

        public static Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        public static string[] Vector(string cadena)
        {
            string[] vector;

            if (cadena.Contains('?'))
            {
                vector = cadena.Split('?');
            }
            else
            {
                vector = new string[1];
                vector[0] = cadena;
            }
            return vector;
        }

        public static DateTime StringaFecha(string _fecha)
        {

            DateTime MyDateTime;
            MyDateTime = new DateTime();
            MyDateTime = DateTime.ParseExact(_fecha, "dd/MM/yyyy HH:mm:ss", null);

            return MyDateTime;

        }

        public static byte[] Image2Bytes(Image pImagen)
        {
            byte[] mImage = null;
            try
            {
                if (pImagen != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        pImagen.Save(ms, pImagen.RawFormat);
                        mImage = ms.GetBuffer();
                        ms.Close();
                    }
                }
                else { mImage = null; }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return mImage;
        }

        public static Image Bytes2Image(byte[] bytes)
        {
            if (bytes == null) return null;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Bitmap bm = null;
                try
                {
                    bm = new Bitmap(ms);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                return bm;
            }
        }

        public static string enviar_correo(string _email_destinatario, string _nombres, string _actividad, string _fecha_hora, string _accion)
        {


            string _destinatarioCC = "mannyalbert81@yahoo.com";
            string _enviado_desde = "info@masoft.net";
            string _enviado_desde_pass = "Info2014";
            string _cliente_host = "smtp.ipage.com";
            string _asunto = "- KIOTO SYSTEM - Registra su entrada al Campus Party Quito";
            //"vilcabamba.yamburara.net";

            //if (_email_destinatario.Length > 0)



            string _error = "";
            string _texto = "";

            StringBuilder myBuilder = new StringBuilder();

            myBuilder.Append("Estimado/a:  '" + _nombres + "'.  ");
            myBuilder.Append("Hemos registrado tu '" + _accion + "'  al Campus Party Quito el: '" + _fecha_hora + "'  ");
            myBuilder.Append("En calidad de '" + _actividad + "'   ");

            myBuilder.Append(" ");
            myBuilder.Append(" ");
            myBuilder.Append(" ");
            myBuilder.Append("En Kioto System nos esforzamos en proporcionarle un servicio y un soporte técnico puntual y oportuno. Si tiene cualquier duda o consulta no dude en contactar con nosotros. ");
            myBuilder.Append("http://kiotosystem.com");
            myBuilder.Append("info@kiotosystem.com");
            myBuilder.Append("Celular: 099 519 5495");

            _texto = myBuilder.ToString();




            /*-------------------------MENSAJE DE CORREO----------------------*/

            //Creamos un nuevo Objeto de mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

            //Direccion de correo electronico a la que queremos enviar el mensaje
            mmsg.To.Add(_email_destinatario);

            //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

            //Asunto
            mmsg.Subject = _asunto;
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //Direccion de correo electronico que queremos que reciba una copia del mensaje
            mmsg.Bcc.Add(_destinatarioCC); //Opcional

            //Cuerpo del Mensaje
            mmsg.Body = _texto + "----> Este Mensaje ha sigo generado por el Sistema de Gestion de OQMED www.sistemadegestion.oqmed.com <--- ";

            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

            //Correo electronico desde la que enviamos el mensaje
            mmsg.From = new System.Net.Mail.MailAddress(_enviado_desde);


            /*-------------------------CLIENTE DE CORREO----------------------*/

            //Creamos un objeto de cliente de correo
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            //Hay que crear las credenciales del correo emisor
            cliente.Credentials =
                new System.Net.NetworkCredential(_enviado_desde, _enviado_desde_pass);

            cliente.Port = 587;

            //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail
            /*

            cliente.EnableSsl = true;
            */

            cliente.Host = _cliente_host; //Para Gmail "smtp.gmail.com";


            /*-------------------------ENVIO DE CORREO----------------------*/

            try
            {
                //Enviamos el mensaje      
                cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException)
            {
                _error = "No se Pudo enviar el Correo ";
            }

            return _error;

        }


        public static string clave = "manuelalbertorosabal";

        public static string cifrar(string cadena)
        {

            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.

            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }

        public static string descifrar(string cadena)
        {

            byte[] llave;

            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clave));
            md5.Clear();

            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            return cadena_descifrada; // Devolvemos la cadena
        }

    }
}
