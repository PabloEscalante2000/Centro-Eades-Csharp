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
        EspecialidadBL objEspecialidadBL = new EspecialidadBL();
        public ProfesionalMan02()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar que este lleno el Id_Espec
                if (cboEspecialidad.SelectedIndex == 0)
                {
                    throw new Exception("La especialidad es obligatoria.");
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
                objProfesionalBE.Id_Espec = Convert.ToInt16(cboEspecialidad.SelectedValue);
                objProfesionalBE.Nom_pro = txtNombres.Text.Trim();
                objProfesionalBE.Ape_pro = txtApellidos.Text.Trim();
                objProfesionalBE.Sue_pro = Convert.ToSingle(mskSueldo.Text.Trim());
                objProfesionalBE.Fech_ing = Convert.ToDateTime(dtgFIng.Text.Trim());
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
            catch (Exception ex)
            {

                MessageBox.Show("Se ha producido el error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfesionalMan02_Load(object sender, EventArgs e)
        {
            //llenar el cboEspecialidad
            DataTable dt = objEspecialidadBL.Listar_Ubigeo();
            DataRow dr = dt.NewRow();
            dr["Id_Espec"] = 0;
            dr["Nom_Espec"] = "--Seleccione--";
            dt.Rows.InsertAt(dr, 0);
            cboEspecialidad.DataSource = dt;
            cboEspecialidad.DisplayMember = "Nom_Espec";
            cboEspecialidad.ValueMember = "Id_Espec";
            //Restringimos la fecha minima a la fecha actual..
            dtgFIng.MinDate = DateTime.Now;
        }
    }
}
