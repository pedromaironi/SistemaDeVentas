namespace PuntoDeVenta.Modulos
{
    partial class VENTAS_MENU_PRINCIPAL
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
            this.btnOmitir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOmitir
            // 
            this.btnOmitir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnOmitir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOmitir.FlatAppearance.BorderSize = 0;
            this.btnOmitir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.btnOmitir.ForeColor = System.Drawing.Color.White;
            this.btnOmitir.Location = new System.Drawing.Point(1004, 31);
            this.btnOmitir.Name = "btnOmitir";
            this.btnOmitir.Size = new System.Drawing.Size(129, 52);
            this.btnOmitir.TabIndex = 624;
            this.btnOmitir.Text = "Omitir";
            this.btnOmitir.UseVisualStyleBackColor = false;
            // 
            // VENTAS_MENU_PRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 693);
            this.Controls.Add(this.btnOmitir);
            this.Name = "VENTAS_MENU_PRINCIPAL";
            this.Text = "Menu principal PedroDev";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnOmitir;
    }
}