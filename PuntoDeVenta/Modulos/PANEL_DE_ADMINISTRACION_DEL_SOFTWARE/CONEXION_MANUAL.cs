using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PuntoDeVenta.Modulos.PANEL_DE_ADMINISTRACION_DEL_SOFTWARE
{
    public partial class CONEXION_MANUAL : Form
    {
        private CONEXION.AES aes = new CONEXION.AES();
        public CONEXION_MANUAL()
        {
            InitializeComponent();
        }
        public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dbcnString;
        public void ReadfromXML()
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, CONEXION.Desencryptacion.appPwdUnique, int.Parse("256")));

            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {


            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavetoXML(aes.Encrypt(txtCnString.Text, CONEXION.Desencryptacion.appPwdUnique, int.Parse("256")));
            mostrar();
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
                MessageBox.Show("Coneccion realizada correctamente", "Conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sin conexion a la Base de datos", "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistado);

        }
        private void CONEXION_MANUAL_Load(object sender, EventArgs e)
        {
        }

        private void CONEXION_MANUAL_Load_1(object sender, EventArgs e)
        {
            ReadfromXML();
        }
    }
}
