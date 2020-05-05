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
namespace PuntoDeVenta
{
    public partial class usuariosok : Form
    {
        public usuariosok()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text !="")
            {
                try
                {
                SqlConnection con = new SqlConnection() ;
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_usuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombres", txtnombre.Text);
                cmd.Parameters.AddWithValue("@Login", txtlogin .Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword .Text);
                
                cmd.Parameters.AddWithValue("@Correo", txtcorreo .Text);
                cmd.Parameters.AddWithValue("@Rol", txtrol .Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ICONO.Image.Save(ms, ICONO.Image.RawFormat);


                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer ());
                cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono .Text);
                cmd.ExecuteNonQuery();
                con.Close();
                mostrar();
                panel4.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
           
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
         
            da = new SqlDataAdapter("mostrar_usuario", con);
            da.Fill(dt);
            datalistado.DataSource = dt;
            con.Close();

                datalistado.Columns[1].Visible = false;
                datalistado.Columns[5].Visible = false;
                datalistado.Columns[6].Visible = false;
                datalistado.Columns[7].Visible = false;
                datalistado.Columns[8].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroIcono.Text = "1";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;

        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            panelICONO.Visible = true;



        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroIcono.Text = "2";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroIcono.Text = "3";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroIcono.Text = "4";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox7.Image;
            lblnumeroIcono.Text = "5";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox8.Image;
            lblnumeroIcono.Text = "6";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox9.Image;
            lblnumeroIcono.Text = "7";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox10.Image;
            lblnumeroIcono.Text = "8";
            LblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void usuariosok_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }
    }
}
