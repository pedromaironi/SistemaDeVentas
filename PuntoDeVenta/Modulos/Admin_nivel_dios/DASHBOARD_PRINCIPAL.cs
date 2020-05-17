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
using System.Management;
using System.Globalization;

namespace PuntoDeVenta.Modulos.Admin_nivel_dios
{
    public partial class DASHBOARD_PRINCIPAL : Form
    {
        public DASHBOARD_PRINCIPAL()
        {
            InitializeComponent();
            Button20.Visible = false;
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            Iniciar_sesion_correcto();
        }
        private void ListarAPERTURAS_de_detalle_de_cierres_de_caja()
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
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL .Text);
                da.Fill(dt);
                datalistado_detalle_cierre_de_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
        private void contar_APERTURAS_de_detalle_de_cierres_de_caja()
        {
            int x;

            x = datalistado_detalle_cierre_de_caja.Rows.Count;
            contadorCajas = (x);

        }
        private void aperturar_detalle_de_cierre_caja()
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
                //cmd.Parameters.AddWithValue("@fecha", DateTime.Today);

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
                da.SelectCommand.Parameters.AddWithValue("@serial", lblIDSERIAL .Text);
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
        int contador_Movimientos_de_caja;
        private void contar_MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL_y_usuario()
        {
            int x;

            x = datalistado_movimientos_validar.Rows.Count;
            contador_Movimientos_de_caja = (x);

        }
        private void Iniciar_sesion_correcto()
        {
            MOSTRAR_id_de_admin();
            IDUSUARIO.Text = Convert.ToString ( id_usarios_admin);
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



            ListarAPERTURAS_de_detalle_de_cierres_de_caja();
            contar_APERTURAS_de_detalle_de_cierres_de_caja();

            if (contadorCajas == 0 & lblROL.Text != "Solo Ventas (no esta autorizado para manejar dinero)")
            {
                aperturar_detalle_de_cierre_caja();
                lblApertura_De_caja.Text = "Nuevo*****";
                timer2.Start();

            }
            else
            {
                if (lblROL .Text != "Solo Ventas (no esta autorizado para manejar dinero)")
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
                    if (contador_Movimientos_de_caja == 0)
                    {

                        if (lblusuario_queinicioCaja.Text != "admin" & txtlogin.Text == "admin")
                        {
                            MessageBox.Show("Continuaras Turno de *" + lblnombredeCajero.Text + " Todos los Registros seran con ese Usuario", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            lblpermisodeCaja.Text = "correcto";
                        }
                        if (lblusuario_queinicioCaja.Text == "admin" & txtlogin.Text == "admin")
                        {

                            lblpermisodeCaja.Text = "correcto";
                        }

                        else if (lblusuario_queinicioCaja.Text != txtlogin.Text & txtlogin.Text != "admin")
                        {
                            MessageBox.Show("Para poder continuar con el Turno de *" + lblnombredeCajero.Text + "* ,Inicia sesion con el Usuario " + lblusuario_queinicioCaja.Text + " -ó-el Usuario *admin*", "Caja Iniciada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblpermisodeCaja.Text = "vacio";

                        }
                        else if (lblusuario_queinicioCaja.Text == txtlogin.Text)
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
                        lblApertura_De_caja.Text = "Aperturado";
                        timer2.Start();

                    }

                }
                else
                {
                    timer2.Start();
                }


            }

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

                da = new SqlDataAdapter("mostrar_cajas_por_Serial_de_DisoDuro", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblIDSERIAL.Text);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        int id_usarios_admin;
        private void MOSTRAR_id_de_admin()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                SqlCommand da = new SqlCommand("select idUsuario from USUARIO2 WHERE Login='admin'", con);
              

                con.Open();
                id_usarios_admin = Convert.ToInt32 (da.ExecuteScalar());
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        private void DASHBOARD_PRINCIPAL_Load(object sender, EventArgs e)
        {

            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");

            lblIDSERIAL.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblIDSERIAL.Text = lblIDSERIAL.Text.Trim();

            //Fecha
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

            int Month = datevalue.Month;
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            string nombreMes = formatoFecha.GetMonthName(Month);
            lblfechaHoy.Text = nombreMes.ToUpper();

        }
        int contadorCajas;

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 5;
                Panel5.Visible = false;
                PictureBox20.Visible = true;
                PictureBox20.Dock = DockStyle.Fill;
            }
            else
            {
                progressBar1.Value = 0;
                timer2.Stop();
                
                
               if (lblApertura_De_caja.Text == "Nuevo*****")
                {
                    this.Hide();
                    CAJA.APERTURA_DE_CAJA frm = new CAJA.APERTURA_DE_CAJA();
                    frm.ShowDialog();
                    Dispose();
                }
                else 
                {
                    this.Hide();
                    VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS frm = new VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS();
                    frm.ShowDialog();
                    Dispose();
                }

            }

        }

        private void PictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            Dispose();
            Modulos.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Modulos.CONFIGURACION.PANEL_CONFIGURACIONES();
            frm.ShowDialog();
        }

        private void Button20_Click(object sender, EventArgs e)
        {

        }
    }
}
