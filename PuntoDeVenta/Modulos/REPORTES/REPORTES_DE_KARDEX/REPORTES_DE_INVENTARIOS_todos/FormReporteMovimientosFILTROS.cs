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

namespace PuntoDeVenta.Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos
{
    public partial class FormReporteMovimientosFILTROS : Form
    {
        public FormReporteMovimientosFILTROS()
        {
            InitializeComponent();
        }

        private void FormReporteMovimientosFILTROS_Load(object sender, EventArgs e)
        {
            mostrar();

        }
        Reporte_Movimientos_con_Filtros rptFREPORT2 = new Reporte_Movimientos_con_Filtros();
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", Modulos.INVENTARIO_KARDEX.INVENTARIO_MENU.fecha);
                da.SelectCommand.Parameters.AddWithValue("@tipo", Modulos.INVENTARIO_KARDEX.INVENTARIO_MENU.Tipo_de_movimiento);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", Modulos.INVENTARIO_KARDEX.INVENTARIO_MENU.id_usuario);

                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new Reporte_Movimientos_con_Filtros();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.Table1.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;

                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }
    }
}
