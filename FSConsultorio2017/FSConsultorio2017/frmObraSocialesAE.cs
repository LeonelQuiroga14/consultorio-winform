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
    public partial class frmObraSocialesAE : Form
    {
        public frmObraSocialesAE()
        {
            InitializeComponent();
        }

        private ObraSociales obrasocial;
        private bool Editar = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (obrasocial == null)
                {
                    obrasocial = new ObraSociales();
                }
                obrasocial.ObraSocial = txtObraSocial.Text;

                if (!Editar)
                {
                    try
                    {
                        ObrasSocialesBD.Agregar(obrasocial);
                        MessageBox.Show("Obra Social agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtObraSocial.Clear();
                            txtObraSocial.Focus();
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

        public void SetObraSocial(ObraSociales os)
        {
            obrasocial = os;
        }
        public ObraSociales GetObraSocial()
        {
            return obrasocial;
        }
        public void SetEditar(bool v)
        {
            Editar = v;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtObraSocial.Text))
            {
                valido = false;
                errorProvider1.SetError(txtObraSocial,"Debe ingresar datos ");
            }
            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (obrasocial!=null)
            {
                txtObraSocial.Text = obrasocial.ObraSocial;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }
    }
}
