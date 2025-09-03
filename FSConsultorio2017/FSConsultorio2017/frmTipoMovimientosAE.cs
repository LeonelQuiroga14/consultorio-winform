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
    public partial class frmTipoMovimientosAE : Form
    {
        public frmTipoMovimientosAE()
        {
            InitializeComponent();
        }

        private bool Editar = false;

        public void SetEditar(bool p)
        {
            Editar = p;
        }

        private TipoMovimientos tipoMov;

        public void SetTipoMovimientos(TipoMovimientos tm)
        {
            tipoMov = tm;
        }

        public TipoMovimientos GetTipoMovimientos()
        {
            return tipoMov;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoMov!=null)
            {
                txtTipoMov.Text = tipoMov.TipoMovimiento;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoMov == null)
                {
                    tipoMov = new TipoMovimientos();
                }
                tipoMov.TipoMovimiento = txtTipoMov.Text;
                if (!Editar)
                {
                    try
                    {
                        TiposMovimientosBD.Agregar(tipoMov);
                        MessageBox.Show("RegistroAgregado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea Agregar otro Registro?", "Continuar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtTipoMov.Clear();
                            txtTipoMov.Focus();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoMov.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTipoMov,"Debe inngresar datos");
            }
            double valor;
            if (double.TryParse(txtTipoMov.Text,out valor))
            {
                valido = false;
                errorProvider1.SetError(txtTipoMov,"No se admiten valores numericos");
            }
            return valido;
        }
    }
}
