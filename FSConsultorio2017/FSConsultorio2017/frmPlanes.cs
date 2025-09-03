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
    public partial class frmPlanes : Form
    {
        public frmPlanes()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static frmPlanes frm = null;

        public static frmPlanes Instancia()
        {
            if (frm==null)
            {
                frm=new frmPlanes();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private List<Planes> lista;
        private void frmPlanes_Load(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;
            try
            {
                lista = PlanesBD.GetLista();
                MostrarDatosGrilla(lista);

            }
            catch (Exception)
            {
                
                throw;
            }

        }
        // x= -53 y= -49 130°

        private void MostrarDatosGrilla(List<Planes> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var plan in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, plan);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Planes plan)
        {
            r.Cells[cmnPlan.Index].Value = plan.Plan;
            r.Cells[cmnOs.Index].Value = plan.ObraSocial.ObraSocial;
            if (plan.Cobertura == (decimal)1.00)
            {
                r.Cells[cmnCobertura.Index].Value = "El plan no posee cobertura";
            }
            else
            {
                r.Cells[cmnCobertura.Index].Value = plan.Cobertura.ToString("F") + "%";
            }
            r.Tag = plan;
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmPlanesAE frm = new frmPlanesAE();
            {
                Text = "Agregar Plan";
            }
            ;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = PlanesBD.GetLista();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
               Planes plan= (Planes)r.Tag;
                Planes planAux = (Planes)plan.Clone();
                frmPlanesAE frm = new frmPlanesAE { Text = "Editar Plan" };
                frm.SetEditar(true);
                frm.SetPlan(plan);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        plan= frm.GetPlan();
                        PlanesBD.Editar(plan);
                        SetearFila(r, plan);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, planAux);

                    }
                }
            }
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            new Exportar().ExportarDgv(dgvDatos);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Planes plan = (Planes)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar a {plan.Plan}?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        PlanesBD.Borrar(plan);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Plan eliminado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
