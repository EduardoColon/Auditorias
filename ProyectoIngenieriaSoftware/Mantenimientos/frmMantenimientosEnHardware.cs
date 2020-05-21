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
    public partial class frmMantenimientosEnHardware : Form
    {
        List<String> lIdEmpleados = new List<String>();
        List<String> lActivosId = new List<String>();
        List<String> lActivosNumSerie = new List<String>();
        List<String> lActivosNumPlaca = new List<String>();
        List<String> lActivosValor = new List<String>();
        List<String> lACtivoUbicacion = new List<String>();
        List<String> lACtivoNombre = new List<String>();
        List<String> lActivosFechaCompra = new List<String>();
        List<String> lActivosNombreEmpleado = new List<String>();
        List<String> lCodAuditoria = new List<String>();

        OdbcConnection con;
        string sArea;

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

        public frmMantenimientosEnHardware(OdbcConnection con, string sArea, string sIdUsuario)
        {
            InitializeComponent();

            this.con = con;
            this.sArea = sArea;
            this.sIdUsuario = sIdUsuario;

            llenarComboBoxActivos();
            llenarComboBoxEmpleados();
        }

        private void llenarComboBoxActivos()
        {
            lActivosId.Clear();
            lActivosNumPlaca.Clear();
            lActivosNumSerie.Clear();
            lActivosFechaCompra.Clear();
            lActivosValor.Clear();
            lActivosNombreEmpleado.Clear();
            lACtivoNombre.Clear();
            lACtivoUbicacion.Clear();
            cboActivo.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select tbl_activo.PK_idActivo " +
                ", tbl_activo.fecha_compra " +
                ", tbl_activo.valor " +
                ", tbl_empleado.nombre" +
                ", tbl_empleado.apellido" +
                ", tbl_inventario_hardware.numero_serie" +
                ", tbl_inventario_hardware.numero_placa" +
                ", tbl_inventario_hardware.nombre" +
                ", tbl_punto_venta.direccion" +
                " FROM tbl_activo INNER JOIN tbl_inventario_hardware " +
                " ON tbl_activo.PK_idActivo = TBL_inventario_hardware.PK_idActivo " +
                " INNER JOIN tbl_empleado " +
                " ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado " +
                " INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta" +
                " WHERE tbl_inventario_hardware.cod_area =" + sArea, con);

            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboActivo.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(7));

                lActivosId.Add(almacena.GetString(0));
                lActivosFechaCompra.Add(almacena.GetDate(1).ToString());
                lActivosValor.Add(almacena.GetDouble(2).ToString());
                lActivosNombreEmpleado.Add(almacena.GetString(4) + ", " + almacena.GetString(3));
                lActivosNumSerie.Add(almacena.GetString(5));
                lActivosNumPlaca.Add(almacena.GetString(6));
                lACtivoNombre.Add(almacena.GetString(7));
                lACtivoUbicacion.Add(almacena.GetString(8));
            }
            almacena.Close();


        }

        private void llenarComboBoxEmpleados()
        {
            lIdEmpleados.Clear();

            cboEmpleado.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select PK_idEmpleado, apellido, nombre FROM tbl_empleado WHERE estado = 1 ORDER BY PK_idEmpleado DESC ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEmpleado.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) + "," + almacena.GetString(2));
                lIdEmpleados.Add(almacena.GetString(0));

            }
            almacena.Close();

            if (lIdEmpleados.Count > 0)
            {
                cboEmpleado.SelectedIndex = 0;
            }
            else
            {
                cboEmpleado.Text = "";
            }
        }


        private void frmMantenimientosEnHardware_Load(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboActivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtActivo.Text = lACtivoNombre[cboActivo.SelectedIndex];
            txtEmpleado.Text = lActivosNombreEmpleado[cboActivo.SelectedIndex];
            txtFechaCompra.Text = lActivosFechaCompra[cboActivo.SelectedIndex];
            txtNumPlaca.Text = lActivosNumPlaca[cboActivo.SelectedIndex];
            txtNumSerie.Text = lActivosNumSerie[cboActivo.SelectedIndex];
            txtValor.Text = lActivosValor[cboActivo.SelectedIndex];
            txtUbicacion.Text = lACtivoUbicacion[cboActivo.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cboActivo.Text.Trim() == "" || cboEmpleado.Text.Trim() == "" || txtAnotaciones.Text.Trim() == "" || dtpProxServicio.Text.Trim() == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
            else
            {
                bool bExito = true;

                DialogResult dialogResult = MessageBox.Show("¿Desea registrar el mantenimiento?", "Registrar auditoria", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        string sInsertar = "INSERT INTO tbl_bitacora_mantenimiento(PK_idActivo, Fecha, anotaciones, ingeniero_responsable, fecha_proximo_servicio) " +
                           "VALUES ('" + lActivosId[cboActivo.SelectedIndex]
                           + "', '" + DateTime.Now.ToString("yyyy-MM-dd")
                           + "', '" + txtAnotaciones.Text.Trim()
                           + "', '" + lIdEmpleados[cboEmpleado.SelectedIndex]
                           + "', '" + dtpProxServicio.Value.ToString("yyyy-MM-dd")
                           + "')";
                        OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                        sqlInsertar.ExecuteNonQuery();

                        sInsertar = "INSERT INTO tbl_bitacora_seguridad (PK_idUsuario, " +
                           "accion, " +
                           "fecha, " +
                           "hora, " +
                           "IP) " +
                           "VALUES(" + sIdUsuario + "" +
                           ",'Registro un mantenimiento sobre el activo: " + lActivosId[cboActivo.SelectedIndex] +
                           "','" + DateTime.Now.ToString("yyy/MM/dd") + "'" +
                           ",'" + DateTime.Now.ToString("hh:mm:ss") + "'" +
                           ",'" + myIP + "')";
                         sqlInsertar = new OdbcCommand(sInsertar, con);
                         sqlInsertar.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al intentar registrar el mantenimiento");
                        bExito = !bExito;
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (bExito)
                        {
                            MessageBox.Show("Mantenimiento registrado exitosamente");
                            txtAnotaciones.Text = "";
                            dtpProxServicio.Value = DateTime.Now;
                        }
                    }
                }
            }
        }
    }
}
