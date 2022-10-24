using CentroEades_BE;
using CentroEades_BL;
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
    public partial class ProfesionalMan02 : Form
    {
        //Instancias..
        ProfesionalBL objProfesionalBL = new ProfesionalBL();
        ProfesionalBE objProfesionalBE = new ProfesionalBE();
        public ProfesionalMan02()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validar que este lleno el Id_Espec
            if (txtId_Esp.Text.Trim() == String.Empty)
            {
                throw new Exception("El codigo de la especialidad es obligatorio.");
            }
            //Validar que este lleno el nombre
            if (txtNombres.Text.Trim() == String.Empty)
            {
                throw new Exception("El nombre del profesional es obligatorio.");
            }
            //Validar que este lleno el apellido
            if (txtApellidos.Text.Trim() == String.Empty)
            {
                throw new Exception("Los apellidos del profesional son obligatorios.");
            }
            //Validar que este lleno el Sueldo
            if (mskSueldo.Text.Trim() == String.Empty)
            {
                throw new Exception("El sueldo es obligatorio.");
            }
            //Validamos que el DNI este lleno
            if (mskDni.MaskFull == false)
            {
                throw new Exception("El DNI debe de tener 8 caracteres.");
            }


            //Pasamos los valores a las propiedades de la instancia...
            objProfesionalBE.Id_Espec = Convert.ToInt16(txtId_Esp.Text.Trim());
            objProfesionalBE.Nom_pro = txtNombres.Text.Trim();
            objProfesionalBE.Ape_pro = txtApellidos.Text.Trim();
            objProfesionalBE.Sue_pro = Convert.ToSingle(mskSueldo.Text.Trim());
            objProfesionalBE.Fech_ing = Convert.ToDateTime(mskFecIng.Text.Trim());
            objProfesionalBE.Dni_pro = mskDni.Text.Trim();
            objProfesionalBE.Email_pro = txtEmail.Text.Trim();

            objProfesionalBE.Usu_Registro = clsCredenciales.Usuario;
            objProfesionalBE.Est_pro = Convert.ToInt16(chkEstado.Checked);

            //Invocamos al metodo insertar..
            if (objProfesionalBL.InsertarProfesional(objProfesionalBE) == true)
            {
                this.Close();
            }
            else
            {
                throw new Exception("No se inserto el registro. Contacte con Administrador del Sistema.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
