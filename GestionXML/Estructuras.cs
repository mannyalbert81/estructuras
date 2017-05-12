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

namespace GestionXML
{
    public partial class Estructuras : Form
    {
        public Estructuras()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox1.Items.Add("Conectando ........");

            listBox1.Items.Add("Buscando Abonos ........");
            
            string columnas = " * ";
            string tabla = " abonos ";

            string _mes = comboBox1.SelectedValue.ToString();
            string _year = comboBox2.SelectedValue.ToString();
            string where = "   extract(MONTH  FROM fecha_pago_abono) = '"+  Convert.ToInt16( _mes) +"'  AND extract(YEAR  FROM fecha_pago_abono) = '"+ Convert.ToInt32(_year)+"'  ";
            string _numero_ope = "";
            string _numero_operacion = "";
            string _cedula_cliente = "";
            DateTime _fecha_pago_abono;
            Double _capital_pagado = 0;
            DataTable dtSaldo = null;
            int regSaldo;
            int registros = 0;
            DataTable dtAbonos = AccesoLogica.Select(columnas,tabla, where);

            string numero_operacion;
            double saldo_actual;
            string identificacion_cliente;
            int regAbonos = dtAbonos.Rows.Count;
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

                    _numero_operacion = _numero_ope + _mes + _year;
                    
                    listBox1.Items.Add("#: " + reg + " Operacion: " + _numero_operacion + "  Identificacion: " + _cedula_cliente + " Fecha Pago: " + _fecha_pago_abono + " Capital: " + _capital_pagado);
                    reg++;


                    

                }
            }
            

            
            
        }

        private void Estructuras_Load(object sender, EventArgs e)
        {
            clases.Funciones.CargarCombo(comboBox1, "id_meses", "nombre_meses", "meses");
            llenarComboYear();
        }

        public void llenarComboYear()
        {

            List<clases.Item> lista = new List<clases.Item>();

            int i = 0;
            for (i = 2000; i < 2017; i++)
            {
                lista.Add(new clases.Item(Convert.ToString(i), Convert.ToString(i) ));
            }
            
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Value";
            comboBox2.DataSource = lista;

        }
    }
}
