using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Auditorias
{
    public partial class frmConsultarAuditoria : Form
    {

        OdbcConnection con;
        List<String> lIdAreas = new List<String>();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmConsultarAuditoria(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;
            llenarComboBoxAreas();
        }

        private void llenarComboBoxAreas()
        {
            lIdAreas.Clear();

            cboArea.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select tbl_area.cod_area, tbl_area.nombre FROM tbl_area", con);
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

        private void frmPlanificarAuditoria_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAuditorias.Rows.Clear();
                string sRecuperarClientes = "SELECT tbl_auditoria_encabezado.PK_idAuditoria, " +
                    " tbl_empleado.nombre, tbl_empleado.apellido, tbl_auditoria_encabezado.fecha_real " +
                    " FROM tbl_auditoria_encabezado INNER JOIN tbl_usuario ON " +
                    " tbl_auditoria_encabezado.PK_idUSuario = tbl_usuario.PK_idUSuario " +
                    " INNER JOIN tbl_empleado ON tbl_usuario.PK_idEmpleado = tbl_empleado.PK_idEmpleado" +
                    " WHERE tbl_auditoria_encabezado.estado = 1 AND tbl_auditoria_encabezado.cod_area=" + lIdAreas[cboArea.SelectedIndex]
                    + " AND tbl_auditoria_encabezado.fecha_real BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND '" + dtpFinal.Value.ToString("yyyy-MM-dd")
                    +"'";
                OdbcCommand sqlRecuperarClientes = new OdbcCommand(sRecuperarClientes, con);
                OdbcDataReader almacenaClientes = sqlRecuperarClientes.ExecuteReader();

                while (almacenaClientes.Read())
                {

                    dgvAuditorias.Rows.Add(almacenaClientes.GetInt32(0), almacenaClientes.GetString(2) + " ," + almacenaClientes.GetString(1), almacenaClientes.GetString(3));
                }
                almacenaClientes.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la auditorias: " + ex.Message);
                MessageBox.Show("Ocurrio un error, intentelo de nuevo");
            }
        }

        private void dgvAuditorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmConsultaAuditoriaDetalle consultaAuditoriaDetalle = new frmConsultaAuditoriaDetalle(con, dgvAuditorias.CurrentRow.Cells[0].Value.ToString());
            consultaAuditoriaDetalle.ShowDialog();
        }
    }
}
