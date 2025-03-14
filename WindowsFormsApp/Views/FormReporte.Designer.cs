namespace WindowsFormsApp.Views
{
    partial class FormReporte
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCargarVentasFecha = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageReporteBuscarVentasPorCliente = new System.Windows.Forms.TabPage();
            this.btnVentasCliente = new System.Windows.Forms.Button();
            this.txtBuscadorVentasCliente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageReporteBuscarVentasPorCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(1038, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(37, 35);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCargarVentasFecha
            // 
            this.btnCargarVentasFecha.AutoSize = true;
            this.btnCargarVentasFecha.BackColor = System.Drawing.Color.Cyan;
            this.btnCargarVentasFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarVentasFecha.Location = new System.Drawing.Point(26, 202);
            this.btnCargarVentasFecha.Name = "btnCargarVentasFecha";
            this.btnCargarVentasFecha.Size = new System.Drawing.Size(147, 35);
            this.btnCargarVentasFecha.TabIndex = 26;
            this.btnCargarVentasFecha.Text = "Cargar Datos";
            this.btnCargarVentasFecha.UseVisualStyleBackColor = false;
            this.btnCargarVentasFecha.Click += new System.EventHandler(this.btnCargarVentasFecha_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.AutoSize = true;
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Location = new System.Drawing.Point(954, 202);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(118, 35);
            this.btnExportar.TabIndex = 25;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Inicial";
            // 
            // dtpInicial
            // 
            this.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicial.Location = new System.Drawing.Point(12, 69);
            this.dtpInicial.Name = "dtpInicial";
            this.dtpInicial.Size = new System.Drawing.Size(178, 31);
            this.dtpInicial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fecha Final";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(12, 155);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(178, 31);
            this.dtpFinal.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Ventas entre Fechas";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageReporteBuscarVentasPorCliente);
            this.tabControl1.Location = new System.Drawing.Point(213, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 228);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPageReporteBuscarVentasPorCliente
            // 
            this.tabPageReporteBuscarVentasPorCliente.Controls.Add(this.btnVentasCliente);
            this.tabPageReporteBuscarVentasPorCliente.Controls.Add(this.txtBuscadorVentasCliente);
            this.tabPageReporteBuscarVentasPorCliente.Controls.Add(this.label4);
            this.tabPageReporteBuscarVentasPorCliente.Location = new System.Drawing.Point(4, 32);
            this.tabPageReporteBuscarVentasPorCliente.Name = "tabPageReporteBuscarVentasPorCliente";
            this.tabPageReporteBuscarVentasPorCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReporteBuscarVentasPorCliente.Size = new System.Drawing.Size(727, 192);
            this.tabPageReporteBuscarVentasPorCliente.TabIndex = 0;
            this.tabPageReporteBuscarVentasPorCliente.Text = "Ventas por Cliente";
            this.tabPageReporteBuscarVentasPorCliente.UseVisualStyleBackColor = true;
            // 
            // btnVentasCliente
            // 
            this.btnVentasCliente.AutoSize = true;
            this.btnVentasCliente.BackColor = System.Drawing.Color.Cyan;
            this.btnVentasCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasCliente.Location = new System.Drawing.Point(10, 96);
            this.btnVentasCliente.Name = "btnVentasCliente";
            this.btnVentasCliente.Size = new System.Drawing.Size(147, 35);
            this.btnVentasCliente.TabIndex = 37;
            this.btnVentasCliente.Text = "Cargar Datos";
            this.btnVentasCliente.UseVisualStyleBackColor = false;
            this.btnVentasCliente.Click += new System.EventHandler(this.btnVentasCliente_Click);
            // 
            // txtBuscadorVentasCliente
            // 
            this.txtBuscadorVentasCliente.Location = new System.Drawing.Point(6, 38);
            this.txtBuscadorVentasCliente.Name = "txtBuscadorVentasCliente";
            this.txtBuscadorVentasCliente.Size = new System.Drawing.Size(307, 31);
            this.txtBuscadorVentasCliente.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cliente / Destino / SAP";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(10, 243);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 359);
            this.dataGridView1.TabIndex = 27;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFinal);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCargarVentasFecha);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpInicial);
            this.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MinimizeBox = false;
            this.Name = "FormReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.tabControl1.ResumeLayout(false);
            this.tabPageReporteBuscarVentasPorCliente.ResumeLayout(false);
            this.tabPageReporteBuscarVentasPorCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCargarVentasFecha;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageReporteBuscarVentasPorCliente;
        private System.Windows.Forms.Button btnVentasCliente;
        private System.Windows.Forms.TextBox txtBuscadorVentasCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}