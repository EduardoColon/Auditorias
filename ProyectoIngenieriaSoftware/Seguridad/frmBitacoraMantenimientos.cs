using System;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Seguridad
{
    public partial class frmBitacoraMantenimientos : Form
    {

        OdbcConnection con;
        string sArea;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmBitacoraMantenimientos(OdbcConnection con, string sArea)
        {
            InitializeComponent();
            this.con = con;
            this.sArea = sArea;
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

        private void frmBitacoraMantenimientos_Load(object sender, EventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void llenarDataGrid()
        {

            try
            {
                dataGridView1.Rows.Clear();

                string sBuscar = "SELECT tbl_bitacora_mantenimiento.PK_idBitacora" +
                    ",tbl_bitacora_mantenimiento.PK_idActivo" +
                    ", tbl_bitacora_mantenimiento.fecha" +
                    ", tbl_empleado.apellido" +
                    ", tbl_empleado.nombre" +
                    ", tbl_bitacora_mantenimiento.anotaciones" +
                    ", tbl_bitacora_mantenimiento.fecha_proximo_servicio " +
                    " FROM tbl_bitacora_mantenimiento INNER JOIN tbl_empleado" +
                    " ON tbl_bitacora_mantenimiento.ingeniero_responsable = tbl_empleado.PK_idEmpleado" +
                    " WHERE tbl_empleado.cod_area= " + sArea +
                    " AND tbl_bitacora_mantenimiento.fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpFinal.Value.ToString("yyyy-MM-dd") + "'";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();
                Console.WriteLine(sBuscar);
                while (almacena.Read())
                {
                    dataGridView1.Rows.Add(almacena.GetInt32(0), almacena.GetString(1), almacena.GetString(2), almacena.GetString(3)
                        + ", " + almacena.GetString(4), almacena.GetString(5), almacena.GetString(6));
                }
                almacena.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
