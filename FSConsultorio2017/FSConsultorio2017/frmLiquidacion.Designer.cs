namespace FSConsultorio2017
{
    partial class frmLiquidacion
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
            this.txtRecaudadoObraSocial = new System.Windows.Forms.TextBox();
            this.lbRecaudacion = new System.Windows.Forms.Label();
            this.txtAlquiler = new System.Windows.Forms.TextBox();
            this.lbAlquiler = new System.Windows.Forms.Label();
            this.txtLiquidacion = new System.Windows.Forms.TextBox();
            this.lbLiquidar = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLiquidacion);
            this.groupBox1.Controls.Add(this.lbLiquidar);
            this.groupBox1.Controls.Add(this.txtAlquiler);
            this.groupBox1.Controls.Add(this.lbAlquiler);
            this.groupBox1.Controls.Add(this.txtRecaudadoObraSocial);
            this.groupBox1.Controls.Add(this.lbRecaudacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // txtRecaudadoObraSocial
            // 
            this.txtRecaudadoObraSocial.Enabled = false;
            this.txtRecaudadoObraSocial.Location = new System.Drawing.Point(134, 31);
            this.txtRecaudadoObraSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txtRecaudadoObraSocial.Name = "txtRecaudadoObraSocial";
            this.txtRecaudadoObraSocial.Size = new System.Drawing.Size(106, 20);
            this.txtRecaudadoObraSocial.TabIndex = 11;
            // 
            // lbRecaudacion
            // 
            this.lbRecaudacion.AutoSize = true;
            this.lbRecaudacion.Location = new System.Drawing.Point(14, 34);
            this.lbRecaudacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRecaudacion.Name = "lbRecaudacion";
            this.lbRecaudacion.Size = new System.Drawing.Size(71, 13);
            this.lbRecaudacion.TabIndex = 10;
            this.lbRecaudacion.Text = "Recaudacion";
            // 
            // txtAlquiler
            // 
            this.txtAlquiler.Enabled = false;
            this.txtAlquiler.Location = new System.Drawing.Point(134, 73);
            this.txtAlquiler.Margin = new System.Windows.Forms.Padding(4);
            this.txtAlquiler.Name = "txtAlquiler";
            this.txtAlquiler.Size = new System.Drawing.Size(106, 20);
            this.txtAlquiler.TabIndex = 14;
            this.txtAlquiler.TabStop = false;
            // 
            // lbAlquiler
            // 
            this.lbAlquiler.AutoSize = true;
            this.lbAlquiler.Location = new System.Drawing.Point(12, 76);
            this.lbAlquiler.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlquiler.Name = "lbAlquiler";
            this.lbAlquiler.Size = new System.Drawing.Size(84, 13);
            this.lbAlquiler.TabIndex = 13;
            this.lbAlquiler.Text = "Valor del alquiler";
            // 
            // txtLiquidacion
            // 
            this.txtLiquidacion.Enabled = false;
            this.txtLiquidacion.Location = new System.Drawing.Point(134, 122);
            this.txtLiquidacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtLiquidacion.Name = "txtLiquidacion";
            this.txtLiquidacion.Size = new System.Drawing.Size(106, 20);
            this.txtLiquidacion.TabIndex = 16;
            // 
            // lbLiquidar
            // 
            this.lbLiquidar.AutoSize = true;
            this.lbLiquidar.Location = new System.Drawing.Point(19, 125);
            this.lbLiquidar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLiquidar.Name = "lbLiquidar";
            this.lbLiquidar.Size = new System.Drawing.Size(44, 13);
            this.lbLiquidar.TabIndex = 15;
            this.lbLiquidar.Text = "Liquidar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::FSConsultorio2017.Properties.Resources._006_cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(208, 217);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 57);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::FSConsultorio2017.Properties.Resources._008_disquete_1;
            this.btnGuardar.Location = new System.Drawing.Point(27, 217);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 57);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmLiquidacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 309);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLiquidacion";
            this.Text = "frmLiquidacion";
            this.Load += new System.EventHandler(this.frmLiquidacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLiquidacion;
        private System.Windows.Forms.Label lbLiquidar;
        private System.Windows.Forms.TextBox txtAlquiler;
        private System.Windows.Forms.Label lbAlquiler;
        private System.Windows.Forms.TextBox txtRecaudadoObraSocial;
        private System.Windows.Forms.Label lbRecaudacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}