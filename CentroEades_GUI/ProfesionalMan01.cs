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
    public partial class ProfesionalMan01 : Form
    {
        ProfesionalBL objProfesionalBL = new ProfesionalBL();
        DataView dtv;
        public ProfesionalMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        {
            // Construimos el objeto Dataview dtv en base al DataTable devuelto por el metodo ListarProfesional
            //Y lo filtramos de acuerdo al parametro strFiltro.
            dtv = new DataView(objProfesionalBL.ListarProfesional());
            dtv.RowFilter = "Ape_pro like '%" + strFiltro + "%'";
            dtgProfesionales.DataSource = dtv;
            lblRegistros.Text = dtgProfesionales.Rows.Count.ToString();
        }

        private void ProfesionalMan01_Load(object sender, EventArgs e)
        {
            try
            {
                // Invocamos al metodo CargarDatos pasandole una cadena vacia,
                // lo cual hara que se muestren todos los profesionales por defecto al momento de cargar
                // el formulario.
                CargarDatos(""); //CargarDatos(String.Empty);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Pasaremos el metodo CargarDatos el texto que se va escribiendo
                //en la caja de texto
                CargarDatos(txtFiltro.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                //Creamos una instancia de ProfesionalMan02 y lo mostramos de manera modal
                ProfesionalMan02 objMan02 = new ProfesionalMan02();
                objMan02.ShowDialog();

                //Al retornar, refrescamos la vista y cargamos los datos para visualizar
                dtv = new DataView(objProfesionalBL.ListarProfesional());
                CargarDatos(txtFiltro.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ProfesionalMan03 profe03 = new ProfesionalMan03();
                //Se toma el valor de la columna cero de la fila seleccionada en el
                //datagridview...
                profe03.Codigo = dtgProfesionales.CurrentRow.Cells[0].Value.ToString();
                profe03.ShowDialog();

                //Al retornar, refrescamos la vista y cargamos los datos para ver los
                //cambios del Apoderado actualizado.
                dtv = new DataView(objProfesionalBL.ListarProfesional());
                CargarDatos(txtFiltro.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult vrpta;
                vrpta = MessageBox.Show("Seguro de eliminar el registro?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (vrpta == DialogResult.Yes)
                {
                    if (objProfesionalBL.EliminarProfesional
                        (dtgProfesionales.CurrentRow.Cells[0].Value.ToString(), clsCredenciales.Usuario) == true)
                    {
                        CargarDatos(txtFiltro.Text.Trim());
                    }
                    else
                    {
                        throw new Exception("Registro no se pudo eliminar . Contacte con Administrador de Sistema");
                    }
                }
            }
            catch (Exception ex)
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
