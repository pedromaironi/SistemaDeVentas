using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Modulos.VENTAS_MENU_PRINCIPAL
{
    public partial class MENUPRINCIPAL_VENTAS : Form
    {
        public MENUPRINCIPAL_VENTAS()
        {
            InitializeComponent();
        }

        private void btnTerminarTurno_Click(object sender, EventArgs e)
        {
            CAJA.Cierre_de_caja frm = new CAJA.Cierre_de_caja();
            frm.ShowDialog();
        }
    }
}
