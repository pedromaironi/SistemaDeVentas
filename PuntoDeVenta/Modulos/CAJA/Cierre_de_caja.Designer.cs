namespace PuntoDeVenta.Modulos.CAJA
{
    partial class Cierre_de_caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cierre_de_caja));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtidcaja = new System.Windows.Forms.Label();
            this.txtfechacierre = new System.Windows.Forms.DateTimePicker();
            this.datalistado_caja = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblSerialPc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_caja)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.lblSerialPc);
            this.panel1.Controls.Add(this.datalistado_caja);
            this.panel1.Controls.Add(this.txtfechacierre);
            this.panel1.Controls.Add(this.txtidcaja);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnIniciar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 505);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1073, 94);
            this.panel2.TabIndex = 622;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1073, 94);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cierre de caja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.btnIniciar.ForeColor = System.Drawing.Color.White;
            this.btnIniciar.Location = new System.Drawing.Point(783, 445);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(278, 48);
            this.btnIniciar.TabIndex = 621;
            this.btnIniciar.Text = "CERRAR TURNO";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtidcaja
            // 
            this.txtidcaja.AutoSize = true;
            this.txtidcaja.Location = new System.Drawing.Point(74, 138);
            this.txtidcaja.Name = "txtidcaja";
            this.txtidcaja.Size = new System.Drawing.Size(35, 13);
            this.txtidcaja.TabIndex = 623;
            this.txtidcaja.Text = "label2";
            // 
            // txtfechacierre
            // 
            this.txtfechacierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtfechacierre.Location = new System.Drawing.Point(429, 159);
            this.txtfechacierre.Name = "txtfechacierre";
            this.txtfechacierre.Size = new System.Drawing.Size(203, 20);
            this.txtfechacierre.TabIndex = 624;
            // 
            // datalistado_caja
            // 
            this.datalistado_caja.AllowUserToAddRows = false;
            this.datalistado_caja.AllowUserToResizeRows = false;
            this.datalistado_caja.BackgroundColor = System.Drawing.Color.White;
            this.datalistado_caja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.datalistado_caja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.datalistado_caja.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datalistado_caja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datalistado_caja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn3});
            this.datalistado_caja.EnableHeadersVisualStyles = false;
            this.datalistado_caja.Location = new System.Drawing.Point(489, 224);
            this.datalistado_caja.Name = "datalistado_caja";
            this.datalistado_caja.ReadOnly = true;
            this.datalistado_caja.RowHeadersVisible = false;
            this.datalistado_caja.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.datalistado_caja.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datalistado_caja.RowTemplate.Height = 30;
            this.datalistado_caja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datalistado_caja.Size = new System.Drawing.Size(94, 57);
            this.datalistado_caja.TabIndex = 633;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn3.Image")));
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            // 
            // lblSerialPc
            // 
            this.lblSerialPc.AutoSize = true;
            this.lblSerialPc.Location = new System.Drawing.Point(168, 208);
            this.lblSerialPc.Name = "lblSerialPc";
            this.lblSerialPc.Size = new System.Drawing.Size(35, 13);
            this.lblSerialPc.TabIndex = 634;
            this.lblSerialPc.Text = "label3";
            // 
            // Cierre_de_caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 505);
            this.Controls.Add(this.panel1);
            this.Name = "Cierre_de_caja";
            this.Text = "Cierre_de_caja";
            this.Load += new System.EventHandler(this.Cierre_de_caja_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistado_caja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label txtidcaja;
        private System.Windows.Forms.DateTimePicker txtfechacierre;
        private System.Windows.Forms.DataGridView datalistado_caja;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Label lblSerialPc;
    }
}