namespace FSConsultorio2017
{
    partial class frmEditarTurnos
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
            this.cboPresente = new System.Windows.Forms.ComboBox();
            this.lbPresente = new System.Windows.Forms.Label();
            this.txtArancel = new System.Windows.Forms.TextBox();
            this.cboCobro = new System.Windows.Forms.ComboBox();
            this.lbCobro = new System.Windows.Forms.Label();
            this.lbArancel = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPresente
            // 
            this.cboPresente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresente.FormattingEnabled = true;
            this.cboPresente.Location = new System.Drawing.Point(178, 30);
            this.cboPresente.Name = "cboPresente";
            this.cboPresente.Size = new System.Drawing.Size(220, 21);
            this.cboPresente.TabIndex = 17;
            // 
            // lbPresente
            // 
            this.lbPresente.AutoSize = true;
            this.lbPresente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPresente.Location = new System.Drawing.Point(26, 32);
            this.lbPresente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPresente.Name = "lbPresente";
            this.lbPresente.Size = new System.Drawing.Size(62, 19);
            this.lbPresente.TabIndex = 16;
            this.lbPresente.Text = "Presente";
            // 
            // txtArancel
            // 
            this.txtArancel.Location = new System.Drawing.Point(178, 135);
            this.txtArancel.Name = "txtArancel";
            this.txtArancel.Size = new System.Drawing.Size(220, 20);
            this.txtArancel.TabIndex = 13;
            // 
            // cboCobro
            // 
            this.cboCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCobro.FormattingEnabled = true;
            this.cboCobro.Location = new System.Drawing.Point(178, 81);
            this.cboCobro.Name = "cboCobro";
            this.cboCobro.Size = new System.Drawing.Size(220, 21);
            this.cboCobro.TabIndex = 12;
            // 
            // lbCobro
            // 
            this.lbCobro.AutoSize = true;
            this.lbCobro.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCobro.Location = new System.Drawing.Point(26, 83);
            this.lbCobro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCobro.Name = "lbCobro";
            this.lbCobro.Size = new System.Drawing.Size(117, 19);
            this.lbCobro.TabIndex = 11;
            this.lbCobro.Text = "Cobro de arancel";
            // 
            // lbArancel
            // 
            this.lbArancel.AutoSize = true;
            this.lbArancel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbArancel.Location = new System.Drawing.Point(26, 137);
            this.lbArancel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbArancel.Name = "lbArancel";
            this.lbArancel.Size = new System.Drawing.Size(118, 19);
            this.lbArancel.TabIndex = 10;
            this.lbArancel.Text = "Valor del arancel";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::FSConsultorio2017.Properties.Resources._006_cancelar;
            this.btnCancelar.Location = new System.Drawing.Point(250, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 57);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::FSConsultorio2017.Properties.Resources._008_disquete_1;
            this.btnGuardar.Location = new System.Drawing.Point(69, 215);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 57);
            this.btnGuardar.TabIndex = 18;
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
            // frmEditarTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 289);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboPresente);
            this.Controls.Add(this.lbPresente);
            this.Controls.Add(this.txtArancel);
            this.Controls.Add(this.cboCobro);
            this.Controls.Add(this.lbCobro);
            this.Controls.Add(this.lbArancel);
            this.Name = "frmEditarTurnos";
            this.Text = "frmEditarTurnos";
            this.Load += new System.EventHandler(this.frmEditarTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPresente;
        private System.Windows.Forms.Label lbPresente;
        private System.Windows.Forms.TextBox txtArancel;
        private System.Windows.Forms.ComboBox cboCobro;
        private System.Windows.Forms.Label lbCobro;
        private System.Windows.Forms.Label lbArancel;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}