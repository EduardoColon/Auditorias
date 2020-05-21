using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Net;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmUsuarios : Form
    {

        OdbcConnection con;

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        List<String> lIdEmpleados = new List<String>();
        List<String> lNombreEmpleados = new List<String>();


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


        public frmUsuarios(OdbcConnection con, string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();
            this.con = con;

            cboPrivilegios.SelectedIndex = 0;

            rdb_actio.Checked = true;
            Btn_guardar.Enabled = false;
            bloquearTextBox();
            ActualizarGrid();
            llenarComboBoxEmpleados();

            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            if (sNivelPrivilegios == "Lectura")
                panel2.Enabled = false;
        }


        private void llenarComboBoxEmpleados()
        {
            lIdEmpleados.Clear();
            lNombreEmpleados.Clear();

            cboEmpleado.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idEmpleado, apellido, nombre FROM tbl_empleado WHERE estado = 1 ORDER BY PK_idEmpleado DESC ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEmpleado.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) + "," + almacena.GetString(2));
                lIdEmpleados.Add(almacena.GetString(0));
                lNombreEmpleados.Add(almacena.GetString(1));

            }
            almacena.Close();

            if (lNombreEmpleados.Count > 0)
            {
                cboEmpleado.SelectedIndex = 0;
            }
            else
            {
                cboEmpleado.Text = "";
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

        private void frmUSuarios_Load(object sender, EventArgs e)
        {

        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            txtNombre.Text = "";
            txtClave.Text = "";
            txtClaveDos.Text = "";
            cboEmpleado.Text = "";
            cboPrivilegios.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sNombre = txtNombre.Text;
            string sClave = txtClave.Text;

            if (boton_ingreso == true)
            {

                if (txtNombre.Text.Trim() == "" || txtClave.Text.Trim() == "" || txtClaveDos.Text.Trim() == ""
                    || cboEmpleado.Text.Trim() == "" || cboPrivilegios.Text.Trim() == "" || txtClave.Text != txtClaveDos.Text)
                {
                    MessageBox.Show("Faltan campos por llenar o las claves no coinciden");
                }
                else
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_usuario(nombre_usuario, clave, nivel_privilegios, PK_idEmpleado, estado) " +
                            "VALUES ('" + sNombre
                            + "', '" + sClave
                            + "', '" + cboPrivilegios.Text
                            + "', '" + lIdEmpleados[cboEmpleado.SelectedIndex]
                            + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        MessageBox.Show("Usuario ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();

                        sInsertar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                             "accion, " +
                             "fecha, " +
                             "hora, " +
                             "IP) " +
                             "VALUES(" + sIdUsuario + "" +
                             ",'Inserto un usuario: " + sNombre +
                             "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                             ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                             ",'" + myIP + "')";
                        sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar un usuario" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtNombre.Text.Trim() == "" || txtClave.Text.Trim() == "" || txtClaveDos.Text.Trim() == ""
                    || cboEmpleado.Text.Trim() == "" || cboPrivilegios.Text.Trim() == "" || txtClave.Text != txtClaveDos.Text)
                {
                    MessageBox.Show("Faltan campos por llenar o las claves no coinciden");
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
                        string sModificarCliente = "UPDATE tbl_usuario SET nombre_usuario = '" + sNombre
                            + "', clave = '" + sClave
                            + "', nivel_privilegios = '" + cboPrivilegios.Text
                            + "', PK_idEmpleado = '" + lIdEmpleados[cboEmpleado.SelectedIndex]
                             + "', estado = '" + sEstado
                            + "' WHERE PK_idUsuario = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();

                        MessageBox.Show("Usuario modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();

                        sModificarCliente = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                             "accion, " +
                             "fecha, " +
                             "hora, " +
                             "IP) " +
                             "VALUES(" + sIdUsuario + "" +
                             ",'Modifico un usuario: " + txtCodigo.Text+
                             "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                             ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                             ",'" + myIP + "')";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de Usuario: " + ex.Message);
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

                    string sEliminar = "UPDATE tbl_usuario SET estado = '0' WHERE PK_idUsuario = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Usuario eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();

                    sEliminar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                             "accion, " +
                             "fecha, " +
                             "hora, " +
                             "IP) " +
                             "VALUES(" + sIdUsuario + "" +
                             ",'Elimino un usuario: " + iCodigo+
                             "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                             ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                             ",'" + myIP + "')";
                    sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del usuario: " + ex.Message);
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
                string sRecuperarClientes = "SELECT tbl_usuario.PK_idUsuario, tbl_empleado.nombre , tbl_usuario.nombre_usuario " +
                    ", tbl_usuario.nivel_privilegios, tbl_usuario.ultima_sesion, tbl_usuario.estado " +
                    "FROM tbl_usuario INNER JOIN tbl_empleado ON tbl_usuario.PK_idEmpleado = tbl_empleado.PK_idEmpleado where tbl_usuario.estado = 1";
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgv_clientes.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(1), almacenaClientes.GetString(2), almacenaClientes.GetString(3), almacenaClientes.GetString(4), almacenaClientes.GetString(5));
                }
                almacenaClientes.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la recuperacion de usuarios: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtClave.Enabled = true;
            txtClaveDos.Enabled = true;
            cboEmpleado.Enabled = true;
            cboPrivilegios.Enabled = true;
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
            txtClave.Text = "";
            txtClaveDos.Text = "";
            cboPrivilegios.Text = "";
            cboEmpleado.Text = "";
            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtClave.Enabled = false;
            txtClaveDos.Enabled = false;
            cboEmpleado.Enabled = false;
            cboPrivilegios.Enabled = false;
            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_usuario.PK_idUsuario, tbl_empleado.nombre , tbl_usuario.nombre_usuario " +
                    ", tbl_usuario.nivel_privilegios, tbl_usuario.ultima_sesion, tbl_usuario.estado " +
                    "FROM tbl_usuario INNER JOIN tbl_empleado ON tbl_usuario.PK_idEmpleado = tbl_empleado.PK_idEmpleado WHERE tbl_usuario.nombre_usuario LIKE '%" + txt_buscar.Text + "%'";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4), almacena.GetString(5));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();

            if (dgv_clientes.CurrentRow.Cells[5].Value.ToString() == "1")
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
