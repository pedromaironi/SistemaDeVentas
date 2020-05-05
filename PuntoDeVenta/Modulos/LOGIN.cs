using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PuntoDeVenta.Modulos
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        public void DIBUJARUsuarios()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT * FROM USUARIO2 WHERE Estado = 'ACTIVO'", con);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Label b = new Label();
                Panel p1 = new Panel();
                PictureBox I1 = new PictureBox();

                //b.text Coge la fila logim
                //b.name para coger de la fila el nombre del usuario

                b.Text = rdr["Login"].ToString();
                b.Name = rdr["idUsuario"].ToString();
                b.Size = new System.Drawing.Size(175,25);
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.FromArgb(28, 54, 67);
                b.ForeColor = Color.White;
                b.Dock = DockStyle.Bottom;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Cursor = Cursors.Hand;

                //Panel

                p1.Size = new System.Drawing.Size(155, 167);
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(28, 54, 67);

                I1.Size = new System.Drawing.Size(175, 132);
                I1.Dock = DockStyle.Top;
                I1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                I1.Image = Image.FromStream(ms);
                I1.SizeMode = PictureBoxSizeMode.Zoom;
                I1.Tag = rdr["Login"].ToString();
                I1.Cursor = Cursors.Hand;

                p1.Controls.Add(b);
                p1.Controls.Add(I1);
                b.BringToFront();
                flowLayoutPanel1.Controls.Add(p1);


            }
            //Cerrar conexion
            con.Close();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            DIBUJARUsuarios();

        }
    }
}
