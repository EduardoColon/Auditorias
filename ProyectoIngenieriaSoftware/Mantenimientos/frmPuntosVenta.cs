using Inventarios;
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


    public partial class frmPuntosVenta : Form
    {

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        string sIdUsuario = "";
        string sNivelPrivilegios = "";

        public static string host = Dns.GetHostName();
        string myIP = Dns.GetHostByName(host).AddressList[0].ToString();

        OdbcConnection con;

        List<String> lIdEmpresa = new List<String>();
        List<String> lNombreEmpresa = new List<String>();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public frmPuntosVenta(OdbcConnection con, string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();

            this.con = con;
            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            rdb_actio.Checked = true;
            Btn_guardar.Enabled = false;
            bloquearTextBox();
            ActualizarGrid();
            llenarComboBoxEmpresas();

            if (sNivelPrivilegios == "Lectura")
                panel2.Enabled = false;
        }

        private void llenarComboBoxEmpresas()
        {
            lIdEmpresa.Clear();
            lNombreEmpresa.Clear();

            cboEmpresa.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idEmpresa, nombre FROM tbl_empresa WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEmpresa.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdEmpresa.Add(almacena.GetString(0));
                lNombreEmpresa.Add(almacena.GetString(1));

            }
            almacena.Close();

            if (lIdEmpresa.Count > 0)
            {
                cboEmpresa.SelectedIndex = 0;
            }
            else
            {
                cboEmpresa.Text = "";
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
            txtDireccion.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sNombre = txtNombre.Text;
            string sEmpresa = cboEmpresa.Text;
            string sDireccion = txtDireccion.Text;

            if (boton_ingreso == true)
            {

                if (txtNombre.Text.Trim() == "" || cboEmpresa.Text.Trim() == "" || txtDireccion.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_punto_venta(nombre, cod_empresa, direccion, estado) VALUES ('" + sNombre + "', '" + lIdEmpresa[cboEmpresa.SelectedIndex] + "', '" + sDireccion + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        MessageBox.Show("Punto de venta ingresado Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();


                        sInsertar ="INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                   "accion, " +
                                   "fecha, " +
                                   "hora, " +
                                   "IP) " +
                                   "VALUES(" + sIdUsuario + "" +
                                   ",'Inserto un punto de venta: " + sNombre   +
                                   "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                   ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                   ",'" + myIP + "')" ;
                        sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar un punto de venta" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtNombre.Text.Trim() == "" || cboEmpresa.Text.Trim() == "" || txtDireccion.Text.Trim() == "")
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
                        string sModificarCliente = "UPDATE tbl_punto_venta SET nombre = '" + sNombre
                            + "', cod_empresa = '" + lIdEmpresa[cboEmpresa.SelectedIndex]
                            + "', direccion = '" + sDireccion
                            + "', estado = '" + sEstado
                            + "' WHERE PK_idPuntoVenta = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();

                        MessageBox.Show("Punto de venta Modificado Exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();

                        sModificarCliente = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                  "accion, " +
                                  "fecha, " +
                                  "hora, " +
                                  "IP) " +
                                  "VALUES(" + sIdUsuario + "" +
                                  ",'Modifico un punto de venta: " + sNombre +
                                  "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                  ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                  ",'" + myIP + "')";
                        sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de punto de venta: " + ex.Message);
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

                    string sEliminar = "UPDATE tbl_punto_venta SET estado = '0' WHERE PK_idPuntoVenta = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Punto de venta eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();

                    sEliminar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                                  "accion, " +
                                  "fecha, " +
                                  "hora, " +
                                  "IP) " +
                                  "VALUES(" + sIdUsuario + "" +
                                  ",'Elimino un punto de venta: " + sNombre +
                                  "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                                  ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                                  ",'" + myIP + "')";
                    sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del punto de venta: " + ex.Message);
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
                string sRecuperarClientes = "SELECT tbl_punto_venta.PK_idPuntoVenta, tbl_punto_venta.nombre , tbl_empresa.nombre , tbl_punto_venta.direccion, " +
                    " tbl_punto_venta.estado FROM tbl_punto_venta INNER JOIN tbl_empresa ON tbl_punto_venta.cod_empresa = tbl_empresa.PK_idEmpresa where tbl_punto_venta.estado = 1";
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgv_clientes.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(1), almacenaClientes.GetString(2), almacenaClientes.GetString(3), almacenaClientes.GetString(4));
                }
                almacenaClientes.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la recuperacion de puntos de venta: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            cboEmpresa.Enabled = true;
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
            cboEmpresa.Text = "";
            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            cboEmpresa.Enabled = false;
            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_punto_venta.PK_idPuntoVenta, tbl_punto_venta.nombre , tbl_empresa.nombre , tbl_punto_venta.direccion, " +
                    " tbl_punto_venta.estado FROM tbl_punto_venta INNER JOIN tbl_empresa ON tbl_punto_venta.cod_empresa = tbl_empresa.PK_idEmpresa WHERE tbl_punto_venta.nombre LIKE '%" + txt_buscar.Text + "%'";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgv_clientes.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3), almacena.GetString(4));
            }
            almacena.Close();
        }

        private void dgv_clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dgv_clientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[1].Value.ToString();
            txtDireccion.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();

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

        private void frmPuntosVenta_Load(object sender, EventArgs e)
        {

        }
    }
}
