using BL;
using Datos;
using Reportes;
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
    public partial class frmTurnos : Form
    {
        public frmTurnos()
        {
            InitializeComponent();
        }
        static frmTurnos frm = null;
        public static frmTurnos GetInstancia()
        {
            if (frm == null)
            {
                frm = new frmTurnos();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        private MedicoEspecialidad medEsp;
        List<MedicoEspecialidad> listaMe;
        List<ReservasTurno> listaTurnos;
        private void frmTurnos_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.dgvTurnos.AllowUserToAddRows = false;
          //  this.tsbImprimir.Enabled = false;
            MedicosBD.CargarCombobox(ref cboMedicos);
            dateTimePicker1.Enabled = false;
        }
        private ReservasTurno turno;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTodos.Checked)
            {
                // radioButton1.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                //radioButton1.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtPorfecha.Checked)
            {
                //radioButton1.Enabled = false; ;
                dateTimePicker1.Enabled = true;

            }
            else
            {
                //radioButton1.Enabled = true;

                dateTimePicker1.Enabled = false;
            }
        }

        private void btnBuscra_Click(object sender, EventArgs e)
        {
            if (rbtTodos.Checked)
            {
                if (ValidarBusqueda())
                {
                    if (turno == null)
                    {
                        turno = new ReservasTurno();
                    }
                    turno.Medico = (Medicos)cboMedicos.SelectedItem;
                    turno.Fecha = dateTimePicker1.Value.Date;
                    turno.MedicoEspecialidad = medEsp;
                    try
                    {
                        listaTurnos = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);
                        MostrarDatosGrillaTurno(listaTurnos);

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            else if (rbtPorfecha.Checked)

            {
                if (ValidarBusqueda())
                {
                    if (turno == null)
                    {
                        turno = new ReservasTurno();
                    }
                    turno.Medico = (Medicos)cboMedicos.SelectedItem;
                    turno.Fecha = dateTimePicker1.Value.Date;
                    turno.MedicoEspecialidad = medEsp;
                    try
                    {
                        listaTurnos = ReservasTurnosBD.ListaReservasTurnoPorFechaYMedico(turno);
                        MostrarDatosGrillaTurno(listaTurnos);

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        private void MostrarDatosGrillaTurno(List<ReservasTurno> listaTurnos)
        {
            dgvTurnos.Rows.Clear();
            foreach (ReservasTurno item in listaTurnos)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvTurnos);
                int celdas, Columnas;
                celdas = r.Cells.Count;
                Columnas = dgvTurnos.ColumnCount;

                SetearFilaTurno(r, item);
                AgregarFilaTurno(r);
            }
        }

        private void SetearFilaTurno(DataGridViewRow r, ReservasTurno item)
        {
            r.Cells[cmIdTurno.Index].Value = item.IdTurno;
            r.Cells[cmMedicos.Index].Value = item.Medico.ApellidoNombre;
            //  r.Cells[cmnEspecialidad.Index].Value =item.MedicoEspecialidad.Especialidad.Especialidad ;
            r.Cells[cmConsultorio.Index].Value = item.Consultorio.Consultorio;
            r.Cells[cmTurno.Index].Value = item.Turno;
            if (item.Paciente == null)
            {

                r.Cells[cmPaciente.Index].Value = string.Empty;
                r.Cells[cmPlan.Index].Value = string.Empty;
                // r.Cells[cmnPago.Index].Value = string.Empty;
                r.Cells[cmObraSocial.Index].Value = string.Empty;
            }
            else
            {
                r.Cells[cmPaciente.Index].Value = item.Paciente.ApellidoNombre;
                r.Cells[cmPlan.Index].Value = item.Paciente.Plan.Plan;
                if (item.Paciente.Plan == null)
                {
                    // r.Cells[cmnPago.Index].Value = string.Empty; ;
                    r.Cells[cmObraSocial.Index].Value = string.Empty; ;
                }
                else
                {
                    // r.Cells[cmnPago.Index].Value = item.Paciente.Plan.Cobertura;
                    r.Cells[cmObraSocial.Index].Value = item.Paciente.Plan.ObraSocial.ObraSocial;
                }
            }
            // r.Cells[cmnPresente.Index].Value = item.Reserva ? "Presente" : "Ausente";
            // r.Cells[cmnfecha.Index].Value = item.Fecha.ToShortDateString();
            // r.Cells[cmnhora.Index].Value = item.Hora;
            r.Tag = item;

        }


        private bool ValidarBusqueda()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboMedicos.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboMedicos, "Seleccione un medico");
            }
            if (dgvMedicoEsp.SelectedRows.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(dgvMedicoEsp, "Seleccione una especialidad");
            }
            return valido;
        }

        private void cboMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedicos.SelectedIndex > 0)
            {
                Medicos medico = (Medicos)cboMedicos.SelectedItem;
                listaMe = MedicoEspecialidadBD.GetLista(medico);
                MostrarDatosGrillaMedicos(listaMe);
            }

        }

        private void MostrarDatosGrillaMedicos(List<MedicoEspecialidad> listaMe)
        {
            dgvMedicoEsp.Rows.Clear();
            foreach (var i in listaMe)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvMedicoEsp);
                SetearFila(i, r);
                AgregarFila(r);
            }
        }

        private void AgregarFilaTurno(DataGridViewRow r)
        {
            dgvTurnos.Rows.Add(r);
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvMedicoEsp.Rows.Add(r);

        }

        private void SetearFila(MedicoEspecialidad i, DataGridViewRow r)
        {
            r.Cells[cmnEspecialidad.Index].Value = i.Especialidad.Especialidad;
            r.Cells[cmnCosto.Index].Value = "$ " + i.CostoConsulta.ToString();
            r.Tag = i;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvMedicoEsp.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvMedicoEsp.SelectedRows[0];
                medEsp = (MedicoEspecialidad)r.Tag;
                txtMedS.Text = medEsp.Medico.ToString();

                txtEspS.Text = medEsp.Especialidad.Especialidad;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("La fecha ingresada no corresponde a ninguna fecha laborable", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
      
        
      
        private void asignarPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvTurnos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvTurnos.SelectedRows[0];
                turno = (ReservasTurno)r.Tag;
                turno.MedicoEspecialidad = medEsp;
                if (turno.Paciente == null)
                {
                    frmListaPacientes frm = new frmListaPacientes();
                    frm.SetTurno(turno);

                    frm.Text = "Asigne el paciente al turno " + turno.Turno + " al medico " + turno.Medico.ApellidoNombre;
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        List<ReservasTurno> lista = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);

                        MostrarDatosGrillaTurno(lista);
                    }
                    else
                    {
                        List<ReservasTurno> lista = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);

                        MostrarDatosGrillaTurno(lista);
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("El turno seleccionado tiene asignado un paciente", "¿Desea quitar el paciente del turno?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        if (turno.Fecha >= DateTime.Now)
                        {
                            ReservasTurnosBD.QuitarPacientesDeTurnos(turno);
                            MessageBox.Show("El turno esta disponible nuevamente", "Menasaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    List<ReservasTurno> lista = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);

                    MostrarDatosGrillaTurno(lista);
                }
            }
        }

        private void cobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvTurnos.SelectedRows[0];
                turno = (ReservasTurno)r.Tag;
                turno.MedicoEspecialidad = medEsp;
                if (turno.Paciente == null)
                {
                    MessageBox.Show("El turno no esta asignado a un paciente por lo tanto no tiene valor", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (turno.Paciente.Plan.Cobertura == 1)
                {
                    MessageBox.Show("La obra social del paciente no tiene cobertura", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (turno.Cobro > 0)
                {
                    MessageBox.Show("El turno seleccionado ya fue cobrado", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmEditarTurnos frm = new frmEditarTurnos();
                    frm.SetTurno(turno);
                    frm.Text = "Edite el turno " + turno.Turno + " del paciente " + turno.Paciente.ApellidoNombre;
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        List<ReservasTurno> lista = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);
                        MostrarDatosGrillaTurno(lista);
                    }
                    else
                    {
                        List < ReservasTurno >lista = ReservasTurnosBD.ListaTodosTurnoPorMedico(turno);
                        MostrarDatosGrillaTurno(lista);
                    }
                }


            }
        }

        private void detalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dgvTurnos.SelectedRows.Count>0)
            //{
            //    DataGridViewRow r = dgvTurnos.SelectedRows[0];
            //    turno = (ReservasTurno)r.Tag;
            //    if (turno.Presente == true)
            //    {
            //        Medicos persona = MedicosBD.GetMedico(turno.Medico.IdMedico);
            //        frmConsulta frm = new frmConsulta();
            //        frm.SetPersona(persona);
            //        DialogResult dr = frm.ShowDialog(this);
            //    }
            //    else
            //    {
            //        MessageBox.Show("El paciente no ha sido atendido aun", "Mensaje", MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            }

        private void acudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hacer que apresca si el paciente acudio ademas de cuando guardas la consulta que se actualize directamente
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.SelectedRows.Count>0)
            {
                ReservasTurno turno;
                DataGridViewRow r = dgvTurnos.SelectedRows[0];
                turno = (ReservasTurno)r.Tag;
                frmReportes formr = new frmReportes();
                formr.Text = "Impresion de turno";
                formr.IdTurno = turno.IdTurno;
                formr.EsIndividual(true);
                formr.ShowDialog();
                


            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmFiltroReporteTurno frm = new FrmFiltroReporteTurno();
            frm.Text = "Filtro para busqueda de turno";
            frm.Show();
        }
    }    
   }

//***********************************//

 
//TODO 4 permisos de medicos en frms


