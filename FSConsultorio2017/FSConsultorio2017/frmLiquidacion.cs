using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Datos;

namespace FSConsultorio2017
{
    public partial class frmLiquidacion : Form
    {
        public frmLiquidacion()
        {
            InitializeComponent();
        }

        internal void SetLiquidacion(CuentasCorrientesMedicos cuenta, decimal total)
        {
            this.cuenta = cuenta;
            this.t = total;
        }
        decimal t;
        CuentasCorrientesMedicos cuenta;




        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            var v = true;
            if (string.IsNullOrEmpty(txtRecaudadoObraSocial.Text))
            {
                errorProvider1.SetError(txtRecaudadoObraSocial, "reinicie la operacion");
                v = false;
            }
            if (string.IsNullOrEmpty(txtAlquiler.Text))
            {
                errorProvider1.SetError(txtAlquiler, "reinicie la operacion");
                v = false;
            }
            if (string.IsNullOrEmpty(txtLiquidacion.Text))
            {
                errorProvider1.SetError(txtLiquidacion, "reinicie la operacion");
                v = false;
            }
            return v;
        }

        private void frmLiquidacion_Load(object sender, EventArgs e)
        {
            if (cuenta == null)
            {
                cuenta = new CuentasCorrientesMedicos();
            }
            txtRecaudadoObraSocial.Text = t.ToString();
            txtAlquiler.Text = cuenta.alquilerConsultorio.Consultorio.Costo.ToString();
            txtLiquidacion.Text = (cuenta.alquilerConsultorio.Consultorio.Costo - t).ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                CtasCtesMedicosBD.Editar(cuenta);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
