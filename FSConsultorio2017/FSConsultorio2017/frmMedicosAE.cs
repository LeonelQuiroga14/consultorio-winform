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
    public partial class frmMedicosAE : Form
    {
        public frmMedicosAE()
        {
            InitializeComponent();
        }

       

        internal void SetMedico(Medicos m)
        {
            medico = m;
        }

        internal Medicos GetMedico()
        {
           return medico;
        }

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TiposDocBD.CargarCombobox(ref cboTipoDoc);
            GenerosBD.CargarCombobox(ref cboGenero);
            NacionalidadesBD.CargarCombobox(ref cboNacionalidad);
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            ProvinciaBD.CargarCombobox(ref cboProvincia);

            if (medico != null)
            {
                txtApellido.Text = medico.Apellido;
                txtNombre.Text = medico.Nombre;
                cboTipoDoc.SelectedValue = medico.TipoDoc.IdTipoDoc;
                txtNroDoc.Text = medico.NumeroDoc.ToString();
                cboGenero.SelectedValue = medico.Genero.IdGenero;
                cboNacionalidad.SelectedValue = medico.Nacionalidad.IdNacionalidad;
                cboProvincia.SelectedValue = medico.Provincia.IdProvincia;
                // LocalidadesBD.CargarCombobox(ref cboLocalidad,medico.Provincia);
                cboLocalidad.SelectedValue = medico.Localidad.IdLocalidad;
                txtDireccion.Text = medico.Direccion;
                dtpFechaNac.Value = medico.FechaNac;
                txtTelMovil.Text = medico.TelefonoMovil;
                txtTelFijo.Text = medico.TelefonoFijo;
                cboObraSocial.SelectedValue = medico.ObraSocial.IdObraSocial;
                // PlanesBD.CargarDatosCombo(ref cboPlanes, medico.ObraSocial);
                cboPlanes.SelectedValue = medico.Plan.IdPlan;
                txtGS.Text = medico.GrupoSanguineo;
                txtNroAfiliado.Text = medico.NroAfiliado;
            }
        }

        private Medicos medico;
        private bool Editar = false;

        public void SetEditar(bool v)
        {
            Editar = v;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (medico == null)
                {
                    medico = new Medicos();
                }
                medico.Apellido = txtApellido.Text;
                medico.Nombre = txtNombre.Text;
                medico.TipoDoc = (TipoDocumento)cboTipoDoc.SelectedItem;
                medico.NumeroDoc = Convert.ToInt32(txtNroDoc.Text);
                medico.Genero = (Generos)cboGenero.SelectedItem;
                medico.Nacionalidad = (Nacionalidades)cboNacionalidad.SelectedItem;
                medico.FechaNac = dtpFechaNac.Value;
                medico.Provincia = (Provincia)cboProvincia.SelectedItem;
                medico.Localidad = (Localidad)cboLocalidad.SelectedItem;
                medico.Direccion = txtDireccion.Text;
                medico.GrupoSanguineo = txtGS.Text;
                medico.TelefonoMovil = txtTelMovil.Text;
                medico.TelefonoFijo = txtTelFijo.Text;
                medico.ObraSocial = (ObraSociales)cboObraSocial.SelectedItem;
                medico.Plan = (Planes)cboPlanes.SelectedItem;
                medico.NroAfiliado = txtNroAfiliado.Text;
                if (!Editar)
                {
                    try
                    {
                        MedicosBD.Agregar(medico);
                        MessageBox.Show("medico registrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea registrar otro medico?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            LimparControles();
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
                    this.DialogResult = DialogResult.OK;

            }
        }

        private void LimparControles()
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboTipoDoc.SelectedIndex = 0;
            txtNroDoc.Text = string.Empty;
            cboGenero.SelectedIndex = 0;
            cboNacionalidad.SelectedIndex = 0;
            cboProvincia.SelectedIndex = 0;
            cboLocalidad.SelectedIndex = 0;
            txtDireccion.Text = String.Empty;
            dtpFechaNac.Value = DateTime.Now;
            txtTelMovil.Text = string.Empty;
            txtTelFijo.Text = String.Empty;
            cboObraSocial.SelectedIndex = 0;
            cboPlanes.SelectedIndex = 0;
            txtGS.Text = String.Empty;
            txtNroAfiliado.Text = String.Empty;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Debe ingresar datos");
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Debe ingresar datos");
            }
            if (cboTipoDoc.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoDoc, "Seleccione un tipo de documento");
            }
            if (string.IsNullOrEmpty(txtNroDoc.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNroDoc, "Debe ingresar datos");
            }
            if (cboGenero.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboGenero, "Seleccione un genero");
            }
            if (cboNacionalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboNacionalidad, "Seleccione una nacionalidad");
            }
            if (cboProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia, "Seleccione una Provincia");
            }
            if (cboLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLocalidad, "Seleccione una Localidad");
            }
         
            if (dtpFechaNac.Value == DateTime.Now || dtpFechaNac.Value > DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaNac,
                    "la fecha de nacimiento no puede ser igual o mayor a la fecha actual ");
            }
          
            if (cboObraSocial.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial, "Seleccione una obra social");
            }
            if (cboPlanes.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPlanes, "Seleccione un plan de la obra social");
            }
            if (string.IsNullOrEmpty(txtGS.Text))
            {
                valido = false;
                errorProvider1.SetError(txtGS, "Debe ingresar datos");
            }
            if (string.IsNullOrEmpty(txtNroAfiliado.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNroAfiliado, "Debe ingresar datos");
            }
            return valido;
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboProvincia.SelectedIndex > 0)
            {
                Provincia prov = (Provincia)cboProvincia.SelectedItem;
                LocalidadesBD.CargarCombobox(ref cboLocalidad, prov);
                cboLocalidad.Enabled = true;
            }
            else
            {
                cboLocalidad.DataSource = null;
                cboLocalidad.Enabled = true;
            }
        }

        private void cboObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObraSocial.SelectedIndex > 0)
            {
                ObraSociales obrasocial = (ObraSociales)cboObraSocial.SelectedItem;
                PlanesBD.CargarDatosCombo(ref cboPlanes, obrasocial);
                cboPlanes.Enabled = true;
            }
            else
            {
                cboPlanes.DataSource = null;
                cboPlanes.Enabled = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            frmProvinciasAE frm = new frmProvinciasAE();
            frm.Text = "Agregar Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ProvinciaBD.CargarCombobox(ref cboProvincia);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            frmLocalidadesAE frm = new frmLocalidadesAE();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LocalidadesBD.CargarCombobox(ref cboLocalidad);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
