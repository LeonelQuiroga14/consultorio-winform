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
    public partial class frmPlanesAE : Form
    {
        public frmPlanesAE()
        {
            InitializeComponent();
        }





        private Planes plan;


        public Planes GetPlan()
        {
            return plan;
        }
        public void SetPlan(Planes p)
        {
            plan = p;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            if (plan!=null)
            {
                txtPlan.Text = plan.Plan;
                cboObraSocial.SelectedValue = plan.ObraSocial.IdObraSocial;
                txtCobertura.Text = plan.Cobertura.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private bool Editar = false;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (plan == null)
                {
                    plan= new Planes();
                }
                plan.Plan = txtPlan.Text;
                plan.ObraSocial = (ObraSociales)cboObraSocial.SelectedItem;
                decimal valor;
               
                    valor =Convert.ToDecimal(txtCobertura.Text);

                if (valor == 0)
                { plan.Cobertura = (decimal)1.00; }
                else
                {
                    plan.Cobertura =valor;
                }
                if (!Editar)
                {
                    try
                    {
                        PlanesBD.Agregar(plan);
                        MessageBox.Show("Plan agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtPlan.Clear();
                            cboObraSocial.SelectedIndex = 0;
                            txtPlan.Focus();
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
            if (string.IsNullOrEmpty(txtPlan.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPlan,"Debe ingresar datos.");
            }
            if (cboObraSocial.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial,"Seleccione una Obra social.");
            }
            decimal v;
            if (!decimal.TryParse(txtCobertura.Text, out v))
            {
                valido = false;
                errorProvider1.SetError(txtCobertura,"Debe ingresar valores numericos");
            }
           else  if (v <0)
           {
               valido = false;
                errorProvider1.SetError(txtCobertura, "Debe ingresar un numero Mayo o igual a 0");

            }
            return valido;
        }

        internal void SetEditar(bool v)
        {
            Editar=v;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmObraSocialesAE frm = new frmObraSocialesAE();
            frm.Text = "Agregar Obra social";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
