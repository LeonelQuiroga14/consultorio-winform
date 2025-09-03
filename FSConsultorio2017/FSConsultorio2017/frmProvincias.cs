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
    public partial class frmProvincias : Form
    {
        public frmProvincias()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Provincia> lista;

        private void frmProvincias_Load(object sender, EventArgs e)
        {

            this.Dock = DockStyle.Fill;
            this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
            try
            {
                lista = ProvinciaBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void MostrarDatosGrilla(List<Provincia> lista)
        {
            dgvDatos.Rows.Clear();

            foreach (var p in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, p);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Provincia p)
        {
            r.Cells[cmnProvincia.Index].Value = p.Nombre;
            r.Tag = p;
        }

        private static frmProvincias frm = null;

        public static frmProvincias Instancia()
        {
            if (frm == null)
            {
                frm = new frmProvincias();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmProvinciasAE frm = new frmProvinciasAE {Text = "Agregar Provincia "};
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = ProvinciaBD.GetLista();
                    MostrarDatosGrilla(lista);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Provincia prov = (Provincia) r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar a {prov.Nombre}? de la lista"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        ProvinciaBD.Borrar(prov);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Provincia eliminada", "Informacion", MessageBoxButtons.OK,
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
                Provincia prov = (Provincia) r.Tag;
                Provincia provAux = (Provincia) prov.Clone();
                frmProvinciasAE frm = new frmProvinciasAE {Text = "Editar Provincia"};
                frm.SetEditar(true);
                frm.SetProvincia(prov);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        prov = frm.GetProvincia();
                        ProvinciaBD.Editar(prov);
                        SetearFila(r, prov);
                        MessageBox.Show("Provincia editada", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, provAux);
                    }
                }
            }
        }
    }
}

