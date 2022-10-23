using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ensamblado..
using CentroEades_BE;
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class frmLogin : Form
    {
        int intentos = 0;
        int tiempo = 40;

        //Declaramos instancias para autenticacion de usuarios..
        UsuarioBE objUsuarioBE = new UsuarioBE();
        UsuarioBL objUsuarioBL = new UsuarioBL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo -= 1;
            this.Text = "Ingrese su login y contraseña. Le quedan...." + tiempo;
            if (tiempo == 0)
            {
                MessageBox.Show("Lo sentimos, sobrepaso el tiempo de espera",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() != "" & txtPassword.Text.Trim() != "")
            {
                //Obtenenos las credenciales del usuario logeado.
                objUsuarioBE = objUsuarioBL.ConsultarUsuarioLogin(txtLogin.Text.Trim());

                //Si el login no existe
                if (objUsuarioBE.Login_Usuario == null)
                {
                    MessageBox.Show("Usuario no existe ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                }
                else if (txtLogin.Text.Trim() == objUsuarioBE.Login_Usuario && txtPassword.Text.Trim() == objUsuarioBE.Pass_Usuario)
                {
                    this.Hide(); //ocultamos el login
                    timer1.Enabled = false; //apagamos el timer
                    //igualamos los valores de objUsuarioBE a los parametros de la clase clsCredenciales
                    clsCredenciales.Usuario = objUsuarioBE.Login_Usuario;
                    clsCredenciales.Password = objUsuarioBE.Pass_Usuario;
                    clsCredenciales.Nivel = objUsuarioBE.Niv_Usuario;

                    //creamos una instancia del MDIPrincipal y lo inicializamos
                    MDIPrincipal objMDI = new MDIPrincipal();
                    objMDI.Show();
                }
                else
                {
                    MessageBox.Show("Password incorrecto ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intentos += 1;
                }
            }
            else
            {
                MessageBox.Show("Usuario o Password obligatorios",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                intentos += 1;
            }
            if (intentos == 3)
            {
                MessageBox.Show("Lo sentimos,  sobrepaso el numero de intentos",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Application.Exit();
        }
    }
}
