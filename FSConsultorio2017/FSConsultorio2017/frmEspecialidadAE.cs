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
    public partial class frmEspecialidadAE : Form
    {
        public frmEspecialidadAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private Especialidades especialidad;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (especialidad!=null)
            {
                txtEspecialidad.Text = especialidad.Especialidad;
            }
        }

        private bool Editar = false;

        public void SetEditar(bool p)
        {
            Editar = p;
        }
        private void frmEspecialidadesAE_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (especialidad == null)
                {
                    especialidad = new Especialidades();
                }
                especialidad.Especialidad = txtEspecialidad.Text;

                if (!Editar)
                {
                    try
                    {
                        EspecialidadesBD.Agregar(especialidad);
                        MessageBox.Show("Especialidad agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtEspecialidad.Clear();
                            txtEspecialidad.Focus();
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

        public Especialidades GetEspecialidad()
        {
            return especialidad;
        }
        public void SetEspecialidad(Especialidades p)
        {
            especialidad = p;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtEspecialidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtEspecialidad,"Debe ingresar datos");
            }
            double valor;
            if (double.TryParse(txtEspecialidad.Text,out valor))
            {
                valido = false;
                errorProvider1.SetError(txtEspecialidad,"No se admiten valores numericos");
            }
            return valido;
        }
    }
}
