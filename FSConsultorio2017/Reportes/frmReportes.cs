using Datos;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reportes
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }


        private bool Individual = false;
        private bool PorMedico = false;
        private bool PorMedicoYFecha = false;
        private bool Receta = false;
        private bool RecetaPorId = false;
        public void EsRecetaPorId(bool v) { RecetaPorId = v; }
        public void EsIndividual(bool v)
        {

            Individual = v;
        }
        bool Alquiler = false;

        public void EsAlquiler(bool v)
        {

            Alquiler= v;
        }
        public void EsReceta(bool v) { Receta = v; }
        public void EsPorMedico(bool v)
        {

            PorMedico= v;
        }

        public void EsPorMedicoYFecha(bool v)
        {

            PorMedicoYFecha= v;
        }
       public  int IdMedico { get; set; }
        public int IdConsulta { get; set; }
        public DateTime fecha { get; set; }
        public int IdTurno { get; set; }
        public int IdAlquiler { get; set; }
        public int IdCta { get; set; }
        private bool cta = false;
        private void frmReportes_Load(object sender, EventArgs e)
        {
            //  esta línea de código carga datos en la tabla 'ConsultorioDS.SP_ReporteTurnosPorMedicoYFechaActual' Puede moverla o quitarla según sea necesario.
            //this.SP_ReporteTurnosPorMedicoYFechaActualTableAdapter.Fill(this.ConsultorioDS.SP_ReporteTurnosPorMedicoYFechaActual);
            if (Individual == true)
            {

                DataTable dt = ReportesBD.GetResultadoTurnoIndividua(IdTurno);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteTurnoIndividual.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            }
            else if (PorMedico == true)
            {
                DataTable dt = ReportesBD.GetResultadoTurnosPorMedico(IdMedico);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteTurnoPorMedico.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            }
            else if (PorMedicoYFecha == true)

            {
                DataTable dt = ReportesBD.GetResultadoTurnoPorMedicoYFecha(IdMedico, fecha);

                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteTurnoPorMedicoYFecha.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            }
            else if (Receta == true)
            {
                DataTable dt = ReportesBD.GetResultadoConsulta(IdTurno);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteConsulta.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            } else if (RecetaPorId == true)
            {
                DataTable dt = ReportesBD.GetResultadoConsultaPorId(IdConsulta);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteConsultaPorIdConsulta.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));

            }
            else if (Alquiler==true)
            {
                DataTable dt = ReportesBD.GetResultadoAlquiler(IdAlquiler);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteAlquiler.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            }
            else if (cta == true)
            {
                DataTable dt = ReportesBD.GetResultadoCtaCte(IdCta);
                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReportCtaCte.rdlc";
                rvTurnoIndividual.LocalReport.DataSources.Clear();
                rvTurnoIndividual.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            }
            this.rvTurnoIndividual.RefreshReport();
        }

      

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public void EsCta(bool v)
        {
            cta = v;
        }
    }
}
//rvTurnoIndividual.Dock = DockStyle.Fill;
//                //this.SP_ReporteTurnoPorIdTurnoTableAdapter.Fill(this.ConsultorioDS.SP_ReporteTurnoPorIdTurno, IdTurno);
//                //*****    linea para setear reporte   ******
//                //Dataset1 es el nombre de donde traes los conjunto de datos esta en las prop de la tabla del reporte
//                          this.SP_ReporteTurnoPorIdTurnoTableAdapter.Fill(this.ConsultorioDS.SP_ReporteTurnoPorIdTurno, IdTurno);
//var rds = new ReportDataSource("DataSet1", (DataTable)ConsultorioDS.SP_ReporteTurnoPorIdTurno);
//                rvTurnoIndividual.LocalReport.DataSources.Clear();
//                rvTurnoIndividual.ProcessingMode = ProcessingMode.Local;
//                rvTurnoIndividual.LocalReport.ReportPath = @"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Reportes\ReporteTurnoIndividual.rdlc";
//                rvTurnoIndividual.LocalReport.DataSources.Add(rds);
//                rvTurnoIndividual.LocalReport.Refresh();
//                this.rvTurnoIndividual.RefreshReport();