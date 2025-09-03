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
    public partial class frmAdministrativos : Form
    {
        public frmAdministrativos()
        {
            InitializeComponent();
        }

        private static frmAdministrativos frm = null;

        public static frmAdministrativos Instancia()
        {
            if (frm==null)
            {
                frm= new frmAdministrativos();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;

        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            new Exportar().ExportarDgv(dgvDatos);
        }

        private List<Administrativos> lista; 
        private void frmAdministrativos_Load(object sender, EventArgs e)
        {
            dgvDatos.AllowUserToAddRows = false;
            this.Dock=DockStyle.Fill;
            this.FormBorderStyle=FormBorderStyle.SizableToolWindow;
            this.ControlBox = false;
            try
            {
                lista = AdministrativosBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        private void MostrarDatosGrilla(List<Administrativos> lista)
        {
           string estado = "";

           dgvDatos.Rows.Clear();
            foreach (var adm in lista)
            {
                if (adm.Estado == true)
                {
                    estado = "Activo/a";

                }
                else
                {
                    estado = "Inactivo/a";
                }
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, adm);              
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Administrativos adm)
        {
           

            r.Cells[cmnNombreApe.Index].Value = adm.ToString();
            r.Cells[cmnTelefonoMovil.Index].Value = adm.TelefonoMovil;
            r.Cells[cmnTelefonofijo.Index].Value = adm.TelefonoFijo;
            r.Cells[cmnEstado.Index].Value = adm.Estado ? "Activo" : "Inactivo";
            
            r.Tag = adm;
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmAdministrativosAE frm= new frmAdministrativosAE {Text = "Agregar administrativos"};
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = AdministrativosBD.GetLista();
                    MostrarDatosGrilla(lista);

                    // MostrarDatosAgregados();
                    //TipoDocumento tp = frm.GetTipoDocumento();
                    //TiposDocBD.Agregar(tp);
                    //DataGridViewRow r= new DataGridViewRow();
                    //r.CreateCells(dgvDatos);
                    //SetearFila(r,tp);
                    //AgregarFlia(r);
                    //MessageBox.Show("Registro Agregado");


                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
