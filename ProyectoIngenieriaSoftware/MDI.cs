using ProyectoIngenieriaSoftware.Mantenimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
