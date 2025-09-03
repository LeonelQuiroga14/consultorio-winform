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
    public partial class frmObrasPlanesAE : Form
    {
        public frmObrasPlanesAE()
        {
            InitializeComponent();
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private ObrasPlan obraplan;
        private bool Editar = false;

        public void SetEditar(bool v)
        {
            Editar = v;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                if (obraplan == null)
                {
                    obraplan = new ObrasPlan();
                }
                obraplan.ObraSocial = (ObraSociales) cboObraSocial.SelectedItem;
                obraplan.plan = (Planes) cboPlanes.SelectedItem;
                obraplan.Cobertura = Convert.ToDecimal(txtCobertura.Text);

                if (!Editar)
                {
                    try
                    {
                        ObrasPlanesBD.Agregar(obraplan);
                        MessageBox.Show("Obra-Plan agregado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            cboObraSocial.SelectedIndex = 0;
                            cboPlanes.SelectedIndex = 0;
                            txtCobertura.Clear();
                            cboObraSocial.Focus();
                        }
                        else
                        {

                            this.DialogResult = DialogResult.OK;
                            //NotifyIcon n= new NotifyIcon();
                            //n.ShowBalloonTip(100,"Registros agregados","Se agregaron todos los registros correctamente",ToolTipIcon.Info);
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            PlanesBD.CargarCombobox(ref cboPlanes);
            if (obraplan != null)
            {
                cboObraSocial.SelectedValue = obraplan.ObraSocial.IdObraSocial;
                cboPlanes.SelectedValue = obraplan.plan.IdPlan;
                txtCobertura.Text = obraplan.Cobertura.ToString();
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboObraSocial.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial, "Debe seleccionar una Obra social");
            }
            if (cboPlanes.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial, "Debe seleccionar un Plan");
            }
            if (string.IsNullOrEmpty(txtCobertura.Text))
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial, "Debe ingresar una cobertura");
            }
            return valido;
        }

        internal void SetObraPlan(ObrasPlan op)
        {
            obraplan = op;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public ObrasPlan GetObraPlan()
        {
            return obraplan;
        }

        private void picOS_Click(object sender, EventArgs e)
        {
            frmObraSocialesAE frm = new frmObraSocialesAE();
            frm.Text = "Agregar Obra social";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //Provincia provincia = frm.GetProvincia();
                    //ProvinciaBD.Agregar(provincia);
                    MessageBox.Show("Obra social agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ObrasSocialesBD.CargarCombobox(ref cboObraSocial);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void picPlan_Click(object sender, EventArgs e)
        {
            frmPlanesAE frm = new frmPlanesAE();
            frm.Text = "Agregar Plan";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //Provincia provincia = frm.GetProvincia();
                    //ProvinciaBD.Agregar(provincia);
                    MessageBox.Show("Plan agregada", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    PlanesBD.CargarCombobox(ref cboPlanes);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmObrasPlanesAE_Load(object sender, EventArgs e)
        {

        }
    }
}
