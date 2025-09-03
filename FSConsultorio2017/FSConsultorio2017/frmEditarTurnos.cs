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
    public partial class frmEditarTurnos : Form
    {
        public frmEditarTurnos()
        {
            InitializeComponent();
        }

        internal void SetTurno(ReservasTurno t)
        {
            turno = t;
        }
        ReservasTurno turno;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmEditarTurnos_Load(object sender, EventArgs e)
        {
            if (turno!=null)
            {
                cboCobro.Items.Add("<Seleccione el estado>");
                cboCobro.Items.Add("Pendiente");
                cboCobro.Items.Add("Cobrado");
                cboPresente.Items.Add("<Seleccione el estado>");
                cboPresente.Items.Add("Ausente");
                cboPresente.Items.Add("Presente");
                if (turno.Paciente.Plan.Cobertura == 1)
                {
                    cboCobro.Enabled = false;
                    txtArancel.Enabled = false;
                    cboPresente.Text = "<Seleccione el estado>";
                }
                else
                {
                    cboCobro.Enabled = true;
                    txtArancel.Enabled = true;
                    txtArancel.Text = turno.MedicoEspecialidad.CostoConsulta.ToString();
                    if (turno.Cobro == 0)
                    {
                        cboCobro.Text = "<Seleccione el estado>";
                    }
                }
                if (turno.Presente == false)
                {
                    cboPresente.Text = "<Seleccione el estado>";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (cboCobro.Enabled == false)
                {
                    if (cboPresente.Text == "Presente")
                    {
                        turno.Presente = true;
                    }
                    else if (cboPresente.Text == "Ausente")
                    {
                        turno.Presente = false;
                    }
                }
                else
                {
                    if (cboPresente.Text == "Presente")
                    {
                        turno.Presente = true;
                    }
                    else if (cboPresente.Text == "Ausente")
                    {
                        turno.Presente = false;
                    }
                    if (cboCobro.Text == "Cobrado")
                    {

                        turno.Cobro = Convert.ToDecimal(txtArancel.Text)-(Convert.ToDecimal(txtArancel.Text)*(turno.Paciente.Plan.Cobertura/100));
                        try
                        {

                            CtasCtesMedicosBD.Agregar(turno);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                   
                }
                try
                {
                    ReservasTurnosBD.EditarPresenteYCobro(turno);
                    MessageBox.Show("Se guardo el cobro en cuenta corriente", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                MessageBox.Show("Los cambio se efectuaron sin problemas");
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            var V = true;
            if (cboPresente.Text == "<Seleccione el estado>")
            {
                errorProvider1.SetError(cboPresente, "Debe elegir una opcion");
                V = false;
            }
            if (cboCobro.Enabled == true)
            {
                if (cboCobro.Text == "<Seleccione el estado>")
                {
                    errorProvider1.SetError(cboCobro, "Debe elejir una opcion");
                    V = false;
                }
            }
            return V;
        }
    }
}
