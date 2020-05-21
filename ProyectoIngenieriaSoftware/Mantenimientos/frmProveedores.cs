﻿using System;
using System.Data.Odbc;
using System.Net;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmProveedores : Form
    {

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        OdbcConnection con;

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


        public frmProveedores(OdbcConnection con,string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();

            this.con = con;

            rdb_actio.Checked = true;
            Btn_guardar.Enabled = false;
            bloquearTextBox();
            ActualizarGrid();

            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            if (sNivelPrivilegios == "Lectura")
                panel2.Enabled = false;
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
            txt_telefono.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sNombre = txtNombre.Text;
            string sTelefono = txt_telefono.Text;
            string sDireccion = txtDireccion.Text;
            string sCorreo = txtCorreo.Text;

            if (boton_ingreso == true)
            {

                if (txtNombre.Text.Trim() == "" || txt_telefono.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtCorreo.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_proveedor(nombre, telefono, correo_electronico, direccion, estado) " +
                            "VALUES ('" + sNombre + "', '" + sTelefono + "', '" + sCorreo + "', '" + sDireccion + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        MessageBox.Show("Proveedor ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();

                        sInsertar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                               "accion, " +
                               "fecha, " +
                               "hora, " +
                               "IP) " +
                               "VALUES(" + sIdUsuario + "" +
                               ",'Inserto un proveedor: " + sNombre +
                               "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                               ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                               ",'" + myIP + "')";
                        sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar un proveedor" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtNombre.Text.Trim() == "" || txt_telefono.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtCorreo.Text.Trim() == "")
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
                        string sModificarCliente = "UPDATE tbl_proveedor SET nombre = '" + sNombre +
                            "', telefono = '" + sTelefono
                            + "', direccion = '" + sDireccion
                            + "', correo_electronico = '" + sCorreo
                            + "', estado = '" + sEstado
                            + "' WHERE PK_idProveedor = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();

                        MessageBox.Show("Proveedor Modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();

                        sModificarCliente = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                               "accion, " +
                               "fecha, " +
                               "hora, " +
                               "IP) " +
                               "VALUES(" + sIdUsuario + "" +
                               ",'Modifico un proveedor: " + txtCodigo.Text +
                               "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                               ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                               ",'" + myIP + "')";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de proveedor: " + ex.Message);
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

                    string sEliminar = "UPDATE tbl_proveedor SET estado = '0' WHERE PK_idProveedor = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Proveedor eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();

                    sEliminar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                               "accion, " +
                               "fecha, " +
                               "hora, " +
                               "IP) " +
                               "VALUES(" + sIdUsuario + "" +
                               ",'Elimino un proveedor: " + iCodigo +
                               "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                               ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                               ",'" + myIP + "')";
                    sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del Proveedor: " + ex.Message);
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
                string sRecuperarClientes = "SELECT PK_idProveedor, nombre, correo_electronico, telefono, direccion, estado FROM tbl_proveedor WHERE estado = 1";
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
                Console.WriteLine("Error en la recuperacion de proveedores: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txt_telefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtDireccion.Enabled = true;
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
            txtDireccion.Text = "";
            txt_telefono.Text = "";
            txtCorreo.Text = "";
            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtCorreo.Enabled = false;
            txt_telefono.Enabled = false;
            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT  PK_idProveedor, nombre, correo_electronico, telefono, direccion, estado FROM tbl_proveedor WHERE nombre LIKE '%" + txt_buscar.Text + "%'";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4), almacena.GetString(5));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dgv_clientes.CurrentRow.Cells[4].Value.ToString();
            txt_telefono.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();
            txtCorreo.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();

            if (dgv_clientes.CurrentRow.Cells[4].Value.ToString() == "1")
            {
                rdb_actio.Checked = true;
            }
            else
            {
                rdb_inactivo.Checked = true;
            }

            tc_Clientes.SelectedTab = tp_abc;
        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dgv_clientes.CurrentRow.Cells[4].Value.ToString();
            txt_telefono.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();
            txtCorreo.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();

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

        private void frmProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
