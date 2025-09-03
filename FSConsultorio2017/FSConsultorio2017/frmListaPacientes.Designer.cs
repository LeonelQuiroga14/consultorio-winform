namespace FSConsultorio2017
{
    partial class frmListaPacientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cmnNombreApe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnGenero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnGs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnDNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTelefonofijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnTelefonoMovil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnObraSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtFiltrado = new System.Windows.Forms.RadioButton();
            this.rbtCompleta = new System.Windows.Forms.RadioButton();
            this.btnlistaCompleta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 268);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgvDatos
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnNombreApe,
            this.cmnGenero,
            this.cmnGs,
            this.cmnDNI,
            this.cmnTelefonofijo,
            this.cmnTelefonoMovil,
            this.cmnObraSocial,
            this.cmnPlan});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(600, 268);
            this.dgvDatos.TabIndex = 11;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // cmnNombreApe
            // 
            this.cmnNombreApe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Lavender;
            this.cmnNombreApe.DefaultCellStyle = dataGridViewCellStyle18;
            this.cmnNombreApe.HeaderText = "Nombre y Apellido";
            this.cmnNombreApe.Name = "cmnNombreApe";
            // 
            // cmnGenero
            // 
            this.cmnGenero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnGenero.HeaderText = "Genero";
            this.cmnGenero.Name = "cmnGenero";
            // 
            // cmnGs
            // 
            this.cmnGs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnGs.HeaderText = "Grupo Sanguineo";
            this.cmnGs.Name = "cmnGs";
            // 
            // cmnDNI
            // 
            this.cmnDNI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnDNI.HeaderText = "Nro. Documento";
            this.cmnDNI.Name = "cmnDNI";
            // 
            // cmnTelefonofijo
            // 
            this.cmnTelefonofijo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Lavender;
            this.cmnTelefonofijo.DefaultCellStyle = dataGridViewCellStyle19;
            this.cmnTelefonofijo.HeaderText = "TelefonoFijo";
            this.cmnTelefonofijo.Name = "cmnTelefonofijo";
            // 
            // cmnTelefonoMovil
            // 
            this.cmnTelefonoMovil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnTelefonoMovil.HeaderText = "Telefono Movil";
            this.cmnTelefonoMovil.Name = "cmnTelefonoMovil";
            // 
            // cmnObraSocial
            // 
            this.cmnObraSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Lavender;
            this.cmnObraSocial.DefaultCellStyle = dataGridViewCellStyle20;
            this.cmnObraSocial.HeaderText = "Obra Social";
            this.cmnObraSocial.Name = "cmnObraSocial";
            // 
            // cmnPlan
            // 
            this.cmnPlan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnPlan.HeaderText = "Plan";
            this.cmnPlan.Name = "cmnPlan";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnlistaCompleta);
            this.splitContainer1.Panel2.Controls.Add(this.rbtCompleta);
            this.splitContainer1.Panel2.Controls.Add(this.rbtFiltrado);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.btnAñadir);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(600, 403);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(544, 12);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(44, 23);
            this.btnAñadir.TabIndex = 1;
            this.btnAñadir.Text = ">>";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(513, 96);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Paciente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese DNI del paciente :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtFiltrado
            // 
            this.rbtFiltrado.AutoSize = true;
            this.rbtFiltrado.Checked = true;
            this.rbtFiltrado.Location = new System.Drawing.Point(30, 18);
            this.rbtFiltrado.Name = "rbtFiltrado";
            this.rbtFiltrado.Size = new System.Drawing.Size(90, 17);
            this.rbtFiltrado.TabIndex = 4;
            this.rbtFiltrado.TabStop = true;
            this.rbtFiltrado.Text = "Filtrar por DNI";
            this.rbtFiltrado.UseVisualStyleBackColor = true;
            this.rbtFiltrado.CheckedChanged += new System.EventHandler(this.rbtFiltrado_CheckedChanged);
            // 
            // rbtCompleta
            // 
            this.rbtCompleta.AutoSize = true;
            this.rbtCompleta.Location = new System.Drawing.Point(191, 18);
            this.rbtCompleta.Name = "rbtCompleta";
            this.rbtCompleta.Size = new System.Drawing.Size(93, 17);
            this.rbtCompleta.TabIndex = 5;
            this.rbtCompleta.Text = "Lista completa";
            this.rbtCompleta.UseVisualStyleBackColor = true;
            this.rbtCompleta.CheckedChanged += new System.EventHandler(this.rbtCompleta_CheckedChanged);
            // 
            // btnlistaCompleta
            // 
            this.btnlistaCompleta.Location = new System.Drawing.Point(339, 15);
            this.btnlistaCompleta.Name = "btnlistaCompleta";
            this.btnlistaCompleta.Size = new System.Drawing.Size(59, 22);
            this.btnlistaCompleta.TabIndex = 6;
            this.btnlistaCompleta.Text = "Buscar";
            this.btnlistaCompleta.UseVisualStyleBackColor = true;
            this.btnlistaCompleta.Click += new System.EventHandler(this.btnlistaCompleta_Click);
            // 
            // frmListaPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 403);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmListaPacientes";
            this.Text = "frmListaPacientes";
            this.Load += new System.EventHandler(this.frmListaPacientes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnNombreApe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnGenero;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnGs;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnDNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTelefonofijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnTelefonoMovil;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnObraSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPlan;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnlistaCompleta;
        private System.Windows.Forms.RadioButton rbtCompleta;
        private System.Windows.Forms.RadioButton rbtFiltrado;
    }
}