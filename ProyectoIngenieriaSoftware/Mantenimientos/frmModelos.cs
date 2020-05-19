using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Mantenimientos
{


    public partial class frmModelos : Form
    {

        OdbcConnection con;

        List<String> lIdMarca = new List<String>();
        List<String> lNombreMarca = new List<String>();

        bool boton_ingreso = false;
        bool boton_modificar = false;
        bool boton_eliminar = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public frmModelos(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;

            rdb_actio.Checked = true;
            Btn_guardar.Enabled = false;
            bloquearTextBox();
            ActualizarGrid();
            llenarComboBoxMarcas();
        }

        private void llenarComboBoxMarcas()
        {
            lIdMarca.Clear();
            lNombreMarca.Clear();

            cboMarca.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idMarca, nombre FROM tbl_marca WHERE estado = 1 ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboMarca.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdMarca.Add(almacena.GetString(0));
                lNombreMarca.Add(almacena.GetString(1));

            }
            almacena.Close();

            if (lIdMarca.Count > 0)
            {
                cboMarca.SelectedIndex = 0;
            }
            else
            {
                cboMarca.Text = "";
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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            habilitarBotones();
            bloquearBotones();
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cboMarca.Text = "";
            gpb_estado.Enabled = false;
            boton_ingreso = true;
            tc_Clientes.SelectedTab = tp_abc;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string sNombre = txtNombre.Text;
            string sDescripcion = txtDescripcion.Text;
            string sMarca = cboMarca.Text;

            if (boton_ingreso == true)
            {

                if (txtNombre.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || cboMarca.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_modelo(nombre, descripcion, cod_marca, estado) " +
                            "VALUES ('" + sNombre
                            + "', '" + sDescripcion
                            + "', '" + lIdMarca[cboMarca.SelectedIndex] + "', '1')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        MessageBox.Show("Marca ingresada Exitosamente");
                        dgv_clientes.Rows.Clear();
                        limpiarForm();
                        ActualizarGrid();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar una marca" + ex.Message);
                        MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                    }
                    tc_Clientes.SelectedTab = tp_datos;

                }
            }
            else if (boton_modificar == true)
            {
                if (txtNombre.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || cboMarca.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    string sEstado;
                    if (rdb_actio.Checked)
                        sEstado = "1";
                    else
                        sEstado = "0";

                    try
                    {
                        string sModificarCliente = "UPDATE tbl_modelo SET nombre = '" + sNombre
                            + "', descripcion = '" + sDescripcion
                            + "', cod_marca = '" + lIdMarca[cboMarca.SelectedIndex]
                             + "', estado = '" + sEstado
                            + "' WHERE PK_idModelo = '" + txtCodigo.Text + "'; ";
                        OdbcCommand sqlModificar = new OdbcCommand(sModificarCliente, con);
                        sqlModificar.ExecuteNonQuery();

                        MessageBox.Show("Modelo modificada exitosamente");
                        dgv_clientes.Rows.Clear();

                        limpiarForm();
                        ActualizarGrid();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error en la modificacion de modelo: " + ex.Message);
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

                    string sEliminar = "UPDATE tbl_modelo SET estado = '0' WHERE PK_idModelo = '" + iCodigo + "'; ";
                    OdbcCommand sqlEliminar = new OdbcCommand(sEliminar, con);
                    sqlEliminar.ExecuteNonQuery();

                    MessageBox.Show("Modelo eliminado Exitosamente");
                    dgv_clientes.Rows.Clear();
                    limpiarForm();
                    ActualizarGrid();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en la eliminacion del punto de modelo: " + ex.Message);
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
                string sRecuperarClientes = "SELECT tbl_modelo.PK_idModelo, tbl_marca.nombre , tbl_modelo.nombre " +
                    ", tbl_modelo.descripcion, tbl_modelo.estado FROM tbl_modelo INNER JOIN tbl_marca " +
                    "ON tbl_modelo.cod_marca= tbl_marca.PK_idMarca where tbl_modelo.estado = 1";
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
                Console.WriteLine("Error en la recuperacion de modelos: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        void habilitarBotones()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            cboMarca.Enabled = true;
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
            txtDescripcion.Text = "";
            cboMarca.Text = "";
            gpb_estado.Enabled = false;
        }

        void bloquearTextBox()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            cboMarca.Enabled = false;
            gpb_estado.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            dgv_clientes.Rows.Clear();
            string sBuscar = "SELECT tbl_modelo.PK_idModelo, tbl_marca.nombre , tbl_modelo.nombre " +
                    ", tbl_modelo.descripcion, tbl_modelo.estado FROM tbl_modelo INNER JOIN tbl_marca " +
                    "ON tbl_modelo.cod_marca= tbl_marca.PK_idMarca WHERE tbl_modelo.nombre LIKE '%" + txt_buscar.Text + "%'";
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
            txtNombre.Text = dgv_clientes.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = dgv_clientes.CurrentRow.Cells[3].Value.ToString();

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
    }
}
