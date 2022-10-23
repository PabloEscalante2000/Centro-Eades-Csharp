using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ensamblado
using CentroEades_BE;
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class ApoderadoMan02 : Form
    {
        //Instancias..
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        ApoderadoBE objApoderadoBE = new ApoderadoBE();
        public ApoderadoMan02()
        {
            InitializeComponent();
        }

        private void ApoderadoMan02_Load(object sender, EventArgs e)
        {
            try
            {

                // Cargamos los combos de Ubigeo
                // Por defecto elegiremos Lima, Lima , Lima (14,01,01)
                CargarUbigeo("14", "01", "01");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

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
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validar que este lleno el nombre
            if (txtNombres.Text.Trim() == String.Empty)
            {
                throw new Exception("El nombre  es obligatorio.");
            }
            //Validar que este lleno el apellido
            if (txtApellidos.Text.Trim() == String.Empty)
            {
                throw new Exception("Los apellidos son obligatorios.");
            }
            //Validar que este lleno la direccion
            if (txtDir.Text.Trim() == String.Empty)
            {
                throw new Exception("La dirección es obligatoria.");
            }
            //Validamos que el DNI este lleno
            if (mskDni.MaskFull == false)
            {
                throw new Exception("El DNI debe de tener 8 caracteres.");
            }

            //Pasamos los valores a las propiedades de la instancia...
            objApoderadoBE.Nom_apo = txtNombres.Text.Trim();
            objApoderadoBE.Ape_apo = txtApellidos.Text.Trim();
            objApoderadoBE.Dir_apo = txtDir.Text.Trim();
            objApoderadoBE.Dni_apo = mskDni.Text.Trim();
            objApoderadoBE.Tel_apo = txtTel.Text.Trim();
            //Recuerde que el IdUbiigeo es la concatenacion de los valores del Id Departamento,
            //Id Provinca y Id Distrito seleccionados desde los respectivos combos
            objApoderadoBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() +
                                        cboProvincia.SelectedValue.ToString() +
                                        cboDistrito.SelectedValue.ToString();
            objApoderadoBE.Usu_Registro = clsCredenciales.Usuario;
            objApoderadoBE.Est_apo = Convert.ToInt16(chkEstado.Checked);

            //Invocamos al metodo insertar..
            if (objApoderadoBL.InsertarApoderado(objApoderadoBE) == true)
            {
                this.Close();
            }
            else
            {
                throw new Exception("No se inserto el registro. Contacte con IT.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Refrescamos los combos con la primera provincia y el primer distrito de esa
            //provincia para el departamento seleccionado del combo cboDepartamento.
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Refrescamos los combos con el primer distrito para el departamento y
            //provincia seleccionado del combo cboDepartamento y cboProvincia.
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), cboProvincia.SelectedValue.ToString(), "01");
        }
    }
}
