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
    public partial class ProfesionalMan03 : Form
    {
        ProfesionalBL objProfesionalBL = new ProfesionalBL();
        ProfesionalBE objProfesionalBE = new ProfesionalBE();
        EspecialidadBL objEspecialidadBL = new EspecialidadBL();
        public ProfesionalMan03()
        {
            InitializeComponent();
        }


        // IMPORTANTE: Creamos la propiedad Codigo ,que recepcionara el valor del codigo del Apoderado 
        // a actualizar enviado desde el formulario ApoderadoMan01
        public String Codigo { get; set; }
        private void ProfesionalMan03_Load(object sender, EventArgs e)
        {
            try
            {
                //Llenamos el cboEspecialidad
                DataTable dt = objEspecialidadBL.Listar_Ubigeo();
                DataRow dr = dt.NewRow();
                dr["Id_Espec"] = 0;
                dr["Nom_Espec"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboEspecialidad.DataSource = dt;
                cboEspecialidad.DisplayMember = "Nom_Espec";
                cboEspecialidad.ValueMember = "Id_Espec";

                //Mostramos los datos del apoderado a actualizar
                objProfesionalBE = objProfesionalBL.ConsultarProfesional(this.Codigo);

                lblCodigo.Text = objProfesionalBE.Cod_pro;
                cboEspecialidad.SelectedValue = Convert.ToString(objProfesionalBE.Id_Espec);
                txtNombres.Text = objProfesionalBE.Nom_pro;
                txtApellidos.Text = objProfesionalBE.Ape_pro;
                mskSueldo.Text = Convert.ToString(objProfesionalBE.Sue_pro);
                dtpFIng.Text = Convert.ToString(objProfesionalBE.Fech_ing);
                mskDni.Text = objProfesionalBE.Dni_pro;
                txtEmail.Text = objProfesionalBE.Email_pro;
                chkEstado.Checked = Convert.ToBoolean(objProfesionalBE.Est_pro);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Aqui->" + ex.Message);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validamos el cod. Especialidad, nombre , apellidos ,sueldo y el dni
                if (cboEspecialidad.SelectedIndex == 0)
                {
                    throw new Exception("La Especialidad es obligatoria");
                }
                if (txtNombres.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre del Profesional es obligatorio");
                }
                if (txtApellidos.Text.Trim() == String.Empty)
                {
                    throw new Exception("El apellido del Profesional es obligatorio");
                }
                if (mskSueldo.Text.Trim() == String.Empty)
                {
                    throw new Exception("El Sueldo del profesional es obligatorio");
                }
                if (mskDni.Text.Trim() == String.Empty)
                {
                    throw new Exception("El numero de DNI es obligatorio");
                }


                //Si todo esta OK , Actualizamos la entidad de negocios..
                objProfesionalBE.Id_Espec = Convert.ToInt16(cboEspecialidad.SelectedValue);
                objProfesionalBE.Nom_pro= txtNombres.Text.Trim();
                objProfesionalBE.Ape_pro = txtApellidos.Text.Trim();
                objProfesionalBE.Sue_pro = Convert.ToSingle(mskSueldo.Text.Trim());
                objProfesionalBE.Fech_ing = Convert.ToDateTime(dtpFIng.Text.Trim());
                objProfesionalBE.Dni_pro = mskDni.Text.Trim();
                objProfesionalBE.Email_pro = txtEmail.Text.Trim();

                objProfesionalBE.Usu_Ult_Mod = clsCredenciales.Usuario;
                objProfesionalBE.Est_pro = Convert.ToInt16(chkEstado.Checked);


                //Invocamos al metodo actualizar..
                if (objProfesionalBL.ActualizarProfesional(objProfesionalBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se actualizo el registro , contacte con Administrador de Sistema");
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

        
    }
}
