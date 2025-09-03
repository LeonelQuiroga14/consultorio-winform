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
    public partial class frmMedicosPlanes : Form
    {
        public frmMedicosPlanes()
        {
            InitializeComponent();
        }

        private static frmMedicosPlanes frm = null;

        public static frmMedicosPlanes GetInstancia()
        {
            if (frm == null)
            {
                frm = new frmMedicosPlanes();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

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

        private void frmMedicosPlanes_Load(object sender, EventArgs e)
        {
            dgvDatos.AllowUserToAddRows = false;
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            try
            {
                lista = MedicosPlanesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                MedicosPlanes mp = (MedicosPlanes) r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar el registro de la lista?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        MedicosPlanesBD.Borrar(mp);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Genero eliminado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                MedicosPlanes mp = (MedicosPlanes)r.Tag;
                MedicosPlanes mpAux = (MedicosPlanes)mp.Clone();
                frmMedicosPlanesAE frm = new frmMedicosPlanesAE { Text = "Editar Medico-Plan" };
                frm.SetEditar(true);
                frm.SetMedicoPlan(mp);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        mp = frm.GetMedicoPlan();
                        MedicosPlanesBD.Editar(mp);
                        SetearFila(r, mp);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception es)
                    {

                        MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, mpAux);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, MedicosPlanes mp)
        {
            r.Cells[cmnNombreApe.Index].Value = mp.MedicoEspecialidad.Medico.ToString();
            r.Cells[cmnEspecialidad.Index].Value = mp.MedicoEspecialidad.Especialidad.Especialidad;
            r.Cells[cmnObraSocial.Index].Value = mp.ObraSocial.ObraSocial;
            r.Cells[cmnGs.Index].Value = mp.Plan.Plan;
            r.Cells[cmnCobertura.Index].Value = mp.Plan.Cobertura.ToString("N");
            r.Tag = mp;
        }

        private List<MedicosPlanes> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmMedicosPlanesAE frm = new frmMedicosPlanesAE() { Text = "Agregar Medico-Plan" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = MedicosPlanesBD.GetLista();
                    MostrarDatosGrilla(lista);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosGrilla(List<MedicosPlanes> lista)
        {
           dgvDatos.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);              
                SetearFila(r,i);AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
}
