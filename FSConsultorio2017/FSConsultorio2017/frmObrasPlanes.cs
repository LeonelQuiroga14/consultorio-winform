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
    public partial class frmObrasPlanes : Form
    {
        public frmObrasPlanes()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmObrasPlanes_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
            try
            {
                lista = ObrasPlanesBD.GetLista();
                    MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private List<ObrasPlan> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmObrasPlanesAE frm = new frmObrasPlanesAE {Text = "Agregar Obra-Plan"};
            
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = ObrasPlanesBD.GetLista();
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

        private void MostrarDatosGrilla(List<ObrasPlan> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ObrasPlan item)
        {
            r.Cells[cmnObra.Index].Value = item.ObraSocial.ObraSocial.ToUpper();
            r.Cells[cmnPlan.Index].Value = item.plan.Plan.ToUpper();
            r.Cells[cmnCobertura.Index].Value = item.Cobertura.ToString()+"%";
            r.Tag = item;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                 ObrasPlan op = (ObrasPlan)r.Tag;
                ObrasPlan opAux = (ObrasPlan)op.Clone();
                frmObrasPlanesAE frm = new frmObrasPlanesAE { Text = "Editar Obra-Plan" };
                frm.SetEditar(true);
                frm.SetObraPlan(op);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        op = frm.GetObraPlan();
                        ObrasPlanesBD.Editar(op);
                        SetearFila(r, op);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, opAux);

                    }
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                ObrasPlan op = (ObrasPlan)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format("¿Desea eliminar a {0}-{1}?",op.ObraSocial.ObraSocial,op.plan.Plan),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ObrasPlanesBD.Borrar(op);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Obra-Plan eliminada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static frmObrasPlanes frm = null;
        internal static frmObrasPlanes Instancia()
        {
            if (frm==null)
            {
                frm= new frmObrasPlanes();
                frm.FormClosed+= new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
    }
}
