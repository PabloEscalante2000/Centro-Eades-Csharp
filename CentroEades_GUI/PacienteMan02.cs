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
//Agregar...
using CentroEades_BE;
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class PacienteMan02 : Form
    {

        //Instancias...
        PacienteBE objPacienteBE = new PacienteBE();
        PacienteBL objPacienteBL = new PacienteBL();
        UbigeoBL objUbigeoBL = new UbigeoBL();
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        MemoryStream archivoMemoria = new MemoryStream();

        public PacienteMan02()
        {
            InitializeComponent();
        }

        private void PacienteMan02_Load(object sender, EventArgs e)
        {
            try
            {
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

                dr["Cod_apo"] = "-";
                dr["res"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);
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
                dr = dt.NewRow();
                dr["Id_Ubigeo"] = "-";
                dr["res"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboUbigeo.DataSource = dt;
                cboUbigeo.DisplayMember = "res";
                cboUbigeo.ValueMember = "Id_Ubigeo";

                // llenamos el cboSexo

                cboSexo.Items.Add("M");
                cboSexo.Items.Add("F");

                cboSexo.SelectedIndex = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void cboUbigeoDepa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboApoderado.SelectedIndex == 0 || cboUbigeo.SelectedIndex == 0)
                {
                    throw new Exception("Tienes que ingresar un apoderado y ubigeo");
                }
                if (txtNombre.Text.Trim() == String.Empty || txtApellido.Text.Trim() == String.Empty
                    || txtTelefono.Text.Trim() == String.Empty)
                {
                    throw new Exception("Tienes que ingresar un un nombre, apellido y telefono");
                }
                if (txtDireccion.Text.Trim() == String.Empty || mtbDNI.MaskFull == false)
                {
                    throw new Exception("Tienes que tener sus datos correctos");
                }
                if (mtbFecNac.MaskFull == false)
                {
                    throw new Exception("Tiene que ingresar una fecha");
                }

                objPacienteBE.Cod_apo = cboApoderado.SelectedValue.ToString();
                objPacienteBE.Id_Ubigeo = cboUbigeo.SelectedValue.ToString();
                objPacienteBE.Nom_pac = txtNombre.Text.Trim();
                objPacienteBE.Ape_pac = txtApellido.Text.Trim();
                objPacienteBE.Dir_pac = txtDireccion.Text.Trim();
                objPacienteBE.Dni_pac = mtbDNI.Text.Trim();
                objPacienteBE.Tel_pac = txtTelefono.Text.Trim();
                objPacienteBE.Sexo = Convert.ToString(cboSexo.SelectedItem);
                objPacienteBE.Fec_nac = Convert.ToDateTime(mtbFecNac.Text.Trim());
                objPacienteBE.Foto_pac = archivoMemoria.GetBuffer();
                objPacienteBE.Usu_Registro = clsCredenciales.Usuario;
                objPacienteBE.Est_pac = (short)(chkActivo.Checked == true ? 1 : 0);

                if (objPacienteBL.InsertarPaciente(objPacienteBE) == true)
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
                throw new Exception("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            DialogResult resultado = dialogo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pctFoto.Image = Image.FromFile(dialogo.FileName);
                pctFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            pctFoto.Image.Save(archivoMemoria, ImageFormat.Bmp);
        }
    }
}
