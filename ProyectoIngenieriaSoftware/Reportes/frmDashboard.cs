using LiveCharts;
using LiveCharts.Wpf;
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

namespace ProyectoIngenieriaSoftware.Reportes
{
    public partial class frmDashboard : Form
    {
        OdbcConnection con;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        Func<ChartPoint, string> labelNumActivos = pcNumActivos => string.Format("{0} ({1:P})", pcNumActivos.Y, pcNumActivos.Participation);


        public frmDashboard(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;

            llenarPieChartNumActivos();
        }

        private void llenarPieChartNumActivos()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();


            try
            {
                string sBuscar = "SELECT SUM(tbl_inventario_hardware.cantidad)" +
             ", tbl_area.nombre" +
             "  FROM tbl_inventario_hardware INNER JOIN tbl_area " +
             " ON tbl_inventario_hardware.cod_area = tbl_area.cod_area" +
             "  GROUP BY  tbl_inventario_hardware.cod_area";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                       {
                           Title = almacena.GetString(1).ToString(),
                           Values = new ChartValues<int> { valor  },
                           DataLabels = true,
                           LabelPoint = labelNumActivos
                       });

                }
                almacena.Close();

                pcNumActivos.Series = seriesNumActivos;
                pcNumActivos.LegendLocation = LegendLocation.Bottom;
            }catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pcNumActivos_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
