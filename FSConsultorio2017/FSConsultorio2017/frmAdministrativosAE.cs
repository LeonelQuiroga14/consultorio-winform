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
    public partial class frmAdministrativosAE : Form
    {
        public frmAdministrativosAE()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private Administrativos administrativo;
        private bool Editar = false;

        public Administrativos GetAdministrativo()
        {
            return administrativo;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TiposDocBD.CargarCombobox(ref cboTipoDoc);
            GenerosBD.CargarCombobox(ref cboGenero);
            NacionalidadesBD.CargarCombobox(ref cboNacionalidad);
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            // PlanesBD.CargarCombobox(ref cboPlanes,(ObraSociales)cboObraSocial.SelectedItem);
            //           cargar combo de planes ver indices en la base de todas las clases agregar datos
            // relaciones y diagrama
            if (administrativo != null)
            {
                txtApellido.Text = administrativo.Apellido;
                txtNombre.Text = administrativo.Nombre;
                cboTipoDoc.SelectedValue = administrativo.TipoDoc.IdTipoDoc;
                txtNroDoc.Text = administrativo.NumeroDoc.ToString();
                cboGenero.SelectedValue = administrativo.Genero.IdGenero;
                cboNacionalidad.SelectedValue = administrativo.Nacionalidad.IdNacionalidad;
                dtpFechaNac.Value = administrativo.FechaNac.Date;
                txtTelMovil.Text = administrativo.TelefonoMovil;
                txtTelFijo.Text = administrativo.TelefonoFijo;
                cboObraSocial.SelectedValue = administrativo.ObraSocial.IdObraSocial;
                PlanesBD.CargarDatosCombo(ref cboPlanes, administrativo.ObraSocial);
                txtNroAfiliado.Text = administrativo.NroAfiliado;
                dtpFechaIngreso.Value = administrativo.FechaIngreso.Date;
                txtSalario.Text = administrativo.Salario.ToString();
                chkEstado.Checked = administrativo.Estado;
            }
        }

        public void SetAdministrativo(Administrativos adm)
        {
            administrativo = adm;
        }

        public void SetEditar(bool v)
        {
            Editar = v;
        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstado.Checked == true)
            {
                chkEstado.Text = "Activa/o";
            }
            else
            {
                chkEstado.Text = "Inactiva/o";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (administrativo == null)
                {
                    administrativo = new Administrativos();
                }
                administrativo.Apellido = txtApellido.Text;
                administrativo.Nombre = txtNombre.Text;
                administrativo.TipoDoc = (TipoDocumento) cboTipoDoc.SelectedItem;
                administrativo.NumeroDoc = Convert.ToInt32(txtNroDoc.Text);
                administrativo.Genero = (Generos) cboGenero.SelectedItem;
                administrativo.Nacionalidad = (Nacionalidades) cboNacionalidad.SelectedItem;
                administrativo.FechaNac = dtpFechaNac.Value;
                administrativo.TelefonoMovil = txtTelMovil.Text;
                administrativo.TelefonoFijo = txtTelFijo.Text;
                administrativo.ObraSocial = (ObraSociales) cboObraSocial.SelectedItem;
                administrativo.Plan = (Planes) cboPlanes.SelectedItem;
                administrativo.NroAfiliado = txtNroAfiliado.Text;
                administrativo.FechaIngreso = dtpFechaIngreso.Value;
                administrativo.Salario = Convert.ToDecimal(txtSalario.Text);
                administrativo.Estado = chkEstado.Checked;
                if (!Editar)
                {
                    try
                    {
                        AdministrativosBD.Agregar(administrativo);
                        MessageBox.Show("Administrativo agregado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            LimpiarControles();
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

        private void LimpiarControles()
        {
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cboTipoDoc.SelectedIndex = 0;
            txtNroDoc.Text = string.Empty;
            cboGenero.SelectedIndex = 0;
            cboNacionalidad.SelectedIndex = 0;
            dtpFechaNac.Value = DateTime.Now;
            txtTelMovil.Text = string.Empty;
            txtTelFijo.Text = String.Empty;
            cboObraSocial.SelectedIndex = 0;
            cboPlanes.SelectedIndex = 0;
            txtNroAfiliado.Text = String.Empty;
            dtpFechaIngreso.Value = DateTime.Now;
            txtSalario.Text = String.Empty;
            chkEstado.Checked = true;
            chkEstado.Text = "Activa/o";
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
            if (string.IsNullOrEmpty(txtNroAfiliado.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNroAfiliado, "Debe ingresar datos");
            }
            if (dtpFechaIngreso.Value > DateTime.Now)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaIngreso, "la fecha de ingreso debe ser menor o igual a la fecha actual ");
            }
            if (string.IsNullOrEmpty(txtSalario.Text))
            {
                valido = false;
                errorProvider1.SetError(txtSalario, "Debe ingresar datos");
            }
            decimal valor;
            if (!decimal.TryParse(txtSalario.Text, out valor))
            {
                valido = false;
                errorProvider1.SetError(txtSalario, "Debe ingresar un costo en valores numericos");
            }
            else if (valor <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtSalario, "Debe ingresar un valor mayor a 0");
            }
            return valido;
        }

        private void cboObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObraSocial.SelectedIndex > 0)
            {
                ObraSociales obrasocial = (ObraSociales) cboObraSocial.SelectedItem;
                PlanesBD.CargarDatosCombo(ref cboPlanes, obrasocial);
                cboPlanes.Enabled = true;
            }
            else
            {
                cboPlanes.DataSource = null;
                cboPlanes.Enabled = true;
            }
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

        private void frmAdministrativosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
    