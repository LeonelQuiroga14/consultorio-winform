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
    public partial class frmListaPacientes : Form
    {
        public frmListaPacientes()
        {
            InitializeComponent();
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmListaPacientes_Load(object sender, EventArgs e)
        {
            btnlistaCompleta.Enabled = false;
            textBox1.Enabled = true;
            button1.Enabled = true;
            groupBox1.Enabled = true;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           string  dni = textBox1.Text + "%";
            listapaciente = PacientesBD.GetLista(dni);
            MostrarDatosGrilla(listapaciente);
        }

        private void MostrarDatosGrilla(List<Pacientes> listapaciente)
        {
            dgvDatos.Rows.Clear();
            foreach (var i in listapaciente)

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

        private void SetearFila(DataGridViewRow r, Pacientes p)
        {
            r.Cells[cmnNombreApe.Index].Value = p.ToString();
            r.Cells[cmnGenero.Index].Value = p.Genero.Genero;
            r.Cells[cmnGs.Index].Value = p.GrupoSanguineo;
            r.Cells[cmnDNI.Index].Value = p.NumeroDoc;
            r.Cells[cmnTelefonoMovil.Index].Value = p.TelefonoMovil;
            r.Cells[cmnTelefonofijo.Index].Value = p.TelefonoFijo;
            r.Cells[cmnObraSocial.Index].Value = p.ObraSocial.ObraSocial;
            r.Cells[cmnPlan.Index].Value = p.Plan.Plan;

            r.Tag = p;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))//char es lo que escrbimos
            {
                e.Handled = false; //handled, es la propieddad que habiita la escritura t= no escribe , f= escribe
                
            }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true;
                MessageBox.Show("Solo se permiten  caracteres numericos");
            } 
            
        }
        List<Pacientes> listapaciente;
        Pacientes paciente;
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtFiltrado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtFiltrado.Checked)
            {
                btnlistaCompleta.Enabled = false;
                textBox1.Enabled = true;
                button1.Enabled = true;
                groupBox1.Enabled = true;
            }
            else if (rbtCompleta.Checked)
            {
                btnlistaCompleta.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
                groupBox1.Enabled = false;
            }
        }

        private void rbtCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCompleta.Checked)
            {
                btnlistaCompleta.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
                groupBox1.Enabled = false;
            }
            else if (rbtFiltrado.Checked)
            {
                btnlistaCompleta.Enabled = false;
                textBox1.Enabled = true;
                button1.Enabled = true;
                groupBox1.Enabled = true;
            }
        }

        private void btnlistaCompleta_Click(object sender, EventArgs e)
        {
            listapaciente = PacientesBD.GetLista();
            MostrarDatosGrilla(listapaciente);
        }

        ReservasTurno turno;
        public void SetTurno(ReservasTurno t)
        {
            turno = t;
        }
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            if (turno!=null)
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    DataGridViewRow r = dgvDatos.SelectedRows[0];
                    paciente = (Pacientes)r.Tag;
                    try
                    {
                        ReservasTurnosBD.AgregarPacienteAlTurno(turno, paciente);
                        MessageBox.Show("Paciente asignado al turno", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                } 
            }
        }
    }
}
