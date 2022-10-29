using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public PacienteMan02()
        {
            InitializeComponent();
        }

        private void PacienteMan02_Load(object sender, EventArgs e)
        {
            try
            {
                /*//llenamos los combos Apoderado y UBIGEO
                DataTable dt = objApoderadoBL.ListarApoderado();
                DataRow dr;

                dr = dt.NewRow();
                dr["Cod_apo"] = "-";
                dr["Nom_apo"] = "--Seleccione--";
                dt.Rows.InsertAt(dr, 0);
                cboApoderado.DataSource = dt;
                cboApoderado.DisplayMember = "Nom_apo";
                cboApoderado.ValueMember = "Cod_apo";

                dt = objUbigeoBL.Ubigeo_Listar();
                dr = dt.NewRow();
                dr["Id_Ubigeo"] = 0;
                dt.Rows.InsertAt(dr, 0);
                cboUbigeo.DataSource = dt;
                cboUbigeo.DisplayMember = "Id_Ubigeo";
                cboUbigeo.ValueMember = "Id_Ubigeo";*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
