using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Npgsql;
using System.Security.Cryptography;

namespace Negocio
{
    public class AccesoLogica
    {



       public static string clavesita = ".Romina.2012"; // Clave de cifrado. NOTA: Puede ser cualquier combinación de carácteres.

       
        // Función para cifrar una cadena.
        public static string cifrar(string cadena)
        {

            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.

            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clavesita));
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

        // Función para descifrar una cadena.
        public static string descifrar(string cadena)
        {

            byte[] llave;

            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.

            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(clavesita));
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



        public static bool Autenticar(string usuario, string password)
        {
            Consultas fun = new Consultas();
            DataTable tabla = fun.Select("*", "usuario", "usuario_usuario = '" + usuario + "'  AND clave_usuario = '" + password + "'");

            int registros = tabla.Rows.Count;
            if (registros > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static global::Npgsql.NpgsqlDataAdapter Select_proyectos(string v)
        {
            throw new NotImplementedException();
        }

        public static DataTable Select(string comando)
        {
            Consultas fun = new Consultas();
            return fun.Select(comando);
        }

        public static DataTable Select(string columnas, string tabla)
        {
            Consultas fun = new Consultas();
            return fun.Select(columnas, tabla);
        }

        public static DataTable Select(string columnas, string tabla, string where)
        {
            Consultas fun = new Consultas();
            return fun.Select(columnas, tabla, where);
        }

        public static DataTable Select_inner_join(string cadena1, string tabla_uno, string tabla_dos, string parametro)
        {
            Consultas fun = new Consultas();
            return fun.Select_inner_join(cadena1, tabla_uno, tabla_dos, parametro);

        }
        public static DataTable Select_secuencia(string secuencia, string AS_nombre)
        {
            Consultas fun = new Consultas();
            return fun.Select_secuencia(secuencia, AS_nombre);

        }
      

        public static int Insert(string datos, string columnas, string tabla)
        {
            Consultas fun = new Consultas();
            return fun.Insert(datos, columnas, tabla);
        }

        public static int Insert(string datos, string columnas, string tipoDatos, string funcion)
        {
            Consultas fun = new Consultas();
            return fun.Insert(datos, columnas, tipoDatos, funcion);
        }

        public static int Delete(string where, string tabla)
        {
            Consultas fun = new Consultas();
            return fun.Delete(where, tabla);
        }

        public static int Update(string tabla, string campo, string where)
        {
            Consultas fun = new Consultas();
            return fun.Update(tabla, campo, where);
        }

        public static NpgsqlDataAdapter Select_reporte(string cadena1, string tabla, string parametro)
        {
            Consultas fun = new Consultas();
            return fun.Select_reporte(cadena1, tabla, parametro);

        }



        //DOS

        public static DataTable Select2(string comando)
        {
            Consultas fun = new Consultas();
            return fun.Select2(comando);
        }

        public static DataTable Select2(string columnas, string tabla)
        {
            Consultas fun = new Consultas();
            return fun.Select2(columnas, tabla);
        }

        public static DataTable Select2(string columnas, string tabla, string where)
        {
            Consultas fun = new Consultas();
            return fun.Select2(columnas, tabla, where);
        }
        

    }
}
