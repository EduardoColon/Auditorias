using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoIngenieriaSoftware.Seguridad
{
    public partial class frmLogin : Form
    {
        MenuStrip menu;

        public frmLogin(MenuStrip menuStrip1)
        {
            InitializeComponent();
            this.menu = menuStrip1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Enabled = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
