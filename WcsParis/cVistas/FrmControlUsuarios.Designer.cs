namespace WcsParis
{
    partial class FrmControlUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmControlUsuarios));
            this.Label6 = new System.Windows.Forms.Label();
            this.CboEstado = new System.Windows.Forms.ComboBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.CboNivel = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.Navy;
            this.Label6.Location = new System.Drawing.Point(13, 243);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(93, 29);
            this.Label6.TabIndex = 41;
            this.Label6.Text = "Estado";
            // 
            // CboEstado
            // 
            this.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstado.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEstado.FormattingEnabled = true;
            this.CboEstado.Location = new System.Drawing.Point(270, 239);
            this.CboEstado.Margin = new System.Windows.Forms.Padding(4);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Size = new System.Drawing.Size(328, 37);
            this.CboEstado.TabIndex = 4;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Navy;
            this.Label5.Location = new System.Drawing.Point(13, 307);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(168, 19);
            this.Label5.TabIndex = 40;
            this.Label5.Text = "Listado De Usuarios";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Navy;
            this.BtnSalir.Image = global::WcsParis.Properties.Resources.salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(465, 650);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(135, 36);
            this.BtnSalir.TabIndex = 35;
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
            this.BtnGuardar.Location = new System.Drawing.Point(322, 650);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(135, 36);
            this.BtnGuardar.TabIndex = 33;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // DgvDatos
            // 
            this.DgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatos.Location = new System.Drawing.Point(13, 333);
            this.DgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.Size = new System.Drawing.Size(580, 309);
            this.DgvDatos.TabIndex = 36;
            this.DgvDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellDoubleClick);
            this.DgvDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvDatos_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Navy;
            this.Label2.Location = new System.Drawing.Point(13, 138);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(144, 29);
            this.Label2.TabIndex = 39;
            this.Label2.Text = "Contraseña";
            // 
            // TxtPass
            // 
            this.TxtPass.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPass.Location = new System.Drawing.Point(270, 136);
            this.TxtPass.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPass.MaxLength = 20;
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.PasswordChar = '*';
            this.TxtPass.Size = new System.Drawing.Size(328, 35);
            this.TxtPass.TabIndex = 2;
            this.TxtPass.Enter += new System.EventHandler(this.TxtPass_Enter);
            this.TxtPass.Leave += new System.EventHandler(this.TxtPass_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Navy;
            this.Label1.Location = new System.Drawing.Point(13, 191);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 29);
            this.Label1.TabIndex = 38;
            this.Label1.Text = "Nivel";
            // 
            // CboNivel
            // 
            this.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboNivel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboNivel.FormattingEnabled = true;
            this.CboNivel.Location = new System.Drawing.Point(270, 187);
            this.CboNivel.Margin = new System.Windows.Forms.Padding(4);
            this.CboNivel.Name = "CboNivel";
            this.CboNivel.Size = new System.Drawing.Size(328, 37);
            this.CboNivel.TabIndex = 3;
            this.CboNivel.Enter += new System.EventHandler(this.CboNivel_Enter);
            this.CboNivel.Leave += new System.EventHandler(this.CboNivel_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Navy;
            this.Label3.Location = new System.Drawing.Point(13, 83);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(102, 29);
            this.Label3.TabIndex = 37;
            this.Label3.Text = "Usuario";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(270, 80);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.MaxLength = 20;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(328, 35);
            this.TxtUsuario.TabIndex = 1;
            this.TxtUsuario.Enter += new System.EventHandler(this.TxtUsuario_Enter);
            this.TxtUsuario.Leave += new System.EventHandler(this.TxtUsuario_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(125, 6);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(356, 29);
            this.Label4.TabIndex = 34;
            this.Label4.Text = "MANTENEDOR DE USUARIOS";
            // 
            // FrmControlUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 692);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.CboEstado);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.DgvDatos);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CboNivel);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.Label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmControlUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmControlUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox CboEstado;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button BtnSalir;
        internal System.Windows.Forms.Button BtnGuardar;
        internal System.Windows.Forms.DataGridView DgvDatos;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtPass;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox CboNivel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtUsuario;
        internal System.Windows.Forms.Label Label4;
    }
}