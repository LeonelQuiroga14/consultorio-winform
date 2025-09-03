using BL;
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
    public partial class frmDetalleConsulta : Form
    {
        public frmDetalleConsulta()
        {
            InitializeComponent();
        }
        private Consultas consulta;
        public void SetConsulta(Consultas S)
        { consulta = S; }
        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalleConsulta_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            Pacientes paciente = consulta.Turno.Paciente;
            lblNombre.Text = paciente.Nombre;
            lblApellido.Text = paciente.Apellido; ;
            lblEdad.Text = Convert.ToString(DateTime.Now.Year - paciente.FechaNac.Year);
            lblGS.Text = paciente.GrupoSanguineo;
            lblObraS.Text = paciente.Plan.ObraSocial.ObraSocial;
            lblPlan.Text = paciente.Plan.Plan;
            lblGenero.Text = paciente.Genero.Genero;


            rtxtSintomas.Text = consulta.Sintomas;
            rtxtDiagnostico.Text = consulta.Diagnostico;
            rtxtmedicacion.Text = consulta.Medicacion;
            rtxtIndicacion.Text = consulta.Observaciones;
            rtxtSintomas.ReadOnly = true;
            rtxtDiagnostico.ReadOnly = true;
            rtxtmedicacion.ReadOnly = true;
            rtxtIndicacion.ReadOnly = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes();
            frm.Text = "Imprimir detalle Consulta";
            frm.IdConsulta = consulta.IdConsulta;
            frm.EsRecetaPorId(true);
            frm.ShowDialog();
        }
    }
}
