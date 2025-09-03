using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSConsultorio2017
{
    public partial class frmCargaInicio : Form
    {
        public frmCargaInicio()
        {
            InitializeComponent();
        }

        private void frmCargaInicio_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

        }

        public void ProgresoDeCarga()
        {
            progressBar1.Increment(2);
            label1.Text = progressBar1.Value.ToString() + "%";
            if (progressBar1.Value==progressBar1.Maximum)
            {
                timer1.Stop();
                this.Hide();
                frmLogin f = new frmLogin();
                f.Show();


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgresoDeCarga();
        }
    }
}
