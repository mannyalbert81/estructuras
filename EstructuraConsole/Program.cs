﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;

namespace EstructuraConsole
{
    class Program
    {
        public static string _mes = "10";
        public static string _year = "2015";

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------");
            Console.WriteLine("Mes: " + _mes);
            Console.WriteLine("Año: " + _year);
            Console.WriteLine("-------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Conectando .....");

            //InsertaEstructuras04();
           InsertaEstructuras05();
           //Verificar();
             Console.Read();

        }
        
        

            //SOLO PARA OCTUBRE ///////////////////

        
         public static void InsertaEstructuras04()
        {
            Console.WriteLine("Comienzo a insertar .....");

            //cabeza
            bool _vencida = false;
           
            DateTime FechaActual;
            string _numero_operacion;
            DateTime _fecha_inicio;
            DateTime _fecha_finalizacion;
            double _saldo_actual;
            string _identificacion_cliente;
            double _morosidad;
            double _porcentaje;
            double _interes_ordinario;
            double _interes_mora;
            double _provision_original;
            double _provision_reducido;
            double _provision_constituida;
            string _tipo_operacion;
            double _objeto_fideico;
            double _prima;
            double _cuota_credito;
            string _tipo;
            string _tipo_cartera;

            string _metodologia_calificacion = "";
            string _calificacion_propia = "";
            string _calificacion_homologada = "";
            int _dias_por_vencer = 0;
            int _dias_vencidos_cabecera = 0;

            int creditos = 0;
            int sobregiros = 0;

            
            int registros = 0;
            DataTable dtCabeza = AccesoLogica.Select(" * ", "cabeza_eres_04_ultima", " numero_operacion LIKE '%%' AND vencida='false'  ORDER BY id_cabeza_eres_04");
            int regCabeza = dtCabeza.Rows.Count;

            if (regCabeza > 0)
            {
                foreach (DataRow renglon in dtCabeza.Rows)
                {
                    registros++;
                    _numero_operacion = Convert.ToString(renglon["numero_operacion"].ToString());
                    _fecha_inicio = Convert.ToDateTime(renglon["fecha_inicio"].ToString());
                    _fecha_finalizacion = Convert.ToDateTime(renglon["fecha_finalizacion"].ToString());
                    _saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    _identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    _morosidad = Convert.ToDouble(renglon["morosidad"].ToString());
                    _porcentaje = Convert.ToDouble(renglon["porcentaje"].ToString());
                    _interes_ordinario = Convert.ToDouble(renglon["interes_ordinario"].ToString());
                    _interes_mora = Convert.ToDouble(renglon["interes_mora"].ToString());
                    _provision_original = Convert.ToDouble(renglon["provision_original"].ToString());
                    _provision_reducido = Convert.ToDouble(renglon["provision_reducido"].ToString());
                    _provision_constituida = Convert.ToDouble(renglon["provision_constituida"].ToString());
                    _tipo_operacion = Convert.ToString(renglon["tipo_operacion"].ToString());
                    _objeto_fideico = Convert.ToDouble(renglon["objeto_fideico"].ToString());
                    _prima = Convert.ToDouble(renglon["prima"].ToString());
                    _cuota_credito = Convert.ToDouble(renglon["cuota_credito"].ToString());
                    _tipo = Convert.ToString(renglon["tipo"].ToString());
                    _metodologia_calificacion = Convert.ToString(renglon["metodologia_calificacion"].ToString());
                    _calificacion_propia = Convert.ToString(renglon["calificacion_propia"].ToString());
                    _calificacion_homologada = Convert.ToString(renglon["calificacion_homologada"].ToString());
                    _tipo_cartera = Convert.ToString(renglon["tipo_cartera"].ToString());
                    _dias_vencidos_cabecera = Convert.ToInt32(renglon["dias_morocidad_ere_04"].ToString());


                    Console.WriteLine("==========================================");
                    Console.WriteLine("Registro ->" + registros);
                    Console.WriteLine("Operacion ->" + _numero_operacion);
                    Console.WriteLine("==========================================");

                    if (_tipo == "C")
                    {
                        creditos++;

                        string _tipo_identificacion_eres_04 = "E";
                        if (_identificacion_cliente.Length == 10)
                        {
                            _tipo_identificacion_eres_04 = "C";
                        }
                        if (_identificacion_cliente.Length > 10 && _identificacion_cliente.Length < 14)
                        {
                            _tipo_identificacion_eres_04 = "R";
                        }


                        //2
                        string _identificacion_sujeto_eres_04 = _identificacion_cliente;
                        //3
                        string _numero_operacion_eres_04 = _numero_operacion;
                        //4
                        string _dias_morosidad_eres_04 = "0";

                    
                        int daysInMes = System.DateTime.DaysInMonth(Convert.ToInt16(_year), Convert.ToInt16(_mes));
                        //int daysInMes = System.DateTime.DaysInMonth(2014, 8);
                        string strActual = daysInMes + "/" + _mes + "/" + _year;   //    "01/08/2008";
                        FechaActual = Convert.ToDateTime(strActual);

                        if (FechaActual > _fecha_finalizacion)
                        {
                            TimeSpan ts = FechaActual - _fecha_finalizacion;
                            _dias_morosidad_eres_04 = ts.Days + "";
                            

                            _vencida = true;
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Dias vencidos #" + _dias_morosidad_eres_04 + "  Operacion: " + _numero_operacion);
                            Console.WriteLine("-------------------------");
                            
                        }
                        else
                        {
                            TimeSpan ts = _fecha_finalizacion - FechaActual;
                            // _dias_por_vencer = ts.Days;
                            _dias_morosidad_eres_04 = ts.Days +"";
                            _dias_por_vencer = Convert.ToInt32(_dias_morosidad_eres_04);
                            _vencida = true;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Dias x vencer #" + _dias_por_vencer + "  Operacion: " + _numero_operacion);
                            Console.WriteLine("-------------------------");

                        }

                        //todas las operaciones pasan a vencida 27/092017
                        _vencida = true;
                        //tome valor de morocidad de la cabecera
                        _dias_morosidad_eres_04 = _dias_vencidos_cabecera.ToString();

                        //5
                        string _metodologia_calificacion_eres_04 = "T";
                        //6
                       // string _calificacion_propia_eres_04 = _calificacion_propia;
                        string _calificacion_propia_eres_04 = "";
                        //7
                        string _calificacion_homologada_eres_04 = _calificacion_homologada;
                        //8
                        double _tasa_interes_eres_04 = _porcentaje;

                        //9
                        double _saldo_ubicar = DevuelveSaldoActual(_tipo, _numero_operacion, _saldo_actual, _year, _mes);
                        double _provision_requerida_original_eres_04 = 0;
                        double _provision_constituida_eres_04 = 0;
                        double _cartera_castigada_eres_04 = 0;



                        int _dias_para_calificacion = Convert.ToInt32(_dias_morosidad_eres_04);
                        if (_tipo_cartera == "COMERCIAL")
                        {
                          
                            if (_dias_para_calificacion<=0) {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion>=1 && _dias_para_calificacion <= 15) {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 60)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 61 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 121 && _dias_para_calificacion <= 180)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 181 && _dias_para_calificacion <= 360)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion >360)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "CONSUMO") {
                           
                            if(_dias_para_calificacion<15)
                            {
                                    _dias_para_calificacion = 16;
                            }
                            
                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 8)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 9 && _dias_para_calificacion <= 15)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 45)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 46 && _dias_para_calificacion <= 70)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 71 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 120)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "VIVIENDA")
                        {
                            
                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 60)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 61 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 121 && _dias_para_calificacion <= 180)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 181 && _dias_para_calificacion <= 210)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 211 && _dias_para_calificacion <= 270)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 271 && _dias_para_calificacion <= 450)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 450)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "MICROCREDITO")
                        {
                            if (_dias_para_calificacion < 15)
                            {
                                _dias_para_calificacion = 16;
                            }

                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 8)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 9 && _dias_para_calificacion <= 15)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 45)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 46 && _dias_para_calificacion <= 70)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 71 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 120)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }

                        //cambio 27/09/2017
                        //todos las epraciones pasan a calificacion vencida
                        _calificacion_propia_eres_04 = "E";

                        if (_calificacion_propia_eres_04 == "A1")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.01;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "A2")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.02;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "A3")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.05;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "B1")
                        {
                             //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.09;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "B2")
                        {
                            // _provision_requerida_original_eres_04 = _saldo_ubicar * 0.19;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "C1")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.39;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "C2")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.59;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "D")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.99;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "E")
                        {
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                            _cartera_castigada_eres_04 = _saldo_ubicar;
                        }

                        
                        double _cuota = DevuelveAbonos(_tipo, _numero_operacion, _saldo_actual, _year, _mes);

                        //10
                        double _valor_vencer_1_a_30_eres_04 = 0;
                        double _valor_vencer_31_a_90_eres_04 = 0;
                        double _valor_vencer_91_a_180_eres_04 = 0;
                        double _valor_vencer_181_a_360_eres_04 = 0;
                        double _valor_vencer_mas_360_eres_04 = 0;
                        double _valor_no_devenga_interes_1_a_30_eres_04 = 0;
                        double _valor_no_devenga_interes_31_a_90_eres_04 = 0;
                        double _valor_no_devenga_interes_91_a_180_eres_04 = 0;
                        double _valor_no_devenga_interes_181_a_360_eres_04 = 0;
                        double _valor_no_devenga_interes_mas_360_eres_04 = 0;
                        double _valor_vencido_1_a_30_eres_04 = 0;
                        double _valor_vencido_31_a_90_eres_04 = 0;
                        double _valor_vencido_91_a_180_eres_04 = 0;
                        double _valor_vencido_181_a_360_eres_04 = 0;
                        double _valor_mas_360_eres_04 = 0;
                        double _valor_vencido_181_a_270_eres_04 = 0;
                        double _valor_mas_270_eres_04 = 0;
                        double _valor_vencido_91_a_270_eres_04 = 0;
                        double _valor_vencido_271_a_360_eres_04 = 0;
                        double _valor_vencido_361_a_720_eres_04 = 0;
                        double _valor_mas_720_eres_04 = 0;
                        double _interes_sobre_mora_eres_04 = 0;
                        double _interes_ordinario_eres_04 = 0;  ///calcular



                        if (_vencida == true)
                        {
                            // INTERES SOBRE MORA
                            int _dias_morosidad = Convert.ToInt32(_dias_morosidad_eres_04);
                            if (_dias_morosidad <= 0)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0;
                            }
                            if (_dias_morosidad >= 1 && _dias_morosidad <= 15)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.00035;
                            }
                            if (_dias_morosidad >= 16 && _dias_morosidad <= 30)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003566666;
                            }
                            if (_dias_morosidad >= 31 && _dias_morosidad <= 60)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003633333;
                            }
                            if (_dias_morosidad > 60)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003666666;
                            }

                            // UBICAR MADURACION VENCIDA

                            int _dias = Convert.ToInt32(_dias_morosidad_eres_04);
                            if (_tipo_cartera == "COMERCIAL")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                   
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencido_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }
                            }

                            if (_tipo_cartera == "CONSUMO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                   
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                   
                                }
                                if (_dias >= 181 && _dias <= 270)
                                {
                                    _valor_vencido_181_a_270_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 270)
                                {
                                    _valor_mas_270_eres_04 = _saldo_ubicar;
                                    
                                }

                            }
                            if (_tipo_cartera == "MICROCREDITO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencido_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }

                            }


                            if (_tipo_cartera == "VIVIENDA")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 270)
                                {
                                    _valor_vencido_91_a_270_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 271 && _dias <= 360)
                                {
                                    _valor_vencido_271_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                               
                                if (_dias >= 361 && _dias <= 720)
                                {
                                    _valor_vencido_361_a_720_eres_04 = _saldo_ubicar;
                                    
                                }
                                
                                if (_dias > 720)
                                {
                                    _valor_mas_720_eres_04 = _saldo_ubicar;
                                    
                                }

                            }


                        }
                        else
                        {
                            // INTERES ORDINARIO
                            int _dias_vencer = _dias_por_vencer;
                            if (_dias_vencer <= 0)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0;
                            }
                            if (_dias_vencer >= 1 && _dias_vencer <= 15)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0105;
                            }
                            if (_dias_vencer >= 16 && _dias_vencer <= 30)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0107;
                            }
                            if (_dias_vencer >= 31 && _dias_vencer <= 60)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0109;
                            }
                            if (_dias_vencer > 60)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.011;
                            }

                            //UBICAR MADURACION POR VENCER
                            int _dias = _dias_por_vencer;
                            if (_tipo_cartera == "COMERCIAL")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                   
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }

                            }

                            if (_tipo_cartera == "CONSUMO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }
                            }

                            if (_tipo_cartera == "MICROCREDITO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }

                            }

                            if (_tipo_cartera == "VIVIENDA")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                    
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                    
                                }
                            }

                        }

                        double _gastos_recuperacion_cartera_vencida_eres_04 = 0;
                        double _demanda_judicial_eres_04 = 0;
                        double _provision_requerida_reducida_eres_04 = 0;
                        string _tipo_operacion_eres_04 = _tipo_operacion;
                        string _objeto_fedeicomiso_eres_04 = " ";
                        double _prima_o_descuento_eres_04 = 0;
                        double _cuota_credito_eres_04 = _cuota;



                        ///inserto 
                        try
                        {

                            InsertaEre04(_tipo_identificacion_eres_04, _identificacion_sujeto_eres_04, _numero_operacion_eres_04, _dias_morosidad_eres_04, _metodologia_calificacion_eres_04, _calificacion_propia_eres_04, _calificacion_homologada_eres_04, _tasa_interes_eres_04, _valor_vencer_1_a_30_eres_04, _valor_vencer_31_a_90_eres_04, _valor_vencer_91_a_180_eres_04, _valor_vencer_181_a_360_eres_04, _valor_vencer_mas_360_eres_04, _valor_no_devenga_interes_1_a_30_eres_04, _valor_no_devenga_interes_31_a_90_eres_04, _valor_no_devenga_interes_91_a_180_eres_04, _valor_no_devenga_interes_181_a_360_eres_04, _valor_no_devenga_interes_mas_360_eres_04, _valor_vencido_1_a_30_eres_04, _valor_vencido_31_a_90_eres_04, _valor_vencido_91_a_180_eres_04, _valor_vencido_181_a_360_eres_04, _valor_mas_360_eres_04, _valor_vencido_181_a_270_eres_04, _valor_mas_270_eres_04, _valor_vencido_91_a_270_eres_04, _valor_vencido_271_a_360_eres_04, _valor_vencido_361_a_720_eres_04, _valor_mas_720_eres_04, _gastos_recuperacion_cartera_vencida_eres_04, _interes_ordinario_eres_04, _interes_sobre_mora_eres_04, _demanda_judicial_eres_04, _cartera_castigada_eres_04, _provision_requerida_original_eres_04, _provision_requerida_reducida_eres_04, _provision_constituida_eres_04, _tipo_operacion_eres_04, _objeto_fedeicomiso_eres_04, _prima_o_descuento_eres_04, _cuota_credito_eres_04);
                            
                            int resul1 = AccesoLogica.Update("eres_04", "saldo = '" + _saldo_ubicar + "', tipo_cartera= '" + _tipo_cartera + "', tipo= '" + _tipo + "'", "eres_04.numero_operacion_eres_04= '" + _numero_operacion_eres_04 + "'");
                            int resul3 = AccesoLogica.Update("cabeza_eres_04_ultima", "saldo_actual = '" + _saldo_ubicar + "'", "cabeza_eres_04_ultima.numero_operacion= '" + _numero_operacion_eres_04 + "'");
                           

                            if (Convert.ToDouble(_saldo_ubicar) <= 0.00)
                            {
                                int resul = AccesoLogica.Update("eres_04", "vencida = 'true'", "eres_04.numero_operacion_eres_04= '" + _numero_operacion_eres_04 + "'");

                                int resul2 = AccesoLogica.Update("cabeza_eres_04_ultima", "vencida = 'true'", "cabeza_eres_04_ultima.numero_operacion= '" + _numero_operacion_eres_04 + "'");

                            }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + _numero_operacion + "  Identificacion: " + _identificacion_cliente + "  Saldo: " + _saldo_actual);

                            Console.WriteLine("-------------------------");


                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("??????????????????????????????????????");
                            Console.WriteLine("ERROR AL INSERTAR ESTRCTURA: " + _numero_operacion_eres_04 + "        E->" + Ex.Message);
                            Console.WriteLine("??????????????????????????????????????");
                        }

                    }

                    if (_tipo == "S")
                    {

                        sobregiros++;

                        //1
                        string _tipo_identificacion_eres_04 = "E";
                        if (_identificacion_cliente.Length == 10)
                        {
                            _tipo_identificacion_eres_04 = "C";
                        }
                        if (_identificacion_cliente.Length > 10 && _identificacion_cliente.Length < 14)
                        {
                            _tipo_identificacion_eres_04 = "R";
                        }
                        //2
                        string _identificacion_sujeto_eres_04 = _identificacion_cliente;
                        //3
                        string _numero_operacion_eres_04 = _numero_operacion;
                        //4
                        string _dias_morosidad_eres_04 = _dias_vencidos_cabecera.ToString();

                        string _dias_morosidad_eres_04_madurar = _dias_morosidad_eres_04;

                        int daysInMes = System.DateTime.DaysInMonth(Convert.ToInt16(_year), Convert.ToInt16(_mes));
                        //string strActual = daysInMes +"/"+ _mes +"/"+ _year;   //    "01/08/2008";
                        string strActual = "05/05/2018";
                        FechaActual = Convert.ToDateTime(strActual);


                        _vencida = true;
                        

                        /*
                        if (FechaActual == _fecha_finalizacion)
                        {
                            TimeSpan ts = FechaActual - _fecha_finalizacion;
                            _dias_morosidad_eres_04 = ts.Days + "";

                            _vencida = true;
                        }
                        else
                        {
                            TimeSpan ts = _fecha_finalizacion - FechaActual;
                            // _dias_por_vencer = ts.Days;
                            _dias_por_vencer = 0;
                            _vencida = false;
                        }
                        */

                        //5
                        string _metodologia_calificacion_eres_04 = "T";
                        //6
                        string _calificacion_propia_eres_04 = "";
                        //7
                        string _calificacion_homologada_eres_04 = _calificacion_homologada;
                        //8
                        double _tasa_interes_eres_04 = _porcentaje;
                        //9
                        double _saldo_ubicar = DevuelveSaldoActual(_tipo, _numero_operacion, _saldo_actual, _year, _mes);
                        double _provision_requerida_original_eres_04 = 0;
                        double _provision_constituida_eres_04 = 0;
                        double _cartera_castigada_eres_04 = 0;


                        int _dias_para_calificacion = Convert.ToInt32(_dias_morosidad_eres_04) ;
                        if (_tipo_cartera == "COMERCIAL")
                        {
                           
                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 15)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 60)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 61 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 121 && _dias_para_calificacion <= 180)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 181 && _dias_para_calificacion <= 360)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 360)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "CONSUMO")
                        {
                            if(_dias_para_calificacion<16)
                            {
                                _dias_para_calificacion = 20;
                            }
                            
                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 8)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 9 && _dias_para_calificacion <= 15)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 45)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 46 && _dias_para_calificacion <= 70)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 71 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 120)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "VIVIENDA")
                        {
                           if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 60)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 61 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 121 && _dias_para_calificacion <= 180)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 181 && _dias_para_calificacion <= 210)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 211 && _dias_para_calificacion <= 270)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 271 && _dias_para_calificacion <= 450)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 450)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }


                        if (_tipo_cartera == "MICROCREDITO")
                        {
                            if (_dias_para_calificacion < 16)
                            {
                                _dias_para_calificacion = 20;
                            }

                            if (_dias_para_calificacion <= 0)
                            {
                                _calificacion_propia_eres_04 = "A1";
                            }

                            if (_dias_para_calificacion >= 1 && _dias_para_calificacion <= 8)
                            {
                                _calificacion_propia_eres_04 = "A2";
                            }

                            if (_dias_para_calificacion >= 9 && _dias_para_calificacion <= 15)
                            {
                                _calificacion_propia_eres_04 = "A3";
                            }

                            if (_dias_para_calificacion >= 16 && _dias_para_calificacion <= 30)
                            {
                                _calificacion_propia_eres_04 = "B1";
                            }
                            if (_dias_para_calificacion >= 31 && _dias_para_calificacion <= 45)
                            {
                                _calificacion_propia_eres_04 = "B2";
                            }

                            if (_dias_para_calificacion >= 46 && _dias_para_calificacion <= 70)
                            {
                                _calificacion_propia_eres_04 = "C1";
                            }
                            if (_dias_para_calificacion >= 71 && _dias_para_calificacion <= 90)
                            {
                                _calificacion_propia_eres_04 = "C2";
                            }

                            if (_dias_para_calificacion >= 91 && _dias_para_calificacion <= 120)
                            {
                                _calificacion_propia_eres_04 = "D";
                            }

                            if (_dias_para_calificacion > 120)
                            {
                                _calificacion_propia_eres_04 = "E";
                            }
                        }

                        //cambio 27092017 todos pasan a vencido
                        _calificacion_propia_eres_04 = "E";

                        if (_calificacion_propia_eres_04 == "A1")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.01;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "A2")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.02;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "A3")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.05;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "B1")
                        {
                             //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.09;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "B2")
                        {
                            // _provision_requerida_original_eres_04 = _saldo_ubicar * 0.19;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "C1")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.39;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "C2")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.59;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "D")
                        {
                            //_provision_requerida_original_eres_04 = _saldo_ubicar * 0.99;
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                        }
                        if (_calificacion_propia_eres_04 == "E")
                        {
                            _provision_requerida_original_eres_04 = _saldo_ubicar;
                            _provision_constituida_eres_04 = _provision_requerida_original_eres_04;
                            _cartera_castigada_eres_04 = _saldo_ubicar;
                        }



                        double _cuota = DevuelveAbonos(_tipo, _numero_operacion, _saldo_actual, _year, _mes);

                        //10
                        double _valor_vencer_1_a_30_eres_04 = 0;
                        double _valor_vencer_31_a_90_eres_04 = 0;
                        double _valor_vencer_91_a_180_eres_04 = 0;
                        double _valor_vencer_181_a_360_eres_04 = 0;
                        double _valor_vencer_mas_360_eres_04 = 0;
                        double _valor_no_devenga_interes_1_a_30_eres_04 = 0;
                        double _valor_no_devenga_interes_31_a_90_eres_04 = 0;
                        double _valor_no_devenga_interes_91_a_180_eres_04 = 0;
                        double _valor_no_devenga_interes_181_a_360_eres_04 = 0;
                        double _valor_no_devenga_interes_mas_360_eres_04 = 0;
                        double _valor_vencido_1_a_30_eres_04 = 0;
                        double _valor_vencido_31_a_90_eres_04 = 0;
                        double _valor_vencido_91_a_180_eres_04 = 0;
                        double _valor_vencido_181_a_360_eres_04 = 0;
                        double _valor_mas_360_eres_04 = 0;
                        double _valor_vencido_181_a_270_eres_04 = 0;
                        double _valor_mas_270_eres_04 = 0;
                        double _valor_vencido_91_a_270_eres_04 = 0;
                        double _valor_vencido_271_a_360_eres_04 = 0;
                        double _valor_vencido_361_a_720_eres_04 = 0;
                        double _valor_mas_720_eres_04 = 0;

                        double _interes_sobre_mora_eres_04 = 0;
                        double _interes_ordinario_eres_04 = 0;




                        if (_vencida == true)
                        {
                            // INTERES SOBRE MORA

                            //int _dias_morosidad = Convert.ToInt32(_dias_morosidad_eres_04) - 5;
                            //27092017
                            int _dias_morosidad = Convert.ToInt32(_dias_morosidad_eres_04);

                            if (_dias_morosidad <= 0)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0;
                            }
                            if (_dias_morosidad >= 1 && _dias_morosidad <= 15)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.00035;
                            }
                            if (_dias_morosidad >= 16 && _dias_morosidad <= 30)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003566666;
                            }
                            if (_dias_morosidad >= 31 && _dias_morosidad <= 60)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003633333;
                            }
                            if (_dias_morosidad > 60)
                            {
                                _interes_sobre_mora_eres_04 = _dias_morosidad * 0.0003666666;
                            }


                            // UBICAR MADURACION VENCIDA

                            int _dias = Convert.ToInt32(_dias_morosidad_eres_04) ;
                            if (_tipo_cartera == "COMERCIAL")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencido_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_mas_360_eres_04 = _saldo_ubicar;
                                }
                            }

                            if (_tipo_cartera == "CONSUMO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 270)
                                {
                                    _valor_vencido_181_a_270_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 270)
                                {
                                    _valor_mas_270_eres_04 = _saldo_ubicar;
                                }

                            }
                            if (_tipo_cartera == "MICROCREDITO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencido_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencido_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_mas_360_eres_04 = _saldo_ubicar;
                                }

                            }


                            if (_tipo_cartera == "VIVIENDA")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencido_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencido_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 270)
                                {
                                    _valor_vencido_91_a_270_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 271 && _dias <= 360)
                                {
                                    _valor_vencido_271_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 361 && _dias <= 720)
                                {
                                    _valor_vencido_361_a_720_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 720)
                                {
                                    _valor_mas_720_eres_04 = _saldo_ubicar;
                                }

                            }



                        }
                        else
                        {
                            // INTERES ORDINARIO
                            int _dias_vencer = _dias_por_vencer;


                            if (_dias_vencer <= 0)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0;
                            }
                            if (_dias_vencer >= 1 && _dias_vencer <= 15)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0105;
                            }
                            if (_dias_vencer >= 16 && _dias_vencer <= 30)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0107;
                            }
                            if (_dias_vencer >= 31 && _dias_vencer <= 60)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.0109;
                            }
                            if (_dias_vencer > 60)
                            {
                                _interes_ordinario_eres_04 = _saldo_ubicar * 0.011;
                            }

                            //UBICAR MADURACION POR VENCER
                            int _dias = _dias_por_vencer;
                            if (_tipo_cartera == "COMERCIAL")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                }

                            }

                            if (_tipo_cartera == "CONSUMO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                }
                            }

                            if (_tipo_cartera == "MICROCREDITO")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                }

                            }

                            if (_tipo_cartera == "VIVIENDA")
                            {
                                if (_dias <= 30)
                                {
                                    _valor_vencer_1_a_30_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 31 && _dias <= 90)
                                {
                                    _valor_vencer_31_a_90_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 91 && _dias <= 180)
                                {
                                    _valor_vencer_91_a_180_eres_04 = _saldo_ubicar;
                                }
                                if (_dias >= 181 && _dias <= 360)
                                {
                                    _valor_vencer_181_a_360_eres_04 = _saldo_ubicar;
                                }
                                if (_dias > 360)
                                {
                                    _valor_vencer_mas_360_eres_04 = _saldo_ubicar;
                                }
                            }

                        }

                        double _gastos_recuperacion_cartera_vencida_eres_04 = 0;
                        ///calcular

                        double _demanda_judicial_eres_04 = 0;
                        double _provision_requerida_reducida_eres_04 = 0;
                        string _tipo_operacion_eres_04 = _tipo_operacion;
                        string _objeto_fedeicomiso_eres_04 = " ";
                        double _prima_o_descuento_eres_04 = 0;
                        double _cuota_credito_eres_04 = _cuota;



                        ///inserto 
                        try
                        {

                            InsertaEre04(_tipo_identificacion_eres_04, _identificacion_sujeto_eres_04, _numero_operacion_eres_04, _dias_morosidad_eres_04, _metodologia_calificacion_eres_04, _calificacion_propia_eres_04, _calificacion_homologada_eres_04, _tasa_interes_eres_04, _valor_vencer_1_a_30_eres_04, _valor_vencer_31_a_90_eres_04, _valor_vencer_91_a_180_eres_04, _valor_vencer_181_a_360_eres_04, _valor_vencer_mas_360_eres_04, _valor_no_devenga_interes_1_a_30_eres_04, _valor_no_devenga_interes_31_a_90_eres_04, _valor_no_devenga_interes_91_a_180_eres_04, _valor_no_devenga_interes_181_a_360_eres_04, _valor_no_devenga_interes_mas_360_eres_04, _valor_vencido_1_a_30_eres_04, _valor_vencido_31_a_90_eres_04, _valor_vencido_91_a_180_eres_04, _valor_vencido_181_a_360_eres_04, _valor_mas_360_eres_04, _valor_vencido_181_a_270_eres_04, _valor_mas_270_eres_04, _valor_vencido_91_a_270_eres_04, _valor_vencido_271_a_360_eres_04, _valor_vencido_361_a_720_eres_04, _valor_mas_720_eres_04, _gastos_recuperacion_cartera_vencida_eres_04, _interes_ordinario_eres_04, _interes_sobre_mora_eres_04, _demanda_judicial_eres_04, _cartera_castigada_eres_04, _provision_requerida_original_eres_04, _provision_requerida_reducida_eres_04, _provision_constituida_eres_04, _tipo_operacion_eres_04, _objeto_fedeicomiso_eres_04, _prima_o_descuento_eres_04, _cuota_credito_eres_04);
                            int resul1 = AccesoLogica.Update("eres_04", "saldo = '" + _saldo_ubicar + "', tipo_cartera= '" + _tipo_cartera + "', tipo= '" + _tipo + "'", "eres_04.numero_operacion_eres_04= '" + _numero_operacion_eres_04 + "'");
                            int resul3 = AccesoLogica.Update("cabeza_eres_04_ultima", "saldo_actual = '" + _saldo_ubicar + "'", "cabeza_eres_04_ultima.numero_operacion= '" + _numero_operacion_eres_04 + "'");
                            

                            if (Convert.ToDouble(_saldo_ubicar) <= 0.00)
                            {
                                int resul = AccesoLogica.Update("eres_04", "vencida = 'true'", "eres_04.numero_operacion_eres_04= '" + _numero_operacion_eres_04 + "'");
                                string numero_ope_abonos = _numero_operacion_eres_04.Replace("082014", "082014");
                                int resul2 = AccesoLogica.Update("cabeza_eres_04_ultima", "vencida = 'true'", "cabeza_eres_04_ultima.numero_operacion= '" + numero_ope_abonos + "'");

                            }
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("-------------------------");
                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + _numero_operacion + "  Identificacion: " + _identificacion_cliente + "  Saldo: " + _saldo_actual);
                            Console.WriteLine("-------------------------");

                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("??????????????????????????????????????");
                            Console.WriteLine("ERROR AL INSERTAR ESTRCTURA: " + _numero_operacion_eres_04 + "        E->" + Ex.Message);
                            Console.WriteLine("??????????????????????????????????????");
                        }

                    }

                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("-------------------------");
                Console.WriteLine("Creditos= " + creditos + "  Sobregiros= " + sobregiros);
                Console.WriteLine("-------------------------");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("No Encuentro ->" + _numero_operacion);
                Console.ForegroundColor = ConsoleColor.White;

            }

        }


        public static void InsertaEstructuras05()
        {
            Console.WriteLine("Cominezo a insertar .....");

            int registros = 0;
            string _tipo_identificacion_eres_04 = "";
            string _identificacion_sujeto_eres_04 = "";
            string _numero_operacion_eres_04 = "";
            string _tipo_transaccion = "C";
            DateTime _fecha_cancelacion = new DateTime();
            string _forma_cancelacion = "N";
            string _calificacion = " ";
            string _tipo = "";
            string numero_ope_abonos = "";
            string numero_ope_abonos1 = "";

            DataTable dtEre04 = AccesoLogica.Select(" * ", "eres_04", "vencida='TRUE'");

            int regEre04 = dtEre04.Rows.Count;

            if (regEre04 > 0)
            {
                foreach (DataRow renglon in dtEre04.Rows)
                {
                    registros++;
                    _tipo_identificacion_eres_04 = Convert.ToString(renglon["tipo_identificacion_eres_04"].ToString());
                    _identificacion_sujeto_eres_04 = Convert.ToString(renglon["identificacion_sujeto_eres_04"].ToString());
                    _numero_operacion_eres_04 = Convert.ToString(renglon["numero_operacion_eres_04"].ToString());
                    _tipo = Convert.ToString(renglon["tipo"].ToString());
                    // _tipo = _tipo.Trim();
                    CultureInfo format_dt = new CultureInfo("es-ES");
                    
                    if (_tipo == "C ")
                    {
                        numero_ope_abonos = _numero_operacion_eres_04.Replace("RCF01", "");
                        numero_ope_abonos1 = _numero_operacion_eres_04.Replace("RCH01", "");
                        //numero_ope_abonos = _numero_operacion_eres_04.Substring(5,6);



                        DataTable dtfecha = AccesoLogica.Select("MAX(fecha_pago_abono)  AS fecha", "abonos", "numero_operacion = '" + numero_ope_abonos + "' OR numero_operacion = '" + numero_ope_abonos1 + "'");
                        foreach (DataRow renglon1 in dtfecha.Rows)
                        {
                            _fecha_cancelacion = Convert.ToDateTime(renglon1["fecha"].ToString());
                            //string fechaconvertir = _fecha_cancelacion.Year + "-" + _fecha_cancelacion.Month.ToString("MM") + "-" + _fecha_cancelacion.Day.ToString("dd");
                            //_fecha_cancelacion = DateTime.ParseExact(fechaconvertir, "yyyy-MM-dd", null);

                            //Console.WriteLine(fechaconvertir);
                        }



                    }
                    if (_tipo == "S ")
                    {

                        numero_ope_abonos = _numero_operacion_eres_04.Replace("082014", "");

                        DataTable dtfecha = AccesoLogica.Select("MAX(fecha_pago_abono)  AS fecha", "abonos", "numero_operacion= '" + numero_ope_abonos + "'");
                        foreach (DataRow renglon1 in dtfecha.Rows)
                        {

                            _fecha_cancelacion = Convert.ToDateTime(renglon1["fecha"].ToString());
                           // string fechaconvertir = _fecha_cancelacion.Year + "-" + _fecha_cancelacion.Month.ToString("00") + "-" + _fecha_cancelacion.Day.ToString("00");
                           //_fecha_cancelacion = DateTime.ParseExact(fechaconvertir, "yyyy-MM-dd", null);

                            //Console.WriteLine(fechaconvertir);
                            
                        }

                    }

                    try
                    {

                        InsertaEre05(_tipo_identificacion_eres_04, _identificacion_sujeto_eres_04, _numero_operacion_eres_04, _tipo_transaccion, _fecha_cancelacion, _forma_cancelacion, _calificacion);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-------------------------");

                        Console.WriteLine("Registros #" + registros + "  Operacion: " + numero_ope_abonos + "  Identificacion: " + _identificacion_sujeto_eres_04);

                        Console.WriteLine("-------------------------");


                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine("??????????????????????????????????????");
                        Console.WriteLine("ERROR AL INSERTAR ESTRCTURA 05: " + _numero_operacion_eres_04 + "        E->" + Ex.Message);
                        Console.WriteLine("??????????????????????????????????????");
                    }


                }
            }

        }



        public static double DevuelveSaldoActual(string _tipo, string _numero_operacion, double _saldo_actual_ere, string _year, string _mes)
        {
            double _saldo_actual = 0;
            string numero_operacion = "";
            double _capital_pagado = 0;
            if (_tipo == "C")
            {
                numero_operacion = _numero_operacion;

            }
            else
            {
                numero_operacion = "SOBREGIRO" + _numero_operacion.Replace("082014", "");
               // numero_operacion = "SOBREGIRO" + _numero_operacion.Replace(_mes + _year, "");
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Operacion ->" + _numero_operacion);

            Console.WriteLine("-------------------------");


            ///BUSCO LA FECHA
            /// 

            string where = "   TRIM( estatus_operacion || numero_operacion ) = '" + numero_operacion.Trim() + "' AND extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string tabla = "abonos";
            string columnas = " SUM(capital_pagado) AS capital_pagado  ";
            DataTable dtAconos = AccesoLogica.Select(columnas, tabla, where);

            Console.WriteLine(where);



            int reg3 = dtAconos.Rows.Count;
            if (reg3 > 0)
            {
                foreach (DataRow renglon3 in dtAconos.Rows)
                {
                    if (renglon3["capital_pagado"].ToString().Length > 0)
                    {
                        _capital_pagado = Convert.ToDouble(renglon3["capital_pagado"].ToString());
                    }
                }
            }

            _saldo_actual = _saldo_actual_ere - _capital_pagado;

            return _saldo_actual;

        }


        public static double DevuelveAbonos(string _tipo, string _numero_operacion, double _saldo_actual_ere, string _year, string _mes)
        {
            
            double _saldo_actual = 0;
            string numero_operacion = "";
            double _capital_pagado = 0;

            if(_tipo == "C")
            {
                numero_operacion = _numero_operacion;
            }
            else
            {
                numero_operacion = "SOBREGIRO" + _numero_operacion.Replace("082014", "");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------");
            Console.WriteLine("-------------------------");



            ///BUSCO LA FECHA
            /// 
            string where = "   TRIM( estatus_operacion || numero_operacion ) = '" + numero_operacion + "' AND extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string tabla = "abonos";
            string columnas = " SUM(capital_pagado) AS capital_pagado";
            DataTable dtAconos = AccesoLogica.Select(columnas, tabla, where);

            int reg3 = dtAconos.Rows.Count;
            if (reg3 > 0)
            {
                foreach (DataRow renglon3 in dtAconos.Rows)
                {
                    if (renglon3["capital_pagado"].ToString().Length > 0)
                    {
                        _capital_pagado = Convert.ToDouble(renglon3["capital_pagado"].ToString());
                    }
                }
            }

            _saldo_actual = _saldo_actual_ere - _capital_pagado;
            // _total_abonos = _capital_pagado;
            //_total_abonos = 0;
            return _saldo_actual;

        }


        public static void InsertaEre04(string _tipo_identificacion_eres_04, string _identificacion_sujeto_eres_04, string _numero_operacion_eres_04, string _dias_morosidad_eres_04, string _metodologia_calificacion_eres_04, string _calificacion_propia_eres_04, string _calificacion_homologada_eres_04, double _tasa_interes_eres_04, double _valor_vencer_1_a_30_eres_04, double _valor_vencer_31_a_90_eres_04, double _valor_vencer_91_a_180_eres_04, double _valor_vencer_181_a_360_eres_04, double _valor_vencer_mas_360_eres_04, double _valor_no_devenga_interes_1_a_30_eres_04, double _valor_no_devenga_interes_31_a_90_eres_04, double _valor_no_devenga_interes_91_a_180_eres_04, double _valor_no_devenga_interes_181_a_360_eres_04, double _valor_no_devenga_interes_mas_360_eres_04, double _valor_vencido_1_a_30_eres_04, double _valor_vencido_31_a_90_eres_04, double _valor_vencido_91_a_180_eres_04, double _valor_vencido_181_a_360_eres_04, double _valor_mas_360_eres_04, double _valor_vencido_181_a_270_eres_04, double _valor_mas_270_eres_04, double _valor_vencido_91_a_270_eres_04, double _valor_vencido_271_a_360_eres_04, double _valor_vencido_361_a_720_eres_04, double _valor_mas_720_eres_04, double _gastos_recuperacion_cartera_vencida_eres_04, double _interes_ordinario_eres_04, double _interes_sobre_mora_eres_04, double _demanda_judicial_eres_04, double _cartera_castigada_eres_04, double _provision_requerida_original_eres_04, double _provision_requerida_reducida_eres_04, double _provision_constituida_eres_04, string _tipo_operacion_eres_04, string _objeto_fedeicomiso_eres_04, double _prima_o_descuento_eres_04, double _cuota_credito_eres_04)
        {
            // ins_eres_04(_tipo_identificacion_eres_04 character varying, _identificacion_sujeto_eres_04 character varying, _numero_operacion_eres_04 character varying, _dias_morosidad_eres_04 character varying, _metodologia_calificacion_eres_04 character varying, _calificacion_propia_eres_04 character varying, _calificacion_homologada_eres_04 character varying, _tasa_interes_eres_04 numeric, _valor_vencer_1_a_30_eres_04 numeric, _valor_vencer_31_a_90_eres_04 numeric, _valor_vencer_91_a_180_eres_04 numeric, _valor_vencer_181_a_360_eres_04 numeric, _valor_vencer_mas_360_eres_04 numeric, _valor_no_devenga_interes_1_a_30_eres_04 numeric, _valor_no_devenga_interes_31_a_90_eres_04 numeric, _valor_no_devenga_interes_91_a_180_eres_04 numeric, _valor_no_devenga_interes_181_a_360_eres_04 numeric, _valor_no_devenga_interes_mas_360_eres_04 numeric, _valor_vencido_1_a_30_eres_04 numeric, _valor_vencido_31_a_90_eres_04 numeric, _valor_vencido_91_a_180_eres_04 numeric, _valor_vencido_181_a_360_eres_04 numeric, _valor_mas_360_eres_04 numeric, _valor_vencido_181_a_270_eres_04 numeric, _valor_mas_270_eres_04 numeric, _valor_vencido_91_a_270_eres_04 numeric, _valor_vencido_271_a_360_eres_04 numeric, _valor_vencido_361_a_720_eres_04 numeric, _valor_mas_720_eres_04 numeric, _gastos_recuperacion_cartera_vencida_eres_04 numeric, _interes_ordinario_eres_04 numeric, _interes_sobre_mora_eres_04 numeric, _demanda_judicial_eres_04 numeric, _cartera_castigada_eres_04 numeric, _provision_requerida_original_eres_04 numeric, _provision_requerida_reducida_eres_04 numeric, _provision_constituida_eres_04 numeric, _tipo_operacion_eres_04 character varying, _objeto_fedeicomiso_eres_04 character varying, _prima_o_descuento_eres_04 numeric, _cuota_credito_eres_04 numeric)


            string cadena1 = _tipo_identificacion_eres_04 + "?" + _identificacion_sujeto_eres_04 + "?" + _numero_operacion_eres_04 + "?" + _dias_morosidad_eres_04 + "?" + _metodologia_calificacion_eres_04 + "?" + _calificacion_propia_eres_04 + "?" + _calificacion_homologada_eres_04 + "?" + _tasa_interes_eres_04 + "?" + _valor_vencer_1_a_30_eres_04 + "?" + _valor_vencer_31_a_90_eres_04 + "?" + _valor_vencer_91_a_180_eres_04 + "?" + _valor_vencer_181_a_360_eres_04 + "?" + _valor_vencer_mas_360_eres_04 + "?" + _valor_no_devenga_interes_1_a_30_eres_04 + "?" + _valor_no_devenga_interes_31_a_90_eres_04 + "?" + _valor_no_devenga_interes_91_a_180_eres_04 + "?" + _valor_no_devenga_interes_181_a_360_eres_04 + "?" + _valor_no_devenga_interes_mas_360_eres_04 + "?" + _valor_vencido_1_a_30_eres_04 + "?" + _valor_vencido_31_a_90_eres_04 + "?" + _valor_vencido_91_a_180_eres_04 + "?" + _valor_vencido_181_a_360_eres_04 + "?" + _valor_mas_360_eres_04 + "?" + _valor_vencido_181_a_270_eres_04 + "?" + _valor_mas_270_eres_04 + "?" + _valor_vencido_91_a_270_eres_04 + "?" + _valor_vencido_271_a_360_eres_04 + "?" + _valor_vencido_361_a_720_eres_04 + "?" + _valor_mas_720_eres_04 + "?" + _gastos_recuperacion_cartera_vencida_eres_04 + "?" + _interes_ordinario_eres_04 + "?" + _interes_sobre_mora_eres_04 + "?" + _demanda_judicial_eres_04 + "?" + _cartera_castigada_eres_04 + "?" + _provision_requerida_original_eres_04 + "?" + _provision_requerida_reducida_eres_04 + "?" + _provision_constituida_eres_04 + "?" + _tipo_operacion_eres_04 + "?" + _objeto_fedeicomiso_eres_04 + "?" + _prima_o_descuento_eres_04 + "?" + _cuota_credito_eres_04;

            string cadena2 = "_tipo_identificacion_eres_04?_identificacion_sujeto_eres_04?_numero_operacion_eres_04?_dias_morosidad_eres_04?_metodologia_calificacion_eres_04?_calificacion_propia_eres_04?_calificacion_homologada_eres_04?_tasa_interes_eres_04?_valor_vencer_1_a_30_eres_04?_valor_vencer_31_a_90_eres_04?_valor_vencer_91_a_180_eres_04?_valor_vencer_181_a_360_eres_04?_valor_vencer_mas_360_eres_04?_valor_no_devenga_interes_1_a_30_eres_04?_valor_no_devenga_interes_31_a_90_eres_04?_valor_no_devenga_interes_91_a_180_eres_04?_valor_no_devenga_interes_181_a_360_eres_04?_valor_no_devenga_interes_mas_360_eres_04?_valor_vencido_1_a_30_eres_04?_valor_vencido_31_a_90_eres_04?_valor_vencido_91_a_180_eres_04?_valor_vencido_181_a_360_eres_04?_valor_mas_360_eres_04?_valor_vencido_181_a_270_eres_04?_valor_mas_270_eres_04?_valor_vencido_91_a_270_eres_04?_valor_vencido_271_a_360_eres_04?_valor_vencido_361_a_720_eres_04?_valor_mas_720_eres_04?_gastos_recuperacion_cartera_vencida_eres_04?_interes_ordinario_eres_04?_interes_sobre_mora_eres_04?_demanda_judicial_eres_04?_cartera_castigada_eres_04?_provision_requerida_original_eres_04?_provision_requerida_reducida_eres_04?_provision_constituida_eres_04?_tipo_operacion_eres_04?_objeto_fedeicomiso_eres_04?_prima_o_descuento_eres_04?_cuota_credito_eres_04";

            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric";

            try
            {
                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_eres_04");
                Console.WriteLine("Insertado ....." + _numero_operacion_eres_04);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion_eres_04 + " ->" + Ex.Message);
                Console.WriteLine("-------------------------------------------------");
            }



        }


        public static void InsertaEre05(string _tipo_identificacion_eres_04, string _identificacion_sujeto_eres_04, string _numero_operacion_eres_04, string _tipo_transaccion, DateTime _fecha_cancelacion, string _forma_cancelacion, string _calificacion)
        {

            string fechaconvertir = _fecha_cancelacion.Year + "-" + _fecha_cancelacion.Month.ToString("00") + "-" + _fecha_cancelacion.Day.ToString("00");
            _fecha_cancelacion = DateTime.ParseExact(fechaconvertir, "yyyy-MM-dd", null);

            string cadena1 = _tipo_identificacion_eres_04 + "?" + _identificacion_sujeto_eres_04 + "?" + _numero_operacion_eres_04 + "?" + _tipo_transaccion + "?" + _fecha_cancelacion.ToString("yyyy-MM-dd") + "?" + _forma_cancelacion + "?" + _calificacion;

            string cadena2 = "_tipo_identificacion_eres_04?_identificacion_sujeto_eres_04?_numero_operacion_eres_04?_tipo_transaccion?_fecha_cancelacion?_forma_cancelacion?_calificacion";

            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

            try
            {
                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_eres_05");
                Console.WriteLine("Insertado ....." + _numero_operacion_eres_04);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion_eres_04 + " ->" + Ex.Message);
                Console.WriteLine("-------------------------------------------------");
            }



        }







        public static void BuscarFechas()
        {
            DateTime fecha_inicio = DateTime.Now;
            double capital_prestado;
            DateTime fecha_final = DateTime.Now;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;
            string tipo = "";
            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;
            int reg3 = 0;
            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion LIKE '%%'   ");

            regSaldo = dtSaldo.Rows.Count;

            string num_ope = "";
            if (regSaldo > 0)
            {
                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    tipo = Convert.ToString(renglon["tipo"].ToString());

                    if (tipo == "C")
                    {
                        numero_operacion = num_ope;
                    }
                    else
                    {
                        numero_operacion = "SOBR" + num_ope.Replace("082014", "");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");



                    ///BUSCO LA FECHA
                    /// 
                    DataTable dtCliente = AccesoLogica.Select(" * ", "fc_clientes", " numero_operacion = '" + numero_operacion + "' ");

                    reg3 = dtCliente.Rows.Count;
                    if (reg3 > 0)
                    {
                        foreach (DataRow renglon3 in dtCliente.Rows)
                        {

                            //num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                            if (renglon3["fecha_inicio"].ToString().Length > 0)
                            {
                                fecha_inicio = Convert.ToDateTime(renglon3["fecha_inicio"].ToString());
                            }
                            if (renglon3["fecha_final"].ToString().Length > 0)
                            {
                                fecha_final = Convert.ToDateTime(renglon3["fecha_inicio"].ToString());
                            }


                            capital_prestado = Convert.ToDouble(renglon3["capital_prestado"].ToString());

                            AccesoLogica.Update("cabeza_eres_04", " fecha_inicio = '" + fecha_inicio + "', fecha_finalizacion = '" + fecha_final + "'    ", "numero_operacion = '" + num_ope + "' ");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Inicio: " + fecha_inicio + "  Final: " + fecha_final);

                            Console.WriteLine("-------------------------");

                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + num_ope);
                Console.ForegroundColor = ConsoleColor.White;

            }




        }





        public static void BuscarFechas2()
        {


            DateTime fecha_inicio = DateTime.Now;
           
            DateTime fecha_final = DateTime.Now;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;
            string tipo = "";
            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;
            int reg3 = 0;
            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion LIKE '%%'   ");

            regSaldo = dtSaldo.Rows.Count;

            string num_ope = "";
            if (regSaldo > 0)
            {
                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    tipo = Convert.ToString(renglon["tipo"].ToString());

                    if (tipo == "C")
                    {
                        numero_operacion = num_ope;
                    }
                    else
                    {
                        numero_operacion = "SOBR" + num_ope.Replace("082014", "");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");



                    ///BUSCO LA FECHA
                    /// 
                    DataTable dtCliente = AccesoLogica.Select(" * ", "abonos_dos", " numero_operacion = '" + numero_operacion + "' ");

                    reg3 = dtCliente.Rows.Count;
                    if (reg3 > 0)
                    {
                        foreach (DataRow renglon3 in dtCliente.Rows)
                        {

                            //num_ope = Convert.ToString(renglon["numero_operacion"].ToString());

                            fecha_inicio = Convert.ToDateTime(renglon3["fecha_otorga"].ToString());
                            fecha_final = Convert.ToDateTime(renglon3["fecha_vencimiento"].ToString());



                            //capital_prestado = Convert.ToDouble(renglon3["capital_prestado"].ToString());

                            AccesoLogica.Update("cabeza_eres_04", " fecha_inicio = '" + fecha_inicio + "', fecha_finalizacion = '" + fecha_final + "'    ", "numero_operacion = '" + num_ope + "' ");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Inicio: " + fecha_inicio + "  Final: " + fecha_final);

                            Console.WriteLine("-------------------------");

                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + num_ope);
                Console.ForegroundColor = ConsoleColor.White;

            }




        }


        public static void LimpiarCabeza()
        {
            Console.WriteLine("Limpiando .....");
            AccesoLogica.Update("cabeza_eres_04", " tipo = 'C' ", " numero_operacion LIKE 'R%'   ");
            AccesoLogica.Update("cabeza_eres_04", " numero_operacion = replace(numero_operacion, '072014', '082014')  ", " tipo = 'S'    ");
            //AccesoLogica.Delete(" tipo = 'S' ", "cabeza_eres_04");
            Console.WriteLine("Limpio .....");
        }


        public static void BuscaOperaciones(string _mes, string _year)
        {

            Console.WriteLine("Buscando Operaciones .....");
            string columnas = " * ";
            string tabla = " abonos ";


            string where = "   extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string _numero_ope = "";
            string _numero_operacion = "";
            string _cedula_cliente = "";
            DateTime _fecha_pago_abono;
            Double _capital_pagado = 0;
            string _identificacion_cliente;
            string _estado_operacion = "";
            DataTable dtAbonos = AccesoLogica.Select(columnas, tabla, where);
            Console.WriteLine("Buscando Anonos .....");
            int regAbonos = dtAbonos.Rows.Count;
            Console.WriteLine("Anonos ->" + regAbonos);
            int reg = 0;
           if (regAbonos > 0)
            {
                foreach (DataRow renglonSub in dtAbonos.Rows)
                {
                    _numero_ope = Convert.ToString(renglonSub["numero_operacion"].ToString());
                    _cedula_cliente = Convert.ToString(renglonSub["cedula_cliente"].ToString());
                    _fecha_pago_abono = Convert.ToDateTime(renglonSub["fecha_pago_abono"].ToString());
                    _capital_pagado = Convert.ToDouble(renglonSub["capital_pagado"].ToString());
                    _estado_operacion = Convert.ToString(renglonSub["estatus_operacion"].ToString());

                    Console.WriteLine("Registro --->" + reg);
                    reg++;
                    if (_estado_operacion.Substring(0, 1) == "R")
                    {
                        _numero_operacion = _estado_operacion + _numero_ope;
                        Console.WriteLine("Credito .....");
                    }
                    else
                    {
                        Console.WriteLine("Sobregiro .....");
                        _numero_operacion = _numero_ope + _mes + _year;

                    }
                    Console.WriteLine("Operacion ->" + _numero_operacion);
                    if (BuscaCabeza(_numero_operacion))
                    {
                        ///actualizo

                    }
                    else
                    {
                        Console.WriteLine("Insertando .....");
                        _numero_operacion = _numero_ope + _mes + _year;
                        _identificacion_cliente = _cedula_cliente;
                        //ins_cabeza_eres_04(_numero_operacion character varying, _identificacion_cliente character varying)
                        string cadena1 = _numero_operacion + "?" + _identificacion_cliente;

                        string cadena2 = "_numero_operacion?_identificacion_cliente";
                        string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";
                        try
                        {
                            int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_cabeza_eres_04");
                            Console.WriteLine("Insertado ....." + _numero_operacion);
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion + " ->" + Ex.Message);
                            Console.WriteLine("-------------------------------------------------");
                        }





                    }



                }
            }

        }

        public static bool BuscaCabeza(string _numero_operacion)
        {
            bool encontrado = false;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;

            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;

            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion = '" + _numero_operacion + "'   ");

            regSaldo = dtSaldo.Rows.Count;

            if (regSaldo > 0)
            {

                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    numero_operacion = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");
                    encontrado = true;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + _numero_operacion);
                Console.ForegroundColor = ConsoleColor.White;

            }



            return encontrado;
        }




/* solo agosto


        public static double DevuelveSaldoActual(string _tipo, string _numero_operacion, double _saldo_actual_ere, string _year, string _mes)
        {
            double _saldo_actual = 0;
            string numero_operacion = "";
            double _capital_pagado = 0;
            if (_tipo == "C")
            {
                numero_operacion = _numero_operacion;

            }
            else
            {
                numero_operacion = "SOBREGIRO" + _numero_operacion.Replace(_mes + _year, "");
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Operacion ->" + _numero_operacion);

            Console.WriteLine("-------------------------");


            ///BUSCO LA FECHA
            /// 

            string where = "   TRIM( estatus_operacion || numero_operacion ) = '" + numero_operacion.Trim() + "' AND extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string tabla = "abonos";
            string columnas = " SUM(capital_pagado) AS capital_pagado  ";
            DataTable dtAconos = AccesoLogica.Select(columnas, tabla, where);

            Console.WriteLine(where);



            int reg3 = dtAconos.Rows.Count;
            if (reg3 > 0)
            {
                foreach (DataRow renglon3 in dtAconos.Rows)
                {
                    if (renglon3["capital_pagado"].ToString().Length > 0)
                    {
                        _capital_pagado = Convert.ToDouble(renglon3["capital_pagado"].ToString());
                    }
                }
            }

            _saldo_actual = _saldo_actual_ere - 0;

            return _saldo_actual;

        }

        public static double DevuelveAbonos(string _tipo, string _numero_operacion, double _saldo_actual_ere, string _year, string _mes)
        {
            double _total_abonos = 0;
            double _saldo_actual = 0;
            string numero_operacion = "";
            double _capital_pagado = 0;
            if (_tipo == "C")
            {
                numero_operacion = _numero_operacion;
            }
            else
            {
                numero_operacion = "SOBREGIRO" + _numero_operacion.Replace(_mes + _year, "");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------");

            Console.WriteLine("-------------------------");



            ///BUSCO LA FECHA
            /// 
            string where = "   TRIM( estatus_operacion || numero_operacion ) = '" + numero_operacion + "' AND extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string tabla = "abonos";
            string columnas = " SUM(capital_pagado) AS capital_pagado";
            DataTable dtAconos = AccesoLogica.Select(columnas, tabla, where);

            int reg3 = dtAconos.Rows.Count;
            if (reg3 > 0)
            {
                foreach (DataRow renglon3 in dtAconos.Rows)
                {
                    if (renglon3["capital_pagado"].ToString().Length > 0)
                    {
                        _capital_pagado = Convert.ToDouble(renglon3["capital_pagado"].ToString());
                    }
                }
            }

            _saldo_actual = _saldo_actual_ere - 0;
            _total_abonos = _capital_pagado;
            //_total_abonos = 0;
            return _saldo_actual;

        }


        public static void InsertaEre04(string _tipo_identificacion_eres_04, string _identificacion_sujeto_eres_04, string _numero_operacion_eres_04, string _dias_morosidad_eres_04, string _metodologia_calificacion_eres_04, string _calificacion_propia_eres_04, string _calificacion_homologada_eres_04, double _tasa_interes_eres_04, double _valor_vencer_1_a_30_eres_04, double _valor_vencer_31_a_90_eres_04, double _valor_vencer_91_a_180_eres_04, double _valor_vencer_181_a_360_eres_04, double _valor_vencer_mas_360_eres_04, double _valor_no_devenga_interes_1_a_30_eres_04, double _valor_no_devenga_interes_31_a_90_eres_04, double _valor_no_devenga_interes_91_a_180_eres_04, double _valor_no_devenga_interes_181_a_360_eres_04, double _valor_no_devenga_interes_mas_360_eres_04, double _valor_vencido_1_a_30_eres_04, double _valor_vencido_31_a_90_eres_04, double _valor_vencido_91_a_180_eres_04, double _valor_vencido_181_a_360_eres_04, double _valor_mas_360_eres_04, double _valor_vencido_181_a_270_eres_04, double _valor_mas_270_eres_04, double _valor_vencido_91_a_270_eres_04, double _valor_vencido_271_a_360_eres_04, double _valor_vencido_361_a_720_eres_04, double _valor_mas_720_eres_04, double _gastos_recuperacion_cartera_vencida_eres_04, double _interes_ordinario_eres_04, double _interes_sobre_mora_eres_04, double _demanda_judicial_eres_04, double _cartera_castigada_eres_04, double _provision_requerida_original_eres_04, double _provision_requerida_reducida_eres_04, double _provision_constituida_eres_04, string _tipo_operacion_eres_04, string _objeto_fedeicomiso_eres_04, double _prima_o_descuento_eres_04, double _cuota_credito_eres_04)
        {
            // ins_eres_04(_tipo_identificacion_eres_04 character varying, _identificacion_sujeto_eres_04 character varying, _numero_operacion_eres_04 character varying, _dias_morosidad_eres_04 character varying, _metodologia_calificacion_eres_04 character varying, _calificacion_propia_eres_04 character varying, _calificacion_homologada_eres_04 character varying, _tasa_interes_eres_04 numeric, _valor_vencer_1_a_30_eres_04 numeric, _valor_vencer_31_a_90_eres_04 numeric, _valor_vencer_91_a_180_eres_04 numeric, _valor_vencer_181_a_360_eres_04 numeric, _valor_vencer_mas_360_eres_04 numeric, _valor_no_devenga_interes_1_a_30_eres_04 numeric, _valor_no_devenga_interes_31_a_90_eres_04 numeric, _valor_no_devenga_interes_91_a_180_eres_04 numeric, _valor_no_devenga_interes_181_a_360_eres_04 numeric, _valor_no_devenga_interes_mas_360_eres_04 numeric, _valor_vencido_1_a_30_eres_04 numeric, _valor_vencido_31_a_90_eres_04 numeric, _valor_vencido_91_a_180_eres_04 numeric, _valor_vencido_181_a_360_eres_04 numeric, _valor_mas_360_eres_04 numeric, _valor_vencido_181_a_270_eres_04 numeric, _valor_mas_270_eres_04 numeric, _valor_vencido_91_a_270_eres_04 numeric, _valor_vencido_271_a_360_eres_04 numeric, _valor_vencido_361_a_720_eres_04 numeric, _valor_mas_720_eres_04 numeric, _gastos_recuperacion_cartera_vencida_eres_04 numeric, _interes_ordinario_eres_04 numeric, _interes_sobre_mora_eres_04 numeric, _demanda_judicial_eres_04 numeric, _cartera_castigada_eres_04 numeric, _provision_requerida_original_eres_04 numeric, _provision_requerida_reducida_eres_04 numeric, _provision_constituida_eres_04 numeric, _tipo_operacion_eres_04 character varying, _objeto_fedeicomiso_eres_04 character varying, _prima_o_descuento_eres_04 numeric, _cuota_credito_eres_04 numeric)


            string cadena1 = _tipo_identificacion_eres_04 + "?" + _identificacion_sujeto_eres_04 + "?" + _numero_operacion_eres_04 + "?" + _dias_morosidad_eres_04 + "?" + _metodologia_calificacion_eres_04 + "?" + _calificacion_propia_eres_04 + "?" + _calificacion_homologada_eres_04 + "?" + _tasa_interes_eres_04 + "?" + _valor_vencer_1_a_30_eres_04 + "?" + _valor_vencer_31_a_90_eres_04 + "?" + _valor_vencer_91_a_180_eres_04 + "?" + _valor_vencer_181_a_360_eres_04 + "?" + _valor_vencer_mas_360_eres_04 + "?" + _valor_no_devenga_interes_1_a_30_eres_04 + "?" + _valor_no_devenga_interes_31_a_90_eres_04 + "?" + _valor_no_devenga_interes_91_a_180_eres_04 + "?" + _valor_no_devenga_interes_181_a_360_eres_04 + "?" + _valor_no_devenga_interes_mas_360_eres_04 + "?" + _valor_vencido_1_a_30_eres_04 + "?" + _valor_vencido_31_a_90_eres_04 + "?" + _valor_vencido_91_a_180_eres_04 + "?" + _valor_vencido_181_a_360_eres_04 + "?" + _valor_mas_360_eres_04 + "?" + _valor_vencido_181_a_270_eres_04 + "?" + _valor_mas_270_eres_04 + "?" + _valor_vencido_91_a_270_eres_04 + "?" + _valor_vencido_271_a_360_eres_04 + "?" + _valor_vencido_361_a_720_eres_04 + "?" + _valor_mas_720_eres_04 + "?" + _gastos_recuperacion_cartera_vencida_eres_04 + "?" + _interes_ordinario_eres_04 + "?" + _interes_sobre_mora_eres_04 + "?" + _demanda_judicial_eres_04 + "?" + _cartera_castigada_eres_04 + "?" + _provision_requerida_original_eres_04 + "?" + _provision_requerida_reducida_eres_04 + "?" + _provision_constituida_eres_04 + "?" + _tipo_operacion_eres_04 + "?" + _objeto_fedeicomiso_eres_04 + "?" + _prima_o_descuento_eres_04 + "?" + _cuota_credito_eres_04;

            string cadena2 = "_tipo_identificacion_eres_04?_identificacion_sujeto_eres_04?_numero_operacion_eres_04?_dias_morosidad_eres_04?_metodologia_calificacion_eres_04?_calificacion_propia_eres_04?_calificacion_homologada_eres_04?_tasa_interes_eres_04?_valor_vencer_1_a_30_eres_04?_valor_vencer_31_a_90_eres_04?_valor_vencer_91_a_180_eres_04?_valor_vencer_181_a_360_eres_04?_valor_vencer_mas_360_eres_04?_valor_no_devenga_interes_1_a_30_eres_04?_valor_no_devenga_interes_31_a_90_eres_04?_valor_no_devenga_interes_91_a_180_eres_04?_valor_no_devenga_interes_181_a_360_eres_04?_valor_no_devenga_interes_mas_360_eres_04?_valor_vencido_1_a_30_eres_04?_valor_vencido_31_a_90_eres_04?_valor_vencido_91_a_180_eres_04?_valor_vencido_181_a_360_eres_04?_valor_mas_360_eres_04?_valor_vencido_181_a_270_eres_04?_valor_mas_270_eres_04?_valor_vencido_91_a_270_eres_04?_valor_vencido_271_a_360_eres_04?_valor_vencido_361_a_720_eres_04?_valor_mas_720_eres_04?_gastos_recuperacion_cartera_vencida_eres_04?_interes_ordinario_eres_04?_interes_sobre_mora_eres_04?_demanda_judicial_eres_04?_cartera_castigada_eres_04?_provision_requerida_original_eres_04?_provision_requerida_reducida_eres_04?_provision_constituida_eres_04?_tipo_operacion_eres_04?_objeto_fedeicomiso_eres_04?_prima_o_descuento_eres_04?_cuota_credito_eres_04";

            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Numeric?NpgsqlDbType.Numeric";

            try
            {
                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_eres_04");
                Console.WriteLine("Insertado ....." + _numero_operacion_eres_04);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion_eres_04 + " ->" + Ex.Message);
                Console.WriteLine("-------------------------------------------------");
            }



        }


        public static void InsertaEre05(string _tipo_identificacion_eres_04, string _identificacion_sujeto_eres_04, string _numero_operacion_eres_04, string _tipo_transaccion, DateTime _fecha_cancelacion, string _forma_cancelacion, string _calificacion)
        {

            string cadena1 = _tipo_identificacion_eres_04 + "?" + _identificacion_sujeto_eres_04 + "?" + _numero_operacion_eres_04 + "?" + _tipo_transaccion + "?" + _fecha_cancelacion + "?" + _forma_cancelacion + "?" + _calificacion;

            string cadena2 = "_tipo_identificacion_eres_04?_identificacion_sujeto_eres_04?_numero_operacion_eres_04?_tipo_transaccion?_fecha_cancelacion?_forma_cancelacion?_calificacion";

            string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar?NpgsqlDbType.DateTime?NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";

            try
            {
                int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_eres_05");
                Console.WriteLine("Insertado ....." + _numero_operacion_eres_04);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion_eres_04 + " ->" + Ex.Message);
                Console.WriteLine("-------------------------------------------------");
            }



        }







        public static void BuscarFechas()
        {
            DateTime fecha_inicio = DateTime.Now;
            double capital_prestado;
            DateTime fecha_final = DateTime.Now;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;
            string tipo = "";
            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;
            int reg3 = 0;
            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion LIKE '%%'   ");

            regSaldo = dtSaldo.Rows.Count;

            string num_ope = "";
            if (regSaldo > 0)
            {
                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    tipo = Convert.ToString(renglon["tipo"].ToString());

                    if (tipo == "C")
                    {
                        numero_operacion = num_ope;
                    }
                    else
                    {
                        numero_operacion = "SOBR" + num_ope.Replace("082014", "");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");



                    ///BUSCO LA FECHA
                    /// 
                    DataTable dtCliente = AccesoLogica.Select(" * ", "fc_clientes", " numero_operacion = '" + numero_operacion + "' ");

                    reg3 = dtCliente.Rows.Count;
                    if (reg3 > 0)
                    {
                        foreach (DataRow renglon3 in dtCliente.Rows)
                        {

                            //num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                            if (renglon3["fecha_inicio"].ToString().Length > 0)
                            {
                                fecha_inicio = Convert.ToDateTime(renglon3["fecha_inicio"].ToString());
                            }
                            if (renglon3["fecha_final"].ToString().Length > 0)
                            {
                                fecha_final = Convert.ToDateTime(renglon3["fecha_inicio"].ToString());
                            }


                            capital_prestado = Convert.ToDouble(renglon3["capital_prestado"].ToString());

                            AccesoLogica.Update("cabeza_eres_04", " fecha_inicio = '" + fecha_inicio + "', fecha_finalizacion = '" + fecha_final + "'    ", "numero_operacion = '" + num_ope + "' ");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Inicio: " + fecha_inicio + "  Final: " + fecha_final);

                            Console.WriteLine("-------------------------");

                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + num_ope);
                Console.ForegroundColor = ConsoleColor.White;

            }




        }





        public static void BuscarFechas2()
        {


            DateTime fecha_inicio = DateTime.Now;
            double capital_prestado;
            DateTime fecha_final = DateTime.Now;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;
            string tipo = "";
            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;
            int reg3 = 0;
            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion LIKE '%%'   ");

            regSaldo = dtSaldo.Rows.Count;

            string num_ope = "";
            if (regSaldo > 0)
            {
                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    num_ope = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    tipo = Convert.ToString(renglon["tipo"].ToString());

                    if (tipo == "C")
                    {
                        numero_operacion = num_ope;
                    }
                    else
                    {
                        numero_operacion = "SOBR" + num_ope.Replace("082014", "");
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");



                    ///BUSCO LA FECHA
                    /// 
                    DataTable dtCliente = AccesoLogica.Select(" * ", "abonos_dos", " numero_operacion = '" + numero_operacion + "' ");

                    reg3 = dtCliente.Rows.Count;
                    if (reg3 > 0)
                    {
                        foreach (DataRow renglon3 in dtCliente.Rows)
                        {

                            //num_ope = Convert.ToString(renglon["numero_operacion"].ToString());

                            fecha_inicio = Convert.ToDateTime(renglon3["fecha_otorga"].ToString());
                            fecha_final = Convert.ToDateTime(renglon3["fecha_vencimiento"].ToString());



                            //capital_prestado = Convert.ToDouble(renglon3["capital_prestado"].ToString());

                            AccesoLogica.Update("cabeza_eres_04", " fecha_inicio = '" + fecha_inicio + "', fecha_finalizacion = '" + fecha_final + "'    ", "numero_operacion = '" + num_ope + "' ");

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("-------------------------");

                            Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Inicio: " + fecha_inicio + "  Final: " + fecha_final);

                            Console.WriteLine("-------------------------");

                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + num_ope);
                Console.ForegroundColor = ConsoleColor.White;

            }




        }


        public static void LimpiarCabeza()
        {
            Console.WriteLine("Limpiando .....");
            AccesoLogica.Update("cabeza_eres_04", " tipo = 'C' ", " numero_operacion LIKE 'R%'   ");
            AccesoLogica.Update("cabeza_eres_04", " numero_operacion = replace(numero_operacion, '072014', '082014')  ", " tipo = 'S'    ");
            //AccesoLogica.Delete(" tipo = 'S' ", "cabeza_eres_04");
            Console.WriteLine("Limpio .....");
        }


        public static void BuscaOperaciones(string _mes, string _year)
        {

            Console.WriteLine("Buscando Operaciones .....");
            string columnas = " * ";
            string tabla = " abonos ";


            string where = "   extract(MONTH  FROM fecha_pago_abono) = '" + Convert.ToInt16(_mes) + "'  AND extract(YEAR  FROM fecha_pago_abono) = '" + Convert.ToInt32(_year) + "'  ";
            string _numero_ope = "";
            string _numero_operacion = "";
            string _cedula_cliente = "";
            DateTime _fecha_pago_abono;
            Double _capital_pagado = 0;
            string _identificacion_cliente;
            string _estado_operacion = "";
            DataTable dtAbonos = AccesoLogica.Select(columnas, tabla, where);
            Console.WriteLine("Buscando Anonos .....");
            int regAbonos = dtAbonos.Rows.Count;
            Console.WriteLine("Anonos ->" + regAbonos);
            int reg = 0;
            int reg2 = 0;
            if (regAbonos > 0)
            {
                foreach (DataRow renglonSub in dtAbonos.Rows)
                {
                    _numero_ope = Convert.ToString(renglonSub["numero_operacion"].ToString());
                    _cedula_cliente = Convert.ToString(renglonSub["cedula_cliente"].ToString());
                    _fecha_pago_abono = Convert.ToDateTime(renglonSub["fecha_pago_abono"].ToString());
                    _capital_pagado = Convert.ToDouble(renglonSub["capital_pagado"].ToString());
                    _estado_operacion = Convert.ToString(renglonSub["estatus_operacion"].ToString());

                    Console.WriteLine("Registro --->" + reg);
                    reg++;
                    if (_estado_operacion.Substring(0, 1) == "R")
                    {
                        _numero_operacion = _estado_operacion + _numero_ope;
                        Console.WriteLine("Credito .....");
                    }
                    else
                    {
                        Console.WriteLine("Sobregiro .....");
                        _numero_operacion = _numero_ope + _mes + _year;

                    }
                    Console.WriteLine("Operacion ->" + _numero_operacion);
                    if (BuscaCabeza(_numero_operacion))
                    {
                        ///actualizo

                    }
                    else
                    {
                        Console.WriteLine("Insertando .....");
                        _numero_operacion = _numero_ope + _mes + _year;
                        _identificacion_cliente = _cedula_cliente;
                        //ins_cabeza_eres_04(_numero_operacion character varying, _identificacion_cliente character varying)
                        string cadena1 = _numero_operacion + "?" + _identificacion_cliente;

                        string cadena2 = "_numero_operacion?_identificacion_cliente";
                        string cadena3 = "NpgsqlDbType.Varchar?NpgsqlDbType.Varchar";
                        try
                        {
                            int resultado = AccesoLogica.Insert(cadena1, cadena2, cadena3, "ins_cabeza_eres_04");
                            Console.WriteLine("Insertado ....." + _numero_operacion);
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Error al insertar Operacion ->" + _numero_operacion + " ->" + Ex.Message);
                            Console.WriteLine("-------------------------------------------------");
                        }





                    }



                }
            }

        }

        public static bool BuscaCabeza(string _numero_operacion)
        {
            bool encontrado = false;
            DataTable dtSaldo;
            int regSaldo;
            int registros = 0;

            string numero_operacion;
            double saldo_actual = 0;
            string identificacion_cliente;

            dtSaldo = AccesoLogica.Select(" * ", "cabeza_eres_04", " numero_operacion = '" + _numero_operacion + "'   ");

            regSaldo = dtSaldo.Rows.Count;

            if (regSaldo > 0)
            {




                foreach (DataRow renglon in dtSaldo.Rows)
                {
                    registros++;

                    numero_operacion = Convert.ToString(renglon["numero_operacion"].ToString());
                    //saldo_actual = Convert.ToDouble(renglon["saldo_actual"].ToString());
                    identificacion_cliente = Convert.ToString(renglon["identificacion_cliente"].ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-------------------------");

                    Console.WriteLine("Cabeza #" + registros + "  Operacion: " + numero_operacion + "  Identificacion: " + identificacion_cliente + "  Saldo: " + saldo_actual);

                    Console.WriteLine("-------------------------");
                    encontrado = true;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Encuentro ->" + _numero_operacion);
                Console.ForegroundColor = ConsoleColor.White;

            }



            return encontrado;
        }


    
    */
    
    }


}


   


