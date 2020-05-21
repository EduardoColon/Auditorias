using Inventarios;
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

namespace ProyectoIngenieriaSoftware.Seguridad
{
    public partial class frmLogin : Form
    {
        OdbcConnection con;
        conexion cn = new conexion();

        public frmLogin()
        {
            InitializeComponent();

            try
            {
                con = cn.conectar();         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectando a la base de datos");
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(txtUsuario.Text.Trim() == "" || txtClave.Text.Trim() == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
            else
            {
                OdbcCommand cmd;
                string sIdUsuario = "";
                string sNivelPrivilegios = "";

                try
                {
                    cmd = new OdbcCommand("{ call procedimientoLogin (?,?)}", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@usuario", OdbcType.Text).Value = txtUsuario.Text.Trim();
                    cmd.Parameters.Add("@pass", OdbcType.Text).Value = txtClave.Text.Trim();
                    OdbcDataReader almacena = cmd.ExecuteReader();

                    if (almacena.HasRows)
                    {
                        while (almacena.Read())
                        {
                            sIdUsuario = almacena.GetInt32(0).ToString();
                            sNivelPrivilegios = almacena.GetString(1).ToString();
                          
                        }
                        this.Visible = false;
                        MDI mdi = new MDI(con, sIdUsuario, sNivelPrivilegios);
                        mdi.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nombre de usuario desconocido o contraseña incorrecta");
                    }

                    almacena.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
