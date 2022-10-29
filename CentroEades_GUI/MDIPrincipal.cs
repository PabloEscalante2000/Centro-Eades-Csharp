using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroEades_GUI
{
    public partial class MDIPrincipal : Form
    {
        //Instancias...
        TimeSpan horaEntrada = new TimeSpan();

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void MDIPrincipal_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void apoderadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApoderadoMan01 apo01 = new ApoderadoMan01();
            apo01.MdiParent = this;
            apo01.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PacienteMan01 pac01 = new PacienteMan01();
            pac01.MdiParent = this;
            pac01.Show();
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfesionalMan01 pro01 = new ProfesionalMan01();
            pro01.MdiParent = this;
            pro01.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Refrescar el titulo del menu principal , mostrando la hora.
            this.Text = "Centro EADES - Menú Principal " + DateTime.Now;

            //Mostramos el tiempo de iniciada la sesion
            lbl1.Text = "Tiempo de sesion : " + 
                DateTime.Now.TimeOfDay.Subtract(horaEntrada).ToString().Substring(0,8); 
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
           
            horaEntrada = DateTime.Now.TimeOfDay;

            //Colocamos el label de usuario el usuario logueado
            this.lblUsuario.Text = clsCredenciales.Usuario;

            //Segun su nivel , le damos acceso a los menus..
            if (clsCredenciales.Nivel == 1)
            {
                //Es administrador...
                mantenimientosToolStripMenuItem.Visible = true;
                
            }
            else if (clsCredenciales.Nivel == 2)
            {
                //Es Recepcionista
                mantenimientosToolStripMenuItem.Visible = false;
                
            }

        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult vrpta;
            vrpta = MessageBox.Show("Seguro de salir de la aplicación?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vrpta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
