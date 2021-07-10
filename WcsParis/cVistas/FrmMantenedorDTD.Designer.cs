namespace WcsParis
{
    partial class FrmMantenedorDTD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenedorDTD));
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtDtd = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtLinea = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Navy;
            this.Label5.Location = new System.Drawing.Point(12, 171);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(106, 19);
            this.Label5.TabIndex = 49;
            this.Label5.Text = "Listado DTD";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsParis.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(464, 650);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 3;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsParis.Properties.Resources.grabar;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(321, 650);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 2;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(12, 200);
            this.DgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.Size = new System.Drawing.Size(580, 442);
            this.DgvDatos.TabIndex = 46;
            this.DgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellDoubleClick);
            this.DgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatos_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Navy;
            this.Label2.Location = new System.Drawing.Point(250, 83);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 29);
            this.Label2.TabIndex = 48;
            this.Label2.Text = "DTD";
            // 
            // TxtDtd
            // 
            this.TxtDtd.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDtd.Location = new System.Drawing.Point(338, 80);
            this.TxtDtd.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDtd.MaxLength = 7;
            this.TxtDtd.Name = "TxtDtd";
            this.TxtDtd.Size = new System.Drawing.Size(131, 35);
            this.TxtDtd.TabIndex = 1;
            this.TxtDtd.Enter += new System.EventHandler(this.TxtDtd_Enter);
            this.TxtDtd.Leave += new System.EventHandler(this.TxtDtd_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Navy;
            this.Label3.Location = new System.Drawing.Point(12, 83);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(76, 29);
            this.Label3.TabIndex = 47;
            this.Label3.Text = "Linea";
            // 
            // TxtLinea
            // 
            this.TxtLinea.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLinea.Location = new System.Drawing.Point(100, 80);
            this.TxtLinea.Margin = new System.Windows.Forms.Padding(4);
            this.TxtLinea.MaxLength = 2;
            this.TxtLinea.Name = "TxtLinea";
            this.TxtLinea.Size = new System.Drawing.Size(131, 35);
            this.TxtLinea.TabIndex = 0;
            this.TxtLinea.Enter += new System.EventHandler(this.TxtLinea_Enter);
            this.TxtLinea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLinea_KeyPress);
            this.TxtLinea.Leave += new System.EventHandler(this.TxtLinea_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(182, 7);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(240, 29);
            this.Label4.TabIndex = 44;
            this.Label4.Text = "MANTENEDOR DTD";
            // 
            // FrmMantenedorDTD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 692);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtDtd);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtLinea);
            this.Controls.Add(this.Label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMantenedorDTD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmMantenedorDTD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtDtd;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtLinea;
        internal System.Windows.Forms.Label Label4;
    }
}