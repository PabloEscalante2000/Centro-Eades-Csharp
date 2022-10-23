using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //para usar DataSet
using System.Data.SqlClient; //para conectarme a Sql
using CentroEades_BE; // conectarme a clase ApoderadoBE

namespace CentroEades_ADO
{
    public class ApoderadoADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
          
        
        // Metodos de mantenimiento
        public Boolean InsertarApoderado(ApoderadoBE objApoderadoBE)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarApoderado";
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objApoderadoBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vNom", objApoderadoBE.Nom_apo);
                cmd.Parameters.AddWithValue("@vApe", objApoderadoBE.Ape_apo);
                cmd.Parameters.AddWithValue("@vDir", objApoderadoBE.Dir_apo);
                cmd.Parameters.AddWithValue("@vDni", objApoderadoBE.Dni_apo);
                cmd.Parameters.AddWithValue("@vTel", objApoderadoBE.Tel_apo);
                cmd.Parameters.AddWithValue("@vUsu_Registro", objApoderadoBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vEst", objApoderadoBE.Est_apo);
                
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
        public Boolean ActualizarApoderado(ApoderadoBE objApoderadoBE)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarApoderado";
                //Agregamos parametros 
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios.
                cmd.Parameters.AddWithValue("@vcod", objApoderadoBE.Cod_apo);
                cmd.Parameters.AddWithValue("@vId_Ubigeo", objApoderadoBE.Id_Ubigeo);
                cmd.Parameters.AddWithValue("@vNom", objApoderadoBE.Nom_apo);
                cmd.Parameters.AddWithValue("@vApe", objApoderadoBE.Ape_apo);
                cmd.Parameters.AddWithValue("@vDir", objApoderadoBE.Dir_apo);
                cmd.Parameters.AddWithValue("@vDni", objApoderadoBE.Dni_apo);
                cmd.Parameters.AddWithValue("@vTel", objApoderadoBE.Tel_apo);
                cmd.Parameters.AddWithValue("@vUsu_Ult_Mod", objApoderadoBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vEst", objApoderadoBE.Est_apo);

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

        public Boolean EliminarApoderado(String strCodigo)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarApoderado";
                //Agregamos parametros
                cmd.Parameters.Clear();
                //Para eliminar un apoderado solo se requiere saber el codigo
                cmd.Parameters.AddWithValue("@vcod", strCodigo);
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

        public ApoderadoBE ConsultarApoderado(String strCodigo)
        {
            
            try
            {

                ApoderadoBE objApoderadoBE = new ApoderadoBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarApoderado";
                //limpiamos los parametros
                cmd.Parameters.Clear();
                //Para la consulta de un proveedor solo se requiere el codigo del proveedor
                cmd.Parameters.AddWithValue("@vCod_apo",strCodigo);
                //abrmos conexion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    //Asignamos las columnas del dtr a las propiedades de la instancia
                    //con solo los datos que deseemos mostrar en la consulta
                    objApoderadoBE.Cod_apo = dtr["Cod_apo"].ToString();
                    objApoderadoBE.Nom_apo = dtr["Nom_apo"].ToString();
                    objApoderadoBE.Ape_apo = dtr["Ape_apo"].ToString();
                    objApoderadoBE.Dir_apo = dtr["Dir_apo"].ToString();
                    objApoderadoBE.Id_Ubigeo = dtr["Id_Ubigeo"].ToString();
                    objApoderadoBE.Departamento = dtr["Departamento"].ToString();
                    objApoderadoBE.Provincia = dtr["Dir_apo"].ToString();
                    objApoderadoBE.Distrito = dtr["Dir_apo"].ToString();
                    objApoderadoBE.Tel_apo = dtr["Tel_apo"].ToString();
                    objApoderadoBE.Fec_reg = Convert.ToDateTime(dtr["Fec_reg"]);
                    objApoderadoBE.Usu_Registro = dtr["Usu_Registro"].ToString();
                    objApoderadoBE.Fech_Ult_Mod = Convert.ToDateTime(dtr["Fech_Ult_Mod"]);
                    objApoderadoBE.Usu_Ult_Mod = dtr["Usu_Ult_Mod"].ToString();
                    objApoderadoBE.Est_apo= Convert.ToInt16(dtr["Est_apo"]);
                    objApoderadoBE.Estado = dtr["Estado"].ToString();  

                }
                //Cerramos el dtr y devolvemos la instancia de la entidad de negocios
                dtr.Close();
                //Devolvemos el resultado
                return objApoderadoBE;
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

        public DataTable ListarApoderado()
        {
            
            try
            {
                //creamos un dataset
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarApoderado";
                cmd.Parameters.Clear();

                //creamos un adaptador 
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //toma la foto
                ada.Fill(dts,"Apoderados");
                return dts.Tables["Apoderados"];
               
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

       

    }
}
