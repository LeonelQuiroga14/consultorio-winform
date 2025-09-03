using BL;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSConsultorio2017
{
    public partial class frmHistoriasClinicas : Form
    {
        public frmHistoriasClinicas()
        {
            InitializeComponent();
        }

        private static frmHistoriasClinicas frm = null;
        public static frmHistoriasClinicas Instancia()
        {
            if (frm==null)
            {
                frm = new frmHistoriasClinicas();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void frmHistoriasClinicas_Load(object sender, EventArgs e)
        {
            this.Text = "Historias Clinicas - Consultorio";
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
           
            lblNombre.Text = "Sin Datos";
            lblApellido.Text = "Sin Datos";
            lblEdad.Text = "Sin Datos";
            lblGS.Text = "Sin Datos";
            lblObraS.Text = "Sin Datos";
            lblPlan.Text = "Sin Datos";
            lblGenero.Text = "Sin Datos";

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; MessageBox.Show("Solo se permiten  caracteres numericos"); }
                
        }
        List<Consultas> listaconsultas;
        private Consultas consulta;
        private ReservasTurno turno;
        Pacientes paciente;
      

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                int dni = Convert.ToInt32(txtDNI.Text);
                try
                {
                    paciente = PacientesBD.GetPaciente(dni);
                    if (paciente != null)
                    {
                        lblNombre.Text = paciente.Nombre;
                        lblApellido.Text = paciente.Apellido; ;
                        lblEdad.Text = Convert.ToString(DateTime.Now.Year - paciente.FechaNac.Year);
                        lblGS.Text = paciente.GrupoSanguineo;
                        lblObraS.Text = paciente.Plan.ObraSocial.ObraSocial;
                        lblPlan.Text = paciente.Plan.Plan;
                        lblGenero.Text = paciente.Genero.Genero;
                    }
                    else
                    {
                        MessageBox.Show("No se encontro ningun paciente registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblNombre.Text = "Sin Datos";
                        lblApellido.Text = "Sin Datos";
                        lblEdad.Text = "Sin Datos";
                        lblGS.Text = "Sin Datos";
                        lblObraS.Text = "Sin Datos";
                        lblPlan.Text = "Sin Datos";
                        lblGenero.Text = "Sin Datos";
                    }
                    //listaconsultas = ConsultasBD.GetListaHistorias(paciente);
                    //MostrarDatosGrilla(listaconsultas);

                }
                catch (Exception ex )
                {

                    throw ex ;
                }
                
               
            }
        }

        private void MostrarDatosGrilla(List<Consultas> listaconsultas)
        {
            dgvHistorias.Rows.Clear();
            foreach (var i in listaconsultas)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvHistorias);
                SetearFila(r,i);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvHistorias.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Consultas i)
        {
            if (i.Turno == null)
            {
                r.Cells[cmnPaciente.Index].Value = string.Empty;
                r.Cells[cmnFecha.Index].Value = string.Empty;
                r.Cells[cmnMedico.Index].Value = string.Empty;
                r.Cells[cmnEspecialidad.Index].Value = string.Empty;
            }
            else
            {
                r.Cells[cmnPaciente.Index].Value = i.Turno.Paciente.ApellidoNombre;
                r.Cells[cmnFecha.Index].Value = i.Turno.Fecha.ToShortDateString();
                r.Cells[cmnMedico.Index].Value = i.Turno.Medico.ApellidoNombre;

                if (i.Turno.MedicoEspecialidad == null) { r.Cells[cmnEspecialidad.Index].Value = string.Empty; }
                else { r.Cells[cmnEspecialidad.Index].Value = i.Turno.MedicoEspecialidad.Especialidad.Especialidad; }
            }
            r.Tag = i;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtDNI.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDNI, "Ingrese el Dni");
            }
            return valido;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listaconsultas = ConsultasBD.GetListaHistorias(paciente);
                MostrarDatosGrilla(listaconsultas);
            }
            catch (Exception ex )
            {

                throw ex ;
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvHistorias.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvHistorias.SelectedRows[0];
                consulta = (Consultas)r.Tag;
                frmDetalleConsulta frm = new frmDetalleConsulta();
                frm.Text = "Detalle de consulta";
                frm.SetConsulta(consulta);
                frm.Show();
                
            }
        }
    }
}
