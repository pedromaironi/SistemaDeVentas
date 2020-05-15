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
using System.Xml;

namespace PuntoDeVenta.Modulos.CAJA
{
    public partial class APERTURA_DE_CAJA : Form
    {
        public APERTURA_DE_CAJA()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
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
        private void APERTURA_DE_CAJA_Load(object sender, EventArgs e)
        {
            panel4.Location = new Point((Width - panel4.Width) / 2, (Height - panel4.Height) / 2);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
            ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
            
                lblSerialPc.Text = MOS.Properties["SerialNumber"].Value.ToString();
            lblSerialPc.Text = lblSerialPc.Text.Trim();

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

        private void txtmonto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //OnlyNumber(e, false);
            //{
            //    // Si se pulsa la tecla Intro, pasar al siguiente
            //    //if( e.KeyChar == Convert.ToChar('\r') ){
            //    if (e.KeyChar == '\r')
            //    {
            //        e.Handled = true;

            //    }
            //    else if (e.KeyChar == ',')
            //    {
            //        // si se pulsa en el punto se convertirá en coma
            //        e.Handled = true;
            //        SendKeys.Send(".");
            //    }
            //}
            //CONEXION.Numeros_separadores.Separador_de_Numeros(txtmonto, e);
            //if (Char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (char.IsSeparator('.'))
            //{
            //    e.Handled = false;

            //}
            //else if (e.KeyChar == ',')
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}

          
            CONEXION.Numero_separadores.Separador_de_Numeros(txtmonto, e);
        }

        private void Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
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
                cmd.Parameters.AddWithValue("@saldo",0);
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
    }
}
