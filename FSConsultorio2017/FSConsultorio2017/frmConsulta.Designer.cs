namespace FSConsultorio2017
{
    partial class frmConsulta
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
            this.dgvMedicoEsp = new System.Windows.Forms.DataGridView();
            this.cmnMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtxtSintomas = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rtxtDiagnostico = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtxtmedicacion = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rtxtIndicacion = new System.Windows.Forms.RichTextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmConsultorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMedico = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEsp = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMedicoEsp
            // 
            this.dgvMedicoEsp.AllowUserToAddRows = false;
            this.dgvMedicoEsp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicoEsp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnMedico,
            this.cmnEspecialidad});
            this.dgvMedicoEsp.Location = new System.Drawing.Point(6, 19);
            this.dgvMedicoEsp.Name = "dgvMedicoEsp";
            this.dgvMedicoEsp.Size = new System.Drawing.Size(379, 139);
            this.dgvMedicoEsp.TabIndex = 1;
            // 
            // cmnMedico
            // 
            this.cmnMedico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnMedico.HeaderText = "Medico";
            this.cmnMedico.Name = "cmnMedico";
            // 
            // cmnEspecialidad
            // 
            this.cmnEspecialidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnEspecialidad.HeaderText = "Especialiad ";
            this.cmnEspecialidad.Name = "cmnEspecialidad";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(88, 165);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(220, 20);
            this.dtpFecha.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha";
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmConsultorio,
            this.cmTurno,
            this.cmPaciente,
            this.cmObraSocial,
            this.cmPlan});
            this.dgvTurnos.Location = new System.Drawing.Point(17, 30);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersVisible = false;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(647, 139);
            this.dgvTurnos.TabIndex = 7;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(337, 164);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(38, 23);
            this.btnSeleccionar.TabIndex = 13;
            this.btnSeleccionar.Text = ">>";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(645, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblEdad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Location = new System.Drawing.Point(233, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 40);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Paciente";
            // 
            // lblGS
            // 
            this.lblGS.AutoSize = true;
            this.lblGS.Location = new System.Drawing.Point(326, 18);
            this.lblGS.Name = "lblGS";
            this.lblGS.Size = new System.Drawing.Size(19, 13);
            this.lblGS.TabIndex = 22;
            this.lblGS.Text = "----";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Grupo Sanguineo :";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(182, 18);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(19, 13);
            this.lblEdad.TabIndex = 20;
            this.lblEdad.Text = "----";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Edad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Nombre :";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(75, 18);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(19, 13);
            this.lblNombre.TabIndex = 16;
            this.lblNombre.Text = "----";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMedicoEsp);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSeleccionar);
            this.groupBox2.Location = new System.Drawing.Point(12, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 194);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busque Turno";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblEsp);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblMedico);
            this.groupBox3.Controls.Add(this.dgvTurnos);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(449, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 223);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seleccione Turno";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rtxtSintomas);
            this.groupBox4.Location = new System.Drawing.Point(18, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(425, 95);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sintomas";
            // 
            // rtxtSintomas
            // 
            this.rtxtSintomas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtSintomas.Location = new System.Drawing.Point(3, 16);
            this.rtxtSintomas.Name = "rtxtSintomas";
            this.rtxtSintomas.Size = new System.Drawing.Size(419, 76);
            this.rtxtSintomas.TabIndex = 0;
            this.rtxtSintomas.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rtxtDiagnostico);
            this.groupBox5.Location = new System.Drawing.Point(21, 312);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(419, 133);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Diagnostico - Observaciones";
            // 
            // rtxtDiagnostico
            // 
            this.rtxtDiagnostico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDiagnostico.Location = new System.Drawing.Point(3, 16);
            this.rtxtDiagnostico.Name = "rtxtDiagnostico";
            this.rtxtDiagnostico.Size = new System.Drawing.Size(413, 114);
            this.rtxtDiagnostico.TabIndex = 0;
            this.rtxtDiagnostico.Text = "";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtxtmedicacion);
            this.groupBox6.Location = new System.Drawing.Point(466, 231);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(460, 86);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Medicacion";
            // 
            // rtxtmedicacion
            // 
            this.rtxtmedicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtmedicacion.Location = new System.Drawing.Point(3, 16);
            this.rtxtmedicacion.Name = "rtxtmedicacion";
            this.rtxtmedicacion.Size = new System.Drawing.Size(454, 67);
            this.rtxtmedicacion.TabIndex = 0;
            this.rtxtmedicacion.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rtxtIndicacion);
            this.groupBox7.Location = new System.Drawing.Point(466, 328);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(460, 114);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Indicaciones";
            // 
            // rtxtIndicacion
            // 
            this.rtxtIndicacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtIndicacion.Location = new System.Drawing.Point(3, 16);
            this.rtxtIndicacion.Name = "rtxtIndicacion";
            this.rtxtIndicacion.Size = new System.Drawing.Size(454, 95);
            this.rtxtIndicacion.TabIndex = 0;
            this.rtxtIndicacion.Text = "";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(970, 312);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 23);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar receta";
            this.btnLimpiar.UseVisualStyleBackColor = true;
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
            // btnCancelar
            // 
            this.btnCancelar.Image = global::FSConsultorio2017.Properties.Resources._006_cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(1038, 382);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 57);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::FSConsultorio2017.Properties.Resources._008_disquete_1;
            this.btnGuardar.Location = new System.Drawing.Point(943, 382);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 57);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Medico :";
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(90, 181);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(19, 13);
            this.lblMedico.TabIndex = 19;
            this.lblMedico.Text = "----";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Especialidad : ";
            // 
            // lblEsp
            // 
            this.lblEsp.AutoSize = true;
            this.lblEsp.Location = new System.Drawing.Point(99, 202);
            this.lblEsp.Name = "lblEsp";
            this.lblEsp.Size = new System.Drawing.Size(19, 13);
            this.lblEsp.TabIndex = 21;
            this.lblEsp.Text = "----";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 466);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmConsulta";
            this.Text = "frmConsulta";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicoEsp;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox rtxtSintomas;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox rtxtDiagnostico;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox rtxtmedicacion;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox rtxtIndicacion;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmConsultorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmPlan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEsp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}