using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BL;
using Datos;

namespace FSConsultorio2017
{
    public partial class frmProvinciasAE : Form
    {
        public frmProvinciasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private Provincia prov;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (prov == null)
                {
                    prov = new Provincia();
                }
                prov.Nombre = txtProvincia.Text;
                if (!Editar)
                {
                    try
                    {
                        ProvinciaBD.Agregar(prov);
                        MessageBox.Show("Provincia Agregada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            InicializarControles();
                        }
                        else
                        {
                            this.DialogResult=DialogResult.OK;
                        }

                    }
                    catch (Exception ex )
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               
                    
                } else
                    {
                        this.DialogResult=DialogResult.OK;
                    }
            }
        }
        
        private void InicializarControles()
        {
           txtProvincia.Clear();
            txtProvincia.Focus();
        }

        private bool Editar = false;

        public void SetEditar(bool p)
        {
            Editar = p;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProvincia.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "Debe Ingresar datos validos");
            }
            double p;
            if (double.TryParse(txtProvincia.Text, out p))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "No se admiten valores numericos ");

            }
            return valido;
        }

        private void frmProvinciasAE_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.txtProvincia.MaxLength = 100;

        }

        internal void SetProvincia(Provincia pro)
        {
            prov = pro;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (prov!=null)
            {
                txtProvincia.Text = prov.Nombre;
            }
        }

        internal Provincia GetProvincia()
        {
            return prov;
        }
    }
}
