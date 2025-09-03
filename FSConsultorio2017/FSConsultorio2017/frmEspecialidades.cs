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
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Especialidades> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmEspecialidadAE frm = new frmEspecialidadAE { Text = "Agregar especialidad" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = EspecialidadesBD.GetLista();
                    MostrarDatosGrilla(lista);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Especialidades esp = (Especialidades)r.Tag;
                Especialidades espAux = (Especialidades)esp.Clone();
                frmEspecialidadAE frm = new frmEspecialidadAE { Text = "Editar especialidad" };
                frm.SetEditar(true);
                frm.SetEspecialidad(esp);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        esp = frm.GetEspecialidad();
                        EspecialidadesBD.Editar(esp);
                        SetearFila(r, esp);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, espAux);

                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Especialidades esp)
        {
            r.Cells[cmnEsp.Index].Value = esp.Especialidad;
            r.Tag = esp;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Especialidades esp = (Especialidades)r.Tag;
                DialogResult dr =
                    MessageBox.Show(string.Format($"¿Desea eliminar {esp.Especialidad} de la lista?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        EspecialidadesBD.Borrar(esp);
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

        private void frmEspecialidades_Load(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
            try
            {
                lista = EspecialidadesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private static frmEspecialidades frm = null;

        public static frmEspecialidades Instancia()
        {
            if(frm==null)
            {
                frm= new frmEspecialidades();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;

        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void MostrarDatosGrilla(List<Especialidades> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var e in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r,e);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
    }
}
