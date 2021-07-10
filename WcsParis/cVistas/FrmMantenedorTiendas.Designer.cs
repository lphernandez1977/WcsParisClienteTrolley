namespace WcsParis
{
    partial class FrmMantenedorTiendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMantenedorTiendas));
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtNomCortoTienda = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtNomTienda = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TxtNumTienda = new System.Windows.Forms.TextBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AllowUserToDeleteRows = false;
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(13, 293);
            this.DgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatos.MultiSelect = false;
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.ReadOnly = true;
            this.DgvDatos.Size = new System.Drawing.Size(580, 309);
            this.DgvDatos.TabIndex = 9;
            this.DgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellDoubleClick);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(155, 7);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(296, 29);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "MANTENEDOR TIENDAS";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.TxtNomCortoTienda);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.TxtNomTienda);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.TxtNumTienda);
            this.GroupBox1.Location = new System.Drawing.Point(13, 43);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(584, 197);
            this.GroupBox1.TabIndex = 7;
            this.GroupBox1.TabStop = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Navy;
            this.Label3.Location = new System.Drawing.Point(24, 147);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 29);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "Alias";
            // 
            // TxtNomCortoTienda
            // 
            this.TxtNomCortoTienda.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomCortoTienda.Location = new System.Drawing.Point(191, 148);
            this.TxtNomCortoTienda.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNomCortoTienda.MaxLength = 4;
            this.TxtNomCortoTienda.Name = "TxtNomCortoTienda";
            this.TxtNomCortoTienda.Size = new System.Drawing.Size(88, 35);
            this.TxtNomCortoTienda.TabIndex = 2;
            this.TxtNomCortoTienda.Enter += new System.EventHandler(this.TxtNomCortoTienda_Enter);
            this.TxtNomCortoTienda.Leave += new System.EventHandler(this.TxtNomCortoTienda_Leave);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Navy;
            this.Label2.Location = new System.Drawing.Point(24, 98);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(151, 29);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Nom Tienda";
            // 
            // TxtNomTienda
            // 
            this.TxtNomTienda.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomTienda.Location = new System.Drawing.Point(191, 92);
            this.TxtNomTienda.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNomTienda.MaxLength = 20;
            this.TxtNomTienda.Name = "TxtNomTienda";
            this.TxtNomTienda.Size = new System.Drawing.Size(385, 35);
            this.TxtNomTienda.TabIndex = 1;
            this.TxtNomTienda.Enter += new System.EventHandler(this.TxtNomTienda_Enter);
            this.TxtNomTienda.Leave += new System.EventHandler(this.TxtNomTienda_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Navy;
            this.Label1.Location = new System.Drawing.Point(24, 33);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(125, 29);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "N° Tienda";
            // 
            // TxtNumTienda
            // 
            this.TxtNumTienda.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumTienda.Location = new System.Drawing.Point(191, 33);
            this.TxtNumTienda.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNumTienda.MaxLength = 3;
            this.TxtNumTienda.Name = "TxtNumTienda";
            this.TxtNumTienda.Size = new System.Drawing.Size(88, 35);
            this.TxtNumTienda.TabIndex = 0;
            this.TxtNumTienda.Enter += new System.EventHandler(this.TxtNumTienda_Enter);
            this.TxtNumTienda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumTienda_KeyPress);
            this.TxtNumTienda.Leave += new System.EventHandler(this.TxtNumTienda_Leave);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsParis.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(462, 638);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 11;
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
            this.BtnGuardar.Location = new System.Drawing.Point(319, 638);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Navy;
            this.Label5.Location = new System.Drawing.Point(9, 270);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(159, 19);
            this.Label5.TabIndex = 41;
            this.Label5.Text = "Listado De Tiendas";
            // 
            // FrmMantenedorTiendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 692);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMantenedorTiendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmMantenedorTiendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtNomCortoTienda;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtNomTienda;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TxtNumTienda;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        internal System.Windows.Forms.Label Label5;
    }
}