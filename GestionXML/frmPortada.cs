using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionXML
{
    public partial class frmPortada : Form
    {
        public frmPortada()
        {
            InitializeComponent();
            
            timer2.Interval = 10000;
            timer2.Start();
            timer2.Tick += (s, e) => {
                clases.ImportaCartones.Inserta();
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Hide();
                timer2.Stop();
            };
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            this.progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString() + ".%";
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
