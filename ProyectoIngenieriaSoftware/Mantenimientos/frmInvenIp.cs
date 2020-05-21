using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmInvenIp : Form
    {
        OdbcConnection con;
        string sArea;

        List<String> lIdEmpleado = new List<String>();
        List<String> lIdProveedor = new List<String>();


        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        string sIdUsuario = "";
        string sNivelPrivilegios = "";

        public static string host = Dns.GetHostName();
        string myIP = Dns.GetHostByName(host).AddressList[0].ToString();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmInvenIp(OdbcConnection con, string v, string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();
            this.con = con;
            this.sArea = v;
            ActualizarGrid();
            llenarComboBoProveedores();
            llenarComboBoxEmpleado();

            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            if (sNivelPrivilegios == "Lectura")
                panel2.Enabled = false;
        }

        private void llenarComboBoxEmpleado()
        {
            lIdEmpleado.Clear();
            cboEmpleado.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idEmpleado, apellido, nombre FROM tbl_empleado WHERE estado = 1 " +
                " AND cod_area= " + sArea, con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEmpleado.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) + "," + almacena.GetString(2));
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

            cboEmpleado.Text = "";
            cboProveedor.Text = "";
            txtIpCableada.Text = "";
            dtpFecha.Text = "";
            txtIpInalambrica.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            //general
            string sFecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            //especificos
            string sIpCableada = txtIpCableada.Text;
            string sIpInalambrica = txtIpInalambrica.Text;

            if (boton_ingreso == true)
            {

                if (txtIpInalambrica.Text.Trim() == "" || txtIpCableada.Text.Trim() == "" || dtpFecha.Text.Trim() == "" ||
                    cboEmpleado.Text.Trim() == "" || cboProveedor.Text.Trim() == "" )
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        //Insert en activo

                        string sInsertar = "INSERT INTO tbl_activo(fecha_compra, cod_empleado_asignado, cod_proveedor_mantenimiento, estado) " +
                            "VALUES ('" + sFecha
                            + "', '" + lIdEmpleado[cboEmpleado.SelectedIndex]
                            + "', '" + lIdProveedor[cboProveedor.SelectedIndex] + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        //Insert tabla especifica

                        string sInsertar2 = "INSERT INTO tbl_inventario_soporte_tecnico_ip (PK_idActivo, direccion_ip_cableada, direccion_ip_inalambrica" +
                            ") " +
                           "VALUES ( (SELECT MAX(PK_idActivo) FROM tbl_activo)"
                           + ", '" + sIpCableada
                           + "', '" + sIpInalambrica + "')";
                        OdbcCommand sqlInsertar2 = new OdbcCommand(sInsertar2, con);
                        sqlInsertar2.ExecuteNonQuery();

                        MessageBox.Show("Activo ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();

                        sInsertar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                              "accion, " +
                              "fecha, " +
                              "hora, " +
                              "IP) " +
                              "VALUES(" + sIdUsuario + "" +
                              ",'Inserto una direccion IP: " + sIpCableada +
                              "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                              ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                              ",'" + myIP + "')";
                        sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();
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
                if (txtIpInalambrica.Text.Trim() == "" || txtIpCableada.Text.Trim() == "" || dtpFecha.Text.Trim() == "" ||
                    cboEmpleado.Text.Trim() == "" || cboProveedor.Text.Trim() == "")
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
                            "fecha_compra = '" + sFecha
                            + "', cod_empleado_asignado = '" + lIdEmpleado[cboEmpleado.SelectedIndex]
                            + "', cod_proveedor_mantenimiento = '" + lIdProveedor[cboProveedor.SelectedIndex]
                            + "', estado = '" + sEstado
                            + "' WHERE PK_idActivo = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();


                        //Especifico
                        sModificarCliente = "UPDATE tbl_inventario_soporte_tecnico_ip SET " +
                          "direccion_ip_cableada = '" + sIpCableada
                          + "', direccion_ip_inalambrica = '" + sIpInalambrica
                          + "' WHERE PK_idActivo = '" + txtCodigo.Text + "'; ";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();


                        MessageBox.Show("Activo modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();

                        sModificarCliente = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                              "accion, " +
                              "fecha, " +
                              "hora, " +
                              "IP) " +
                              "VALUES(" + sIdUsuario + "" +
                              ",'Modifico una IP: " + sIpCableada +
                              "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                              ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                              ",'" + myIP + "')";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();
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

                    sEliminar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                              "accion, " +
                              "fecha, " +
                              "hora, " +
                              "IP) " +
                              "VALUES(" + sIdUsuario + "" +
                              ",'Elimino una direccion IP: " + sIpCableada+
                              "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                              ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                              ",'" + myIP + "')";
                    sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();
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
                string sRecuperarClientes = "SELECT tbl_activo.PK_idActivo" +
                    ", tbl_activo.fecha_compra, tbl_activo.fecha_ultima_auditoria, tbl_empleado.nombre" +
                    ", tbl_proveedor.nombre" +

                    ", tbl_inventario_soporte_tecnico_ip.direccion_ip_cableada, tbl_inventario_soporte_tecnico_ip.direccion_ip_inalambrica" +

                    ", tbl_activo.estado " +

                    " FROM tbl_activo INNER JOIN tbl_inventario_soporte_tecnico_ip " +
                    "ON tbl_activo.PK_idActivo = tbl_inventario_soporte_tecnico_ip.PK_idActivo" +
                    " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado " +
                    "INNER JOIN tbl_proveedor ON tbl_activo.cod_proveedor_mantenimiento = tbl_proveedor.PK_idProveedor  where tbl_activo.estado = 1";
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                Console.WriteLine(sRecuperarClientes);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgv_clientes.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(1), almacenaClientes.GetString(2), almacenaClientes.GetString(3)
                        , almacenaClientes.GetString(4), almacenaClientes.GetString(5), almacenaClientes.GetString(6), almacenaClientes.GetString(7));
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


            dtpFecha.Enabled = true;
            cboEmpleado.Enabled = true;
            cboProveedor.Enabled = true;
            txtIpCableada.Enabled = true;
            txtIpInalambrica.Enabled = true;

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
            txtIpInalambrica.Text = "";
            txtIpCableada.Text = "";

            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;

            dtpFecha.Enabled = false;
            cboEmpleado.Enabled = false;
            cboProveedor.Enabled = false;
            txtIpCableada.Enabled = false;
            txtIpInalambrica.Enabled = false;

            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_activo.PK_idActivo" +
                    ", tbl_activo.fecha_compra, tbl_activo.fecha_ultima_auditoria, tbl_empleado.nombre" +
                    ", tbl_proveedor.nombre" +

                    ", tbl_inventario_soporte_tecnico_ip.direccion_ip_cableada, tbl_inventario_soporte_tecnico_ip.direccion_ip_inalambrica" +


                    ", tbl_activo.estado " +

                    " FROM tbl_activo INNER JOIN tbl_inventario_soporte_tecnico_ip " +
                    "ON tbl_activo.PK_idActivo = tbl_inventario_soporte_tecnico_ip.PK_idActivo " +
                    " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado " +
                    "INNER JOIN tbl_proveedor ON tbl_activo.cod_proveedor_mantenimiento = tbl_proveedor.PK_idProveedor  WHERE tbl_activo.PK_idActivo LIKE '%" + txt_buscar.Text + "%' ";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4)
                    , almacena.GetString(5), almacena.GetString(6), almacena.GetString(7));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();

            //
            txtIpCableada.Text = dgv_clientes.CurrentRow.Cells[5].Value.ToString();
            txtIpInalambrica.Text = dgv_clientes.CurrentRow.Cells[6].Value.ToString();

            if (dgv_clientes.CurrentRow.Cells[7].Value.ToString() == "1")
            {
                rdb_actio.Checked = true;
            }
            else
            {
                rdb_inactivo.Checked = true;
            }

            tc_Clientes.SelectedTab = tp_abc;
        }

        private void frmInvenIp_Load(object sender, EventArgs e)
        {

        }
    }
}
