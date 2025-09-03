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
using BL;
using Reportes;

namespace FSConsultorio2017
{
    public partial class frmCtaCta : Form
    {
        public frmCtaCta()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCuentaCorriente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        List<CuentasCorrientesMedicos> Listactacte;
        Medicos medico;

        private static  frmCtaCta frm = null;
        public static frmCtaCta Instancia()
        {
            if (frm==null)
            {
                frm = new frmCtaCta();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }


        private void MostrarDatosGrilla(List<CuentasCorrientesMedicos> lista)
        {
            dgvCuentaCorriente.Rows.Clear();
            foreach (CuentasCorrientesMedicos item in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvCuentaCorriente);
                SetearFila(r, item);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvCuentaCorriente.Rows.Add(r);
        }

        private void AgregarFilaSaldo(DataGridViewRow r)
        {
            dgvSaldo.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, CuentasCorrientesMedicos item)
        {
            r.Cells[cmIdCtaCte.Index].Value = item.IdCtaCte;
            r.Cells[cmMedico.Index].Value = item.Medico.ApellidoNombre;
            r.Cells[cmConsultorio.Index].Value = item.alquilerConsultorio.Consultorio.Consultorio;
            r.Cells[cmPaciente.Index].Value = item.turno.Paciente.ApellidoNombre;
            r.Cells[cmTurno.Index].Value = item.turno.Turno;
            r.Cells[cmObraSocial.Index].Value = item.turno.Paciente.Plan.ObraSocial.ObraSocial;
            r.Cells[cmCobro.Index].Value = item.turno.Cobro;
            r.Cells[cmliquidado.Index].Value = item.Liquidado?"Liquidado":"No posee liquidacion registrada";
            if (item.Liquidado == true)
            {
               
                r.Cells[cmFechaLiquidacion.Index].Value = item.FechaLiquidacion.ToShortDateString();
              

            }
            else
            {
                
                r.Cells[cmFechaLiquidacion.Index].Value = "Sin datos";
            }
            r.Tag = item;
        }
        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        Usuarios usuario;
        private Usuarios GetUsuario() { return usuario; }
        private void frmCtaCta_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
            MedicosBD.CargarCombobox(ref cboMedico);
            VerificarUsuario();

           // dtpDesde.Value = DateTime.Today.Date;

        }

        private void VerificarUsuario()
        {
            usuario = GetUsuario();
            switch (usuario.TipoUsuario.IdTipoUsuario)
            {
                case 1 :
                    cboMedico.SelectedIndex = 0;
                    cboMedico.Enabled = true;
                    break;
                case 2 :
                    cboMedico.SelectedIndex = 0;
                    cboMedico.Enabled = false;

                    break;
                case 3:
                    cboMedico.SelectedValue = usuario.Medico.IdMedico;
                    cboMedico.Enabled = false;
                    break;
            }
        }

        ReservasTurno turno;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboMedico.SelectedIndex>0)
            {
                turno = new ReservasTurno();
                turno.Medico = (Medicos)cboMedico.SelectedItem;
              //  turno.Fecha = dtpDesde.Value;
                try
                {
                     Listactacte = CtasCtesMedicosBD.GetListaFiltrada(turno);
                    MostrarDatosGrilla(Listactacte);
                    MostrarDatosGrillaSaldo(Listactacte);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void MostrarDatosGrillaSaldo(List<CuentasCorrientesMedicos> listactacte)
        {
            dgvSaldo.Rows.Clear();
            foreach (CuentasCorrientesMedicos item in listactacte)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvSaldo);
                SetearFilaSaldo(r, item);
                AgregarFilaSaldo(r);
            }
        }
        
        private void SetearFilaSaldo(DataGridViewRow r, CuentasCorrientesMedicos item)
        {
            r.Cells[cmnFecha.Index].Value = item.Fecha.ToShortDateString();
            r.Cells[cmnDebe.Index].Value = "$ "+item.Debe.ToString();
            r.Cells[cmnHaber.Index].Value = "$ " + item.Haber.ToString();
            r.Cells[cmnSaldo.Index].Value = "$ " + item.total.ToString();
            r.Tag = item;
        }

        CuentasCorrientesMedicos cuenta;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCuentaCorriente.Rows)
            {
                total += Convert.ToDecimal(row.Cells["cmCobro"].Value);
            }
            DataGridViewRow r = dgvCuentaCorriente.SelectedRows[0];
            cuenta = (CuentasCorrientesMedicos)r.Tag;
            frmLiquidacion frm = new frmLiquidacion();
            frm.SetLiquidacion(cuenta, total);
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("Liquidacion ingresada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La liquidacion no se concreto", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void dgvCuentaCorriente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {



            Medicos m = (Medicos)cboMedico.SelectedItem;
            frmReportes formr = new frmReportes();
            formr.Text = "Detalle de cuenta";
            formr.IdCta = m.IdMedico;
            formr.EsCta(true);
            formr.ShowDialog();
        }

        internal void SetUsuario(Usuarios u)
        {
            usuario = u; ;
        }
    }
}
