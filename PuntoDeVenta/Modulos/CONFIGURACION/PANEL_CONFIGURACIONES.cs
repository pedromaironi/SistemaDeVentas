using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Modulos.CONFIGURACION
{
    public partial class PANEL_CONFIGURACIONES : Form
    {
        public PANEL_CONFIGURACIONES()
        {
            InitializeComponent();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            PRODUCTOS.PRODUCTOSOK frm = new PRODUCTOS.PRODUCTOSOK();
            frm.ShowDialog();
        }
        MASCARAS.MASCARA frm = new MASCARAS.MASCARA();

        private void Mostrar_mascara()
        {
            frm.Show();
        }
        public void ocultar_mascara()
        {
            frm.Dispose();
        }
        private void Logo_empresa_Click(object sender, EventArgs e)
        {
            Configurar_empresa();

        }

        private void Configurar_empresa()
        {
          EMPRESA_CONFIGURACION.EMPRESA_CONFIG frm = new EMPRESA_CONFIGURACION.EMPRESA_CONFIG();
          frm.ShowDialog();
        }
        private void Label47_Click(object sender, EventArgs e)
        {
            Configurar_empresa();
        }

        private void PANEL_CONFIGURACIONES_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point((Width - panel1.Width) / 2, (Height - panel1.Height) / 2);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Usuarios();
        }
        private void Usuarios()
        {
            usuariosok frm = new usuariosok();
            frm.ShowDialog();
        }

        private void Label26_Click(object sender, EventArgs e)
        {
            Usuarios();
        }

        private void ToolStripButton22_Click(object sender, EventArgs e)
        {
            Hide();
            Admin_nivel_dios.DASHBOARD_PRINCIPAL frm = new Admin_nivel_dios.DASHBOARD_PRINCIPAL();
            frm.ShowDialog();
            Dispose();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            EMPRESA_CONFIGURACION.EMPRESA_CONFIG frm = new EMPRESA_CONFIGURACION.EMPRESA_CONFIG();
            frm.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Modulos.CAJA.Cajas_form frm = new Modulos.CAJA.Cajas_form();
            frm.ShowDialog();
        }

        private void Label27_Click(object sender, EventArgs e)
        {
            Modulos.CAJA.Cajas_form frm = new Modulos.CAJA.Cajas_form();
            frm.ShowDialog();
        }
    }
}
