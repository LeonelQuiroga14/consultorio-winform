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
    public partial class frmDiasAE : Form
    {
        public frmDiasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private Dias dia;
        private bool Editar = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (dia == null)
                {
                    dia = new Dias();
                }
                dia.Dia = txtDia.Text;

                if (!Editar)
                {
                    try
                    {
                        DiasBD.Agregar(dia);
                        MessageBox.Show("Dia agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {

                            
                            txtDia.Clear();
                            txtDia.Focus();
                        }
                        else
                        {
                            frmDias.VerificarCantidad();
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
                    frmDias.VerificarCantidad();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        internal void SetEditar(bool v)
        {
            Editar = v;
        }

        internal Dias GetDia()
        {
            return dia;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (dia!=null)
            {
                txtDia.Text = dia.Dia;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDia.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDia,"Debe ingresar datos");
            }
            return valido;
        }

        public void SetDia(Dias d)
        {
            dia = d;
        }
    }
}
