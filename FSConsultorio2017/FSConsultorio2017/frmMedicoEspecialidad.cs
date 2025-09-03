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
    public partial class frmMedicoEspecialidad : Form
    {
        public frmMedicoEspecialidad()
        {
            InitializeComponent();
        }

        private List<MedicoEspecialidad> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmMedicoEspecialidadAE frm = new frmMedicoEspecialidadAE() { Text = "Agregar Medico-Especialidad" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = MedicoEspecialidadBD.GetLista();
                    MostrarDatosGrilla(lista);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosGrilla(List<MedicoEspecialidad> lista)
        {
           dgvDatos.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r,i);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                MedicoEspecialidad mp = (MedicoEspecialidad)r.Tag;
                MedicoEspecialidad mpAux = (MedicoEspecialidad)mp.Clone();
                frmMedicoEspecialidadAE frm = new frmMedicoEspecialidadAE { Text = "Editar Medico-Especialidad" };
                frm.SetEditar(true);
                frm.SetMedicoEspecialidad(mp);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    try
                    {
                        mp = frm.GetMedicoEspecialidad();
                        MedicoEspecialidadBD.Editar(mp);
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

        private void SetearFila(DataGridViewRow r, MedicoEspecialidad mp)
        {
            r.Cells[cmnNombreApe.Index].Value = mp.Medico.ToString();
            r.Cells[cmnEspecialidad.Index].Value = mp.Especialidad.Especialidad;
            r.Cells[cmnMat.Index].Value = mp.Matricula;
            r.Cells[cmnCosto.Index].Value = "$ " + mp.CostoConsulta.ToString();
            r.Tag = mp;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                MedicoEspecialidad mp = (MedicoEspecialidad) r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar el registro de la lista?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        MedicoEspecialidadBD.Borrar(mp);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static frmMedicoEspecialidad frm = null;

        public static frmMedicoEspecialidad GetInstancia()
        {
            if (frm==null)
            {
                frm= new frmMedicoEspecialidad();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void frmMedicoEspecialidad_Load(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;
            this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
            dgvDatos.AllowUserToAddRows = false;
            this.ControlBox = false;

            try
            {
                lista = MedicoEspecialidadBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
