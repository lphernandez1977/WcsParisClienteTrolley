namespace WcsParis
{
    partial class FrmReporteScanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteScanner));
            this.label2 = new System.Windows.Forms.Label();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.Fecha1 = new System.Windows.Forms.DateTimePicker();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Fecha2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(358, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 33);
            this.label2.TabIndex = 38;
            this.label2.Text = "REPORTE SCANNER";
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(50, 150);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowTemplate.Height = 24;
            this.DgvDatos.Size = new System.Drawing.Size(950, 500);
            this.DgvDatos.TabIndex = 39;
            this.DgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatos_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(50, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 33);
            this.label1.TabIndex = 40;
            this.label1.Text = "Fecha Inicio";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Navy;
            this.BtnGuardar.Image = global::WcsParis.Properties.Resources.excel;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(726, 662);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Exportar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsParis.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(865, 662);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 4;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // Fecha1
            // 
            this.Fecha1.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha1.CalendarForeColor = System.Drawing.Color.Navy;
            this.Fecha1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha1.Location = new System.Drawing.Point(228, 103);
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.Size = new System.Drawing.Size(200, 27);
            this.Fecha1.TabIndex = 0;
            this.Fecha1.Value = new System.DateTime(2019, 7, 7, 0, 0, 0, 0);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.Navy;
            this.BtnBuscar.Image = global::WcsParis.Properties.Resources.buscar;
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBuscar.Location = new System.Drawing.Point(865, 98);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(135, 36);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(439, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 33);
            this.label3.TabIndex = 46;
            this.label3.Text = "Fecha Fin";
            // 
            // Fecha2
            // 
            this.Fecha2.CalendarFont = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha2.CalendarForeColor = System.Drawing.Color.Navy;
            this.Fecha2.CalendarTitleForeColor = System.Drawing.Color.Navy;
            this.Fecha2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Fecha2.Location = new System.Drawing.Point(580, 103);
            this.Fecha2.Name = "Fecha2";
            this.Fecha2.Size = new System.Drawing.Size(200, 27);
            this.Fecha2.TabIndex = 1;
            this.Fecha2.Value = new System.DateTime(2019, 7, 7, 0, 0, 0, 0);
            // 
            // FrmReporteScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 718);
            this.Controls.Add(this.Fecha2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.Fecha1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReporteScanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmReporteScanner_FormClosed);
            this.Load += new System.EventHandler(this.FrmReporteScanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DateTimePicker Fecha1;
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker Fecha2;
    }
}