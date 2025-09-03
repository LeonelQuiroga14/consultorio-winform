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
    public partial class frmLocalidadesAE : Form
    {
        public frmLocalidadesAE()
        {
            InitializeComponent();
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }

        private Localidad localidad;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ProvinciaBD.CargarCombobox(ref cboProvincia);
            if (localidad != null)

            {
                
                cboProvincia.SelectedValue = localidad.provincia.IdProvincia;
                txtLocalidad.Text = localidad.NombreLocalidad;
            }
        }

        private void frmLocalidadesAE_Load(object sender, EventArgs e)
        {

        }

        private bool Editar = false;

        public  void SetEditar(bool p)
        {
            Editar = p;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidad==null)
                {
                    localidad=new Localidad();

                }
                localidad.NombreLocalidad = txtLocalidad.Text;
                localidad.provincia = (Provincia)cboProvincia.SelectedItem;
                if (!Editar)
                {
                    try
                    {
                        LocalidadesBD.Agregar(localidad);
                        MessageBox.Show("Localidad agregada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            txtLocalidad.Clear();
                            txtLocalidad.Focus();
                            cboProvincia.SelectedIndex = 0;
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
                {
                    this.DialogResult=DialogResult.OK;
                }
            }
           
            
        }

        internal void SetLocalidad(Localidad loc)
        {
            localidad = loc;
        }

        internal Localidad GetLocalidad()
        {
            return localidad;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad,"Debe ingresar una localidad");
        }
            if (cboProvincia.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincia,"Debe seleccionar una provincia");
            }
            return valido;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmProvinciasAE frm = new frmProvinciasAE();
            frm.Text = "Agregar Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    //Provincia provincia = frm.GetProvincia();
                    //ProvinciaBD.Agregar(provincia);
                    MessageBox.Show("Provincia agregada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ProvinciaBD.CargarCombobox(ref cboProvincia);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
