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
    public partial class frmMedicoEspecialidadAE : Form
    {
        public frmMedicoEspecialidadAE()
        {
            InitializeComponent();
        }


        private MedicoEspecialidad me;
        private bool Editar = false;

        //
        internal void SetEditar(bool v)
        {
            Editar = v;
        }

        internal void SetMedicoEspecialidad(MedicoEspecialidad mp)
        {
            me = mp;
        }

        internal MedicoEspecialidad GetMedicoEspecialidad()
        {
            return me;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MedicosBD.CargarCombobox(ref cboMedico);
            EspecialidadesBD.CargarCombobox(ref cboEspecialidad);
            if (me != null)
            {
                cboMedico.SelectedValue = me.Medico.IdMedico;
                cboEspecialidad.SelectedValue = me.Especialidad.IdEspecialidad;
                txtmatricula.Text = me.Matricula;
                txtCosto.Text = me.CostoConsulta.ToString();

            }
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (me == null)
                {
                    me = new MedicoEspecialidad();

                }
                me.Especialidad = (Especialidades)cboEspecialidad.SelectedItem;
                me.Medico = (Medicos)cboMedico.SelectedItem;
                me.Matricula = txtmatricula.Text;
                me.CostoConsulta = Convert.ToDecimal(txtCosto.Text);

                if (!Editar)
                {
                    try
                    {
                        MedicoEspecialidadBD.Agregar(me);
                        MessageBox.Show("Medico-Especialidad agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            cboMedico.SelectedIndex = 0;
                            cboEspecialidad.SelectedIndex = 0;
                            txtmatricula.Clear();
                            txtCosto.Clear();
                            cboMedico.Focus();
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
            if (cboMedico.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboMedico,"Seleccione un medico");
            }
            if (cboEspecialidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboEspecialidad, "Seleccione una especialidad");
            }
            if (string.IsNullOrEmpty(txtmatricula.Text))
            {
                valido = false;
                errorProvider1.SetError(txtmatricula, "ingrese datos");
            }
            if (string.IsNullOrEmpty(txtCosto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCosto, "ingrese datos");
            }
            decimal costo;
            if (!(decimal.TryParse(txtCosto.Text ,out costo)))
            {
                valido = false;
                errorProvider1.SetError(txtCosto, "ingrese datos numericos");
            }

            return valido;
        }
    }
}
