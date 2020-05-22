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



        public frmDashboard(OdbcConnection con)
        {
            InitializeComponent();
            this.con = con;

            llenarPieChartNumActivos();
            llenarPieChartAuditoriasRealizadas();
            llenarPieChartAuditoriasPendients();
            llenarPieChartEmpleadosArea();
            llenarPieChartEmpleadoPuntoVenta();
            llenarPieChartActivosPuntoVenta();
            llenarPieChartMantenimientosArea();
            llenarPieChartMantenimientosPuntoVenta();

        }

        private void llenarPieChartNumActivos()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcNumActivos => string.Format("{0} ({1:P})", pcNumActivos.Y, pcNumActivos.Participation);

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
                pcNumActivos.LegendLocation = LegendLocation.Right;
            }catch(Exception ex)
            {
               Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartActivosPuntoVenta()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcActivosPuntoVenta => string.Format("{0} ({1:P})", pcActivosPuntoVenta.Y, pcActivosPuntoVenta.Participation);

            try
            {
                string sBuscar = "SELECT SUM(tbl_inventario_hardware.cantidad)" +
             ", tbl_punto_venta.nombre" +
             "  FROM tbl_inventario_hardware INNER JOIN tbl_activo " +
             " ON tbl_inventario_hardware.PK_idACtivo = tbl_activo.PK_idActivo" +
             " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado" +
             " INNER JOIN tbl_punto_venta ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta " +
             "  GROUP BY  tbl_punto_venta.PK_idPuntoVenta";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcActivosPuntoVenta.Series = seriesNumActivos;
                pcActivosPuntoVenta.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartEmpleadosArea()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcEmpleadosArea => string.Format("{0} ({1:P})", pcEmpleadosArea.Y, pcEmpleadosArea.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_empleado.PK_idEmpleado)" +
             ", tbl_area.nombre" +
             "  FROM tbl_empleado INNER JOIN tbl_area " +
             " ON tbl_empleado.cod_area = tbl_area.cod_area" +
             "  GROUP BY  tbl_empleado.cod_area";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcEmpleadosArea.Series = seriesNumActivos;
                pcEmpleadosArea.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartEmpleadoPuntoVenta()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcEmpleadosPuntoVenta => string.Format("{0} ({1:P})", pcEmpleadosPuntoVenta.Y, pcEmpleadosPuntoVenta.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_empleado.PK_idEmpleado)" +
             ", tbl_punto_venta.nombre" +
             "  FROM tbl_empleado INNER JOIN tbl_punto_venta " +
             " ON tbl_empleado.cod_punto_venta = tbl_punto_venta.PK_idPuntoVenta" +
             "  GROUP BY  tbl_empleado.cod_area";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcEmpleadosPuntoVenta.Series = seriesNumActivos;
                pcEmpleadosPuntoVenta.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        private void llenarPieChartAuditoriasRealizadas()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcAuditoriasRealizadas => string.Format("{0} ({1:P})", pcAuditoriasRealizadas.Y, pcAuditoriasRealizadas.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_auditoria_encabezado.PK_idAuditoria)" +
             ", tbl_area.nombre" +
             "  FROM tbl_auditoria_encabezado INNER JOIN tbl_area " +
             " ON tbl_auditoria_encabezado.cod_area = tbl_area.cod_area" +
             " WHERE tbl_auditoria_encabezado.estado = 1" +
             " AND fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND' " + dtpFinal.Value.ToString("yyyy-MM-dd") + "' " +
             "  GROUP BY  tbl_auditoria_encabezado.cod_area ";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcAuditoriasRealizadas.Series = seriesNumActivos;
                pcAuditoriasRealizadas.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartAuditoriasPendients()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcAuditoriasPlanificadas => string.Format("{0} ({1:P})", pcAuditoriasPlanificadas.Y, pcAuditoriasPlanificadas.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_auditoria_encabezado.PK_idAuditoria)" +
             ", tbl_area.nombre" +
             "  FROM tbl_auditoria_encabezado INNER JOIN tbl_area " +
             " ON tbl_auditoria_encabezado.cod_area = tbl_area.cod_area" +
             " WHERE tbl_auditoria_encabezado.estado = 0 " +
             " AND fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND' " + dtpFinal.Value.ToString("yyyy-MM-dd") + "' " +
             "  GROUP BY  tbl_auditoria_encabezado.cod_area ";
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcAuditoriasPlanificadas.Series = seriesNumActivos;
                pcAuditoriasPlanificadas.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartMantenimientosArea()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcMantenimientosArea => string.Format("{0} ({1:P})", pcMantenimientosArea.Y, pcMantenimientosArea.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_bitacora_mantenimiento.PK_idBitacora)" +
             ", tbl_area.nombre" +
             "  FROM tbl_bitacora_mantenimiento INNER JOIN tbl_activo " +
             " ON tbl_bitacora_mantenimiento.PK_idActivo = tbl_activo.PK_idActivo" +
             " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado" +
             " INNER JOIN tbl_area ON tbl_empleado.cod_area= tbl_area.cod_area" +
             " WHERE fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND' " + dtpFinal.Value.ToString("yyyy-MM-dd") + "' " +
             "  GROUP BY  tbl_area.cod_area ";

                Console.WriteLine(sBuscar);
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcMantenimientosArea.Series = seriesNumActivos;
                pcMantenimientosArea.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void llenarPieChartMantenimientosPuntoVenta()
        {
            SeriesCollection seriesNumActivos = new SeriesCollection();
            Func<ChartPoint, string> labelNumActivos = pcMantenimientosPuntoVenta => string.Format("{0} ({1:P})", pcMantenimientosPuntoVenta.Y, pcMantenimientosPuntoVenta.Participation);

            try
            {
                string sBuscar = "SELECT COUNT(tbl_bitacora_mantenimiento.PK_idBitacora)" +
             ", tbl_punto_Venta.nombre" +
             "  FROM tbl_bitacora_mantenimiento INNER JOIN tbl_activo " +
             " ON tbl_bitacora_mantenimiento.PK_idActivo = tbl_activo.PK_idActivo" +
             " INNER JOIN tbl_empleado ON tbl_activo.cod_empleado_asignado = tbl_empleado.PK_idEmpleado" +
             " INNER JOIN tbl_punto_Venta ON tbl_empleado.cod_punto_Venta= tbl_punto_Venta.PK_idPuntoVenta" +
             " WHERE fecha BETWEEN '" + dtpInicial.Value.ToString("yyyy-MM-dd") + "' AND' " + dtpFinal.Value.ToString("yyyy-MM-dd") + "' " +
             "  GROUP BY  tbl_punto_venta.PK_idPuntoVenta";

                Console.WriteLine(sBuscar);
                OdbcCommand sqlBuscar = new OdbcCommand(sBuscar, con);
                OdbcDataReader almacena = sqlBuscar.ExecuteReader();

                while (almacena.Read())
                {
                    int valor = Convert.ToInt32(almacena.GetInt64(0));

                    seriesNumActivos.Add(new PieSeries()
                    {
                        Title = almacena.GetString(1).ToString(),
                        Values = new ChartValues<int> { valor },
                        DataLabels = true,
                        LabelPoint = labelNumActivos
                    });

                }
                almacena.Close();

                pcMantenimientosPuntoVenta.Series = seriesNumActivos;
                pcMantenimientosPuntoVenta.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
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

        private void button1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            llenarPieChartNumActivos();
            llenarPieChartAuditoriasRealizadas();
            llenarPieChartAuditoriasPendients();
            llenarPieChartEmpleadosArea();
            llenarPieChartEmpleadoPuntoVenta();
            llenarPieChartActivosPuntoVenta();
            llenarPieChartMantenimientosArea();
            llenarPieChartMantenimientosPuntoVenta();

        }
    }
}
