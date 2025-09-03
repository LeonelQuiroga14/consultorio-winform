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
    public partial class FrmFiltroReporteTurno : Form
    {
        public FrmFiltroReporteTurno()
        {
            
                InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMedicosolo.Checked)
            {
                label1.Text = "Se buscaran los turnos del medico seleccionado de la fecha actual.";
                label2.Text= "---";
                dtpFecha.Enabled = false;

            }
            else if (rbtMedicoYfecha.Checked)
            {
                label2.Text = "Se buscaran los turnos del medico seleccionado de la fecha seleccionada.";
                label1.Text= "---";
                dtpFecha.Enabled = true;

            }
        }

        private void FrmFiltroReporteTurno_Load(object sender, EventArgs e)
        {
            MedicosBD.CargarCombobox(ref cboMedico);
            rbtMedicosolo.Enabled = false;
            rbtMedicoYfecha.Enabled = false;
            dtpFecha.Enabled = false;
            btnBuscar.Enabled = false;
            
            
        }
        Medicos medico;
        DateTime fecha;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMedico.SelectedIndex > 0)
            {
                medico = (Medicos)cboMedico.SelectedItem;
                rbtMedicosolo.Enabled = true;
                rbtMedicoYfecha.Enabled = true;
                btnBuscar.Enabled = true;
            }
            else
            {
                medico = null;
                rbtMedicosolo.Enabled = false;
                rbtMedicoYfecha.Enabled = false;
                btnBuscar.Enabled = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes();
            frm.Text = "Reporte de turnos";
            if (rbtMedicosolo.Checked)
            {
                medico = (Medicos)cboMedico.SelectedItem;
                label1.Text = "Se buscaran los turnos del medico seleccionado de la fecha actual.";
               
                frm.IdMedico = medico.IdMedico;
                frm.EsPorMedico(true);
                frm.ShowDialog();


            } else if (rbtMedicoYfecha.Checked)
                    {
                label1.Text = "Se buscaran los turnos del medico seleccionado de la fecha seleccionada.";
                medico = (Medicos)cboMedico.SelectedItem;
                fecha = dtpFecha.Value.Date;
                frm.IdMedico = medico.IdMedico;
                frm.fecha = fecha;
                frm.EsPorMedicoYFecha(true);
                frm.ShowDialog();
            }
        }

        private void rbtMedicoYfecha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMedicoYfecha.Checked)
            {
                label2.Text = "Se buscaran los turnos del medico seleccionado de la fecha seleccionada.";
                label1.Text = "---";
                dtpFecha.Enabled = true;

            }
            else if (rbtMedicosolo.Checked)
            {
                label1.Text = "Se buscaran los turnos del medico seleccionado de la fecha actual.";
                label2.Text= "---";
                dtpFecha.Enabled = false;
            }
        }
    }
}
