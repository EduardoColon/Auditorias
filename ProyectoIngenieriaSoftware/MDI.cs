using ProyectoIngenieriaSoftware.Auditorias;
using ProyectoIngenieriaSoftware.Mantenimientos;
using ProyectoIngenieriaSoftware.Seguridad;
using System;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleados empleados = new frmEmpleados();
            empleados.MdiParent = this;
            empleados.Show();
        }

        private void puntosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuntosVenta puntosVenta = new frmPuntosVenta();
            puntosVenta.MdiParent = this;
            puntosVenta.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores proveedores = new frmProveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.MdiParent = this;
            marcas.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModelos modelos = new frmModelos();
            modelos.MdiParent = this;
            modelos.Show();
        }


        private void licenciasEquiposDeComputoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenSoftware software = new frmInvenSoftware();
            software.MdiParent = this;
            software.Show();
        }

        private void hardwareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware();
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void inventarioDeIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenIp invenIp = new frmInvenIp();
            invenIp.MdiParent = this;
            invenIp.Show();
        }

        private void enlacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenEnlaces invenEnlaces = new frmInvenEnlaces();
            invenEnlaces.MdiParent = this;
            invenEnlaces.Show();
        }

        private void sistemaTelefonicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware();
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void hardwareToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware();
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void hardwareToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmInvenHardware invenHardware = new frmInvenHardware();
            invenHardware.MdiParent = this;
            invenHardware.Show();
        }

        private void bitacoraMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraMantenimientos bitacoraMantenimientos = new frmBitacoraMantenimientos();
            bitacoraMantenimientos.MdiParent = this;
            bitacoraMantenimientos.Show();
        }

        private void bitacoraSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBitacoraseguridad bitacoraseguridad = new frmBitacoraseguridad();
            bitacoraseguridad.MdiParent = this;
            bitacoraseguridad.Show();
        }

        private void consultarAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultarAuditoria consultaAuditoria = new frmConsultarAuditoria();
            consultaAuditoria.MdiParent = this;
            consultaAuditoria.Show();
        }

        private void planificarAuditoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPlanificarAuditoria planificarAuditoria = new frmPlanificarAuditoria();
            planificarAuditoria.MdiParent = this;
            planificarAuditoria.Show();
        }
    }
}
