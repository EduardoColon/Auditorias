using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Auditorias
{
    public partial class frmPlanificarAuditoria : Form
    {
        OdbcConnection con;

        List<String> lIdUsuario = new List<String>();
        List<String> lIdAreas = new List<String>();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmPlanificarAuditoria(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;

            llenarComboBoxUsuarios();
            llenarComboBoxAreas();
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

        private void llenarComboBoxAreas()
        {
            lIdAreas.Clear();

            cboArea.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select tbl_area.cod_area, tbl_area.nombre FROM tbl_area" , con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboArea.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1));
                lIdAreas.Add(almacena.GetString(0));

            }
            almacena.Close();

            if (lIdAreas.Count > 0)
            {
                cboArea.SelectedIndex = 0;
            }
            else
            {
                cboArea.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sFecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            if (txtDetalles.Text.Trim() == "" || cboArea.Text.Trim() == "" || cboEncargado.Text.Trim() == "" || dtpFecha.Text.Trim() == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
            {
                try
                {
                    string sInsertar = "INSERT INTO tbl_auditoria_encabezado(PK_idUsuario, fecha, anotacion_general, cod_area) " +
                        "VALUES ('" + lIdUsuario[cboEncargado.SelectedIndex]
                        + "', '" + sFecha
                        + "', '" + txtDetalles.Text.Trim()
                        + "', '" + lIdAreas[cboArea.SelectedIndex]   + "')";
                    OdbcCommand sqlInsertar = new OdbcCommand(sInsertar, con);
                    sqlInsertar.ExecuteNonQuery();

                    MessageBox.Show("Auditoria planificada correctamente");               
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al planificar auditoria" + ex.Message);
                    MessageBox.Show("Ocurrio un error, intentelo de nuevo");
                }
            }
        }
        
        private void limpiarForm()
        {
            txtDetalles.Text = "";
            cboArea.Text = "";
            cboEncargado.Text = "";

        }
    }
}
