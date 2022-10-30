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
using CentroEades_BE;

namespace CentroEades_GUI
{
    public partial class PacienteMan02 : Form
    {
        PacienteBL objPacienteBL = new PacienteBL();
        PacienteBE objPacienteBE = new PacienteBE();
        public PacienteMan02()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();

                // Si se escogio una foto se carga en el picture Box
                if (openFileDialog1.FileName != String.Empty)
                {
                    pcbFoto.Image = Image.FromFile(openFileDialog1.FileName);
                }


            }
            catch (Exception)
            {

                throw;
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
            try
            {
                // Validar nombres , apellidos y dni
                if (txtNombres.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio.");
                }
                if (txtApellidos.Text.Trim() == String.Empty)
                {
                    throw new Exception("Los apellido es obligatorio.");
                }
                if (mskDni.Text.Trim() == String.Empty)
                {
                    throw new Exception("El DNI es obligatorio.");
                }
                // Validamos foto
                if (pcbFoto.Image == null)
                {
                    throw new Exception("Debe registrar la foto.");
                }
                // Pasamos los valores a las propiedades de la instancia...
                objPacienteBE.Cod_apo = txtCod_apo.Text.Trim();
                objPacienteBE.Nom_pac = txtNombres.Text.Trim();
                objPacienteBE.Ape_pac = txtApellidos.Text.Trim();
                objPacienteBE.Dir_pac = txtDir.Text.Trim();
                objPacienteBE.Dni_pac = mskDni.Text.Trim();
                objPacienteBE.Tel_pac = txtTel.Text.Trim();
                //Recuerde que el IdUbiigeo es la concatenacion de los valores del Id Departamento,
                //Id Provinca y Id Distrito seleccionados desde los respectivos combos
                objPacienteBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() +
                                            cboProvincia.SelectedValue.ToString() +
                                            cboDistrito.SelectedValue.ToString();

                if (optFemenino.Checked == true) 
                {
                    objPacienteBE.Sexo = Convert.ToString('F'); 
                }
                if (optMasculino.Checked == true)
                {
                    objPacienteBE.Sexo = Convert.ToString('M');
                }
                objPacienteBE.Fec_nac = Convert.ToDateTime(mskFech_nac.Text.Trim());
                
                // Convertimos la foto en un arreglo de Bytes y lo almacenamos en su respectiva propiedad
                objPacienteBE.Foto_pac = File.ReadAllBytes(openFileDialog1.FileName);
                objPacienteBE.Usu_Registro = clsCredenciales.Usuario;
                objPacienteBE.Est_pac = Convert.ToInt16(chkEstado.Checked);

                // Insertamos el registro de nueva categoria...
                if (objPacienteBL.InsertarPaciente(objPacienteBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el registro. Contacte con Administrador de Sistema.");
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

        private void PacienteMan02_Load(object sender, EventArgs e)
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
