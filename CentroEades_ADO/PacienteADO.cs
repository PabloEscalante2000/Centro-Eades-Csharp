using CentroEades_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_ADO
{
    public class PacienteADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;

        // Metodos de mantenimiento
        public Boolean InsertarPaciente(PacienteBE objPacienteBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarPaciente";
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios
                cmd.Parameters.AddWithValue("@vCod_apo", objPacienteBE.Cod_apo);
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objPacienteBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vNom", objPacienteBE.Nom_pac);
                cmd.Parameters.AddWithValue("@vApe", objPacienteBE.Ape_pac);
                cmd.Parameters.AddWithValue("@vDir", objPacienteBE.Dir_pac);
                cmd.Parameters.AddWithValue("@vDni", objPacienteBE.Dni_pac);
                cmd.Parameters.AddWithValue("@vTel", objPacienteBE.Tel_pac);
                cmd.Parameters.AddWithValue("@vSex", objPacienteBE.Sexo);
                cmd.Parameters.AddWithValue("@vFech_nac", objPacienteBE.Fec_nac);
                cmd.Parameters.AddWithValue("@vFoto", objPacienteBE.Foto_pac);
                cmd.Parameters.AddWithValue("@vUsu_Registro", objPacienteBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vEst", objPacienteBE.Est_pac);

                //Ejecutamos...
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;


            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }

        public Boolean ActualizarPaciente(PacienteBE objPacienteBE)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarPaciente";
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios
                cmd.Parameters.AddWithValue("@vcod", objPacienteBE.Cod_apo);
                cmd.Parameters.AddWithValue("@vCod_apo", objPacienteBE.Cod_apo);
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objPacienteBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vNom", objPacienteBE.Nom_pac);
                cmd.Parameters.AddWithValue("@vApe", objPacienteBE.Ape_pac);
                cmd.Parameters.AddWithValue("@vDir", objPacienteBE.Dir_pac);
                cmd.Parameters.AddWithValue("@vDni", objPacienteBE.Dni_pac);
                cmd.Parameters.AddWithValue("@vTel", objPacienteBE.Tel_pac);
                cmd.Parameters.AddWithValue("@vSex", objPacienteBE.Sexo);
                cmd.Parameters.AddWithValue("@vFech_nac", objPacienteBE.Fec_nac);
                cmd.Parameters.AddWithValue("@vFoto", objPacienteBE.Foto_pac);
                cmd.Parameters.AddWithValue("@vUsu_Ult_Mod", objPacienteBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vEst", objPacienteBE.Est_pac);

                //Ejecutamos...
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;


            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }


        }

        public Boolean EliminarPaciente(String strCodigo, String strUsuario)
        {

            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarPaciente";
                //Agregamos parametros
                cmd.Parameters.Clear();
                //Para eliminar un profesional solo se requiere saber el codigo
                cmd.Parameters.AddWithValue("@vcod", strCodigo);
                cmd.Parameters.AddWithValue("@Usuario", strUsuario);
                //Abrimos conexion y ejecutamos
                cnx.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (SqlException x)
            {
                throw new Exception(x.Message);
                return false;
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }
        }

        public PacienteBE ConsultarPaciente(String strCodigo)
        {

            try
            {

                PacienteBE objPacienteBE = new PacienteBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarPaciente";
                //limpiamos los parametros
                cmd.Parameters.Clear();
                //Para la consulta de un profesional solo se requiere el codigo del profesional
                cmd.Parameters.AddWithValue("@vCod_pac", strCodigo);
                //abrimos conexion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    //Asignamos las columnas del dtr a las propiedades de la instancia
                    //con solo los datos que deseemos mostrar en la consulta
                    objPacienteBE.Cod_pac = dtr["Cod_pac"].ToString();
                    objPacienteBE.Cod_apo = dtr["Cod_apo"].ToString();
                    objPacienteBE.Nom_pac = dtr["Nom_pac"].ToString();
                    objPacienteBE.Ape_pac = dtr["Ape_pac"].ToString();
                    objPacienteBE.Dir_pac = dtr["Dir_pac"].ToString();
                    objPacienteBE.Id_Ubigeo = dtr["Id_Ubigeo"].ToString();
                    objPacienteBE.Dni_pac = dtr["Dni_pac"].ToString();
                    objPacienteBE.Sexo = dtr["Sexo"].ToString();
                    objPacienteBE.Tel_pac = dtr["Tel_pac"].ToString();
                    objPacienteBE.Foto_pac = Encoding.ASCII.GetBytes(dtr["Foto_pac"].ToString());
                    objPacienteBE.Fec_reg = Convert.ToDateTime(dtr["Fec_reg"]);
                    objPacienteBE.Fec_nac = Convert.ToDateTime(dtr["Fec_nac"]);
                    objPacienteBE.Usu_Registro = dtr["Usu_registro"].ToString();
                    objPacienteBE.Fech_Ult_Mod = Convert.ToDateTime(dtr["Fech_Ult_Mod"]);
                    objPacienteBE.Usu_Ult_Mod = dtr["Usu_Ult_Mod"].ToString();
                    objPacienteBE.Est_pac = Convert.ToInt16(dtr["Est_pac"]);

                }
                //Cerramos el dtr y devolvemos la instancia de la entidad de negocios
                dtr.Close();
                //Devolvemos el resultado
                return objPacienteBE;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (cnx.State == ConnectionState.Open)
                {
                    cnx.Close();
                }

            }

        }

        public DataTable ListarPaciente()
        {

            try
            {
                //creamos un dataset
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarPaciente";
                cmd.Parameters.Clear();

                //creamos un adaptador 
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //toma la foto
                ada.Fill(dts, "Pacientes");
                return dts.Tables["Pacientes"];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
