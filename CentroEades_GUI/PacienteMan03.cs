using CentroEades_BE;
using CentroEades_BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentroEades_GUI
{
    public partial class PacienteMan03 : Form
    {
        PacienteBL objPacienteBL = new PacienteBL();
        PacienteBE objPacienteBE = new PacienteBE();
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        Stream imagen;

        public PacienteMan03()
        {
            InitializeComponent();
        }

        public String Codigo { get; set; }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pctFoto.Image = Image.FromFile(dialogo.FileName);
                pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void PacienteMan03_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargamos los combos

                //llenamos cboApoderado

                DataTable dt = objApoderadoBL.ListarApoderado();
                DataRow dr;

                dr = dt.NewRow();
                dt.Columns.Add("res", typeof(string));

                foreach (DataRow new_apo in dt.Rows)
                {
                    new_apo["res"] = new_apo["Nom_apo"] + " " +
                        new_apo["Ape_apo"];
                }
                cboApoderado.DataSource = dt;
                cboApoderado.DisplayMember = "res";
                cboApoderado.ValueMember = "Cod_apo";

                //llenamos cboUbigeo

                dt = objUbigeoBL.Ubigeo_Listar();
                dt.Columns.Add("res", typeof(string));

                foreach (DataRow new_dr in dt.Rows)
                {
                    new_dr["res"] = new_dr["Departamento"] +
                        " - " + new_dr["Provincia"] + " - "
                        + new_dr["Distrito"];
                }
                cboUbigeo.DataSource = dt;
                cboUbigeo.DisplayMember = "res";
                cboUbigeo.ValueMember = "Id_Ubigeo";

                // llenamos el cboSexo

                cboSexo.Items.Add("M");
                cboSexo.Items.Add("F");

                cboSexo.SelectedIndex = 0;

                //Mostramos los datos del apoderado a actualizar
                objPacienteBE = objPacienteBL.ConsultarPaciente(this.Codigo);

                lblCodigo.Text = objPacienteBE.Cod_pac;
                cboApoderado.SelectedValue = objPacienteBE.Cod_apo;
                cboUbigeo.SelectedValue = objPacienteBE.Id_Ubigeo;
                txtNombre.Text = objPacienteBE.Nom_pac;
                txtApellido.Text = objPacienteBE.Ape_pac;
                txtDir.Text = objPacienteBE.Dir_pac;
                mskDNI.Text = objPacienteBE.Dni_pac;
                txtTelefono.Text = objPacienteBE.Tel_pac;
                cboSexo.SelectedIndex = objPacienteBE.Sexo == "M" ? 0 : 1;
                mskFecNac.Text = Convert.ToString(objPacienteBE.Fec_nac);
                chkActivo.Checked = objPacienteBE.Est_pac == 1 ? true : false;

                //Agregamos la imagen
                if (objPacienteBE.Foto_pac != null)
                {
                    imagen = new MemoryStream(objPacienteBE.Foto_pac);
                    pctFoto.Image = Image.FromStream(imagen);
                    pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : Aqui -> " + ex.Message);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream archivoMemoria = new MemoryStream();
                pctFoto.Image.Save(archivoMemoria, ImageFormat.Bmp);

                if (txtNombre.Text.Trim() == String.Empty || txtApellido.Text.Trim() == String.Empty
                    || txtTelefono.Text.Trim() == String.Empty)
                {
                    throw new Exception("Tienes que ingresar un un nombre, apellido y telefono");
                }
                if (txtDir.Text.Trim() == String.Empty || mskDNI.MaskFull == false)
                {
                    throw new Exception("Tienes que tener sus datos correctos");
                }
                if (mskFecNac.MaskFull == false)
                {
                    throw new Exception("Tiene que ingresar una fecha");
                }

                objPacienteBE.Cod_pac = /*lblCodigo.Text*/ "P003" ;
                objPacienteBE.Cod_apo = /*cboApoderado.SelectedValue.ToString()*/"-";
                objPacienteBE.Id_Ubigeo = /*cboUbigeo.SelectedValue.ToString()*/"-";
                objPacienteBE.Nom_pac = /*txtNombre.Text.Trim()*/"-";
                objPacienteBE.Ape_pac = /*txtApellido.Text.Trim()*/"-";
                objPacienteBE.Dir_pac = /*txtDir.Text.Trim()*/"-";
                objPacienteBE.Dni_pac = /*mskDNI.Text.Trim()*/"1";
                objPacienteBE.Tel_pac = /*txtTelefono.Text.Trim()*/ "1";
                objPacienteBE.Sexo = /*Convert.ToString(cboSexo.SelectedItem)*/ "M";
                objPacienteBE.Fec_nac = /*Convert.ToDateTime(mskFecNac.Text.Trim())*/ DateTime.Now;
                objPacienteBE.Foto_pac = archivoMemoria.GetBuffer();
                objPacienteBE.Usu_Ult_Mod = clsCredenciales.Usuario;
                objPacienteBE.Est_pac = (short)/*(chkActivo.Checked == true ? 1 : 0)*/ 1;

                if (objPacienteBL.ActualizarPaciente(objPacienteBE) == true)
                {
                    MessageBox.Show("Se ha actualizado");
                    this.Close();
                }
                else
                {
                    throw new Exception("No se inserto el registro. Contacte con Administrador del Sistema.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
