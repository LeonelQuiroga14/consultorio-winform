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
    public partial class frmGenerosAE : Form
    {
        public frmGenerosAE()
        {
            InitializeComponent();
        }

        private Generos genero;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (genero != null)
            {
                txtGenero.Text = genero.Genero;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool Editar = false;

        public void SetEditar(bool p)
        {
            Editar = p;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (genero == null)
                {
                    genero = new Generos();
                }
                genero.Genero = txtGenero.Text;

                if (!Editar)
                {
                    try
                    {
                        GenerosBD.Agregar(genero);
                        MessageBox.Show("Genero agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtGenero.Clear();
                            txtGenero.Focus();
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

        public void SetGenero(Generos p)
        {
            genero = p;

        }
        public Generos GetGenero()
        {
            return genero;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtGenero.Text))
            {
                valido = false;
                errorProvider1.SetError(txtGenero, "Debe ingresar datos validos");
            }
            double valor;
            if (double.TryParse(txtGenero.Text, out valor))
            {
                valido = false;
                errorProvider1.SetError(txtGenero, "No se admiten valores numericos");
            }
            return valido;
        }

    }
}

