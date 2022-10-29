using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Ensamblando...
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class PacienteMan01 : Form
    {
        PacienteBL objPacienteBL = new PacienteBL();
        DataView dtv;
        public PacienteMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        { 
            dtv = new DataView(objPacienteBL.ListarPaciente());
            dtv.RowFilter = "nom_pac like '%" + strFiltro + "%'";
            dtgPacientes.DataSource = dtv;
            lblRegistros.Text = dtgPacientes.Rows.Count.ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            PacienteMan02 objPacienteMan02 = new PacienteMan02();
            objPacienteMan02.ShowDialog();

            //Refresacar la grilla
            CargarDatos(txtFiltro.Text.Trim());
        }

        private void PacienteMan01_Load(object sender, EventArgs e)
        {
            CargarDatos("");
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult vrpta;
                vrpta = MessageBox.Show("Seguro de eliminar el registro", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (vrpta == DialogResult.Yes)
                {
                    if (objPacienteBL.EliminarPaciente
                        (dtgPacientes.CurrentRow.Cells[0].Value.ToString(),
                        clsCredenciales.Usuario) == true)
                    {
                        CargarDatos(txtFiltro.Text.Trim());
                    }
                    else
                    {
                        throw new Exception("Registro no se pudo eliminar contacte con TI");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
