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
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class PacienteMan03 : Form
    {
        PacienteBL objPacienteBL = new PacienteBL();
        PacienteBE objPacienteBE = new PacienteBE();
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        // Variable para determinar si se a cambiado de foto o no.
        Boolean blnCambio;
        // Array de Bytes para conservar la foto original , por si no se desea cambiarla.
        Byte[] FotoOriginal;
        public PacienteMan03()
        {
            InitializeComponent();
        }
        // IMPORTANTE: Creamos la propiedad Codigo ,que recepcionara el valor del codigo del Apoderado 
        // a actualizar enviado desde el formulario ApoderadoMan01
        public String Codigo { get; set; }
        private void PacienteMan03_Load(object sender, EventArgs e)
        {
            try
            {
                //llenamos el cboApoderado
                DataTable dt = objApoderadoBL.ListarApoderado();

                dt.Columns.Add("res", typeof(string));

                foreach (DataRow d in dt.Rows)
                {
                    d["res"] = d["Nom_apo"] + " " + d["ape_apo"];
                }
                
                DataRow dr;
                
                dr = dt.NewRow();
                dr["Cod_apo"] = "-";
                dr["res"] = "--Seleccionar--";

                dt.Rows.InsertAt(dr, 0);
                cboApoderado.DataSource = dt;
                cboApoderado.DisplayMember = "res";
                cboApoderado.ValueMember = "Cod_apo";

                // Mostramos los datos de la Categoria a actualizar
                objPacienteBE = objPacienteBL.ConsultarPaciente(this.Codigo);

                lblCod.Text = objPacienteBE.Cod_pac;
                cboApoderado.SelectedValue = objPacienteBE.Cod_apo;
                txtNombres.Text = objPacienteBE.Nom_pac;
                txtApellidos.Text = objPacienteBE.Ape_pac;
                txtDir.Text = objPacienteBE.Dir_pac;
                mskDni.Text = objPacienteBE.Dni_pac;
                txtTel.Text = objPacienteBE.Tel_pac;
                if (objPacienteBE.Sexo == "F")
                {
                    optFemenino.Checked = true;
                }
                if (objPacienteBE.Sexo == "M")
                {
                    optMasculino.Checked = true;
                }
                
                //con el maskedTextBox
                //mskFech_nac.Text = Convert.ToString(objPacienteBE.Fec_nac);

                //Con el DateTimePicker
                dtpFNac.Text = Convert.ToString(objPacienteBE.Fec_nac);

                chkEstado.Checked = Convert.ToBoolean(objPacienteBE.Est_pac);
                

                String Id_Ubigeo = objPacienteBE.Id_Ubigeo;
                //Mostramos en los 3 combos el ubigeo
                //Caracteres 1 y 2 : Departamento, Caracteres 3 y 4 : Provincia, Caracteres 5 y 6: Distrito
                //Cargamos el Ubigeo
                CargarUbigeo(Id_Ubigeo.Substring(0, 2), Id_Ubigeo.Substring(2, 2), Id_Ubigeo.Substring(4, 2));

                

                // Si no tiene foto....
                if (objPacienteBE.Foto_pac.Length == 0)
                {
                    pcbFoto.Image = null;

                }
                else // Pero si tiene foto
                {
                    MemoryStream fotoStream = new MemoryStream(objPacienteBE.Foto_pac);
                    pcbFoto.Image = Image.FromStream(fotoStream);
                    // Guardamos la foto original , por si no se hace cambios...
                    FotoOriginal = objPacienteBE.Foto_pac;
                }

                

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


        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.FileName = String.Empty;
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();

                // Si se escogio una foto se carga en el picture Box y la variable blnCambio se pone en true
                // Esta variable permitira saber si se cambio la foto en la categoria.
                if (openFileDialog1.FileName != String.Empty)
                {
                    pcbFoto.Image = Image.FromFile(openFileDialog1.FileName);
                    blnCambio = true;
                }
                else // de lo contrario la variable blnCambio se mantiene en falso
                {
                    blnCambio = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar descripcion
                if (cboApoderado.SelectedIndex == 0)
                {
                    throw new Exception("El apoderado es obligatorio.");
                }
                if (txtNombres.Text.Trim() == String.Empty)
                {
                    throw new Exception("El nombre es obligatorio.");
                }
                if (txtApellidos.Text.Trim() == String.Empty)
                {
                    throw new Exception("El apellido es obligaorio.");
                }
                if (mskDni.Text.Trim() == String.Empty)
                {
                    throw new Exception("El Dni es obligatorio.");
                }
                if (dtpFNac.Text.Trim() == String.Empty)
                {
                    throw new Exception("La fecha de nacimiento es obligatorio.");
                }

                // Validamos foto
                if (pcbFoto.Image == null)
                {
                    throw new Exception("Debe registrar la foto.");
                }
                //Si todo esta OK , Actualizamos la entidad de negocios..
                objPacienteBE.Cod_apo = cboApoderado.SelectedValue.ToString();
                objPacienteBE.Nom_pac = txtNombres.Text.Trim();
                objPacienteBE.Ape_pac = txtApellidos.Text.Trim();
                objPacienteBE.Dir_pac = txtDir.Text.Trim();
                objPacienteBE.Dni_pac = mskDni.Text.Trim();
                objPacienteBE.Tel_pac = txtTel.Text.Trim();
                if (optFemenino.Checked == true)
                {
                     objPacienteBE.Sexo = "F";
                }
                if (optMasculino.Checked == true)
                {
                     objPacienteBE.Sexo = "M";
                }
                objPacienteBE.Fec_nac = Convert.ToDateTime(dtpFNac.Text.Trim());

                objPacienteBE.Usu_Ult_Mod = clsCredenciales.Usuario;
                objPacienteBE.Est_pac = Convert.ToInt16(chkEstado.Checked);

                //Recuerde que el IdUbiigeo es la concatenacion de los valores del Id Departamento,
                //Id Provinca y Id Distrito seleccionados desde los respectivos combos
                objPacienteBE.Id_Ubigeo = cboDepartamento.SelectedValue.ToString() + cboProvincia.SelectedValue.ToString() +
                    cboDistrito.SelectedValue.ToString();
                

                // Si cambio la foto...
                if (blnCambio == true)
                {
                    objPacienteBE.Foto_pac = File.ReadAllBytes(openFileDialog1.FileName);
                }
                else  //Mantenemos la foto original
                {
                    objPacienteBE.Foto_pac = FotoOriginal;
                }
                // Actualizamos....
                if (objPacienteBL.ActualizarPaciente(objPacienteBE) == true)
                {
                    this.Close();
                }
                else
                {
                    throw new Exception("No se actualizo el registro. Contacte con Administrador de Sistema.");
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

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(), "01", "01");
        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarUbigeo(cboDepartamento.SelectedValue.ToString(),
                                cboProvincia.SelectedValue.ToString(), "01");
        }
    }
}
