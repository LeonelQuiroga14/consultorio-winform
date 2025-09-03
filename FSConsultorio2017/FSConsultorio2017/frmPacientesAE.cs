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
    public partial class frmPacientesAE : Form
    {
        public frmPacientesAE()
        {
            InitializeComponent();
        }

        private Pacientes paciente;
        private bool Editar = false;


        public void SetPaciente(Pacientes pa)
        {
            paciente = pa;
        }

        public Pacientes GetPaciente()
        {
            return paciente;
        }

        public void SetEditar(bool v)
        {
            Editar = v;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            frmTiposDocAE frm = new frmTiposDocAE();
            frm.Text = "Agregar Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    TiposDocBD.CargarCombobox(ref cboTipoDoc);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmGenerosAE frm = new frmGenerosAE();
            frm.Text = "Agregar Genero";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GenerosBD.CargarCombobox(ref cboGenero);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmNacionalidadesAE frm = new frmNacionalidadesAE();
            frm.Text = "Agregar Nacionalidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NacionalidadesBD.CargarCombobox(ref cboNacionalidad);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            frmPlanesAE frm = new frmPlanesAE();
            frm.Text = "Agregar Plan";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //TipoDeProducto tipo = frm.GetTipoDeProducto();
                    //TipoDeProductoBD.Agregar(tipo);
                    //MessageBox.Show("Tipo de Producto agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    PlanesBD.CargarCombobox(ref cboPlanes);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            else if (txtNroDoc.Text.Length > 10)
            {

                valido = false;
                errorProvider1.SetError(txtNroDoc, "Ingresastes mas de 10 numeros");
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
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Debe ingresar datos");
            }
            if (dtpFechaNac.Value == DateTime.Now || dtpFechaNac.Value > DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaNac,
                    "la fecha de nacimiento no puede ser igual o mayor a la fecha actual ");
            }
            if (string.IsNullOrEmpty(txtTelMovil.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelMovil, "Debe ingresar datos");
            }
            if (string.IsNullOrEmpty(txtTelFijo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelFijo, "Debe ingresar datos");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (paciente==null)
                {
                    paciente = new Pacientes();
                }
                paciente.Apellido = txtApellido.Text;
                paciente.Nombre = txtNombre.Text;
                paciente.TipoDoc = (TipoDocumento)cboTipoDoc.SelectedItem;
                paciente.NumeroDoc = Convert.ToInt32(txtNroDoc.Text);
                paciente.Genero = (Generos)cboGenero.SelectedItem;
                paciente.Nacionalidad = (Nacionalidades)cboNacionalidad.SelectedItem;
                paciente.FechaNac = dtpFechaNac.Value;
                paciente.Provincia = (Provincia)cboProvincia.SelectedItem;
                paciente.Localidad = (Localidad) cboLocalidad.SelectedItem;
                paciente.Direccion = txtDireccion.Text;
                paciente.GrupoSanguineo = txtGS.Text;
                paciente.TelefonoMovil = txtTelMovil.Text;
                paciente.TelefonoFijo = txtTelFijo.Text;
                paciente.ObraSocial = (ObraSociales)cboObraSocial.SelectedItem;
                paciente.Plan = (Planes)cboPlanes.SelectedItem;
                paciente.NroAfiliado = txtNroAfiliado.Text;
                if (!Editar)
                {
                    try
                    {
                        PacientesBD.Agregar(paciente);
                        MessageBox.Show("Paciente registrado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea registrar otro paciente?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            LimparControles();
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
                }
                else 
                    this.DialogResult=DialogResult.OK;

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
            txtDireccion.Text=String.Empty;
            dtpFechaNac.Value = DateTime.Now;
            txtTelMovil.Text = string.Empty;
            txtTelFijo.Text = String.Empty;
            cboObraSocial.SelectedIndex = 0;
            cboPlanes.SelectedIndex = 0;
            txtGS.Text=String.Empty;
            txtNroAfiliado.Text = String.Empty;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TiposDocBD.CargarCombobox(ref cboTipoDoc);
            GenerosBD.CargarCombobox(ref cboGenero);
            NacionalidadesBD.CargarCombobox(ref cboNacionalidad);
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            ProvinciaBD.CargarCombobox(ref cboProvincia);
            
            if (paciente!=null)
            {
                txtApellido.Text =paciente.Apellido ;
                txtNombre.Text =paciente.Nombre  ;
                cboTipoDoc.SelectedValue=paciente.TipoDoc.IdTipoDoc;
                txtNroDoc.Text = paciente.NumeroDoc.ToString();
                cboGenero.SelectedValue=paciente.Genero.IdGenero;
                cboNacionalidad.SelectedValue = paciente.Nacionalidad.IdNacionalidad;
                cboProvincia.SelectedValue = paciente.Provincia.IdProvincia;
               // LocalidadesBD.CargarCombobox(ref cboLocalidad,paciente.Provincia);
                cboLocalidad.SelectedValue = paciente.Localidad.IdLocalidad;
                txtDireccion.Text = paciente.Direccion;
                dtpFechaNac.Value=paciente.FechaNac;
                 txtTelMovil.Text =paciente.TelefonoMovil;
                txtTelFijo.Text =paciente.TelefonoFijo ;
                cboObraSocial.SelectedValue=paciente.ObraSocial.IdObraSocial;
                // PlanesBD.CargarDatosCombo(ref cboPlanes, paciente.ObraSocial);
                cboPlanes.SelectedValue = paciente.Plan.IdPlan;
                txtGS.Text = paciente.GrupoSanguineo;
                txtNroAfiliado.Text = paciente.NroAfiliado;
            }
        }

        private void frmPacientesAE_Load(object sender, EventArgs e)
        {
            
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

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedIndex > 0)
            {
                Provincia prov= (Provincia)cboProvincia.SelectedItem;
                LocalidadesBD.CargarCombobox(ref cboLocalidad, prov);
                cboLocalidad.Enabled = true;
            }
            else
            {
                cboLocalidad.DataSource = null;
                cboLocalidad.Enabled = true;
            }
        }
    }
}
