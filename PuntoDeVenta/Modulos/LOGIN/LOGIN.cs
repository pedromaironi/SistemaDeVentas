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

        int contador;
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

                // Event Handles
                b.Click += new EventHandler(mieventoLabel);
                I1.Click += new EventHandler(mieventoimagen);


            }
            //Cerrar conexion
            con.Close();
        }
        private void mieventoLabel (System.Object sender, EventArgs e)
        {
            txtLogin.Text = ((Label)sender).Text;
            panel2.Visible = true;
            panel1.Visible = false;

        }
        private void mieventoimagen(System.Object sender, EventArgs e)
        {
            txtLogin.Text = ((PictureBox)sender).Tag.ToString();
            panel2.Visible = true;
            panel1.Visible = false;

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            DIBUJARUsuarios();
            panel2.Visible = false;

        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {

        }

        private void txtpaswword_TextChanged(object sender, EventArgs e)
        {
            iniciarSesion();
        }

        private void iniciarSesion()
        {
            cargarusuarios();
            contar();
            if (contador > 0)
            {
                CAJA.Apertura_de_caja formulario_apertura_de_caja = new CAJA.Apertura_de_caja();

                this.Hide();
                formulario_apertura_de_caja.ShowDialog();
            }

        }

        private void contar()
        {
            int x;
            x = datalistado.Rows.Count;
            contador = (x);

        }
        private void cargarusuarios()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password", txtpaswword.Text);
                da.SelectCommand.Parameters.AddWithValue("@login", txtLogin.Text);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
