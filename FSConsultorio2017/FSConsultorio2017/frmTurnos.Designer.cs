namespace FSConsultorio2017
{
    partial class frmTurnos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMedS = new System.Windows.Forms.TextBox();
            this.txtEspS = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMedicoEsp = new System.Windows.Forms.DataGridView();
            this.cmnEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscra = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rbtPorfecha = new System.Windows.Forms.RadioButton();
            this.rbtTodos = new System.Windows.Forms.RadioButton();
            this.cboMedicos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.cmIdTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmMedicos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDgvTurno = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asignarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cobroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.cmsDgvTurno.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMedS);
            this.groupBox1.Controls.Add(this.txtEspS);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnBuscra);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.rbtPorfecha);
            this.groupBox1.Controls.Add(this.rbtTodos);
            this.groupBox1.Controls.Add(this.cboMedicos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(789, 115);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(38, 23);
            this.btnSeleccionar.TabIndex = 12;
            this.btnSeleccionar.Text = ">>";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Especialidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Medico seleccionado";
            // 
            // txtMedS
            // 
            this.txtMedS.Enabled = false;
            this.txtMedS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedS.Location = new System.Drawing.Point(415, 157);
            this.txtMedS.Name = "txtMedS";
            this.txtMedS.Size = new System.Drawing.Size(174, 20);
            this.txtMedS.TabIndex = 9;
            // 
            // txtEspS
            // 
            this.txtEspS.Enabled = false;
            this.txtEspS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspS.Location = new System.Drawing.Point(668, 161);
            this.txtEspS.Name = "txtEspS";
            this.txtEspS.Size = new System.Drawing.Size(174, 20);
            this.txtEspS.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(301, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 131);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Especialidad";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMedicoEsp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 112);
            this.panel2.TabIndex = 6;
            // 
            // dgvMedicoEsp
            // 
            this.dgvMedicoEsp.AllowUserToAddRows = false;
            this.dgvMedicoEsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicoEsp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnEspecialidad,
            this.cmnCosto});
            this.dgvMedicoEsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicoEsp.Location = new System.Drawing.Point(0, 0);
            this.dgvMedicoEsp.Name = "dgvMedicoEsp";
            this.dgvMedicoEsp.Size = new System.Drawing.Size(465, 112);
            this.dgvMedicoEsp.TabIndex = 0;
            // 
            // cmnEspecialidad
            // 
            this.cmnEspecialidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnEspecialidad.HeaderText = "Especialiad ";
            this.cmnEspecialidad.Name = "cmnEspecialidad";
            // 
            // cmnCosto
            // 
            this.cmnCosto.HeaderText = "P. Consulta";
            this.cmnCosto.Name = "cmnCosto";
            // 
            // btnBuscra
            // 
            this.btnBuscra.Location = new System.Drawing.Point(878, 115);
            this.btnBuscra.Name = "btnBuscra";
            this.btnBuscra.Size = new System.Drawing.Size(75, 23);
            this.btnBuscra.TabIndex = 5;
            this.btnBuscra.Text = "Buscar";
            this.btnBuscra.UseVisualStyleBackColor = true;
            this.btnBuscra.Click += new System.EventHandler(this.btnBuscra_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(81, 98);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(195, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rbtPorfecha
            // 
            this.rbtPorfecha.AutoSize = true;
            this.rbtPorfecha.Location = new System.Drawing.Point(20, 102);
            this.rbtPorfecha.Name = "rbtPorfecha";
            this.rbtPorfecha.Size = new System.Drawing.Size(55, 17);
            this.rbtPorfecha.TabIndex = 3;
            this.rbtPorfecha.Text = "Fecha";
            this.rbtPorfecha.UseVisualStyleBackColor = true;
            this.rbtPorfecha.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtTodos
            // 
            this.rbtTodos.AutoSize = true;
            this.rbtTodos.Checked = true;
            this.rbtTodos.Location = new System.Drawing.Point(20, 69);
            this.rbtTodos.Name = "rbtTodos";
            this.rbtTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtTodos.TabIndex = 2;
            this.rbtTodos.TabStop = true;
            this.rbtTodos.Text = "Todos";
            this.rbtTodos.UseVisualStyleBackColor = true;
            this.rbtTodos.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cboMedicos
            // 
            this.cboMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedicos.FormattingEnabled = true;
            this.cboMedicos.Location = new System.Drawing.Point(71, 30);
            this.cboMedicos.Name = "cboMedicos";
            this.cboMedicos.Size = new System.Drawing.Size(205, 21);
            this.cboMedicos.TabIndex = 1;
            this.cboMedicos.SelectedIndexChanged += new System.EventHandler(this.cboMedicos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Medico  ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTurnos);
            this.panel1.Location = new System.Drawing.Point(12, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 322);
            this.panel1.TabIndex = 1;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmIdTurno,
            this.cmMedicos,
            this.cmConsultorio,
            this.cmTurno,
            this.cmPaciente,
            this.cmObraSocial,
            this.cmPlan});
            this.dgvTurnos.ContextMenuStrip = this.cmsDgvTurno;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 0);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(985, 322);
            this.dgvTurnos.TabIndex = 1;
            // 
            // cmIdTurno
            // 
            this.cmIdTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmIdTurno.HeaderText = "IdTurno";
            this.cmIdTurno.Name = "cmIdTurno";
            this.cmIdTurno.ReadOnly = true;
            this.cmIdTurno.Visible = false;
            // 
            // cmMedicos
            // 
            this.cmMedicos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmMedicos.HeaderText = "Medicos";
            this.cmMedicos.Name = "cmMedicos";
            this.cmMedicos.ReadOnly = true;
            // 
            // cmConsultorio
            // 
            this.cmConsultorio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmConsultorio.HeaderText = "Consultorio";
            this.cmConsultorio.Name = "cmConsultorio";
            this.cmConsultorio.ReadOnly = true;
            // 
            // cmTurno
            // 
            this.cmTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmTurno.HeaderText = "Turno";
            this.cmTurno.Name = "cmTurno";
            this.cmTurno.ReadOnly = true;
            // 
            // cmPaciente
            // 
            this.cmPaciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmPaciente.HeaderText = "Paciente";
            this.cmPaciente.Name = "cmPaciente";
            this.cmPaciente.ReadOnly = true;
            // 
            // cmObraSocial
            // 
            this.cmObraSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmObraSocial.HeaderText = "Obra social";
            this.cmObraSocial.Name = "cmObraSocial";
            this.cmObraSocial.ReadOnly = true;
            // 
            // cmPlan
            // 
            this.cmPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmPlan.HeaderText = "Plan";
            this.cmPlan.Name = "cmPlan";
            this.cmPlan.ReadOnly = true;
            // 
            // cmsDgvTurno
            // 
            this.cmsDgvTurno.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asignarPacienteToolStripMenuItem,
            this.cobroToolStripMenuItem,
            this.imprimirToolStripMenuItem});
            this.cmsDgvTurno.Name = "cmsDgvTurno";
            this.cmsDgvTurno.Size = new System.Drawing.Size(201, 70);
            // 
            // asignarPacienteToolStripMenuItem
            // 
            this.asignarPacienteToolStripMenuItem.Name = "asignarPacienteToolStripMenuItem";
            this.asignarPacienteToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.asignarPacienteToolStripMenuItem.Text = "Asignar/Quitar Paciente";
            this.asignarPacienteToolStripMenuItem.Click += new System.EventHandler(this.asignarPacienteToolStripMenuItem_Click);
            // 
            // cobroToolStripMenuItem
            // 
            this.cobroToolStripMenuItem.Name = "cobroToolStripMenuItem";
            this.cobroToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.cobroToolStripMenuItem.Text = "Cobro";
            this.cobroToolStripMenuItem.Click += new System.EventHandler(this.cobroToolStripMenuItem_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir ";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.imprimirToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbImprimir,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1009, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.Image = global::FSConsultorio2017.Properties.Resources._004_impresora;
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(73, 22);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::FSConsultorio2017.Properties.Resources._001_puerta;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 498);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTurnos";
            this.Text = "frmTurnos";
            this.Load += new System.EventHandler(this.frmTurnos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.cmsDgvTurno.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtPorfecha;
        private System.Windows.Forms.RadioButton rbtTodos;
        private System.Windows.Forms.ComboBox cboMedicos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btnBuscra;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMedicoEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCosto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMedS;
        private System.Windows.Forms.TextBox txtEspS;
        private System.Windows.Forms.ContextMenuStrip cmsDgvTurno;
        private System.Windows.Forms.ToolStripMenuItem asignarPacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cobroToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmIdTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmMedicos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmPlan;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
    }
}