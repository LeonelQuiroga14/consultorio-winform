using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace FSConsultorio2017
{
    public partial class frmTipoMovimientos : Form
    {
        public frmTipoMovimientos()
        {
            InitializeComponent();
        }

        private static frmTipoMovimientos frm = null;
        public static frmTipoMovimientos Instancia()
        {
            if (frm == null)
            {
                frm = new frmTipoMovimientos();
                frm.FormClosed += new FormClosedEventHandler(form_FormClosed);
            }
            return frm;
        }
        private static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private List<TipoMovimientos> lista;
       

        private void MostrarDatosGrilla(List<TipoMovimientos> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, item);
                AgregarFlia(r);


            }
        }

        private void AgregarFlia(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoMovimientos item)
        {
            r.Cells[cmnTipoMov.Index].Value = item.TipoMovimiento;
            r.Tag = item;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmTipoMovimientosAE frm = new frmTipoMovimientosAE { Text = "Agregar tipos de movimiento" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    MostrarDatosAgregados();
                    //TipoMovimientos tm = frm.GetTipoMovimientos();
                    //TiposMovimientosBD.Agregar(tm);
                    //DataGridViewRow r= new DataGridViewRow();
                    //r.CreateCells(dgvDatos);
                    //SetearFila(r,tm);
                    //AgregarFlia(r);
                    //MessageBox.Show("Registro Agregado");


                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void MostrarDatosAgregados()
        {
            List<TipoMovimientos> lista = TiposMovimientosBD.GetLista();
            MostrarDatosGrilla(lista);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoMovimientos tm = (TipoMovimientos)r.Tag;
                DialogResult dr =
                    MessageBox.Show(string.Format($"¿Desea eliminar {tm.TipoMovimiento} de la lista?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        TiposMovimientosBD.Borrar(tm);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Informacion", MessageBoxButtons.OK,
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
                TipoMovimientos tm = (TipoMovimientos)r.Tag;
                TipoMovimientos tmAux = (TipoMovimientos)tm.Clone();
                frmTipoMovimientosAE frm = new frmTipoMovimientosAE { Text = "Editar Tipo De movimiento" };
                frm.SetEditar(true);
                frm.SetTipoMovimientos(tm);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        tm = frm.GetTipoMovimientos();
                        TiposMovimientosBD.Editar(tm);
                        SetearFila(r, tm);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, tmAux);

                    }
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmTipoMovimientos_Load_1(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            try
            {
                lista = TiposMovimientosBD.GetLista();
                MostrarDatosGrilla(lista);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
