namespace Reportes
{
    partial class frmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SP_ReporteTurnoPorIdTurnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ConsultorioDS = new Reportes.ConsultorioDS();
            this.SP_ReporteTurnoPorIdTurnoTableAdapter = new Reportes.ConsultorioDSTableAdapters.SP_ReporteTurnoPorIdTurnoTableAdapter();
            this.SP_ReporteTurnosPorMedicoYFechaActualBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_ReporteTurnosPorMedicoYFechaActualTableAdapter = new Reportes.ConsultorioDSTableAdapters.SP_ReporteTurnosPorMedicoYFechaActualTableAdapter();
            this.rvTurnoIndividual = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteTurnoPorIdTurnoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultorioDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteTurnosPorMedicoYFechaActualBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_ReporteTurnoPorIdTurnoBindingSource
            // 
            this.SP_ReporteTurnoPorIdTurnoBindingSource.DataMember = "SP_ReporteTurnoPorIdTurno";
            this.SP_ReporteTurnoPorIdTurnoBindingSource.DataSource = this.ConsultorioDS;
            // 
            // ConsultorioDS
            // 
            this.ConsultorioDS.DataSetName = "ConsultorioDS";
            this.ConsultorioDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_ReporteTurnoPorIdTurnoTableAdapter
            // 
            this.SP_ReporteTurnoPorIdTurnoTableAdapter.ClearBeforeFill = true;
            // 
            // SP_ReporteTurnosPorMedicoYFechaActualBindingSource
            // 
            this.SP_ReporteTurnosPorMedicoYFechaActualBindingSource.DataMember = "SP_ReporteTurnosPorMedicoYFechaActual";
            this.SP_ReporteTurnosPorMedicoYFechaActualBindingSource.DataSource = this.ConsultorioDS;
            // 
            // SP_ReporteTurnosPorMedicoYFechaActualTableAdapter
            // 
            this.SP_ReporteTurnosPorMedicoYFechaActualTableAdapter.ClearBeforeFill = true;
            // 
            // rvTurnoIndividual
            // 
            this.rvTurnoIndividual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvTurnoIndividual.Location = new System.Drawing.Point(0, 0);
            this.rvTurnoIndividual.Name = "rvTurnoIndividual";
            this.rvTurnoIndividual.Size = new System.Drawing.Size(432, 339);
            this.rvTurnoIndividual.TabIndex = 0;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 339);
            this.Controls.Add(this.rvTurnoIndividual);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteTurnoPorIdTurnoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultorioDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_ReporteTurnosPorMedicoYFechaActualBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource SP_ReporteTurnoPorIdTurnoBindingSource;
        private ConsultorioDS ConsultorioDS;
        private ConsultorioDSTableAdapters.SP_ReporteTurnoPorIdTurnoTableAdapter SP_ReporteTurnoPorIdTurnoTableAdapter;
        private System.Windows.Forms.BindingSource SP_ReporteTurnosPorMedicoYFechaActualBindingSource;
        private ConsultorioDSTableAdapters.SP_ReporteTurnosPorMedicoYFechaActualTableAdapter SP_ReporteTurnosPorMedicoYFechaActualTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rvTurnoIndividual;
    }
}