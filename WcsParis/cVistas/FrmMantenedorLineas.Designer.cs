namespace WcsParis
{
    partial class FrmMantenedorLineas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenedorLineas));
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.CboEstado = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TxtSalida = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Navy;
            this.Label5.Location = new System.Drawing.Point(11, 258);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(154, 19);
            this.Label5.TabIndex = 46;
            this.Label5.Text = "Listado De Salidas";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsParis.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(464, 626);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 45;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsParis.Properties.Resources.grabar;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(321, 626);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 44;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AllowUserToDeleteRows = false;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(15, 281);
            this.DgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatos.MultiSelect = false;
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.ReadOnly = true;
            this.DgvDatos.Size = new System.Drawing.Size(580, 309);
            this.DgvDatos.TabIndex = 43;
            this.DgvDatos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellContentDoubleClick);
            this.DgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellDoubleClick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CboEstado);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TxtSalida);
            this.GroupBox1.Location = new System.Drawing.Point(15, 50);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(584, 152);
            this.GroupBox1.TabIndex = 42;
            this.GroupBox1.TabStop = false;
            // 
            // CboEstado
            // 
            this.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstado.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEstado.FormattingEnabled = true;
            this.CboEstado.Location = new System.Drawing.Point(191, 92);
            this.CboEstado.Margin = new System.Windows.Forms.Padding(4);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Size = new System.Drawing.Size(328, 37);
            this.CboEstado.TabIndex = 4;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Navy;
            this.Label2.Location = new System.Drawing.Point(24, 95);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(93, 29);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Estado";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Navy;
            this.Label1.Location = new System.Drawing.Point(24, 30);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(118, 29);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "N° Salida";
            // 
            // TxtSalida
            // 
            this.TxtSalida.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSalida.Location = new System.Drawing.Point(191, 30);
            this.TxtSalida.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSalida.MaxLength = 3;
            this.TxtSalida.Name = "TxtSalida";
            this.TxtSalida.Size = new System.Drawing.Size(88, 35);
            this.TxtSalida.TabIndex = 0;
            this.TxtSalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumTienda_KeyPress);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(160, 13);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(296, 29);
            this.Label4.TabIndex = 47;
            this.Label4.Text = "MANTENEDOR SALIDAS";
            // 
            // FrmMantenedorLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 692);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMantenedorLineas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmMantenedorLineas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TxtSalida;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox CboEstado;
    }
}