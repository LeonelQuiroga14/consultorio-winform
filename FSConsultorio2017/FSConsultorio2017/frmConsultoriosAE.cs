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
    public partial class frmConsultoriosAE : Form
    {
        public frmConsultoriosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (consultorio!=null)
            {
                txtConsultorio.Text = consultorio.Consultorio;
                txtCosto.Text = consultorio.Costo.ToString();
                chkEstado.Checked = consultorio.Estado;
            }
            
        }

        private Consultorios consultorio;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        internal void SetConsultorio(Consultorios con)
        {
            consultorio = con;
        }

        internal void SetEditar(bool v)
        {
            Editar = v;
        }

        internal Consultorios GetConsultorio()
        {
            return consultorio;
        }

        private bool Editar = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (consultorio == null)
                {
                    consultorio = new Consultorios();

                }
                consultorio.Consultorio = txtConsultorio.Text;
                consultorio.Costo = Convert.ToDecimal(txtCosto.Text);
                consultorio.Estado = chkEstado.Checked;
                if (!Editar)
                {
                    try
                    {
                        ConsultoriosBD.Agregar(consultorio);
                        MessageBox.Show("Consultorio agregado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtConsultorio.Clear();
                            txtCosto.Clear();
                            chkEstado.Checked = false;
                            txtConsultorio.Focus();
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
            if (string.IsNullOrEmpty(txtConsultorio.Text))
            {
                valido = false;
                errorProvider1.SetError(txtConsultorio, "Debe ingresar datos");
            }
            decimal v;
            if (!decimal.TryParse(txtCosto.Text, out v))
            {
                valido = false;
                errorProvider1.SetError(txtCosto, "Debe ingresar un costo en valores numericos");
            }
            else if (v <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtCosto, "Debe ingresar un valor mayor a 0");
            }
            return valido;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "";
            if (chkEstado.Checked == true)
            {
                chkEstado.Text = "Habilitado";
                this.label4.Text = "El consultorio se puede alquilar";
            }

            else
            {
                if (chkEstado.Checked == false)

                    chkEstado.Text = "Deshabilitado";
                
                label4.Text = "El consultorio se encuentra en Reparacion \nO no es apto para el alquiler";
            }
        }

        private void frmConsultoriosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
