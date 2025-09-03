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
    public partial class frmListaAlquileres : Form
    {
        public frmListaAlquileres()
        {
            InitializeComponent();
        }
        private static frmListaAlquileres frm = null;
        public static frmListaAlquileres GetInstancia()
        {
            if (frm==null)
            {
                frm = new frmListaAlquileres();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        List<AlquileresConsultorio> lista;
        private void frmListaAlquileres_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            try
            {
                lista = AlquilerConsultorioBD.GetListaAlquileres();
                MostrarDatosGrilla(lista);

            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        private void MostrarDatosGrilla(List<AlquileresConsultorio> lista)
        {
            dgvAlquilerConsultorio.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvAlquilerConsultorio);
                SetearFila(r, i);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvAlquilerConsultorio.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, AlquileresConsultorio i)
        {
            r.Cells[cmAlquiler.Index].Value = i.Jornada.Alquiler.ToString();
            r.Cells[cmConsultorio.Index].Value = i.Consultorio.Consultorio;
            r.Cells[cmMedico.Index].Value = i.Medico.ToString();
            r.Cells[cmFechaInicio.Index].Value = i.FechaInicio.ToShortDateString();
            r.Cells[cmFechaFin.Index].Value = i.FechaFin.ToShortDateString();
            r.Tag = i;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        AlquileresConsultorio ac;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvAlquilerConsultorio.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvAlquilerConsultorio.SelectedRows[0];
                ac = (AlquileresConsultorio)r.Tag;
                frmReportes frm = new frmReportes();
                frm.Text = "Impimir Alquiler";
                frm.IdAlquiler = ac.IdAlquilerConsultorio;
                frm.EsAlquiler(true);
                frm.ShowDialog();
            }
        }
    }
}
