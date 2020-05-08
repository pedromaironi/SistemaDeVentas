namespace PuntoDeVenta.Modulos.VENTAS_MENU_PRINCIPAL
{
    partial class MENUPRINCIPAL_VENTAS
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
            this.btnTerminarTurno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTerminarTurno
            // 
            this.btnTerminarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.btnTerminarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminarTurno.FlatAppearance.BorderSize = 0;
            this.btnTerminarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
            this.btnTerminarTurno.ForeColor = System.Drawing.Color.White;
            this.btnTerminarTurno.Location = new System.Drawing.Point(825, 25);
            this.btnTerminarTurno.Name = "btnTerminarTurno";
            this.btnTerminarTurno.Size = new System.Drawing.Size(233, 52);
            this.btnTerminarTurno.TabIndex = 622;
            this.btnTerminarTurno.Text = "Terminar turno";
            this.btnTerminarTurno.UseVisualStyleBackColor = false;
            this.btnTerminarTurno.Click += new System.EventHandler(this.btnTerminarTurno_Click);
            // 
            // MENUPRINCIPAL_VENTAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 582);
            this.Controls.Add(this.btnTerminarTurno);
            this.Name = "MENUPRINCIPAL_VENTAS";
            this.Text = "MENUPRINCIPAL_VENTAS";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnTerminarTurno;
    }
}