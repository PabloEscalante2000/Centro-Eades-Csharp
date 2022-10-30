using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            // Construimos el dataview en base al datatable devuelto por el metodo ListarCategoria
            dtv = new DataView(objPacienteBL.ListarPaciente());
            // Y se filtra el dataview segun la cadena strFiltro recibido como parametro
            dtv.RowFilter = "Ape_pac like  '%" + strFiltro + "%'";
            // Se enlaza el datagrid al dataview ya filtrado
            dtgPacientes.DataSource = dtv;
            // Mostramos la cantidad de filas filtradas
            lblRegistros.Text = dtgPacientes.Rows.Count.ToString();
        }
        private void PacienteMan01_Load(object sender, EventArgs e)
        {
            try
            {
                // Configuramos el datagrid para que no se generen columnas automaticamente
                dtgPacientes.AutoGenerateColumns = false;
                // Invocamos al metodo para cargar los datos              
                CargarDatos("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)
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
                // Creamos una instancia de CategoriaMan02 y lo mostramos de manera modal
                PacienteMan02 pacMan02 = new PacienteMan02();
                pacMan02.ShowDialog();

                // Al retornar, refrescamos la vista y cargamos los datos para visualizar
                // al Categoria agregado
                dtv = new DataView(objPacienteBL.ListarPaciente());
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
                PacienteMan03 pacMan03 = new PacienteMan03();
                // Se toma el valor de la columna cero de la fila seleccionada en el
                // datagridview ....
                pacMan03.Codigo = dtgPacientes.CurrentRow.Cells[0].Value.ToString();
                pacMan03.ShowDialog();

                // Al retornar, refrescamos la vista y cargamos los datos para ver los
                // cambios del Categoria actualizado
                dtv = new DataView(objPacienteBL.ListarPaciente());
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
                vrpta = MessageBox.Show("Seguro de eliminar registro?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (vrpta == DialogResult.Yes)
                {
                    if (objPacienteBL.EliminarPaciente
                        (dtgPacientes.CurrentRow.Cells[0].Value.ToString(), clsCredenciales.Usuario) == true)
                    {
                        CargarDatos(txtFiltro.Text.Trim());
                    }
                    else
                    {
                        throw new Exception("Registro no se pudo eliminar . Contacte con TI");
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
