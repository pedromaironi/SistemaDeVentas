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
using System.Net.Mail;
using System.Net;
using System.Management;

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
            timer1.Start();
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
        private void MostrarCorreos()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("select Correo from USUARIO2 where Estado = 'ACTIVO'", con);
                da.Fill(dt);
                txtcorreo.DisplayMember = "Correo";
                txtcorreo.ValueMember = "Correo";
                txtcorreo.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void btnOlvideClave_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = true;
            MostrarCorreos();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = false;
        }

        private void mostrar_usuarios_por_correo()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                SqlCommand da = new SqlCommand("buscar_USUARIO_por_correo", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@correo", txtcorreo.Text);

                con.Open();
                lblResultadoContrasena.Text = Convert.ToString(da.ExecuteScalar());
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        internal void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                lblEstado_de_envio.Text = "ENVIADO";
                MessageBox.Show("Contraseña Enviada, revisa tu correo electrónico", "Restauración de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PanelRestaurarCuenta.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR, revisa tu correo electronico", "Restauración de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblEstado_de_envio.Text = "Correo no registrado";
            }

        }
        /*private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DiscoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }*/
        private void Button3_Click(object sender, EventArgs e)
        {
            mostrar_usuarios_por_correo();
            richTextBox1.Text = richTextBox1.Text.Replace("@pass", lblResultadoContrasena.Text);
            enviarCorreo("pedrocode29@gmail.com", "Juandejesus29", richTextBox1.Text, "Solicitud de Contraseña", txtcorreo.Text, "");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void MOSTRAR_CAJA_POR_SERIAL()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_Disoduro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            try
            {

                ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                foreach (ManagementObject getserial in MOS.Get())
                {
                    lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();

                    MOSTRAR_CAJA_POR_SERIAL();
                    try
                    {
                        txtidcaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                        lblcaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "0";
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtpaswword.Text = txtpaswword.Text + "9";
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtpaswword.Clear();

        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }
    }
}

