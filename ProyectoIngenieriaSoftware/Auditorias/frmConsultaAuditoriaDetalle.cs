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

namespace ProyectoIngenieriaSoftware.Auditorias
{
    public partial class frmConsultaAuditoriaDetalle : Form
    {

        OdbcConnection con;
        string sIdAuditoria;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public frmConsultaAuditoriaDetalle(OdbcConnection con, string v)
        {
            InitializeComponent();
            this.con = con;
            this.sIdAuditoria = v;
            llenarDatagrid();
        }

        private void llenarDatagrid()
        {
            dgvActivos.Rows.Clear();
            string sBuscar = "SELECT tbl_auditoria_detalle.PK_idActivo, " 
                + " tbl_empleado.nombre, tbl_empleado.apellido" +
                ", tbl_punto_venta.direccion, tbl_auditoria_detalle.detalles"+
                " FROM tbl_auditoria_detalle INNER JOIN tbl_activo ON " +
                " tbl_auditoria_detalle.PK_idActivo = tbl_activo.PK_idActivo " +
                " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado " +
                " INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta " +
                "WHERE tbl_auditoria_detalle.PK_idAuditoria =" + sIdAuditoria;
            OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
            OdbcDataReader almacena = sqlBuscar.ExecuteReader();

            while (almacena.Read())
            {
                dgvActivos.Rows.Add(almacena.GetInt32(0), almacena.GetString(2)+ ", " + almacena.GetString(1), almacena.GetString(3), almacena.GetString(4));
            }
            almacena.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void frmConsultaAuditoriaDetalle_Load(object sender, EventArgs e)
        {

        }
    }
}
