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
    public partial class frmTiposDocAE : Form
    {
        public frmTiposDocAE()
        {
            InitializeComponent();
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private TipoDocumento tipoDoc;
        private bool Editar =false;

       

       public  void SetEditar(bool p)
       {

           Editar = p;
       }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDoc==null)
                {
                    tipoDoc=new TipoDocumento();
                }
                tipoDoc.TipoDoc = txtTipoDoc.Text;
                if (!Editar)
                {
                    try
                    {
                        TiposDocBD.Agregar(tipoDoc);
                        MessageBox.Show("RegistroAgregado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea Agregar otro Registro?", "Continuar",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                            InicializarControles();
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
                    this.DialogResult=DialogResult.OK;
                }
            }
        }

        private void InicializarControles()
        {
            txtTipoDoc.Clear();
            txtTipoDoc.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDoc.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDoc,"Debe Ingresar Datos");

            }

            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDoc!=null)
            {
                txtTipoDoc.Text = tipoDoc.TipoDoc;
            }
        }

        internal TipoDocumento GetTipoDocumento()
        {
            return tipoDoc;
        }

        internal void SetTipoDocumento(TipoDocumento tp)
        {
            tipoDoc = tp;
        }

        private void frmTiposDocAE_Load(object sender, EventArgs e)
        {

        }
    }
}
