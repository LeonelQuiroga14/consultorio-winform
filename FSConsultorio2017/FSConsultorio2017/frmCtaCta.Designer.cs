namespace FSConsultorio2017
{
    partial class frmCtaCta
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
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCuentaCorriente = new System.Windows.Forms.DataGridView();
            this.cmIdCtaCte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmliquidado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmFechaLiquidacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSaldo = new System.Windows.Forms.DataGridView();
            this.cmnFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDebe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnHaber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentaCorriente)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboMedico
            // 
            this.cboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(84, 26);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(224, 21);
            this.cboMedico.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Medico";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(872, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::FSConsultorio2017.Properties.Resources._004_anadir;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(90, 22);
            this.toolStripButton1.Text = "Liquidar Dia";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::FSConsultorio2017.Properties.Resources._001_puerta;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton2.Text = "Salir";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(344, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvCuentaCorriente);
            this.panel1.Location = new System.Drawing.Point(0, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 319);
            this.panel1.TabIndex = 17;
            // 
            // dgvCuentaCorriente
            // 
            this.dgvCuentaCorriente.AllowUserToAddRows = false;
            this.dgvCuentaCorriente.AllowUserToDeleteRows = false;
            this.dgvCuentaCorriente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentaCorriente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmIdCtaCte,
            this.cmMedico,
            this.cmConsultorio,
            this.cmPaciente,
            this.cmTurno,
            this.cmObraSocial,
            this.cmCobro,
            this.cmliquidado,
            this.cmFechaLiquidacion});
            this.dgvCuentaCorriente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCuentaCorriente.Location = new System.Drawing.Point(0, 0);
            this.dgvCuentaCorriente.Name = "dgvCuentaCorriente";
            this.dgvCuentaCorriente.ReadOnly = true;
            this.dgvCuentaCorriente.RowHeadersVisible = false;
            this.dgvCuentaCorriente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCuentaCorriente.Size = new System.Drawing.Size(872, 319);
            this.dgvCuentaCorriente.TabIndex = 1;
            this.dgvCuentaCorriente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCuentaCorriente_CellContentClick_1);
            // 
            // cmIdCtaCte
            // 
            this.cmIdCtaCte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.cmIdCtaCte.HeaderText = "IdCtaCte";
            this.cmIdCtaCte.Name = "cmIdCtaCte";
            this.cmIdCtaCte.ReadOnly = true;
            this.cmIdCtaCte.Visible = false;
            // 
            // cmMedico
            // 
            this.cmMedico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMedico.HeaderText = "Medico";
            this.cmMedico.Name = "cmMedico";
            this.cmMedico.ReadOnly = true;
            // 
            // cmConsultorio
            // 
            this.cmConsultorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmConsultorio.HeaderText = "Consultorio";
            this.cmConsultorio.Name = "cmConsultorio";
            this.cmConsultorio.ReadOnly = true;
            // 
            // cmPaciente
            // 
            this.cmPaciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmPaciente.HeaderText = "Paciente";
            this.cmPaciente.Name = "cmPaciente";
            this.cmPaciente.ReadOnly = true;
            // 
            // cmTurno
            // 
            this.cmTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmTurno.HeaderText = "Turno";
            this.cmTurno.Name = "cmTurno";
            this.cmTurno.ReadOnly = true;
            // 
            // cmObraSocial
            // 
            this.cmObraSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmObraSocial.HeaderText = "Obra social";
            this.cmObraSocial.Name = "cmObraSocial";
            this.cmObraSocial.ReadOnly = true;
            // 
            // cmCobro
            // 
            this.cmCobro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmCobro.HeaderText = "Cobro";
            this.cmCobro.Name = "cmCobro";
            this.cmCobro.ReadOnly = true;
            // 
            // cmliquidado
            // 
            this.cmliquidado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmliquidado.HeaderText = "Liquidado";
            this.cmliquidado.Name = "cmliquidado";
            this.cmliquidado.ReadOnly = true;
            // 
            // cmFechaLiquidacion
            // 
            this.cmFechaLiquidacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmFechaLiquidacion.HeaderText = "Fecha liquidacion";
            this.cmFechaLiquidacion.Name = "cmFechaLiquidacion";
            this.cmFechaLiquidacion.ReadOnly = true;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::FSConsultorio2017.Properties.Resources._004_impresora;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton3.Text = "Imprimir";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSaldo);
            this.groupBox1.Location = new System.Drawing.Point(469, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 106);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle Saldo";
            // 
            // dgvSaldo
            // 
            this.dgvSaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaldo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnFecha,
            this.cmnDebe,
            this.cmnHaber,
            this.cmnSaldo});
            this.dgvSaldo.Location = new System.Drawing.Point(1, 20);
            this.dgvSaldo.MultiSelect = false;
            this.dgvSaldo.Name = "dgvSaldo";
            this.dgvSaldo.RowHeadersVisible = false;
            this.dgvSaldo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSaldo.Size = new System.Drawing.Size(371, 82);
            this.dgvSaldo.TabIndex = 19;
            // 
            // cmnFecha
            // 
            this.cmnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnFecha.HeaderText = "Ultimo Mov.";
            this.cmnFecha.Name = "cmnFecha";
            // 
            // cmnDebe
            // 
            this.cmnDebe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDebe.HeaderText = "Debe";
            this.cmnDebe.Name = "cmnDebe";
            // 
            // cmnHaber
            // 
            this.cmnHaber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnHaber.HeaderText = "Haber";
            this.cmnHaber.Name = "cmnHaber";
            // 
            // cmnSaldo
            // 
            this.cmnSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnSaldo.HeaderText = "Saldo";
            this.cmnSaldo.Name = "cmnSaldo";
            // 
            // frmCtaCta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 472);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMedico);
            this.Name = "frmCtaCta";
            this.Text = "frmCtaCta";
            this.Load += new System.EventHandler(this.frmCtaCta_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentaCorriente)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaldo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCuentaCorriente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmIdCtaCte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmliquidado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmFechaLiquidacion;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDebe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnHaber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnSaldo;
    }
}