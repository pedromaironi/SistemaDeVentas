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

namespace PuntoDeVenta.Modulos.INVENTARIO_KARDEX
{
    public partial class INVENTARIO_MENU : Form
    {
        public INVENTARIO_MENU()
        {
            InitializeComponent();

        }
        private void buscar_productos_movimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarMovimiento.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_Movimientos.DataSource = dt;
                con.Close();


                DATALISTADO_PRODUCTOS_Movimientos.Columns[1].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[3].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[4].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[5].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[6].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[7].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[8].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[9].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[10].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[11].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[12].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[13].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[14].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[15].Visible = false;
                DATALISTADO_PRODUCTOS_Movimientos.Columns[16].Visible = false;

                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref DATALISTADO_PRODUCTOS_Movimientos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void txtbuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarMovimiento.Text == "Buscar producto" | txtbuscarMovimiento.Text == "")
            {
                DATALISTADO_PRODUCTOS_Movimientos.Visible = false;

            }
            else
            {
                DATALISTADO_PRODUCTOS_Movimientos.Visible = true;
                buscar_productos_movimientos();
            }
        }

        private void buscar_MOVIMIENTOS_DE_KARDEX()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                DatalistadoMovimientos.DataSource = dt;
                con.Close();


                DatalistadoMovimientos.Columns[0].Visible = false;
                DatalistadoMovimientos.Columns[10].Visible = false;
                DatalistadoMovimientos.Columns[11].Visible = false;
                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El producto:"+txtbuscarMovimiento.Text+" no existe","Inventario | Kardex", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        public static int idProducto;

        private void DATALISTADO_PRODUCTOS_Movimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarMovimiento.Text = DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[2].Value.ToString();
            DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            buscar_MOVIMIENTOS_DE_KARDEX();
            try
            {
                idProducto = Convert.ToInt32(DATALISTADO_PRODUCTOS_Movimientos.SelectedCells[1].Value.ToString());

            }
            catch (Exception ex)
            {
            }
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            DATALISTADO_PRODUCTOS_Movimientos.Visible = false;
            txtTipoMovi.Text = "-Todos-";
            buscar_MOVIMIENTOS_FILTROS();
            buscar_MOVIMIENTOS_FILTROS_ACUMULADO();
            panel5.Visible = true;
            MenuStrip2.Visible = false;
            MenuStrip6.Visible = false;
        }

        private void buscar_MOVIMIENTOS_FILTROS()
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
                da.SelectCommand.Parameters.AddWithValue("@fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                DatalistadoMovimientos.DataSource = dt;
                con.Close();


                DatalistadoMovimientos.Columns[0].Visible = false;
                DatalistadoMovimientos.Columns[10].Visible = false;
                DatalistadoMovimientos.Columns[11].Visible = false;

                DatalistadoMovimientos.Columns[9].Visible = false;
                DatalistadoMovimientos.Columns[13].Visible = false;
                DatalistadoMovimientos.Columns[14].Visible = false;
                DatalistadoMovimientos.Columns[12].Visible = false;
                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref DatalistadoMovimientos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void buscar_MOVIMIENTOS_FILTROS_ACUMULADO()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("buscar_MOVIMIENTOS_DE_KARDEX_filtros_acumulado", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", txtfechaM.Value);
                da.SelectCommand.Parameters.AddWithValue("@tipo", txtTipoMovi.Text);
                da.SelectCommand.Parameters.AddWithValue("@Id_usuario", txtIdusuario.Text);


                da.Fill(dt);
                datalistadoMovimientosACUMULADO_PRODUCTOS.DataSource = dt;
                con.Close();


                datalistadoMovimientosACUMULADO_PRODUCTOS.Columns[4].Visible = false;
                datalistadoMovimientosACUMULADO_PRODUCTOS.Columns[5].Visible = false;
                datalistadoMovimientosACUMULADO_PRODUCTOS.Columns[6].Visible = false;

                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoMovimientosACUMULADO_PRODUCTOS);
                DataGridViewCellStyle styCabeceras = new DataGridViewCellStyle();
                styCabeceras.BackColor = System.Drawing.Color.FromArgb(26, 115, 232);
                styCabeceras.ForeColor = System.Drawing.Color.White;
                styCabeceras.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                datalistadoMovimientosACUMULADO_PRODUCTOS.ColumnHeadersDefaultCellStyle = styCabeceras;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void INVENTARIO_MENU_Load(object sender, EventArgs e)
        {
            panelMOVIMIENTOS.Dock = DockStyle.None;
            panelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            panelMOVIMIENTOS.Visible = false;
            panelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = true;
            PanelKardex.Dock = DockStyle.Fill;
            Panelv.Visible = false;
            panelVencimiento.Visible = false;
            panelVencimiento.Dock = DockStyle.None;

            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;

            txtbuscarKardex_movimientos.Text = "Buscar producto";
        }
        private void buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("select*from USUARIO2 where Estado = 'ACTIVO'", con);

                da.Fill(dt);
                txtUSUARIOS.DisplayMember = "Nombre_y_Apellido";
                txtUSUARIOS.ValueMember = "idUsuario";

                txtUSUARIOS.DataSource = dt;
                //txtIdusuario.Text = txtUSUARIOS.ValueMember;

                con.Close();
                Buscar_id_USUARIOS();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }


        }
        internal void Buscar_id_USUARIOS()
        {

            string resultado;
            string queryMoneda;
            queryMoneda = "Buscar_id_USUARIOS";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;

            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            comMoneda.CommandType = CommandType.StoredProcedure;
            comMoneda.Parameters.AddWithValue("@Nombre_y_Apelllidos", txtUSUARIOS.Text);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                txtIdusuario.Text = resultado;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                resultado = "";
            }
        }

        private void txtUSUARIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {

                Buscar_id_USUARIOS();
                buscar_MOVIMIENTOS_FILTROS();
                buscar_MOVIMIENTOS_FILTROS_ACUMULADO();
            }
        }

        private void txtfechaM_ValueChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscar_MOVIMIENTOS_FILTROS();
                buscar_MOVIMIENTOS_FILTROS_ACUMULADO();
            }
        }

        private void txtTipoMovi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groupBox1.Visible == true)
            {
                buscar_MOVIMIENTOS_FILTROS();
                buscar_MOVIMIENTOS_FILTROS_ACUMULADO();
            }
        }

        private void tver_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            groupBox1.Visible = false;
            txtTipoMovi.Text = "-Todos-";
            txtbuscarMovimiento.Text = "Buscar producto";
            MenuStrip2.Visible = true;
            MenuStrip6.Visible = true;
            //buscar_MOVIMIENTOS_DE_KARDEX();
            
        }

        private void txtIdusuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TNOTAS_Click(object sender, EventArgs e)
        {
            panelMOVIMIENTOS.Dock = DockStyle.None;
            panelREPORTEInventario.Dock = DockStyle.None;

            panelMOVIMIENTOS.Visible = false;
            panelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = true;
            PaneliNVENTARIObajo.Dock = DockStyle.Fill;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            PanelK.Visible = false;
            PanelI.Visible = true;
            PanelM.Visible = false;
            PanelR.Visible = false;
            Panelv.Visible = false;
            panelVencimiento.Visible = false;
            panelVencimiento.Dock = DockStyle.None;
            Panelv.Visible = false;
            MOSTRAR_Inventarios_bajo_minimo();

        }

        private void TOTROSPAGOS_Click(object sender, EventArgs e)
        {
            PanelR.Visible = true;
            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = false;
            Panelv.Visible = false;
            panelMOVIMIENTOS.Visible = false;
            panelREPORTEInventario.Visible = true;
            PaneliNVENTARIObajo.Visible = false;
            panelMOVIMIENTOS.Dock = DockStyle.None;
            panelREPORTEInventario.Dock = DockStyle.Fill;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            panelVencimiento.Visible = false;
            panelVencimiento.Dock = DockStyle.None;
            Panelv.Visible = false;
            mostrar_inventarios_todos();
            sumar_costo_de_inventario_CONTAR_PRODUCTOS();

        }
        internal void sumar_costo_de_inventario_CONTAR_PRODUCTOS()
        {


            string resultado;
            string queryMoneda;
            queryMoneda = "SELECT Moneda  FROM EMPRESA";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToString(comMoneda.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                resultado = "";
            }

            string importe;
            string query;
            query = "SELECT      CONVERT(NUMERIC(18,2),sum(Producto1.Precio_de_compra * Stock )) as suma FROM  Producto1 where  Usa_inventarios ='SI'";

            SqlCommand com = new SqlCommand(query, con);
            try
            {
                con.Open();
                importe = Convert.ToString(com.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcostoInventario.Text = resultado + " " + importe;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                lblcostoInventario.Text = resultado + " " + 0;
            }

            string conteoresultado;
            string querycontar;
            querycontar = "select count(Id_Producto1 ) from Producto1 ";
            SqlCommand comcontar = new SqlCommand(querycontar, con);
            try
            {
                con.Open();
                conteoresultado = Convert.ToString(comcontar.ExecuteScalar()); //asignamos el valor del importe
                con.Close();
                lblcantidaddeProductosEnInventario.Text = conteoresultado;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);

                conteoresultado = "";
                lblcantidaddeProductosEnInventario.Text = "0";
            }

        }
        private void MOSTRAR_Inventarios_bajo_minimo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_Inventarios_bajo_minimo", con);

                da.Fill(dt);
                datalistadoInventarioBAJO.DataSource = dt;
                con.Close();


                datalistadoInventarioBAJO.Columns[0].Visible = false;
                datalistadoInventarioBAJO.Columns[4].Visible = false;
                datalistadoInventarioBAJO.Columns[7].Visible = false;
                datalistadoInventarioBAJO.Columns[8].Visible = false;
                datalistadoInventarioBAJO.Columns[9].Visible = false;


                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoInventarioBAJO);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtbuscarKardex_movimientos_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscarKardex_movimientos.Text == "Buscar producto" | txtbuscarKardex_movimientos.Text == "")
            {
                DATALISTADO_PRODUCTOS_Kardex.Visible = false;
            }
            else
            {
                buscar_productos_kardex();
            }
        }

        private void buscar_productos_kardex()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("BUSCAR_PRODUCTOS_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letrab", txtbuscarKardex_movimientos.Text);
                da.Fill(dt);
                DATALISTADO_PRODUCTOS_Kardex.DataSource = dt;
                con.Close();


                DATALISTADO_PRODUCTOS_Kardex.Columns[1].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[3].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[4].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[5].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[6].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[7].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[8].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[9].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[10].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[11].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[12].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[13].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[14].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[15].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Columns[16].Visible = false;
                DATALISTADO_PRODUCTOS_Kardex.Visible = true;
                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref DATALISTADO_PRODUCTOS_Kardex);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mostrar_inventarios_todos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_inventarios_todos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtbuscar_inventarios.Text);

                da.Fill(dt);
                datalistadoInventariosReport.DataSource = dt;
                con.Close();


                datalistadoInventariosReport.Columns[0].Visible = false;
                datalistadoInventariosReport.Columns[9].Visible = false;
                datalistadoInventariosReport.Columns[10].Visible = false;

                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoInventariosReport);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtbuscar_inventarios_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar_inventarios.Text != "Buscar...")
            {
                mostrar_inventarios_todos();
            }
        }
        
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            txtbuscar_inventarios.Clear();
            mostrar_inventarios_todos();
        }
        
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip7_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtBuscarVencimientos_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarVencimientos.Text != "Buscar producto/Codigo")
            {
                buscar_productos_vencidos();
                CheckPorVencer30enDias.Checked = false;
                CheckProductosVencidos.Checked = false;

            }
        }

        private void buscar_productos_vencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("buscar_productos_vencidos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", txtBuscarVencimientos.Text);

                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;
                datalistadoVencimientos.Columns[6].Visible = false;
                datalistadoVencimientos.Columns[7].Visible = false;
                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoVencimientos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscarVencimientos_Click(object sender, EventArgs e)
        {
            txtBuscarVencimientos.SelectAll();
        }

        private void CheckPorVencer30enDias_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";
            mostrar_productos_vencidos_en_menos_de_30_dias();
        }

        private void mostrar_productos_vencidos_en_menos_de_30_dias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_productos_vencidos_en_menos_de_30_dias", con);


                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;

                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoVencimientos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtbuscarMovimiento_Click(object sender, EventArgs e)
        {
            txtbuscarMovimiento.SelectAll();
        }

        private void CheckProductosVencidos_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";
            mostrar_productos_vencidos();
        }
        private void mostrar_productos_vencidos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("mostrar_productos_vencidos", con);


                da.Fill(dt);
                datalistadoVencimientos.DataSource = dt;
                con.Close();


                datalistadoVencimientos.Columns[0].Visible = false;
                datalistadoVencimientos.Columns[1].Visible = false;

                CONEXION.Tamaño_automatico_de_datatables.Multilinea(ref datalistadoVencimientos);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TKardex_Click(object sender, EventArgs e)
        {
            PanelR.Visible = false;
            PanelK.Visible = true;
            PanelI.Visible = false;
            PanelM.Visible = false;
            Panelv.Visible = false;

            panelMOVIMIENTOS.Dock = DockStyle.None;
            panelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            panelMOVIMIENTOS.Visible = false;
            panelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = true;
            PanelKardex.Dock = DockStyle.Fill;
            panelVencimiento.Visible = false;
            panelVencimiento.Dock = DockStyle.None;
            Panelv.Visible = false;
            txtbuscarKardex_movimientos.Text = "Buscar producto";
        }

        private void TMOVIMIENTOS_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            PanelR.Visible = false;
            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = true;
            Panelv.Visible = false;
            panelMOVIMIENTOS.Visible = true;
            panelREPORTEInventario.Visible = false;

            panelMOVIMIENTOS.Dock = DockStyle.Fill;
            panelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Visible = false;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            panelVencimiento.Visible = false;
            panelVencimiento.Dock = DockStyle.None;
            Panelv.Visible = false;
            buscar_productos_movimientos();
            buscar_usuario();
            Buscar_id_USUARIOS();
            txtbuscarMovimiento.Text = "Buscar producto";
            MenuStrip2.Visible = true;
            MenuStrip6.Visible = true;
        }

        private void TVencimientos_Click(object sender, EventArgs e)
        {
            PanelR.Visible = false;
            PanelK.Visible = false;
            PanelI.Visible = false;
            PanelM.Visible = false;
            Panelv.Visible = true;
            panelMOVIMIENTOS.Visible = false;
            panelREPORTEInventario.Visible = false;
            PaneliNVENTARIObajo.Visible = false;
            panelMOVIMIENTOS.Dock = DockStyle.None;
            panelREPORTEInventario.Dock = DockStyle.None;
            PaneliNVENTARIObajo.Dock = DockStyle.None;
            PanelKardex.Visible = false;
            PanelKardex.Dock = DockStyle.None;
            panelVencimiento.Visible = true;
            panelVencimiento.Dock = DockStyle.Fill;
            Panelv.Visible = true;
            txtBuscarVencimientos.Text = "Buscar producto/Codigo";
        }

        private void DATALISTADO_PRODUCTOS_Kardex_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbuscarKardex_movimientos.Text = DATALISTADO_PRODUCTOS_Kardex.SelectedCells[2].Value.ToString();
            DATALISTADO_PRODUCTOS_Kardex.Visible = false;
            mostrar_kardex_movimientos();


        }
        REPORTES.REPORTES_DE_KARDEX.REPORTE_DE_KARDEX_DISEÑO.ReportKardex_Movimientos_ok rptFREPORT2 = new REPORTES.REPORTES_DE_KARDEX.REPORTE_DE_KARDEX_DISEÑO.ReportKardex_Movimientos_ok();
        private void mostrar_kardex_movimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.CONEXION;
                con.Open();

                da = new SqlDataAdapter("MOSTRAR_MOVIMIENTOS_DE_KARDEX", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idProducto", DATALISTADO_PRODUCTOS_Kardex.SelectedCells[1].Value.ToString());
                da.Fill(dt);
                con.Close();
                rptFREPORT2 = new REPORTES.REPORTES_DE_KARDEX.REPORTE_DE_KARDEX_DISEÑO.ReportKardex_Movimientos_ok();
                rptFREPORT2.DataSource = dt;
                rptFREPORT2.table1.DataSource = dt;
                reportViewer1.Report = rptFREPORT2;
                reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void MenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormMovimientosBuscar frm = new Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormMovimientosBuscar();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuStrip6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MenuStrip10_Click(object sender, EventArgs e)
        {
            Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormInventariosTodos frm = new Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormInventariosTodos();
            frm.ShowDialog();
        }

        public static string Tipo_de_movimiento;
        public static DateTime fecha;
        public static int id_usuario;


        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Tipo_de_movimiento = txtTipoMovi.Text;
            fecha = txtfechaM.Value;
            id_usuario = Convert.ToInt32(txtIdusuario.Text);

            Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormReporteMovimientosFILTROS frm = new Modulos.REPORTES.REPORTES_DE_KARDEX.REPORTES_DE_INVENTARIOS_todos.FormReporteMovimientosFILTROS();
            frm.ShowDialog();
        }
    }
}
