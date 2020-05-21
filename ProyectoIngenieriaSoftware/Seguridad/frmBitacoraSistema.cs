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

namespace ProyectoIngenieriaSoftware.Seguridad
{
    public partial class frmBitacoraseguridad : Form
    {

        List<String> lIdUsuario = new List<String>();
        OdbcConnection con;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        public frmBitacoraseguridad(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;

            llenarComboBoxUsuarios();
        }

        private void llenarComboBoxUsuarios()
        {
            lIdUsuario.Clear();

            cboEncargado.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select tbl_usuario.PK_idUsuario, tbl_empleado.apellido, tbl_empleado.nombre FROM tbl_usuario " +
                "INNER JOIN tbl_empleado on tbl_usuario.PK_idEmpleado = tbl_empleado.PK_idEmpleado WHERE tbl_usuario.estado = 1 ORDER BY tbl_usuario.PK_idEmpleado DESC ", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboEncargado.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) + "," + almacena.GetString(2));
                lIdUsuario.Add(almacena.GetString(0));

            }
            almacena.Close();

            if (lIdUsuario.Count > 0)
            {
                cboEncargado.SelectedIndex = 0;
            }
            else
            {
                cboEncargado.Text = "";
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void frmBitacoraseguridad_Load(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void llenarDataGrid()
        {
            dataGridView1.Rows.Clear();

            string sBuscar = "SELECT tbl_bitacora_seguridad.PK_idBitacora" +
                ",tbl_bitacora_seguridad.PK_idUsuario" +
                ", tbl_usuario.nombre_usuario" +
                ", tbl_bitacora_seguridad.accion" +
                ", tbl_bitacora_seguridad.fecha" +
                ", tbl_bitacora_seguridad.hora" +
                ", tbl_bitacora_seguridad.ip " +
                " FROM tbl_bitacora_seguridad INNER JOIN tbl_usuario" +
                " ON tbl_bitacora_seguridad.PK_idUsuario = tbl_usuario.PK_idUsuario" +
                " WHERE tbl_bitacora_seguridad.PK_idUsuario = " + lIdUsuario[cboEncargado.SelectedIndex]+
                " AND tbl_bitacora_seguridad.fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpFinal.Value.ToString("yyyy-MM-dd") + "'";
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dataGridView1.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3)
                    , almacena.GetString(4), almacena.GetString(5), almacena.GetString(6));
            }
            almacena.Close();
        }
    }
}
