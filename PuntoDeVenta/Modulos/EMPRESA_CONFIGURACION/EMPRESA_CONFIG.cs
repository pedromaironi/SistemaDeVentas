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
using System.Text.RegularExpressions;
using System.IO;

using System.Management;

namespace PuntoDeVenta.Modulos.EMPRESA_CONFIGURACION
{
    public partial class EMPRESA_CONFIG : Form
    {
        public EMPRESA_CONFIG()
        {

            InitializeComponent();
        }

        private void EMPRESA_CONFIG_Load(object sender, EventArgs e)
        {
            TXTCON_LECTORA.Enabled = false;

            Panel16.Location = new Point((Width - Panel16.Width) / 2, (Height - Panel16.Height) / 2);
            mostrar();
            Obtener_datos();
        }
        string Vendes_con_impuestos;
        string tipo_de_busqueda;
        private void Obtener_datos()
        {
            txtempresa.Text = datalistado.SelectedCells[2].Value.ToString();
            ImagenEmpresa.BackgroundImage = null;
            byte[] b = (Byte[])datalistado.SelectedCells[1].Value;
            MemoryStream ms = new MemoryStream(b);
            ImagenEmpresa.Image = Image.FromStream(ms);

            TXTPAIS.Text = datalistado.SelectedCells[13].Value.ToString();
            txtmoneda.Text = datalistado.SelectedCells[4].Value.ToString();
            Vendes_con_impuestos = datalistado.SelectedCells[10].Value.ToString();
            if (Vendes_con_impuestos == "SI")
            {
                si.Checked = true;
                PanelImpuesto.Visible = true;
            }
            if (Vendes_con_impuestos == "NO")
            {
                PanelImpuesto.Visible = false;
                no.Checked = true;
            }
            txtporcentaje.Text = datalistado.SelectedCells[6].Value.ToString();
            txtimpuesto.Text = datalistado.SelectedCells[7].Value.ToString();
            tipo_de_busqueda = datalistado.SelectedCells[8].Value.ToString();
            if (tipo_de_busqueda == "LECTORA")
            {
                TXTCON_LECTORA.Checked = true;
                txtteclado.Checked = false;
            }
            if (tipo_de_busqueda == "TECLADO")
            {
                TXTCON_LECTORA.Checked = false;
                txtteclado.Checked = true;
            }
            txtRuta.Text = datalistado.SelectedCells[12].Value.ToString();
            txtcorreo.Text = datalistado.SelectedCells[11].Value.ToString();

        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                da = new SqlDataAdapter("mostrar_Empresa", con);
                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validar_Mail(string sMail)
        {
            return Regex.IsMatch(sMail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void TSIGUIENTE_Y_GUARDAR__Click(object sender, EventArgs e)
        {

            if (validar_Mail(txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com," + " por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcorreo.Focus();
                txtcorreo.SelectAll();
            }
            else
            {
                if (txtempresa.Text != "")
                {
                    try
                    {
                        if (no.Checked == true)
                        {
                            Vendes_con_impuestos = "NO";
                        }
                        else
                        {
                            Vendes_con_impuestos = "SI";
                        }

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd = new SqlCommand("editar_Empresa", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre_Empresa", txtempresa.Text);
                        cmd.Parameters.AddWithValue("@Impuesto", txtimpuesto.Text);
                        cmd.Parameters.AddWithValue("@Porcentaje_impuesto", txtporcentaje.Text);
                        cmd.Parameters.AddWithValue("@Moneda", txtmoneda.Text);
                        cmd.Parameters.AddWithValue("@Trabajas_con_impuestos", Vendes_con_impuestos);

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        ImagenEmpresa.Image.Save(ms, ImagenEmpresa.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@logo", ms.GetBuffer());
                        if (TXTCON_LECTORA.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Modo_de_busqueda", "LECTORA");
                        }
                        if (txtteclado.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@Modo_de_busqueda", "TECLADO");

                        }
                        cmd.Parameters.AddWithValue("@Carpeta_para_copias_de_seguridad", txtRuta.Text);
                        cmd.Parameters.AddWithValue("@Correo_para_envio_de_reportes", txtcorreo.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Cambios guardados", "Guardando Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Hide();
                    Modulos.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Modulos.CONFIGURACION.PANEL_CONFIGURACIONES();
                    frm.ShowDialog();
                    Dispose();
                }
            }
        }

        private void si_CheckedChanged(object sender, EventArgs e)
        {
            PanelImpuesto.Visible = true;

        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            PanelImpuesto.Visible = false;
        }

        private void TXTCON_LECTORA_CheckedChanged(object sender, EventArgs e)
        {
            if (TXTCON_LECTORA.Checked == true)
            {
                txtteclado.Checked = false;
            }
            else
            {
                txtteclado.Checked = true;
            }
        }

        private void txtteclado_CheckedChanged(object sender, EventArgs e)
        {
            if (txtteclado.Checked == true)
            {
                TXTCON_LECTORA.Checked = false;
            }
            else
            {
                TXTCON_LECTORA.Checked = true;
            }
        }

        private void TXTPAIS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmoneda.SelectedIndex = TXTPAIS.SelectedIndex;
        }

        private void lbleditarLogo_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "cargador de Imagenes PedroDev";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImagenEmpresa.BackgroundImage = null;
                ImagenEmpresa.Image = new Bitmap(dlg.FileName);
                ImagenEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            Obtener_ruta();
        }
        private void Obtener_ruta()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                string ruta = folderBrowserDialog1.SelectedPath;
                if (ruta.Contains(@"F:\"))
                {
                    MessageBox.Show("Seleccione un disco diferente al F", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtRuta.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            Obtener_ruta();
        }
        ////MODULOS.CONFIGURACION .PANEL_CONFIGURACIONES.pa
        ////try
        ////{
        ////foreach (Form frm in Application.OpenForms)
        ////{
        ////    if (frm.GetType() == typeof(MODULOS.MASCARAS.MASCARA))
        ////    {
        ////        frm.Hide  ();
        ////            frm.e
        ////        //MODULOS.MASCARAS.MASCARA ff = new MODULOS.MASCARAS.MASCARA();
        ////        //ff.Show();
        ////        //break;
        ////    }
        ////}

        ////}
        ////catch (Exception ex)
        ////{

        ////}
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Hide();
            Modulos.CONFIGURACION.PANEL_CONFIGURACIONES frm = new Modulos.CONFIGURACION.PANEL_CONFIGURACIONES();
            frm.ShowDialog();
            Dispose();
        }
    }
}
