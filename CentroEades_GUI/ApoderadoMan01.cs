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
using CentroEades_BL;

namespace CentroEades_GUI
{
    public partial class ApoderadoMan01 : Form
    {
        ApoderadoBL objApoderadoBL = new ApoderadoBL();
        DataView dtv;
        public ApoderadoMan01()
        {
            InitializeComponent();
        }

        public void CargarDatos(String strFiltro)
        {
            // Construimos el objeto Dataview dtv en base al DataTable devuelto por el metodo ListarProveedor
            //Y lo filtramos de acuerdo al parametro strFiltro.
            dtv = new DataView(objApoderadoBL.ListarApoderado());
            dtv.RowFilter = "nom_apo like '%" + strFiltro + "%'";
            dtgApoderados.DataSource = dtv;
            lblRegistros.Text = dtgApoderados.Rows.Count.ToString();
        }

        private void ApoderadoMan01_Load(object sender, EventArgs e)
        {
            try
            {
                // Invocamos al metodo CargarDatos pasandole una cadena vacia,
                // lo cual hara que se muestren todos los proveedores por defecto al momento de cargar
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
                //Creamos una instancia de ApoderadoMan02 y lo mostramos de manera modal
                ApoderadoMan02 objMan02 = new ApoderadoMan02();
                objMan02.ShowDialog();

                //Al retornar, refrescamos la vista y cargamos los datos para visualizar
                dtv = new DataView(objApoderadoBL.ListarApoderado());
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
                //ApoderadoMan03 apode03 = new ApoderadoMan03();
                //Se toma el valor de la columna cero de la fila seleccionada en el
                //datagridview...
                //apode03.Codigo = dtgApoderados.CurrentRow.Cells[0].Value.ToString();
                //apode03.ShowDialog();

                //Al retornar, refrescamos la vista y cargamos los datos para ver los
                //cambios del proveedor actualizado.
                dtv = new DataView(objApoderadoBL.ListarApoderado());
                CargarDatos(txtFiltro.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
