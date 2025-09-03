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
    public partial class frmNacionalidadesAE : Form
    {
        public frmNacionalidadesAE()
        {
            InitializeComponent();
        }

         Nacionalidades nacionalidad;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (nacionalidad!=null)
            {
                txtNacionalidad.Text = nacionalidad.Nacionalidad;
            }
        }

         private bool Editar = false;

        public  void SetEditar(bool p)
        {

            Editar = p;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (nacionalidad==null)
                {
                    nacionalidad = new Nacionalidades();
                }
                nacionalidad.Nacionalidad = txtNacionalidad.Text;
              
                if (!Editar)
                {
                    try
                    {
                        NacionalidadesBD.Agregar(nacionalidad);
                        MessageBox.Show("Nacionalidad agregada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr==DialogResult.Yes)
                        {
                            txtNacionalidad.Clear();
                            txtNacionalidad.Focus();
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

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNacionalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNacionalidad, "Debe ingresar datos validos");
            }
            double valor;
            if (double.TryParse(txtNacionalidad.Text, out valor))
            {
                valido = false;
                errorProvider1.SetError(txtNacionalidad,"No se admiten valores numericos");
            }
            return valido;
        }

        internal void SetNacionalidad(Nacionalidades nac)
        {
            nacionalidad = nac;
        }

        internal Nacionalidades GetNacionalidad()
        {
            return nacionalidad;
        }

        private void frmNacionalidadesAE_Load(object sender, EventArgs e)
        {

        }

        private void txtNacionalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
