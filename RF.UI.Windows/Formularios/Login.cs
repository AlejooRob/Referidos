using RF.UI.Windows.Controladores;
using RF.UI.Windows.VistaModelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RF.UI.Windows.Formularios
{
    public partial class Login : Form
    {
        private UsuariosControlador servicioUsuario;
        private UsuariosVistaModelo usuariosVistaModelo;
        public Login()
        {
            InitializeComponent();
            servicioUsuario = new UsuariosControlador();
            usuariosVistaModelo = new UsuariosVistaModelo();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var result = servicioUsuario.verificarUsurioPassword(textBoxUserID.Text.Trim(), textBoxPassword.Text.Trim());
            if(result != 0)
            {
                this.Hide();
                Dashboard dashboardForm = new Dashboard(result);
                dashboardForm.FormClosed += (s, args) => this.Close();
                dashboardForm.Show();
            }
            else
            {
                MessageBox.Show("Email o Password incorrectos");
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
