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
using Reportes;

namespace FSConsultorio2017
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        internal void SetPersona(Medicos persona)
        {
            throw new NotImplementedException();
        }

        List<MedicoEspecialidad> listaMedicoEsp;
        List<ReservasTurno> ListaTurnos;
        private void frmConsulta_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = "Consultorios - Consultas";
            try
            {
                listaMedicoEsp = MedicoEspecialidadBD.GetLista();
                MostrarDatosGrillaMedico(listaMedicoEsp);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static frmConsulta frm = null;
        public static frmConsulta Instancia()
        {
            if (frm == null)
            {
                frm = new frmConsulta();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void MostrarDatosGrillaMedico(List<MedicoEspecialidad> listaMedicoEsp)
        {
            dgvMedicoEsp.Rows.Clear();
            foreach (var i in listaMedicoEsp)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvMedicoEsp);
                SetearFilaMedico(i, r);
                AgregarFilaMedico(r);
            }
        }

        private void AgregarFilaMedico(DataGridViewRow r)
        {
            dgvMedicoEsp.Rows.Add(r);
        }

        private void SetearFilaMedico(MedicoEspecialidad i, DataGridViewRow r)
        {
            r.Cells[cmnMedico.Index].Value = i.Medico.ApellidoNombre;
            r.Cells[cmnEspecialidad.Index].Value = i.Especialidad.Especialidad;
            r.Tag = i;
        }

        Consultas consulta;

        MedicoEspecialidad medesp;
        DateTime fecha;
        
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvMedicoEsp.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvMedicoEsp.SelectedRows[0];
                medesp = (MedicoEspecialidad)r.Tag;
                fecha = dtpFecha.Value.Date;
                ListaTurnos = ReservasTurnosBD.ListaReservasTurnoPorFechaYMedico(medesp,fecha);
                MostrarDatosGrillaturno(ListaTurnos);

            }
        }

        private void MostrarDatosGrillaturno(List<ReservasTurno> listaTurnos)
        {
            dgvTurnos.Rows.Clear();
            foreach (var i in listaTurnos)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvTurnos);
                SetearFilaTurnos(r, i);
                AgregarFilaTurnos(r);
            }
        }

        private void AgregarFilaTurnos(DataGridViewRow r)
        {
            dgvTurnos.Rows.Add(r);
        }

        private void SetearFilaTurnos(DataGridViewRow r, ReservasTurno i)
        {
           // r.Cells[cmnMedico.Index].Value = i.Alquiler.Medico.ApellidoNombre; ;
            r.Cells[cmConsultorio.Index].Value = i.Consultorio.Consultorio;
            r.Cells[cmTurno.Index].Value = i.Turno.ToString();
            if (i.Paciente == null)
            {
                r.Cells[cmPaciente.Index].Value = string.Empty;
                r.Cells[cmObraSocial.Index].Value = string.Empty;
                r.Cells[cmPlan.Index].Value = string.Empty;
            }
            else
            {
                r.Cells[cmPaciente.Index].Value = i.Paciente.ApellidoNombre;
                r.Cells[cmObraSocial.Index].Value = i.Paciente.Plan.ObraSocial.ObraSocial;
                r.Cells[cmPlan.Index].Value = i.Paciente.Plan.Plan;
            }
           
            r.Tag = i;
        }
        ReservasTurno turno;
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvTurnos.SelectedRows[0];
                turno = (ReservasTurno)r.Tag;
                lblMedico.Text = turno.Medico.ApellidoNombre;
                lblEsp.Text = medesp.Especialidad.Especialidad;
                if (turno.Paciente != null)
                {
                    lblNombre.Text = turno.Paciente.ApellidoNombre;
                    int edad = DateTime.Now.Year - turno.Paciente.FechaNac.Year;
                    lblEdad.Text = edad.ToString();
                    lblGS.Text = turno.Paciente.GrupoSanguineo;
                    
                }
                else
                {
                    lblNombre.Text = "Sin Datos";
                    //int edad = "Sin Datos";// DateTime.Now.Year - turno.Paciente.FechaNac.Year;
                    lblEdad.Text = "Sin Datos";// edad.To String();
                    lblGS.Text = "Sin Datos";
                }
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (turno.Paciente == null)
                {
                    MessageBox.Show("Mensaje", "El turno no tiene ningun paciente asignado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    if (consulta==null)
                    {
                        consulta = new Consultas();
                    }
                    consulta.Turno = turno;
                    consulta.Sintomas = rtxtSintomas.Text;
                    consulta.Diagnostico = rtxtDiagnostico.Text;
                    consulta.Medicacion = rtxtmedicacion.Text;
                    consulta.Observaciones = rtxtIndicacion.Text;
                    try
                    {
                        ConsultasBD.Agregar(consulta,turno);
                        MessageBox.Show("Consulta Agregada y turno editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show( "¿Desea Imprimir la receta de la consulta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr==DialogResult.Yes)
                        {
                           
                            frmReportes frmReporte = new frmReportes();
                            frmReporte.Text = "Impresion de Receta -Consultorio";
                            frmReporte.IdTurno = turno.IdTurno;
                            frmReporte.EsReceta(true);
                            frmReporte.ShowDialog();

                        }
                    }
                    catch (Exception EX )
                    {

                        throw EX ;
                    }
                    LimpiarReceta();

                }
            }
        }

        private void LimpiarReceta()
        {
            rtxtDiagnostico.Text = string.Empty;
            rtxtmedicacion.Text = string.Empty;
            rtxtIndicacion.Text = string.Empty;
            rtxtSintomas.Text = string.Empty;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (dgvMedicoEsp.SelectedRows.Count==0)
            {
                valido = false;
                errorProvider1.SetError(dgvMedicoEsp, "Seleccione un medico");
            }
            if (dgvTurnos.SelectedRows.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(dgvTurnos, "Seleccione un turno");
            }
            return valido;
        }
    }
}
