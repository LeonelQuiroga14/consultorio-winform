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
    public partial class frmNacionalidades : Form
    {
        public frmNacionalidades()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Nacionalidades n = (Nacionalidades)r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar {n.Nacionalidad} de la lista?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr==DialogResult.Yes)
                {
                    try
                    {
                        NacionalidadesBD.Borrar(n);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Nacionalidad eliminada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            
                    }
                    catch (Exception ex )
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private List<Nacionalidades> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmNacionalidadesAE frm = new frmNacionalidadesAE {Text = "Agregar nacionalidad"};
            DialogResult dr = frm.ShowDialog();
            if (dr== DialogResult.OK)
            {
                try
                {
                    lista = NacionalidadesBD.GetLista();
                    MostrarDatosGrilla(lista);
                }
                catch (Exception ex )
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    

        private void frmNacionalidades_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock=DockStyle.Fill;
            try
            {
               lista = NacionalidadesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static frmNacionalidades frm = null;

        internal static frmNacionalidades Instancia()
        {
            if (frm==null)
            {
                frm= new frmNacionalidades();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void MostrarDatosGrilla(List<Nacionalidades> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var n in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, n);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Nacionalidades n)
        {
            r.Cells[cmnNac.Index].Value = n.Nacionalidad;
            r.Tag = n;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Nacionalidades nac = (Nacionalidades)r.Tag;
                Nacionalidades nacAux = (Nacionalidades) nac.Clone();
                frmNacionalidadesAE frm = new frmNacionalidadesAE { Text = "Editar nacionalidad" };
                frm.SetEditar(true);
                frm.SetNacionalidad(nac);
                DialogResult dr = frm.ShowDialog(this);
                if (dr==DialogResult.OK)
                {
                    try
                    {
                        nac = frm.GetNacionalidad();
                        NacionalidadesBD.Editar(nac);
                        SetearFila(r,nac);
                        MessageBox.Show("Registro editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception es )
                    {

                        MessageBox.Show(es.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r,nacAux);
                    }
                }
            }

        }
    }
}
