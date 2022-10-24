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
    public partial class ApoderadoMan03 : Form
    {
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        ApoderadoBE objApoderadoBE = new ApoderadoBE();
        public ApoderadoMan03()
        {
            InitializeComponent();
        }

        // IMPORTANTE: Creamos la propiedad Codigo ,que recepcionara el valor del codigo del Apoderado 
        // a actualizar enviado desde el formulario ApoderadoMan01
        public String Codigo { get; set; }


        private void ApoderadoMan03_Load(object sender, EventArgs e)
        {
            try
            {
                //Mostramos los datos del apoderado a actualizar
                objApoderadoBE = objApoderadoBL.ConsultarApoderado(this.Codigo);

                lblCod.Text = objApoderadoBE.Cod_apo;
                txtNombre.Text = objApoderadoBE.Nom_apo;
                txtApellido.Text = objApoderadoBE.Ape_apo;
                txtDir.Text = objApoderadoBE.Dir_apo;
                mskDni.Text = objApoderadoBE.Dni_apo;
                txtTel.Text = objApoderadoBE.Tel_apo;
                chkEstado.Checked = Convert.ToBoolean(objApoderadoBE.Est_apo);
                String Id_Ubigeo = objApoderadoBE.Id_Ubigeo;
                //Mostramos en los 3 combos el ubigeo
                //Caracteres 1 y 2 : Departamento, Caracteres 3 y 4 : Provincia, Caracteres 5 y 6: Distrito
                //Cargamos el Ubigeo
                CargarUbigeo(Id_Ubigeo.Substring(0, 2), Id_Ubigeo.Substring(2, 2), Id_Ubigeo.Substring(4, 2));


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
                //Validamos el nombre , apellidos , la direccion y el dni
                if (txtNombre.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre del apoderado es obligatorio");
                }
                if (txtApellido.Text.Trim() == String.Empty)
                {
                    throw new Exception("El apellido del apoderado es obligatorio");
                }
                if (txtDir.Text.Trim() == String.Empty)
                {
                    throw new Exception("La dirección del apoderado es obligatoria");
                }
                if (mskDni.Text.Trim() == String.Empty)
                {
                    throw new Exception("El numero de DNI es obligatorio");
                }
                //Validamos el ubigeo
                if (cboDepartamento.SelectedIndex == 0 || cboProvincia.SelectedIndex == 0 || cboDistrito.SelectedIndex == 0)
                {
                    throw new Exception("El Departamento , Provincia y Distrito son datos obligatorios");
                }

                //Si todo esta OK , Actualizamos la entidad de negocios..
                objApoderadoBE.Cod_apo = lblCod.Text;
                objApoderadoBE.Nom_apo = txtNombre.Text.Trim();
                objApoderadoBE.Ape_apo = txtApellido.Text.Trim();
                objApoderadoBE.Dir_apo = txtDir.Text.Trim();
                objApoderadoBE.Dni_apo = mskDni.Text.Trim();
                objApoderadoBE.Tel_apo = txtTel.Text.Trim();
                //Recuerde que el IdUbiigeo es la concatenacion de los valores del Id Departamento,
                //Id Provinca y Id Distrito seleccionados desde los respectivos combos
                objApoderadoBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() + cboProvincia.SelectedValue.ToString() +
                    cboDistrito.SelectedValue.ToString();
                objApoderadoBE.Usu_Ult_Mod = clsCredenciales.Usuario;
                objApoderadoBE.Est_apo = Convert.ToInt16(chkEstado.Checked);

                
                //Invocamos al metodo actualizar..
                if (objApoderadoBL.ActualizarApoderado(objApoderadoBE) == true)
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

        private void CargarUbigeo(String IdDepa, String IdProv, String IdDist)
        {
            UbigeoBL objUbigeoBL = new UbigeoBL();
            cboDepartamento.DataSource = objUbigeoBL.Ubigeo_Departamentos();
            cboDepartamento.ValueMember = "IdDepa";
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.SelectedValue = IdDepa;

            cboProvincia.DataSource = objUbigeoBL.Ubigeo_ProvinciasDepartamento(IdDepa);
            cboProvincia.ValueMember = "IdProv";
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.SelectedValue = IdProv;

            cboDistrito.DataSource = objUbigeoBL.Ubigeo_DistritosProvinciaDepartamento(IdDepa, IdProv);
            cboDistrito.ValueMember = "IdDist";
            cboDistrito.DisplayMember = "Distrito";
            cboDistrito.SelectedValue = IdDist;

        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(),
                                cboProvincia.SelectedValue.ToString(), "01");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
