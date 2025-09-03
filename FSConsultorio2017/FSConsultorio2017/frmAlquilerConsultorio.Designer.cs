namespace FSConsultorio2017
{
    partial class frmAlquilerConsultorio
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
            this.cbxViernes = new System.Windows.Forms.CheckBox();
            this.cbxJueves = new System.Windows.Forms.CheckBox();
            this.cbxMiercoles = new System.Windows.Forms.CheckBox();
            this.cbxMartes = new System.Windows.Forms.CheckBox();
            this.cbxLunes = new System.Windows.Forms.CheckBox();
            this.cbxDiasSemana = new System.Windows.Forms.CheckBox();
            this.lbConsultorio = new System.Windows.Forms.Label();
            this.lbMedico = new System.Windows.Forms.Label();
            this.lbTipoAlquiler = new System.Windows.Forms.Label();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.cboConsultorio = new System.Windows.Forms.ComboBox();
            this.cboJornda = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxBusqueda = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpIni = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mntcAlquiler = new System.Windows.Forms.MonthCalendar();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMedS = new System.Windows.Forms.TextBox();
            this.txtEspS = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMedicoEsp = new System.Windows.Forms.DataGridView();
            this.cmnEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxViernes
            // 
            this.cbxViernes.AutoSize = true;
            this.cbxViernes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxViernes.Enabled = false;
            this.cbxViernes.Location = new System.Drawing.Point(448, 289);
            this.cbxViernes.Name = "cbxViernes";
            this.cbxViernes.Size = new System.Drawing.Size(61, 17);
            this.cbxViernes.TabIndex = 18;
            this.cbxViernes.Text = "Viernes";
            this.cbxViernes.UseVisualStyleBackColor = true;
            // 
            // cbxJueves
            // 
            this.cbxJueves.AutoSize = true;
            this.cbxJueves.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxJueves.Enabled = false;
            this.cbxJueves.Location = new System.Drawing.Point(370, 289);
            this.cbxJueves.Name = "cbxJueves";
            this.cbxJueves.Size = new System.Drawing.Size(60, 17);
            this.cbxJueves.TabIndex = 17;
            this.cbxJueves.Text = "Jueves";
            this.cbxJueves.UseVisualStyleBackColor = true;
            // 
            // cbxMiercoles
            // 
            this.cbxMiercoles.AutoSize = true;
            this.cbxMiercoles.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMiercoles.Enabled = false;
            this.cbxMiercoles.Location = new System.Drawing.Point(270, 289);
            this.cbxMiercoles.Name = "cbxMiercoles";
            this.cbxMiercoles.Size = new System.Drawing.Size(71, 17);
            this.cbxMiercoles.TabIndex = 14;
            this.cbxMiercoles.Text = "Miercoles";
            this.cbxMiercoles.UseVisualStyleBackColor = true;
            this.cbxMiercoles.CheckedChanged += new System.EventHandler(this.cbxMiercoles_CheckedChanged);
            // 
            // cbxMartes
            // 
            this.cbxMartes.AutoSize = true;
            this.cbxMartes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxMartes.Enabled = false;
            this.cbxMartes.Location = new System.Drawing.Point(182, 289);
            this.cbxMartes.Name = "cbxMartes";
            this.cbxMartes.Size = new System.Drawing.Size(58, 17);
            this.cbxMartes.TabIndex = 15;
            this.cbxMartes.Text = "Martes";
            this.cbxMartes.UseVisualStyleBackColor = true;
            // 
            // cbxLunes
            // 
            this.cbxLunes.AutoSize = true;
            this.cbxLunes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxLunes.Enabled = false;
            this.cbxLunes.Location = new System.Drawing.Point(110, 289);
            this.cbxLunes.Name = "cbxLunes";
            this.cbxLunes.Size = new System.Drawing.Size(55, 17);
            this.cbxLunes.TabIndex = 16;
            this.cbxLunes.Text = "Lunes";
            this.cbxLunes.UseVisualStyleBackColor = true;
            // 
            // cbxDiasSemana
            // 
            this.cbxDiasSemana.AutoSize = true;
            this.cbxDiasSemana.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxDiasSemana.Location = new System.Drawing.Point(29, 268);
            this.cbxDiasSemana.Name = "cbxDiasSemana";
            this.cbxDiasSemana.Size = new System.Drawing.Size(47, 17);
            this.cbxDiasSemana.TabIndex = 19;
            this.cbxDiasSemana.Text = "Dias";
            this.cbxDiasSemana.UseVisualStyleBackColor = true;
            this.cbxDiasSemana.CheckedChanged += new System.EventHandler(this.cbxDiasSemana_CheckedChanged);
            // 
            // lbConsultorio
            // 
            this.lbConsultorio.AutoSize = true;
            this.lbConsultorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConsultorio.Location = new System.Drawing.Point(29, 226);
            this.lbConsultorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbConsultorio.Name = "lbConsultorio";
            this.lbConsultorio.Size = new System.Drawing.Size(59, 13);
            this.lbConsultorio.TabIndex = 21;
            this.lbConsultorio.Text = "Consultorio";
            // 
            // lbMedico
            // 
            this.lbMedico.AutoSize = true;
            this.lbMedico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMedico.Location = new System.Drawing.Point(26, 27);
            this.lbMedico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMedico.Name = "lbMedico";
            this.lbMedico.Size = new System.Drawing.Size(42, 13);
            this.lbMedico.TabIndex = 20;
            this.lbMedico.Text = "Medico";
            // 
            // lbTipoAlquiler
            // 
            this.lbTipoAlquiler.AutoSize = true;
            this.lbTipoAlquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoAlquiler.Location = new System.Drawing.Point(310, 226);
            this.lbTipoAlquiler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTipoAlquiler.Name = "lbTipoAlquiler";
            this.lbTipoAlquiler.Size = new System.Drawing.Size(45, 13);
            this.lbTipoAlquiler.TabIndex = 24;
            this.lbTipoAlquiler.Text = "Jornada";
            // 
            // cboMedico
            // 
            this.cboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(89, 24);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(228, 21);
            this.cboMedico.TabIndex = 25;
            this.cboMedico.SelectedIndexChanged += new System.EventHandler(this.cboMedico_SelectedIndexChanged);
            // 
            // cboConsultorio
            // 
            this.cboConsultorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsultorio.FormattingEnabled = true;
            this.cboConsultorio.Location = new System.Drawing.Point(110, 223);
            this.cboConsultorio.Name = "cboConsultorio";
            this.cboConsultorio.Size = new System.Drawing.Size(163, 21);
            this.cboConsultorio.TabIndex = 26;
            // 
            // cboJornda
            // 
            this.cboJornda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJornda.FormattingEnabled = true;
            this.cboJornda.Location = new System.Drawing.Point(370, 223);
            this.cboJornda.Name = "cboJornda";
            this.cboJornda.Size = new System.Drawing.Size(163, 21);
            this.cboJornda.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMedS);
            this.groupBox1.Controls.Add(this.txtEspS);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.cbxJueves);
            this.groupBox1.Controls.Add(this.cboJornda);
            this.groupBox1.Controls.Add(this.cboConsultorio);
            this.groupBox1.Controls.Add(this.cbxLunes);
            this.groupBox1.Controls.Add(this.cboMedico);
            this.groupBox1.Controls.Add(this.cbxMartes);
            this.groupBox1.Controls.Add(this.lbTipoAlquiler);
            this.groupBox1.Controls.Add(this.cbxMiercoles);
            this.groupBox1.Controls.Add(this.lbConsultorio);
            this.groupBox1.Controls.Add(this.cbxViernes);
            this.groupBox1.Controls.Add(this.lbMedico);
            this.groupBox1.Controls.Add(this.cbxDiasSemana);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 322);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // cbxBusqueda
            // 
            this.cbxBusqueda.AutoSize = true;
            this.cbxBusqueda.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbxBusqueda.Location = new System.Drawing.Point(44, 520);
            this.cbxBusqueda.Name = "cbxBusqueda";
            this.cbxBusqueda.Size = new System.Drawing.Size(100, 17);
            this.cbxBusqueda.TabIndex = 28;
            this.cbxBusqueda.Text = "Consultorio libre";
            this.cbxBusqueda.UseVisualStyleBackColor = true;
            this.cbxBusqueda.CheckedChanged += new System.EventHandler(this.cbxBusqueda_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFin);
            this.groupBox2.Controls.Add(this.dtpIni);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(298, 520);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(613, 56);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Periodo de alquiler";
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(354, 24);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFin.TabIndex = 3;
            // 
            // dtpIni
            // 
            this.dtpIni.Location = new System.Drawing.Point(73, 24);
            this.dtpIni.Name = "dtpIni";
            this.dtpIni.Size = new System.Drawing.Size(200, 20);
            this.dtpIni.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio";
            // 
            // mntcAlquiler
            // 
            this.mntcAlquiler.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.mntcAlquiler.Location = new System.Drawing.Point(0, 346);
            this.mntcAlquiler.Name = "mntcAlquiler";
            this.mntcAlquiler.TabIndex = 30;
            this.mntcAlquiler.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mntcAlquiler_DateChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::FSConsultorio2017.Properties.Resources._006_cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(513, 582);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 57);
            this.btnCancelar.TabIndex = 32;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::FSConsultorio2017.Properties.Resources._008_disquete_1;
            this.btnGuardar.Location = new System.Drawing.Point(336, 582);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 57);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(981, 25);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
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
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(501, 172);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(38, 23);
            this.btnSeleccionar.TabIndex = 33;
            this.btnSeleccionar.Text = ">>";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Especialidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Medico seleccionado";
            // 
            // txtMedS
            // 
            this.txtMedS.Enabled = false;
            this.txtMedS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedS.Location = new System.Drawing.Point(632, 83);
            this.txtMedS.Name = "txtMedS";
            this.txtMedS.Size = new System.Drawing.Size(174, 20);
            this.txtMedS.TabIndex = 30;
            // 
            // txtEspS
            // 
            this.txtEspS.Enabled = false;
            this.txtEspS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEspS.Location = new System.Drawing.Point(632, 120);
            this.txtEspS.Name = "txtEspS";
            this.txtEspS.Size = new System.Drawing.Size(174, 20);
            this.txtEspS.TabIndex = 29;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Location = new System.Drawing.Point(19, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 131);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Especialidad";
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
            // frmAlquilerConsultorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 694);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.mntcAlquiler);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbxBusqueda);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAlquilerConsultorio";
            this.Text = "frmAlquilerConsultorio";
            this.Load += new System.EventHandler(this.frmAlquilerConsultorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicoEsp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxViernes;
        private System.Windows.Forms.CheckBox cbxJueves;
        private System.Windows.Forms.CheckBox cbxMiercoles;
        private System.Windows.Forms.CheckBox cbxMartes;
        private System.Windows.Forms.CheckBox cbxLunes;
        private System.Windows.Forms.CheckBox cbxDiasSemana;
        private System.Windows.Forms.Label lbConsultorio;
        private System.Windows.Forms.Label lbMedico;
        private System.Windows.Forms.Label lbTipoAlquiler;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.ComboBox cboConsultorio;
        private System.Windows.Forms.ComboBox cboJornda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxBusqueda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MonthCalendar mntcAlquiler;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpIni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMedS;
        private System.Windows.Forms.TextBox txtEspS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvMedicoEsp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCosto;
    }
}