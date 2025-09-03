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
    public partial class frmObraSociales : Form
    {
        public frmObraSociales()
        {
            InitializeComponent();
        }

        private static frmObraSociales frm = null;

        public static frmObraSociales Instancia()
        {
            if (frm == null)
            {
                frm = new frmObraSociales();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private List<ObraSociales> lista;

        private void frmObraSociales_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            try
            {
                lista = ObrasSocialesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosGrilla(List<ObraSociales> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var os in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, os);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ObraSociales os)
        {
            r.Cells[cmnOs.Index].Value = os.ObraSocial.ToUpper();
            r.Tag = os;
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmObraSocialesAE frm = new frmObraSocialesAE {Text = "Agregar Obra social"};
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = ObrasSocialesBD.GetLista();
                    MostrarDatosGrilla(lista);
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
                ObraSociales os = (ObraSociales) r.Tag;
                ObraSociales osAux = (ObraSociales) os.Clone();
                frmObraSocialesAE frm = new frmObraSocialesAE {Text = "Editar Obra social"};
                frm.SetEditar(true);
                frm.SetObraSocial(os);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        os = frm.GetObraSocial();
                        ObrasSocialesBD.Editar(os);
                        SetearFila(r, os);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception es)
                    {

                        MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, osAux);
                    }
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                ObraSociales os = (ObraSociales)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar {os.ObraSocial} de la lista?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ObrasSocialesBD.Borrar(os);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Obra social eliminada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            new Exportar().ExportarDgv(dgvDatos);
        }
    }
}
