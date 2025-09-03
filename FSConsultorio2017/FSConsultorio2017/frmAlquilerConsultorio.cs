using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Datos;

namespace FSConsultorio2017
{
    public partial class frmAlquilerConsultorio : Form
    {
        public frmAlquilerConsultorio()
        {
            InitializeComponent();
        }

        private void cbxMiercoles_CheckedChanged(object sender, EventArgs e)
        {

        }

        private static frmAlquilerConsultorio frm = null;

        public static frmAlquilerConsultorio GetInstancia()
        {
            if (frm == null)
            {
                frm = new frmAlquilerConsultorio();
                frm.FormClosed += new FormClosedEventHandler(frm_FormCLosed);
            }
            return frm;
        }

        private static void frm_FormCLosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void frmAlquilerConsultorio_Load(object sender, EventArgs e)
        {
            MedicosBD.CargarCombobox(ref cboMedico);
            ConsultoriosBD.CargarCombobox(ref cboConsultorio);
            JornadasBD.CargarCombobox(ref cboJornda);
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.mntcAlquiler.MaxSelectionCount = 31;

        }

        private void mntcAlquiler_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime ini, fin;
            ini = mntcAlquiler.SelectionRange.Start;
            fin = mntcAlquiler.SelectionRange.End;
            dtpIni.Value = ini;
            dtpFin.Value = fin;

        }

        private AlquileresConsultorio alquilercons;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (alquilercons == null)
            {
                alquilercons = new AlquileresConsultorio();
            }
            dtpIni.Value = mntcAlquiler.SelectionRange.Start;
            dtpFin.Value = mntcAlquiler.SelectionRange.End;
            alquilercons.Consultorio = (Consultorios)cboConsultorio.SelectedItem;
            alquilercons.Medico = (Medicos)cboMedico.SelectedItem;
            alquilercons.Jornada = (Jornadas)cboJornda.SelectedItem;
            alquilercons.FechaInicio = dtpIni.Value;
            alquilercons.FechaFin = dtpFin.Value;
            alquilercons.MedicoEspecialidad = me;
            if (ValidarAlquiler())
            {
                if (AlquilerConsultorioBD.GetAlquilerConsultorio(alquilercons) == null) //si no hay registro en la lista
                {
                    //entonces agregramos y vemos los chk seleccionads
                    if (cbxDiasSemana.Checked == false) //si el chk no esta chequeado
                    {
                        try
                        {
                            AlquilerConsultorioBD.Agregar(alquilercons); //agregamos el alquiler generado
                           alquilercons.IdAlquilerConsultorio=  AlquilerConsultorioBD.GetIDAlquiler(me.IdMedicoEspecialidad, dtpIni.Value.Date, dtpFin.Value.Date);
                            
                            while (dtpIni.Value != dtpFin.Value)
                                // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                            {
                                //isntancio el turno que se va generar
                                ReservasTurno rturno = new ReservasTurno();
                                DateTime fechaturno = dtpIni.Value.Date;
                                //preguntamso que no sean  sabado o domingo
                                if (fechaturno.DayOfWeek != DayOfWeek.Saturday ||
                                    fechaturno.DayOfWeek != DayOfWeek.Sunday)
                                { 
                                    
                                    rturno.Consultorio = alquilercons.Consultorio;
                                    rturno.Medico = alquilercons.Medico;                                  
                                    rturno.Fecha = fechaturno;
                                    rturno.Hora = alquilercons.Jornada.HoraInicial;
                                    rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;
                                    rturno.Presente = false;
                                    rturno.Reserva = false;
                                    rturno.Alquiler = alquilercons;
                                    //agregamos el turno, y asignamos la jornada?
                                    ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                }
                                dtpIni.Value = fechaturno.AddDays(1);

                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("El Consultorio que selecciono no esta habilitado.", "Se cancelo la transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    else
                    {
                        if (cbxLunes.Checked)
                        {
                            try
                            {
                                AlquilerConsultorioBD.Agregar(alquilercons); //agregamos el alquiler generado
                                while (dtpIni.Value != dtpFin.Value)
                                    // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                                {
                                    //isntancio el turno que se va generar
                                    ReservasTurno rturno = new ReservasTurno();
                                    DateTime fechaturno = dtpIni.Value.Date;
                                    //preguntamso que no sean  sabado o domingo
                                    if (fechaturno.DayOfWeek == DayOfWeek.Monday)
                                    {
                                        rturno.Consultorio = alquilercons.Consultorio;
                                        rturno.Medico = alquilercons.Medico;
                                        rturno.Fecha = fechaturno;
                                        rturno.Hora = alquilercons.Jornada.HoraInicial;
                                        rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;

                                        rturno.Presente = false;
                                        rturno.Reserva = false;
                                        rturno.Alquiler = alquilercons;
                                        //agregamos el turno, y asignamos la jornada?
                                        ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                    }
                                    dtpIni.Value = fechaturno.AddDays(1);

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("El Consultorio que selecciono no esta habilitado.", "Se cancelo la transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                LimpiarFrm();
                            }
                        }
                        else if (cbxMartes.Checked)
                        {
                            try
                            {
                                AlquilerConsultorioBD.Agregar(alquilercons); //agregamos el alquiler generado
                                while (dtpIni.Value != dtpFin.Value)
                                    // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                                {
                                    //isntancio el turno que se va generar
                                    ReservasTurno rturno = new ReservasTurno();
                                    DateTime fechaturno = dtpIni.Value.Date;
                                    //preguntamso que no sean  sabado o domingo
                                    if (fechaturno.DayOfWeek == DayOfWeek.Tuesday)
                                    {
                                        rturno.Consultorio = alquilercons.Consultorio;
                                        rturno.Medico = alquilercons.Medico;
                                        rturno.Fecha = fechaturno;
                                        rturno.Hora = alquilercons.Jornada.HoraInicial;
                                        rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;

                                        rturno.Presente = false;
                                        rturno.Reserva = false;
                                        rturno.Alquiler = alquilercons;
                                        //agregamos el turno, y asignamos la jornada?
                                        ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                    }
                                    dtpIni.Value = fechaturno.AddDays(1);

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("El Consultorio que selecciono no esta habilitado.", "Se cancelo la transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                LimpiarFrm();
                            }
                        }
                        else if (cbxMiercoles.Checked)
                        {
                            try
                            {
                                AlquilerConsultorioBD.Agregar(alquilercons); //agregamos el alquiler generado
                                while (dtpIni.Value != dtpFin.Value)
                                    // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                                {
                                    //isntancio el turno que se va generar
                                    ReservasTurno rturno = new ReservasTurno();
                                    DateTime fechaturno = dtpIni.Value.Date;
                                    //preguntamso que no sean  sabado o domingo
                                    if (fechaturno.DayOfWeek == DayOfWeek.Wednesday)
                                    {
                                        rturno.Consultorio = alquilercons.Consultorio;
                                        rturno.Medico = alquilercons.Medico;
                                        rturno.Fecha = fechaturno;
                                        rturno.Hora = alquilercons.Jornada.HoraInicial;
                                        rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;

                                        rturno.Presente = false;
                                        rturno.Reserva = false;
                                        rturno.Alquiler = alquilercons;
                                        //agregamos el turno, y asignamos la jornada?
                                        ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                    }
                                    dtpIni.Value = fechaturno.AddDays(1);

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("El Consultorio que selecciono no esta habilitado.", "Se cancelo la transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                LimpiarFrm();
                            }
                        }
                        else if (cbxJueves.Checked)
                        {
                            try
                            {
                                AlquilerConsultorioBD.Agregar(alquilercons);
                                //agregamos el alquiler generado
                                while (dtpIni.Value != dtpFin.Value)
                                    // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                                {
                                    //isntancio el turno que se va generar
                                    ReservasTurno rturno = new ReservasTurno();
                                    DateTime fechaturno = dtpIni.Value.Date;
                                    //preguntamso que no sean  sabado o domingo
                                    if (fechaturno.DayOfWeek == DayOfWeek.Thursday)
                                    {
                                        rturno.Consultorio = alquilercons.Consultorio;
                                        rturno.Medico = alquilercons.Medico;
                                        rturno.Fecha = fechaturno;
                                        rturno.Hora = alquilercons.Jornada.HoraInicial;
                                        rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;

                                        rturno.Presente = false;
                                        rturno.Reserva = false;
                                        rturno.Alquiler = alquilercons;
                                        //agregamos el turno, y asignamos la jornada?
                                        ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                    }
                                    dtpIni.Value = fechaturno.AddDays(1);

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("El Consultorio que selecciono no esta habilitado.", "Se cancelo la transaccion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                                LimpiarFrm();
                            }
                        }
                        else if (cbxViernes.Checked)
                        {
                            try
                            {
                                AlquilerConsultorioBD.Agregar(alquilercons);
                                //agregamos el alquiler generado
                                while (dtpIni.Value != dtpFin.Value)
                                    // mientras la fecha de inicio no sea igual a la final *preg xq no menor
                                {
                                    //isntancio el turno que se va generar
                                    ReservasTurno rturno = new ReservasTurno();
                                    DateTime fechaturno = dtpIni.Value.Date;
                                    //preguntamso que no sean  sabado o domingo
                                    if (fechaturno.DayOfWeek == DayOfWeek.Friday)
                                    {
                                        rturno.Consultorio = alquilercons.Consultorio;
                                        rturno.Medico = alquilercons.Medico;
                                        rturno.Fecha = fechaturno;
                                        rturno.Hora = alquilercons.Jornada.HoraInicial;
                                        rturno.MedicoEspecialidad = alquilercons.MedicoEspecialidad;

                                        rturno.Presente = false;
                                        rturno.Reserva = false;
                                        rturno.Alquiler = alquilercons;
                                        //agregamos el turno, y asignamos la jornada?
                                        ReservasTurnosBD.Agregar(rturno, alquilercons.Jornada);

                                    }
                                    dtpIni.Value = fechaturno.AddDays(1);

                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("El Consultorio que selecciono no esta habilitado.","Se cancelo la transaccion",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                                LimpiarFrm();
                            }
                        }
                    }
                    MessageBox.Show("Se genero el Alquiler Correctamente", "Informacion", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    MessageBox.Show(string.Format("Se generaron los turnos para el  consultorio {0} y el medico {1}",
                        this.alquilercons.Consultorio.Consultorio,
                        this.alquilercons.Medico.ToString()), "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                      "El consultorio se encuentra ocupado para la fecha inicial del alquiler, busque hasta que fecha esta alquilado el consultorio",
                      "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void LimpiarFrm()
        {
            cboMedico.SelectedIndex = 0;
            cboConsultorio.SelectedIndex = 0;
            cboJornda.SelectedIndex = 0;
            mntcAlquiler.SelectionStart = DateTime.Now.Date;
        }

        private bool ValidarAlquiler()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboMedico.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboMedico, "Seleccione un medico");

            }
            if (cboConsultorio.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboConsultorio, "Seleccione un consultorio");
            }
            if (cboJornda.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboJornda, "Seleccione una jornada");

            }
            if (dtpIni.Value.Date< DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(dtpIni, "La fecha inicial no puede der menor a la fecha Actual");
                errorProvider1.SetError(mntcAlquiler, "Verifique la fecha inicial.");
            }
            return valido;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxDiasSemana_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxDiasSemana.Checked == true)
            {
                cbxLunes.Enabled = true;
                cbxMartes.Enabled = true;
                cbxMiercoles.Enabled = true;
                cbxJueves.Enabled = true;
                cbxViernes.Enabled = true;
            }
            else
            {
                cbxLunes.Enabled = false;
                cbxLunes.Checked = false;
                cbxMartes.Enabled = false;
                cbxMartes.Enabled = false;
                cbxMiercoles.Enabled = false;
                cbxMiercoles.Checked = false;
                cbxJueves.Enabled = false;
                cbxJueves.Checked = false;
                cbxViernes.Enabled = false;
                cbxViernes.Checked = false;
            }
        }

        private void cbxBusqueda_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbxBusqueda.Checked)
            //{
            //    btnGuardar.Enabled = true;
            //    btnGuardar.Visible = true;
            //    btnGuardaAlquiler.Enabled = false;
            //    btnGuardaAlquiler.Visible = false;
            //    cboMedicos.Enabled = false;
            //    cboAlquiler.Enabled = false;
            //}
            //else
            //{
            //    btnBuscar.Enabled = false;
            //    btnBuscar.Visible = false;
            //    btnGuardaAlquiler.Enabled = true;
            //    btnGuardaAlquiler.Visible = true;
            //    cboMedicos.Enabled = true;
            //    cboAlquiler.Enabled = false;
            //}
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           Close();
        }
        MedicoEspecialidad me;

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
            if (dgvMedicoEsp.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvMedicoEsp.SelectedRows[0];

                me = (MedicoEspecialidad)r.Tag;

                txtMedS.Text = me.Medico.ToString();

                txtEspS.Text = me.Especialidad.Especialidad;
            }
        }
        List<MedicoEspecialidad> listaMe;
        private void cboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedico.SelectedIndex > 0)
            {
                Medicos medico = (Medicos)cboMedico.SelectedItem;
                listaMe = MedicoEspecialidadBD.GetLista(medico);
                MostrarDatosGrillaMedicos(listaMe);
            }
        }
    }
}
