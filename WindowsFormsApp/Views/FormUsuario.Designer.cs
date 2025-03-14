namespace WindowsFormsApp.Views
{
    partial class FormUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUbicacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.groupBoxUbicacion = new System.Windows.Forms.GroupBox();
            this.btnCancelarUbicacion = new System.Windows.Forms.Button();
            this.lblIdUbicacion = new System.Windows.Forms.Label();
            this.dataGridViewU = new System.Windows.Forms.DataGridView();
            this.btnActualizarUbicacion = new System.Windows.Forms.Button();
            this.btnGuardarUbicacion = new System.Windows.Forms.Button();
            this.btnNuevoUbicacion = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonAgregarUbicacion = new System.Windows.Forms.RadioButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxUbicacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewU)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Completo";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Location = new System.Drawing.Point(192, 3);
            this.txtNombreCompleto.MaxLength = 100;
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(287, 31);
            this.txtNombreCompleto.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Ingreso";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(192, 40);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(178, 31);
            this.dtpFechaIngreso.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(192, 77);
            this.txtUsuario.MaxLength = 100;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(287, 31);
            this.txtUsuario.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contraseña";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(192, 114);
            this.txtPwd.MaxLength = 100;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(287, 31);
            this.txtPwd.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ubicación";
            // 
            // cmbUbicacion
            // 
            this.cmbUbicacion.DisplayMember = "IdUbicacion";
            this.cmbUbicacion.FormattingEnabled = true;
            this.cmbUbicacion.Location = new System.Drawing.Point(192, 151);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Size = new System.Drawing.Size(287, 31);
            this.cmbUbicacion.TabIndex = 4;
            this.cmbUbicacion.ValueMember = "IdUbicacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Items.AddRange(new object[] {
            "Administrador",
            "Vendedor"});
            this.cmbRol.Location = new System.Drawing.Point(192, 188);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(287, 31);
            this.cmbRol.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbRol, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPwd, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreCompleto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbUbicacion, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaIngreso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 222);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = true;
            this.btnNuevo.Location = new System.Drawing.Point(500, 13);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(94, 33);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = true;
            this.btnGuardar.Location = new System.Drawing.Point(500, 53);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 33);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.Location = new System.Drawing.Point(500, 201);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 33);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.AutoSize = true;
            this.btnActualizar.Location = new System.Drawing.Point(500, 113);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 33);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(12, 240);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 359);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.AutoSize = true;
            this.lblIdEmpleado.Location = new System.Drawing.Point(501, 160);
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(68, 23);
            this.lblIdEmpleado.TabIndex = 17;
            this.lblIdEmpleado.Text = "label7";
            this.lblIdEmpleado.Visible = false;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(566, 160);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(68, 23);
            this.lblIdUsuario.TabIndex = 18;
            this.lblIdUsuario.Text = "label8";
            this.lblIdUsuario.Visible = false;
            // 
            // groupBoxUbicacion
            // 
            this.groupBoxUbicacion.Controls.Add(this.btnCancelarUbicacion);
            this.groupBoxUbicacion.Controls.Add(this.lblIdUbicacion);
            this.groupBoxUbicacion.Controls.Add(this.dataGridViewU);
            this.groupBoxUbicacion.Controls.Add(this.btnActualizarUbicacion);
            this.groupBoxUbicacion.Controls.Add(this.btnGuardarUbicacion);
            this.groupBoxUbicacion.Controls.Add(this.btnNuevoUbicacion);
            this.groupBoxUbicacion.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxUbicacion.Location = new System.Drawing.Point(681, 41);
            this.groupBoxUbicacion.Name = "groupBoxUbicacion";
            this.groupBoxUbicacion.Size = new System.Drawing.Size(360, 367);
            this.groupBoxUbicacion.TabIndex = 19;
            this.groupBoxUbicacion.TabStop = false;
            this.groupBoxUbicacion.Text = "Gestionar Ubicaciones";
            this.groupBoxUbicacion.Visible = false;
            // 
            // btnCancelarUbicacion
            // 
            this.btnCancelarUbicacion.AutoSize = true;
            this.btnCancelarUbicacion.Location = new System.Drawing.Point(252, 324);
            this.btnCancelarUbicacion.Name = "btnCancelarUbicacion";
            this.btnCancelarUbicacion.Size = new System.Drawing.Size(102, 33);
            this.btnCancelarUbicacion.TabIndex = 33;
            this.btnCancelarUbicacion.Text = "Cancelar";
            this.btnCancelarUbicacion.UseVisualStyleBackColor = true;
            this.btnCancelarUbicacion.Click += new System.EventHandler(this.btnCancelarUbicacion_Click);
            // 
            // lblIdUbicacion
            // 
            this.lblIdUbicacion.AutoSize = true;
            this.lblIdUbicacion.Location = new System.Drawing.Point(9, 324);
            this.lblIdUbicacion.Name = "lblIdUbicacion";
            this.lblIdUbicacion.Size = new System.Drawing.Size(68, 23);
            this.lblIdUbicacion.TabIndex = 32;
            this.lblIdUbicacion.Text = "label7";
            this.lblIdUbicacion.Visible = false;
            // 
            // dataGridViewU
            // 
            this.dataGridViewU.AllowUserToAddRows = false;
            this.dataGridViewU.AllowUserToDeleteRows = false;
            this.dataGridViewU.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewU.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewU.Location = new System.Drawing.Point(6, 125);
            this.dataGridViewU.MultiSelect = false;
            this.dataGridViewU.Name = "dataGridViewU";
            this.dataGridViewU.ReadOnly = true;
            this.dataGridViewU.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewU.ShowEditingIcon = false;
            this.dataGridViewU.Size = new System.Drawing.Size(348, 196);
            this.dataGridViewU.TabIndex = 31;
            this.dataGridViewU.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewU_CellClick);
            // 
            // btnActualizarUbicacion
            // 
            this.btnActualizarUbicacion.AutoSize = true;
            this.btnActualizarUbicacion.Location = new System.Drawing.Point(118, 324);
            this.btnActualizarUbicacion.Name = "btnActualizarUbicacion";
            this.btnActualizarUbicacion.Size = new System.Drawing.Size(114, 33);
            this.btnActualizarUbicacion.TabIndex = 29;
            this.btnActualizarUbicacion.Text = "Actualizar";
            this.btnActualizarUbicacion.UseVisualStyleBackColor = true;
            this.btnActualizarUbicacion.Click += new System.EventHandler(this.btnActualizarUbicacion_Click);
            // 
            // btnGuardarUbicacion
            // 
            this.btnGuardarUbicacion.AutoSize = true;
            this.btnGuardarUbicacion.Location = new System.Drawing.Point(118, 72);
            this.btnGuardarUbicacion.Name = "btnGuardarUbicacion";
            this.btnGuardarUbicacion.Size = new System.Drawing.Size(97, 33);
            this.btnGuardarUbicacion.TabIndex = 26;
            this.btnGuardarUbicacion.Text = "Guardar";
            this.btnGuardarUbicacion.UseVisualStyleBackColor = true;
            this.btnGuardarUbicacion.Click += new System.EventHandler(this.btnGuardarUbicacion_Click);
            // 
            // btnNuevoUbicacion
            // 
            this.btnNuevoUbicacion.AutoSize = true;
            this.btnNuevoUbicacion.Location = new System.Drawing.Point(6, 72);
            this.btnNuevoUbicacion.Name = "btnNuevoUbicacion";
            this.btnNuevoUbicacion.Size = new System.Drawing.Size(94, 33);
            this.btnNuevoUbicacion.TabIndex = 28;
            this.btnNuevoUbicacion.Text = "Nuevo";
            this.btnNuevoUbicacion.UseVisualStyleBackColor = true;
            this.btnNuevoUbicacion.Click += new System.EventHandler(this.btnNuevoUbicacion_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtUbicacion, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 29);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(335, 37);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(112, 3);
            this.txtUbicacion.MaxLength = 25;
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(220, 31);
            this.txtUbicacion.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ubicacion";
            // 
            // radioButtonAgregarUbicacion
            // 
            this.radioButtonAgregarUbicacion.AutoSize = true;
            this.radioButtonAgregarUbicacion.Location = new System.Drawing.Point(681, 8);
            this.radioButtonAgregarUbicacion.Name = "radioButtonAgregarUbicacion";
            this.radioButtonAgregarUbicacion.Size = new System.Drawing.Size(203, 27);
            this.radioButtonAgregarUbicacion.TabIndex = 20;
            this.radioButtonAgregarUbicacion.Text = "Agregar Ubicación";
            this.radioButtonAgregarUbicacion.UseVisualStyleBackColor = true;
            this.radioButtonAgregarUbicacion.CheckedChanged += new System.EventHandler(this.radioButtonAgregarUbicacion_CheckedChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(1040, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(37, 35);
            this.btnSalir.TabIndex = 21;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.radioButtonAgregarUbicacion);
            this.Controls.Add(this.groupBoxUbicacion);
            this.Controls.Add(this.lblIdUsuario);
            this.Controls.Add(this.lblIdEmpleado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxUbicacion.ResumeLayout(false);
            this.groupBoxUbicacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewU)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUbicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.GroupBox groupBoxUbicacion;
        private System.Windows.Forms.Label lblIdUbicacion;
        private System.Windows.Forms.DataGridView dataGridViewU;
        private System.Windows.Forms.Button btnActualizarUbicacion;
        private System.Windows.Forms.Button btnGuardarUbicacion;
        private System.Windows.Forms.Button btnNuevoUbicacion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonAgregarUbicacion;
        private System.Windows.Forms.Button btnCancelarUbicacion;
        private System.Windows.Forms.Button btnSalir;
    }
}