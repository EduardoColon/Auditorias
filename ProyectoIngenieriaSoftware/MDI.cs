using Inventarios;
using ProyectoIngenieriaSoftware.Auditorias;
using ProyectoIngenieriaSoftware.Mantenimientos;
using ProyectoIngenieriaSoftware.Reportes;
using ProyectoIngenieriaSoftware.Seguridad;
using System;
using System.Data.Odbc;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware
{

    //Soporte tecnico       1
    //infraestructura       2
    //telecomunicaciones    3

    public partial class MDI : Form
    {
        OdbcConnection con;

        string sIdUsuario = "";
        string sNivelPrivilegios = "";

        public MDI(OdbcConnection con, string sIdUsuario, string sNivelPrivilegios)
        {
            InitializeComponent();

            this.con = con;
            this.sIdUsuario = sIdUsuario;
            this.sNivelPrivilegios = sNivelPrivilegios;

            if(sNivelPrivilegios != "Super")
            {
                stmSeguridad.Enabled = false;
            }

            if(sNivelPrivilegios == "Lectura")
            {
                stmPlanificarAuditoria.Enabled = false;
                stmRegistrarAuditoria.Enabled = false;
                mantenimientoHardwareToolStripMenuItem.Enabled = false;
                mantenimientoHardwareToolStripMenuItem.Enabled = false;
                mantenimientoDeHardwareToolStripMenuItem1.Enabled = false;
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados empleados = new frmEmpleados(con, sIdUsuario, sNivelPrivilegios);
            empleados.MdiParent = this;
            empleados.Show();
        }

        private void puntosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuntosVenta puntosVenta = new frmPuntosVenta(con, sIdUsuario, sNivelPrivilegios);
            puntosVenta.MdiParent = this;
            puntosVenta.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores(con, sIdUsuario, sNivelPrivilegios);
            proveedores.MdiParent = this;
            proveedores.Show();
        }


        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas(con, sIdUsuario, sNivelPrivilegios);
            marcas.MdiParent = this;
            marcas.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelos modelos = new frmModelos(con, sIdUsuario, sNivelPrivilegios);
            modelos.MdiParent = this;
            modelos.Show();
        }


        private void licenciasEquiposDeComputoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenSoftware software = new frmInvenSoftware(con, "1", sIdUsuario, sNivelPrivilegios);
            software.MdiParent = this;
            software.Show();
        }

        private void hardwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware(con, "1", sIdUsuario, sNivelPrivilegios);
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void inventarioDeIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenIp invenIp = new frmInvenIp(con , "1", sIdUsuario, sNivelPrivilegios);
            invenIp.MdiParent = this;
            invenIp.Show();
        }

        private void enlacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenEnlaces invenEnlaces = new frmInvenEnlaces(con ,"3", sIdUsuario, sNivelPrivilegios);
            invenEnlaces.MdiParent = this;
            invenEnlaces.Show();
        }

        private void sistemaTelefonicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware(con, "3", sIdUsuario, sNivelPrivilegios);
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void hardwareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware(con, "3", sIdUsuario, sNivelPrivilegios);
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void hardwareToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware(con, "2", sIdUsuario, sNivelPrivilegios);
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void bitacoraMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraMantenimientos bitacoraMantenimientos = new frmBitacoraMantenimientos(con, "2");
            bitacoraMantenimientos.MdiParent = this;
            bitacoraMantenimientos.Show();
        }

        private void bitacoraSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraseguridad bitacoraseguridad = new frmBitacoraseguridad(con);
            bitacoraseguridad.MdiParent = this;
            bitacoraseguridad.Show();
        }

        private void consultarAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarAuditoria consultaAuditoria = new frmConsultarAuditoria(con);
            consultaAuditoria.MdiParent = this;
            consultaAuditoria.Show();
        }

        private void planificarAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlanificarAuditoria planificarAuditoria = new frmPlanificarAuditoria(con, sIdUsuario);
            planificarAuditoria.MdiParent = this;
            planificarAuditoria.Show();
        }

        private void registrarAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarAuditoria registrarAuditoria = new frmRegistrarAuditoria(sIdUsuario, con);
            registrarAuditoria.MdiParent = this;
            registrarAuditoria.Show();
        }

        private void tableroDeIndicadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard(con);
            dashboard.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MDI_Load(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios(con, sIdUsuario, sNivelPrivilegios);
            usuarios.MdiParent = this;
            usuarios.Show();
        }

        private void mantenimientoHardwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientosEnHardware mantenimientosEnHardware = new frmMantenimientosEnHardware(con, "1", sIdUsuario);
            mantenimientosEnHardware.MdiParent = this;
            mantenimientosEnHardware.Show();
        }

        private void mantenimientoDeHardwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantenimientosEnHardware mantenimientosEnHardware = new frmMantenimientosEnHardware(con, "3", sIdUsuario);
            mantenimientosEnHardware.MdiParent = this;
            mantenimientosEnHardware.Show();
        }

        private void mantenimientoDeHardwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMantenimientosEnHardware mantenimientosEnHardware = new frmMantenimientosEnHardware(con, "2", sIdUsuario);
            mantenimientosEnHardware.MdiParent = this;
            mantenimientosEnHardware.Show();
        }

        private void bitacoraMantenimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBitacoraMantenimientos bitacoraMantenimientos = new frmBitacoraMantenimientos(con, "1");
            bitacoraMantenimientos.MdiParent = this;
            bitacoraMantenimientos.Show();
        }

        private void bitacoraDeMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraMantenimientos bitacoraMantenimientos = new frmBitacoraMantenimientos(con, "3");
            bitacoraMantenimientos.MdiParent = this;
            bitacoraMantenimientos.Show();
        }
    }
}
