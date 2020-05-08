using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Modulos.CAJA
{
    public partial class Apertura_de_caja : Form
    {
        public Apertura_de_caja()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("editar_dinero_caja_inicial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_caja", txtidcaja.Text);
                cmd.Parameters.AddWithValue("@saldo", txtmonto.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS frm = new VENTAS_MENU_PRINCIPAL.MENUPRINCIPAL_VENTAS();
                frm.ShowDialog();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void btnOmitir_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Apertura_de_caja_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                lblSerialPc.Text = getserial.Properties["SerialNumber"].Value.ToString();
                MOSTRAR_CAJA_POR_SERIAL();
                try
                {
                    txtidcaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private static void OnlyNumber(KeyPressEventArgs e, bool isdecimal)
        {
            String aceptados;
            if (!isdecimal)
            {
                aceptados = "0123456789." + Convert.ToChar(8);
            }
            else
                aceptados = "0123456789," + Convert.ToChar(8);

            if (aceptados.Contains("" + e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
