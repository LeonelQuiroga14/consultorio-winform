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
    public partial class frmGeneros : Form
    {
        public frmGeneros()
        {
            InitializeComponent();
        }

        private List<Generos> lista;

        //Editar todos los tsb 
        //frmAe
        
        private void frmGeneros_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock = DockStyle.Fill;
            try
            {
                lista = GenerosBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosGrilla(List<Generos> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var g in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r,g);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmGenerosAE frm = new frmGenerosAE() {Text = "Agregar Genero"};
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista =GenerosBD.GetLista();
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
               Generos genero = (Generos) r.Tag;
                Generos generoAux = (Generos) genero.Clone();
                frmGenerosAE frm = new frmGenerosAE {Text = "Editar Genero"};
                frm.SetEditar(true);
                frm.SetGenero(genero);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        genero = frm.GetGenero();
                        GenerosBD.Editar(genero);
                        SetearFila(r, genero);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception es)
                    {

                        MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, generoAux);
                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Generos genero)
        {
            r.Cells[cmnGenero.Index].Value = genero.Genero;
            r.Tag = genero;
        }

        private static frmGeneros frm = null;

        public static frmGeneros Instancia()
        {
            if (frm==null)
            {
                frm= new frmGeneros();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Generos g = (Generos) r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar {g.Genero} de la lista?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                       GenerosBD.Borrar(g);
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
    }
}
