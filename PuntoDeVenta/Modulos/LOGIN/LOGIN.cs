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
//git reset PuntoDeVenta/bin/Debug/SQLEXPR_x86_ESN/
//git reset PuntoDeVenta/bin/Debug/SQLEXPR_x86_ESN.exe

namespace PuntoDeVenta.Modulos
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();

        }

        int contador;
        int contadorCajas;
        int contadorMovimientoCajas;
        public static String idusuariovariable;
        public static String idcajavariable;
        public void DIBUJARUsuarios()
        {
            try
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

                    b.Text = rdr["Login"].ToString();
                    b.Name = rdr["idUsuario"].ToString();
                    b.Size = new System.Drawing.Size(175, 25);
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);
                    b.FlatStyle = FlatStyle.Flat;
                    b.BackColor = Color.FromArgb(20, 20, 20);
                    b.ForeColor = Color.White;
                    b.Dock = DockStyle.Bottom;
                    b.TextAlign = ContentAlignment.MiddleCenter;
                    b.Cursor = Cursors.Hand;

                    p1.Size = new System.Drawing.Size(155, 167);
                    p1.BorderStyle = BorderStyle.None;
                    p1.BackColor = Color.FromArgb(20, 20, 20);

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
            }catch(Exception ex)
            {
                //MessageBox.Show("asd111");
            }
        }
        private void mieventoLabel (System.Object sender, EventArgs e)
        {
            txtLogin.Text = ((Label)sender).Text;
            panel2.Visible = true;
            panel1.Visible = false;
            MOSTRAR_PERMISOS();

        }
        private void mieventoimagen(System.Object sender, EventArgs e)
        {
            txtLogin.Text = ((PictureBox)sender).Tag.ToString();
            panel2.Visible = true;
            panel1.Visible = false;
            MOSTRAR_PERMISOS();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
                DIBUJARUsuarios();
                panel2.Visible = false;
                timer1.Start();
                PictureBox2.Location = new Point((Width - PictureBox2.Width) / 2, (Height - PictureBox2.Height) / 2);
                panel1.Location = new Point((Width - panel1.Width) / 2, (Height - panel1.Height) / 2);
                PanelRestaurarCuenta.Location = new Point((Width - PanelRestaurarCuenta.Width) / 2, (Height - PanelRestaurarCuenta.Height) / 2);
                panel2.Location = new Point((Width - panel2.Width) / 2, (Height - panel2.Height) / 2);
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario o contraseña incorrectos", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtpaswword.Clear();
        }

        private void ListarAperturaDeDetalleDeCierresDeCaja()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPc.Text);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void aperturar_detalle_cierre_caja()
        {
            try
            {


                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_DETALLE_cierre_de_caja", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaini", DateTime.Today);
                cmd.Parameters.AddWithValue("@fechafin", DateTime.Today);
                cmd.Parameters.AddWithValue("@fechacierre", DateTime.Today);
                cmd.Parameters.AddWithValue("@ingresos", "0.00");
                cmd.Parameters.AddWithValue("@egresos", "0.00");
                cmd.Parameters.AddWithValue("@saldo", "0.00");
                cmd.Parameters.AddWithValue("@idusuario", IDUSUARIO.Text);
                cmd.Parameters.AddWithValue("@totalcaluclado", "0.00");
                cmd.Parameters.AddWithValue("@totalreal", "0.00");

                cmd.Parameters.AddWithValue("@estado", "CAJA APERTURADA");
                cmd.Parameters.AddWithValue("@diferencia", "0.00");
                cmd.Parameters.AddWithValue("@id_caja", txtidcaja.Text);

                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtpaswword_TextChanged(object sender, EventArgs e)
        {
            iniciarSesion();
        }

        private void iniciarSesion()
        {
            cargarusuarios();
            contar();

            try
            {
                IDUSUARIO.Text = datalistado.SelectedCells[1].Value.ToString();
                txtnombre.Text = datalistado.SelectedCells[2].Value.ToString();
                idusuariovariable = IDUSUARIO.Text;
            }
            catch
            {
            }
            if (contador > 0)
            {
                ListarAperturaDeDetalleDeCierresDeCaja();
                contarAperturaDeDetalleCierresDeCaja();
                if (contadorCajas == 0 & lblRol.Text != "Solo Ventas (no esta autorizado para manejar dinero)")
                {
                    aperturar_detalle_cierre_caja();
                    lblAperturaCierreCaja.Text = "Nuevo*****";
                    timer2.Start();
                }
                else
                {
                    if (lblRol.Text != "Solo Ventas (no esta autorizado para manejar dinero)")
                    {
                        MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario();
                        contar_MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario();
                        try
                        {
                            lblusuario_queinicioCaja.Text = datalistado_detalle_cierre_de_caja.SelectedCells[1].Value.ToString();
                            lblnombredeCajero.Text = datalistado_detalle_cierre_de_caja.SelectedCells[2].Value.ToString();
                        }
                        catch
                        {

                        }
                        if (contadorMovimientoCajas == 0)
                        {

                            if (lblusuario_queinicioCaja.Text != "admin" & txtLogin.Text == "admin")
                            {
                                MessageBox.Show("Continuaras turno de *" + lblnombredeCajero.Text + " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lblpermisodeCaja.Text = "correcto";
                            }
                            if (lblusuario_queinicioCaja.Text == "admin" & txtLogin.Text == "admin")
                            {

                                lblpermisodeCaja.Text = "correcto";
                            }

                            else if (lblusuario_queinicioCaja.Text != txtLogin.Text)
                            {
                                MessageBox.Show("Para poder continuar con el Turno de *" + lblnombredeCajero.Text + "* ,Inicia sesion con el Usuario " + lblusuario_queinicioCaja.Text + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lblpermisodeCaja.Text = "vacio";

                            }
                            else if (lblusuario_queinicioCaja.Text == txtLogin.Text)
                            {
                                lblpermisodeCaja.Text = "correcto";
                            }
                        }
                        else
                        {
                            lblpermisodeCaja.Text = "correcto";
                        }

                        if (lblpermisodeCaja.Text == "correcto")
                        {
                            lblAperturaCierreCaja.Text = "Aperturado";
                            timer2.Start();

                        }

                    }
                    else
                    {
                        timer2.Start();
                    }
                }
            }
        }
        private void MOSTRAR_licencia_temporal()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                da = new SqlDataAdapter("select * from Marcan", con);
                da.Fill(dt);
                datalistado_licencia_temporal.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {

            }
        }
        private void MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialPc.Text);
                da.SelectCommand.Parameters.AddWithValue("@idusuario", IDUSUARIO.Text);
                da.Fill(dt);
                datalistado_movimientos_validar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contadorMovimientoCajas = (x);

        }

        private void MOSTRAR_PERMISOS()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;

            SqlCommand com = new SqlCommand("mostrar_permisos_por_usuario_ROL_UNICO", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LOGIN", txtLogin.Text);
            string importe;

            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar());
                con.Close();
                lblRol.Text = importe;

            }
            catch (Exception ex)
            {
            }

        }

        private void contarAperturaDeDetalleCierresDeCaja()
        {
            int x;
            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

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
                da.SelectCommand.Parameters.AddWithValue("@password", CONEXION.Encryptar_en_texto.Encriptar(txtpaswword.Text));
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
            panel1.Visible = false;
            PanelRestaurarCuenta.Visible = true;
            MostrarCorreos();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            PanelRestaurarCuenta.Visible = false;
            panel1.Visible = true;
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
        string INDICADOR;

        private void mostrar_usuarios_registrados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                da = new SqlDataAdapter("select * from USUARIO2", con);
                da.Fill(dt);
                datalistado_USUARIOS_REGISTRADOS.DataSource = dt;
                con.Close();
                INDICADOR = "CORRECTO";
            }
            catch (Exception ex)
            {
                INDICADOR = "INCORRECTO";
            }
        }
        int txtcontador_USUARIOS;
        private void contar_USUARIOS()
        {
            int x;

            x = datalistado_USUARIOS_REGISTRADOS.Rows.Count;
            txtcontador_USUARIOS = (x);
            MessageBox.Show(x.ToString());

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Stop();
            mostrar_usuarios_registrados();
            if (INDICADOR == "CORRECTO")
            {
                contar_USUARIOS();
                if (txtcontador_USUARIOS == 0)
                {
                    Hide();
                    Modulos.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA frm = new Modulos.ASISTENTE_DE_INSTALACION_servidor.REGISTRO_DE_EMPRESA();
                    frm.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MOSTRAR_licencia_temporal();
                }

            }

            if (INDICADOR == "INCORRECTO")
            {
                Hide();
                Modulos.ASISTENTE_DE_INSTALACION_servidor.Eleccion_Servidor_o_remoto frm = new Modulos.ASISTENTE_DE_INSTALACION_servidor.Eleccion_Servidor_o_remoto();
                frm.ShowDialog();
                Dispose();
            }

            try
            {

                ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
                lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString().Trim();
                //MessageBox.Show(lblSerialPc.Text);

                MOSTRAR_CAJA_POR_SERIAL();
                try
                {
                    txtidcaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                    lblcaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                    idcajavariable = txtidcaja.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MOSTRAR_licencia_temporal();


                try
                {
                    txtfecha_final_licencia_temporal.Value = Convert.ToDateTime(CONEXION.Encryptar_en_texto.Desencriptar(datalistado_licencia_temporal.SelectedCells[3].Value.ToString()));
                    lblSerialPcLocal.Text = (CONEXION.Encryptar_en_texto.Desencriptar(datalistado_licencia_temporal.SelectedCells[2].Value.ToString()));
                    LBLESTADOLICENCIALLocal.Text = CONEXION.Encryptar_en_texto.Desencriptar(datalistado_licencia_temporal.SelectedCells[4].Value.ToString());
                    txtfecha_inicio_licencia.Value = Convert.ToDateTime(CONEXION.Encryptar_en_texto.Desencriptar(datalistado_licencia_temporal.SelectedCells[5].Value.ToString()));

                }
                catch (Exception ex)
                {

                }


                if (LBLESTADOLICENCIALLocal.Text != "VENCIDO")

                {
                    string fechaHoy = Convert.ToString(DateTime.Now);
                    DateTime fecha_ddmmyyyy = Convert.ToDateTime(fechaHoy.Split(' ')[0]);

                    if (txtfecha_final_licencia_temporal.Value >= fecha_ddmmyyyy)
                    {
                        if (txtfecha_inicio_licencia.Value <= fecha_ddmmyyyy)
                        {
                            if (LBLESTADOLICENCIALLocal.Text == "?ACTIVO?")
                            {
                                Ingresar_por_licencia_Temporal();
                            }
                            else if (LBLESTADOLICENCIALLocal.Text == "?ACTIVADO PRO?")
                            {
                                Ingresar_por_licencia_de_paga();
                            }

                        }
                        else
                        {
                            Hide();
                            Modulos.LICENCIAS_MENBRESIAS.Membresias frm = new Modulos.LICENCIAS_MENBRESIAS.Membresias();
                            frm.ShowDialog();
                            Dispose();
                        }

                    }
                    else
                    {
                        Hide();

                        Modulos.LICENCIAS_MENBRESIAS.Membresias frm = new Modulos.LICENCIAS_MENBRESIAS.Membresias();
                        frm.ShowDialog();
                        Dispose();
                    }
                }
                else
                {
                    Hide();

                    Modulos.LICENCIAS_MENBRESIAS.Membresias frm = new Modulos.LICENCIAS_MENBRESIAS.Membresias();
                    frm.ShowDialog();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Ingresar_por_licencia_Temporal()
        {
            lblestadoLicencia.Text = "Licencia de Prueba Activada hasta el: " + txtfecha_final_licencia_temporal.Text;
        }
        private void Ingresar_por_licencia_de_paga()
        {
            lblestadoLicencia.Text = "LICENCIA | PROFESIONAL";
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

        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtpaswword.Text != "")
                {
                    largo = txtpaswword.Text.Length;
                    txtpaswword.Text = Mid(txtpaswword.Text, 1, largo - 1);
                }
            }
            catch
            {

            }
        }

        private void tver_Click(object sender, EventArgs e)
        {
            txtpaswword.PasswordChar = '\0';
            tocultar.Visible = true;
            tver.Visible = false;
        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtpaswword.PasswordChar = '*';
            tocultar.Visible = false;
            tver.Visible = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            PanelRestaurarCuenta.Visible = true;
            MostrarCorreos();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                BackColor = Color.FromArgb(20, 20, 20);
                progressBar1.Value = progressBar1.Value + 10;
                PictureBox2.Visible = true;

            }
            else
            {
                progressBar1.Value = 0;
                timer2.Stop();
                if (lblAperturaCierreCaja.Text == "Nuevo*****" & lblRol.Text != "Solo Ventas (no esta autorizado para manejar dinero)")
                {
                    this.Hide();
                    CAJA.APERTURA_DE_CAJA frm = new CAJA.APERTURA_DE_CAJA();
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    this.Hide();
                    VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS frm = new VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS();
                    frm.ShowDialog();
                    this.Hide();
                }

            }
        }

        private void btnOlvideClave_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            PanelRestaurarCuenta.Visible = true;
            MostrarCorreos();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

