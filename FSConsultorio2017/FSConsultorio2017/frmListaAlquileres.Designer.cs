namespace FSConsultorio2017
{
    partial class frmListaAlquileres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaAlquileres));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAlquilerConsultorio = new System.Windows.Forms.DataGridView();
            this.cmIdAlquilerConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquilerConsultorio)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(796, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAlquilerConsultorio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 312);
            this.panel1.TabIndex = 3;
            // 
            // dgvAlquilerConsultorio
            // 
            this.dgvAlquilerConsultorio.AllowUserToAddRows = false;
            this.dgvAlquilerConsultorio.AllowUserToDeleteRows = false;
            this.dgvAlquilerConsultorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlquilerConsultorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmIdAlquilerConsultorio,
            this.cmAlquiler,
            this.cmConsultorio,
            this.cmMedico,
            this.cmFechaInicio,
            this.cmFechaFin});
            this.dgvAlquilerConsultorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlquilerConsultorio.Location = new System.Drawing.Point(0, 0);
            this.dgvAlquilerConsultorio.Name = "dgvAlquilerConsultorio";
            this.dgvAlquilerConsultorio.ReadOnly = true;
            this.dgvAlquilerConsultorio.RowHeadersVisible = false;
            this.dgvAlquilerConsultorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlquilerConsultorio.Size = new System.Drawing.Size(796, 312);
            this.dgvAlquilerConsultorio.TabIndex = 2;
            // 
            // cmIdAlquilerConsultorio
            // 
            this.cmIdAlquilerConsultorio.HeaderText = "cmAlquilerConsultorio";
            this.cmIdAlquilerConsultorio.Name = "cmIdAlquilerConsultorio";
            this.cmIdAlquilerConsultorio.ReadOnly = true;
            this.cmIdAlquilerConsultorio.Visible = false;
            // 
            // cmAlquiler
            // 
            this.cmAlquiler.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmAlquiler.HeaderText = "Alquiler";
            this.cmAlquiler.Name = "cmAlquiler";
            this.cmAlquiler.ReadOnly = true;
            // 
            // cmConsultorio
            // 
            this.cmConsultorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmConsultorio.HeaderText = "Consultorio";
            this.cmConsultorio.Name = "cmConsultorio";
            this.cmConsultorio.ReadOnly = true;
            // 
            // cmMedico
            // 
            this.cmMedico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMedico.HeaderText = "Medicos";
            this.cmMedico.Name = "cmMedico";
            this.cmMedico.ReadOnly = true;
            // 
            // cmFechaInicio
            // 
            this.cmFechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmFechaInicio.HeaderText = "Inicio del alquiler";
            this.cmFechaInicio.Name = "cmFechaInicio";
            this.cmFechaInicio.ReadOnly = true;
            // 
            // cmFechaFin
            // 
            this.cmFechaFin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmFechaFin.HeaderText = "Final del alquiler";
            this.cmFechaFin.Name = "cmFechaFin";
            this.cmFechaFin.ReadOnly = true;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::FSConsultorio2017.Properties.Resources._004_impresora;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton2.Text = "Imprimir";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // frmListaAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 337);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmListaAlquileres";
            this.Text = "frmListaAlquileres";
            this.Load += new System.EventHandler(this.frmListaAlquileres_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquilerConsultorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvAlquilerConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmIdAlquilerConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmFechaFin;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}