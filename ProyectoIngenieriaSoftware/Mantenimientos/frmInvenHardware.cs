using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmInvenHardware : Form
    {

        OdbcConnection con;
        string sTipoActivo;

        List<String> lIdEmpleado = new List<String>();
        List<String> lIdModelo = new List<String>();
        List<String> lIdProveedor = new List<String>();

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public frmInvenHardware(OdbcConnection con, string sTipoActivo)
        {
            InitializeComponent();
            this.con = con;
            this.sTipoActivo = sTipoActivo;

            llenarComboBoProveedores();
            llenarComboBoxEmpleado();
            llenarComboBoxModelos();
            ActualizarGrid();
        }


        private void llenarComboBoxEmpleado()
        {
            lIdEmpleado.Clear();
            cboEmpleado.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idEmpleado, apellido, nombre FROM tbl_empleado WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEmpleado.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) +"," + almacena.GetString(2));
                lIdEmpleado.Add(almacena.GetString(0));

            }
            almacena.Close();

            if (lIdEmpleado.Count > 0)
            {
                cboEmpleado.SelectedIndex = 0;
            }
            else
            {
                cboEmpleado.Text = "";
            }
        }

        private void llenarComboBoProveedores()
        {
            lIdProveedor.Clear();

            cboProveedor.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idProveedor, nombre FROM tbl_proveedor WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboProveedor.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdProveedor.Add(almacena.GetString(0));
            }
            almacena.Close();

            if (lIdProveedor.Count > 0)
            {
                cboProveedor.SelectedIndex = 0;
            }
            else
            {
                cboProveedor.Text = "";
            }
        }

        private void llenarComboBoxModelos()
        {
            lIdModelo.Clear();

            cboModelo.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idModelo, nombre FROM tbl_modelo WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboModelo.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdModelo.Add(almacena.GetString(0));

            }
            almacena.Close();

            if (lIdModelo.Count > 0)
            {
                cboModelo.SelectedIndex = 0;
            }
            else
            {
                cboModelo.Text = "";
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void txt_telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();

            dtpFecha.Text = "";
            cboEmpleado.Text = "";
            cboProveedor.Text = "";
            cboModelo.Text = "";
            txtNumSerie.Text = "";
            txtNumPlaca.Text = "";
            txtGarantia.Text = "";
            txtNombreActivo.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //general
            string sValor = txtValor.Value.ToString();
            string sDepreciacion = txtDepreciacion.Value.ToString();
            string sFecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            string sCantidad = txtCantidad.Value.ToString();

            //especificos
            string sNombre = txtNombreActivo.Text;
            string sNumeroSerie = txtNumSerie.Text;
            string sNumPlaco = txtNumPlaca.Text;
            string sGarantia = txtGarantia.Text;

            if (boton_ingreso == true)
            {

                if (txtValor.Text.Trim() == "" || txtDepreciacion.Text.Trim() == "" || dtpFecha.Text.Trim() == "" ||
                    cboEmpleado.Text.Trim() == "" || cboProveedor.Text.Trim() == "" || cboModelo.Text.Trim() == "" ||
                    txtCantidad.Text.Trim() == "" || txtNumSerie.Text.Trim() == "" || txtNumSerie.Text.Trim() == "" ||
                    txtGarantia.Text.Trim() == "" || txtNombreActivo.Text.Trim() == "" )
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        //Insert en activo

                        string sInsertar = "INSERT INTO tbl_activo(valor, depreciacion, fecha_compra, cod_empleado_asignado, cod_proveedor_mantenimiento, estado) " +
                            "VALUES ('" + sValor 
                            + "', '" + sDepreciacion
                            + "', '" + sFecha
                            + "', '" + lIdEmpleado[cboEmpleado.SelectedIndex]
                            + "', '" + lIdProveedor[cboProveedor.SelectedIndex] + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        //Insert tabla especifica

                        string sInsertar2 = "INSERT INTO tbl_inventario_hardware (PK_idActivo, cantidad, nombre" +
                            ", cod_modelo, numero_serie, numero_placa, status_garantia, cod_departamento) " +
                           "VALUES ( (SELECT MAX(PK_idActivo) FROM tbl_activo)"
                           + ", '" + sCantidad
                           + "', '" + sNombre
                           + "', '" + lIdModelo[cboModelo.SelectedIndex]
                           + "', '" + sNumeroSerie
                           + "', '" + sNumPlaco
                           + "', '" + sGarantia
                           + "', '" + sTipoActivo + "')";
                        OdbcCommand sqlInsertar2 = new OdbcCommand(sInsertar2, con);
                        sqlInsertar2.ExecuteNonQuery();

                        MessageBox.Show("Activo ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar un activo" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtValor.Text.Trim() == "" || txtDepreciacion.Text.Trim() == "" || dtpFecha.Text.Trim() == "" ||
                    cboEmpleado.Text.Trim() == "" || cboProveedor.Text.Trim() == "" || cboModelo.Text.Trim() == "" ||
                    txtCantidad.Text.Trim() == "" || txtNumSerie.Text.Trim() == "" || txtNumSerie.Text.Trim() == "" ||
                    txtGarantia.Text.Trim() == "" || txtNombreActivo.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    string sEstado = "";

                    if (rdb_actio.Checked)
                        sEstado = "1";
                    else
                        sEstado = "0";

                    try
                    {
                        //General
                        string sModificarCliente = "UPDATE tbl_activo SET " +
                            "valor = '" + sValor
                            + "', depreciacion = '" + sDepreciacion
                            + "', fecha_compra = '" + sFecha
                            + "', cod_empleado_asignado = '" + lIdEmpleado[cboEmpleado.SelectedIndex]
                            + "', cod_proveedor_mantenimiento = '" + lIdProveedor[cboProveedor.SelectedIndex]
                            + "', estado = '" + sEstado
                            + "' WHERE PK_idActivo = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();


                        //Especifico
                         sModificarCliente = "UPDATE tbl_inventario_hardware SET " +
                           "cantidad = '" + sCantidad
                           + "', nombre = '" + sNombre
                           + "', cod_modelo = '" + lIdModelo[cboModelo.SelectedIndex]
                           + "', numero_serie = '" + sNumeroSerie
                           + "', numero_placa = '" + sNumPlaco
                           + "', status_garantia = '" + sGarantia
                           + "' WHERE PK_idActivo = '" + txtCodigo.Text + "'; ";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();


                        MessageBox.Show("Activo modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de activo: " + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }

            }
            else if (boton_eliminar == true)
            {
                try
                {
                    int iCodigo = Convert.ToInt32(txtCodigo.Text);

                    string sEliminar = "UPDATE tbl_activo SET estado = '0' WHERE PK_idActivo = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Activo eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del activo: " + ex.Message);
                    MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                }
                tc_Clientes.SelectedTab = tp_datos;
            }
        }

        private void Btn_modificar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            boton_modificar = true;
            boton_ingreso = false;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            boton_eliminar = true;
            boton_modificar = false;
            boton_ingreso = false;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            limpiarForm();
            Btn_guardar.Enabled = false;
            bloquearTextBox();
        }

        /// <summary>
        /// ///////////////
        /// </summary>
        /// 

        void ActualizarGrid()
        {
            try
            {
                dgv_clientes.Rows.Clear();
                string sRecuperarClientes = "SELECT tbl_activo.PK_idActivo, tbl_activo.valor , tbl_activo.depreciacion" +
                    ", tbl_activo.fecha_compra, tbl_activo.fecha_ultima_auditoria, tbl_activo.cod_empleado_asignado" +
                    ", tbl_activo.cod_proveedor_mantenimiento" +

                    ", tbl_inventario_hardware.nombre, tbl_inventario_hardware.cantidad, tbl_inventario_hardware.cod_modelo" +
                    ", tbl_inventario_hardware.numero_serie, tbl_inventario_hardware.numero_placa, tbl_inventario_hardware.status_garantia  "+


                    ", tbl_activo.estado " +

                    " FROM tbl_activo INNER JOIN tbl_inventario_hardware " +
                    "ON tbl_activo.PK_idActivo = tbl_inventario_hardware.PK_idActivo where tbl_activo.estado = 1 AND tbl_inventario_hardware.cod_departamento = " + sTipoActivo;
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                Console.WriteLine(sRecuperarClientes);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgv_clientes.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(1), almacenaClientes.GetString(2), almacenaClientes.GetString(3)
                        , almacenaClientes.GetString(4), almacenaClientes.GetString(5), almacenaClientes.GetString(6), almacenaClientes.GetString(7)
                        , almacenaClientes.GetString(8), almacenaClientes.GetString(9), almacenaClientes.GetString(10), almacenaClientes.GetString(11)
                        , almacenaClientes.GetString(12), almacenaClientes.GetString(13));
                }
                almacenaClientes.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la recuperacion de activos: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
          

            txtValor.Enabled = true;
            txtDepreciacion.Enabled = true;
            dtpFecha.Enabled = true;
            cboEmpleado.Enabled = true;
            cboProveedor.Enabled = true;
            cboModelo.Enabled = true;
            txtCantidad.Enabled = true;
            txtNumSerie.Enabled = true;
            txtNumSerie.Enabled = true;
            txtGarantia.Enabled = true;
            txtNombreActivo.Enabled = true;

            gpb_estado.Enabled = true;
        }

        void bloquearBotones()
        {
            Btn_eliminar.Enabled = false;
            Btn_ingresar.Enabled = false;
            Btn_modificar.Enabled = false;
            Btn_guardar.Enabled = true;
        }

        void limpiarForm()
        {
            Btn_ingresar.Enabled = true;
            Btn_guardar.Enabled = false;
            Btn_modificar.Enabled = true;
            Btn_eliminar.Enabled = true;

            dtpFecha.Text = "";
            cboEmpleado.Text = "";
            cboProveedor.Text = "";
            cboModelo.Text = "";
            txtNumSerie.Text = "";
            txtNumPlaca.Text = "";
            txtGarantia.Text = "";
            txtNombreActivo.Text = "";


            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;

            txtValor.Enabled = false;
            txtDepreciacion.Enabled = false;
            dtpFecha.Enabled = false;
            cboEmpleado.Enabled = false;
            cboProveedor.Enabled = false;
            cboModelo.Enabled = false;
            txtCantidad.Enabled = false;
            txtNumSerie.Enabled = false;
            txtNumSerie.Enabled = false;
            txtGarantia.Enabled = false;
            txtNombreActivo.Enabled = false;

            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_activo.PK_idActivo, tbl_activo.valor , tbl_activo.depreciacion" +
                    ", tbl_activo.fecha_compra, tbl_activo.fecha_ultima_auditoria, tbl_activo.cod_empleado_asignado" +
                    ", tbl_activo.cod_proveedor_mantenimiento" +

                    ", tbl_inventario_hardware.nombre, tbl_inventario_hardware.cantidad, tbl_inventario_hardware.cod_modelo" +
                    ", tbl_inventario_hardware.numero_serie, tbl_inventario_hardware.numero_placa, tbl_inventario_hardware.status_garantia  " +


                    ", tbl_activo.estado " +

                    " FROM tbl_activo INNER JOIN tbl_inventario_hardware " +
                    "ON tbl_activo.PK_idActivo = tbl_inventario_hardware.PK_idActivo WHERE tbl_activo.PK_idActivo LIKE '%" + txt_buscar.Text + "%' " +
                    "AND tbl_inventario_hardware.cod_departamento =" + sTipoActivo;
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4)
                    , almacena.GetString(5), almacena.GetString(6), almacena.GetString(7), almacena.GetString(8), almacena.GetString(9)
                    , almacena.GetString(10), almacena.GetString(11), almacena.GetString(12), almacena.GetString(13));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtValor.Text = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
            txtDepreciacion.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();
            dtpFecha.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();

            //
            txtNombreActivo.Text = dgv_clientes.CurrentRow.Cells[7].Value.ToString();
            txtCantidad.Text = dgv_clientes.CurrentRow.Cells[8].Value.ToString();
            txtNumSerie.Text = dgv_clientes.CurrentRow.Cells[10].Value.ToString();
            txtNumPlaca.Text = dgv_clientes.CurrentRow.Cells[11].Value.ToString();
            txtGarantia.Text = dgv_clientes.CurrentRow.Cells[12].Value.ToString();


            if (dgv_clientes.CurrentRow.Cells[13].Value.ToString() == "1")
            {
                rdb_actio.Checked = true;
            }
            else
            {
                rdb_inactivo.Checked = true;
            }

            tc_Clientes.SelectedTab = tp_abc;
        }
    }
}
