﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Datos
{
    class MetodosDatos
    {
        public static string cadenaConexion = @"Server=186.4.241.148;Port=5432;User Id=postgres;Password=.Romina.2012;Database=xml;Preload Reader = true;";
        //DOS
        public static string cadenaConexion2 = @"Server=186.4.241.148;Port=5433;User Id=postgres;Password=.Romina.2012;Database=ad_territorial_cor;Preload Reader = true;";
        //186.65.24.196

        public static DataTable EjecutarConsula(string comando)
        {
            DataTable data = new DataTable();
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
                conexion.Open();
                NpgsqlDataAdapter consulta = new NpgsqlDataAdapter(comando, conexion);
                conexion.Close();
                consulta.Fill(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }

        public static NpgsqlCommand CrearComandoProc(string nombre_proc)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
            NpgsqlCommand comando = new NpgsqlCommand(nombre_proc, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }

        public static int EjecutarComando(NpgsqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }

    //DOS
        /// 


        public static DataTable EjecutarConsula2(string comando)
        {
            DataTable data = new DataTable();
            try
            {
                NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion2);
                conexion.Open();
                NpgsqlDataAdapter consulta = new NpgsqlDataAdapter(comando, conexion);
                conexion.Close();
                consulta.Fill(data);
            }
            catch (Exception ex)
            {
                
            }

            return data;
        }

        public static NpgsqlCommand CrearComandoProc2(string nombre_proc)
        {
            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion2);
            NpgsqlCommand comando = new NpgsqlCommand(nombre_proc, conexion);
            comando.CommandType = CommandType.StoredProcedure;
            return comando;
        }

        public static int EjecutarComando2(NpgsqlCommand comando)
        {
            try
            {
                comando.Connection.Open();
                return comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                comando.Connection.Dispose();
                comando.Connection.Close();
            }
        }



    }
}
