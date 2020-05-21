using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Net;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmEmpleados : Form
    {

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        string sIdUsuario = "";
        string sNivelPrivilegios = "";

        public static string host = Dns.GetHostName();
        string myIP = Dns.GetHostByName(host).AddressList[0].ToString();


        OdbcConnection con;

        List<String> lIdPuntoVenta = new List<String>();
        List<String> lNombrePuntoVenta = new List<String>();

        List<String> lIdArea = new List<String>();
        List<String> lNombreArea = new List<String>();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public frmEmpleados(OdbcConnection con, string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();

            this.con = con;

            rdb_actio.Checked = true;
            Btn_guardar.Enabled = false;
            bloquearTextBox();
            ActualizarGrid();

            llenarComboBoxAreas();
            llenarComboBoxPuntoVenta();

            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            if (sNivelPrivilegios == "Lectura")
                panel2.Enabled = false;
        }

        private void llenarComboBoxPuntoVenta()
        {
            lIdPuntoVenta.Clear();
            lNombrePuntoVenta.Clear();

            cboPuntoVenta.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idPuntoVenta, nombre FROM tbl_punto_venta WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboPuntoVenta.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdPuntoVenta.Add(almacena.GetString(0));
                lNombrePuntoVenta.Add(almacena.GetString(1));

            }
            almacena.Close();

            if (lIdPuntoVenta.Count > 0)
            {
                cboPuntoVenta.SelectedIndex = 0;
            }
            else
            {
                cboPuntoVenta.Text = "";
            }
        }

        private void llenarComboBoxAreas()
        {
            lIdArea.Clear();
            lNombreArea.Clear();

            cboPuntoVenta.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select cod_area , nombre FROM tbl_area  ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboArea.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdArea.Add(almacena.GetString(0));
                lNombreArea.Add(almacena.GetString(1));

            }
            almacena.Close();

            if (lIdArea.Count > 0)
            {
                cboArea.SelectedIndex = 0;
            }
            else
            {
                cboArea.Text = "";
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
            txtNombre.Text = "";
            txtApellido.Text = "";
            txt_telefono.Text = "";
            cboArea.Text = "";
            cboPuntoVenta.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sNombre = txtNombre.Text;
            string sApellido = txtApellido.Text;
            string sTelefono = txt_telefono.Text;
            string sCorreo = txtCorreo.Text;
            string sPuntoVenta = cboPuntoVenta.Text;
            string sArea = cboArea.Text;

            if (boton_ingreso == true)
            {

                if (txtNombre.Text.Trim() == "" || txt_telefono.Text.Trim() == "" || txtCorreo.Text.Trim() == ""
                    || txtApellido.Text.Trim() == "" || cboArea.Text.Trim() == "" || cboPuntoVenta.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_empleado(nombre, apellido, telefono, correo_electronico, cod_punto_venta, cod_area, estado) " +
                            "VALUES ('" + sNombre
                            + "', '" + sApellido
                            + "', '" + sTelefono
                            + "', '" + sCorreo
                            + "', '" + lIdPuntoVenta[cboPuntoVenta.SelectedIndex]
                            + "', '" + lIdArea[cboArea.SelectedIndex] + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        MessageBox.Show("Empleado ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();

                        sInsertar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                "accion, " +
                                "fecha, " +
                                "hora, " +
                                "IP) " +
                                "VALUES(" + sIdUsuario + "" +
                                ",'Inserto un empleado: " + sNombre +
                                "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                ",'" + myIP + "')";
                        sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar un Empleado" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtNombre.Text.Trim() == "" || txt_telefono.Text.Trim() == "" || txtCorreo.Text.Trim() == ""
                    || txtApellido.Text.Trim() == "" || cboArea.Text.Trim() == "" || cboPuntoVenta.Text.Trim() == "")
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
                        string sModificarCliente = "UPDATE tbl_empleado SET nombre = '" + sNombre
                            + "', apellido = '" + sApellido
                             + "', telefono = '" + sTelefono
                              + "', correo_electronico = '" + sCorreo
                               + "', cod_punto_venta = '" + lIdPuntoVenta[cboPuntoVenta.SelectedIndex]
                            + "', cod_area = '" + lIdArea[cboArea.SelectedIndex]
                              + "', estado = '" + sEstado
                            + "' WHERE PK_idEmpleado = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();

                        MessageBox.Show("Empleado Modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();

                        sModificarCliente = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                "accion, " +
                                "fecha, " +
                                "hora, " +
                                "IP) " +
                                "VALUES(" + sIdUsuario + "" +
                                ",'Modifico un empleado: " + sNombre +
                                "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                ",'" + myIP + "')";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de empleado: " + ex.Message);
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

                    string sEliminar = "UPDATE tbl_empleado SET estado = '0' WHERE PK_idEmpleado = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Empleado eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();

                    sEliminar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                "accion, " +
                                "fecha, " +
                                "hora, " +
                                "IP) " +
                                "VALUES(" + sIdUsuario + "" +
                                ",'Elimino un empleado: " + sNombre +
                                "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                ",'" + myIP + "')";
                    sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del Empleado: " + ex.Message);
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
                string sRecuperarClientes = "SELECT tbl_empleado.PK_idEmpleado, tbl_empleado.nombre, tbl_empleado.apellido, " +
                    "tbl_empleado.correo_electronico, tbl_empleado.telefono, tbl_punto_venta.nombre, tbl_area.nombre, tbl_empleado.estado " +
                    "FROM tbl_empleado INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta " +
                    "INNER JOIN tbl_area ON tbl_empleado.cod_area = tbl_area.cod_area where tbl_empleado.estado = 1";
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgv_clientes.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(1), almacenaClientes.GetString(2), almacenaClientes.GetString(3), almacenaClientes.GetString(4)
                        , almacenaClientes.GetString(5), almacenaClientes.GetString(6), almacenaClientes.GetString(7));
                }
                almacenaClientes.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la recuperacion de empleados: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txt_telefono.Enabled = true;
            txtCorreo.Enabled = true;
            cboArea.Enabled = true;
            cboPuntoVenta.Enabled = true;
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
            txtNombre.Text = "";
            txtApellido.Text = "";
            txt_telefono.Text = "";
            txtCorreo.Text = "";
            cboArea.Text = "";
            cboPuntoVenta.Text = "";
            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txt_telefono.Enabled = false;
            txtCorreo.Enabled = false;
            cboArea.Enabled = false;
            cboPuntoVenta.Enabled = false;
            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_empleado.PK_idEmpleado, tbl_empleado.nombre, tbl_empleado.apellido, " +
                    "tbl_empleado.correo_electronico, tbl_empleado.telefono, tbl_punto_venta.nombre, tbl_area.nombre, tbl_empleado.estado " +
                    "FROM tbl_empleado INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta " +
                    "INNER JOIN tbl_area ON tbl_empleado.cod_area = tbl_area.cod_area  WHERE tbl_empleado.nombre LIKE '%" + txt_buscar.Text + "%'";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4), almacena.GetString(5), almacena.GetString(6), almacena.GetString(7));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();
            txtCorreo.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();
            txt_telefono.Text = dgv_clientes.CurrentRow.Cells[4].Value.ToString();

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

        private void frmEmpleados_Load(object sender, EventArgs e)
        {

        }
    }
}
