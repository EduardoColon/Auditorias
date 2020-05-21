using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Auditorias
{
    public partial class frmRegistrarAuditoria : Form
    {
        string sIdUsuario;
        string sCodAuditoriaActual = "";
        OdbcConnection con;

        List<String> lIdAuditorias = new List<String>();
        List<String> lActivosId = new List<String>();
        List<String> lActivosNumSerie = new List<String>();
        List<String> lActivosNumPlaca = new List<String>();
        List<String> lActivosValor = new List<String>();
        List<String> lACtivoUbicacion = new List<String>();
        List<String> lACtivoNombre = new List<String>();
        List<String> lActivosFechaCompra = new List<String>();
        List<String> lActivosNombreEmpleado = new List<String>();
        List<String> lCodAuditoria = new List<String>();
        List<String> lActivosSeleccionados = new List<String>();


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmRegistrarAuditoria(string sIdUsuario, OdbcConnection con)
        {
            InitializeComponent();
            this.sIdUsuario = sIdUsuario;
            this.con = con;

            llenarComboBoxAuditorias();
        }

        private void llenarComboBoxAuditorias()
        {
            lIdAuditorias.Clear();

            cboAuditoria.Items.Clear();

            OdbcCommand sql = new OdbcCommand("Select tbl_auditoria_encabezado.PK_idAuditoria, " +
                "tbl_auditoria_encabezado.fecha, tbl_area.nombre, tbl_auditoria_encabezado.cod_area FROM tbl_auditoria_encabezado " +
                "INNER JOIN tbl_area on tbl_auditoria_encabezado.cod_area = tbl_area.cod_area " +
                "WHERE tbl_auditoria_encabezado.PK_idUsuario = '" + sIdUsuario + "' AND tbl_auditoria_encabezado.estado = 0", con);
            OdbcDataReader almacena = sql.ExecuteReader();
            while (almacena.Read() == true)
            {
                cboAuditoria.Items.Add(almacena.GetString(0) + " - " + almacena.GetString(1) + "  ,  " + almacena.GetString(2));
                lIdAuditorias.Add(almacena.GetString(0));
                lCodAuditoria.Add(almacena.GetString(3));
            }
            almacena.Close();

            if (lIdAuditorias.Count > 0)
            {
                cboAuditoria.SelectedIndex = 0;
            }
            else
            {
                cboAuditoria.Text = "";
            }
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
                " INNER JOIN tbl_auditoria_encabezado ON tbl_inventario_hardware.cod_area = tbl_auditoria_encabezado.cod_area" +
                " INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta" +
                " WHERE tbl_auditoria_encabezado.estado = 0 " +
                " AND tbl_auditoria_encabezado.cod_area =" + sCodAuditoriaActual, con);

            MessageBox.Show(sCodAuditoriaActual);
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

        private void cboAuditoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvActivos.Rows.Clear();
            lActivosSeleccionados.Clear();
            sCodAuditoriaActual = lCodAuditoria[cboAuditoria.SelectedIndex];
         
            llenarComboBoxActivos();
          
            txtActivo.Text = "";
            txtEmpleado.Text = "";
            txtFechaCompra.Text = "";
            txtNumPlaca.Text = "";
            txtNumSerie.Text = "";
            txtValor.Text = "" ;
            txtUbicacion.Text = "";
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
            if (lActivosSeleccionados.Contains(lActivosId[cboActivo.SelectedIndex]))
            {
                MessageBox.Show("El activo ya fue seleccionado en esta auditoria");
            }
            else
            {

                if (txtObservaciones.Text.Trim() == "" || txtActivo.Text == "" || txtDepreciacion.Text.Trim() == "")
                {
                    MessageBox.Show("Faltan campos por llenar");
                }
                else
                {
                    lActivosSeleccionados.Add(lActivosId[cboActivo.SelectedIndex]);

                    dgvActivos.Rows.Add(lActivosId[cboActivo.SelectedIndex],
                        txtEmpleado.Text,
                        txtValor.Text,
                        txtDepreciacion.Value.ToString(),
                        txtObservaciones.Text);

                    MessageBox.Show("Activo agregado a la presente auditoria");

                }
            }        
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if(dgvActivos.Rows.Count == 0)
            {
                MessageBox.Show("No ha agregado ningun activo a la auditoria");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea registrar la auditoria?", "Registrar auditoria", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OdbcCommand command = new OdbcCommand();
                    OdbcTransaction transaction = null;
                    bool exito =true;

                    try
                    {
                        transaction = con.BeginTransaction();
                        command.Connection = con;
                        command.Transaction = transaction;

                        command.CommandText =
                                    "UPDATE tbl_auditoria_encabezado SET estado = 1" +
                                    ", fecha_real = ' "+ DateTime.Now.ToString("yyyy-MM-dd") +
                                      "' WHERE PK_idAuditoria =" + lIdAuditorias[cboAuditoria.SelectedIndex];
                        command.ExecuteNonQuery();

                        foreach(DataGridViewRow row in dgvActivos.Rows)
                        {
                            command.CommandText =
                                    "UPDATE tbl_activo SET depreciacion =" + txtDepreciacion.Value.ToString() +
                                    ", fecha_ultima_auditoria = ' " + DateTime.Now.ToString("yyyy-MM-dd") +
                                      "' WHERE PK_idActivo =" + row.Cells[0].Value.ToString();
                            command.ExecuteNonQuery();

                            command.CommandText =
                                    "INSERT INTO tbl_auditoria_detalle (PK_idAuditoria, PK_idActivo, detalles) " +
                                    "VALUES (" + lIdAuditorias[cboAuditoria.SelectedIndex] +
                                    ", " + row.Cells[0].Value.ToString() +
                                     ", '" + row.Cells[4].Value.ToString() +"')";
                            command.ExecuteNonQuery();
                        }
                       
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        exito = false;
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Ocurrio un error al intentar registrar la auditoria");
                    }
                    finally
                    {
                        if (exito)
                        {
                            MessageBox.Show("Auditoria registrada correctamente");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
