using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; //para usar DataSet
using System.Data.SqlClient; //para conectarme a Sql
using CentroEades_BE; // conectarme a clase ProfesionalBE

namespace CentroEades_ADO
{
    public class ProfesionalADO
    {
        // Insumos.....
        ConexionADO MiConexion = new ConexionADO();
        SqlConnection cnx = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dtr;
          
        
        // Metodos de mantenimiento
        public Boolean InsertarProfesional(ProfesionalBE objProfesionalBE)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertarProfesional";
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios
                cmd.Parameters.AddWithValue("@vId_Espec", objProfesionalBE.Id_Espec);
                cmd.Parameters.AddWithValue("@vNom", objProfesionalBE.Nom_pro);
                cmd.Parameters.AddWithValue("@vApe", objProfesionalBE.Ape_pro);
                cmd.Parameters.AddWithValue("@vSuel", objProfesionalBE.Sue_pro);
                cmd.Parameters.AddWithValue("@vFec", objProfesionalBE.Fech_ing);
                cmd.Parameters.AddWithValue("@vDni", objProfesionalBE.Dni_pro);
                cmd.Parameters.AddWithValue("@vEmail", objProfesionalBE.Email_pro);
                cmd.Parameters.AddWithValue("@vUsu_Registro", objProfesionalBE.Usu_Registro);
                cmd.Parameters.AddWithValue("@vEst", objProfesionalBE.Est_pro);
                
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
        public Boolean ActualizarProfesional(ProfesionalBE objProfesionalBE)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ActualizarProfesional";
                //Agregamos parametros 
                cmd.Parameters.Clear();
                //Pasamos los parametros al SP desde las propiedades de la entidad de negocios.
                cmd.Parameters.AddWithValue("@vcod", objProfesionalBE.Cod_pro);
                cmd.Parameters.AddWithValue("@vId_Espec", objProfesionalBE.Id_Espec);
                cmd.Parameters.AddWithValue("@vNom", objProfesionalBE.Nom_pro);
                cmd.Parameters.AddWithValue("@vApe", objProfesionalBE.Ape_pro);
                cmd.Parameters.AddWithValue("@vSuel", objProfesionalBE.Sue_pro);
                cmd.Parameters.AddWithValue("@vFec", objProfesionalBE.Fech_ing);
                cmd.Parameters.AddWithValue("@vDni", objProfesionalBE.Dni_pro);
                cmd.Parameters.AddWithValue("@vEmail", objProfesionalBE.Email_pro);
                cmd.Parameters.AddWithValue("@vUsu_Ult_Mod", objProfesionalBE.Usu_Ult_Mod);
                cmd.Parameters.AddWithValue("@vEst", objProfesionalBE.Est_pro);

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

        public Boolean EliminarProfesional(String strCodigo ,String strUsuario)
        {
            
            try
            {
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_EliminarProfesional";
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

        public ProfesionalBE ConsultarProfesional(String strCodigo)
        {
            
            try
            {

                ProfesionalBE objProfesionalBE = new ProfesionalBE();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ConsultarProfesional";
                //limpiamos los parametros
                cmd.Parameters.Clear();
                //Para la consulta de un profesional solo se requiere el codigo del profesional
                cmd.Parameters.AddWithValue("@vCod_pro",strCodigo);
                //abrimos conexion y ejecutamos
                cnx.Open();
                dtr = cmd.ExecuteReader();
                if (dtr.HasRows == true)
                {
                    dtr.Read();
                    //Asignamos las columnas del dtr a las propiedades de la instancia
                    //con solo los datos que deseemos mostrar en la consulta
                    objProfesionalBE.Cod_pro = dtr["Cod_pro"].ToString();
                    objProfesionalBE.Id_Espec = Convert.ToInt16(dtr["Id_Espec"]);
                    objProfesionalBE.Nom_pro = dtr["Nom_pro"].ToString();
                    objProfesionalBE.Ape_pro = dtr["Ape_pro"].ToString();
                    objProfesionalBE.Sue_pro = Convert.ToSingle(dtr["Sue_pro"]);
                    objProfesionalBE.Fech_ing = Convert.ToDateTime(dtr["Fech_ing"]);
                    objProfesionalBE.Dni_pro = dtr["Dni_pro"].ToString();
                    objProfesionalBE.Email_pro = dtr["Email_pro"].ToString();
                    objProfesionalBE.Fech_Registro = Convert.ToDateTime(dtr["Fec_reg"]);
                    objProfesionalBE.Usu_Registro = dtr["Usu_Registro"].ToString();
                    objProfesionalBE.Fech_Ult_Mod = Convert.ToDateTime(dtr["Usu_Registro"]);
                    objProfesionalBE.Usu_Ult_Mod = dtr["Usu_Ult_Mod"].ToString();
                    objProfesionalBE.Est_pro= Convert.ToInt16(dtr["Est_pro"]);

                }
                //Cerramos el dtr y devolvemos la instancia de la entidad de negocios
                dtr.Close();
                //Devolvemos el resultado
                return objProfesionalBE;
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

        public DataTable ListarProfesional()
        {
            
            try
            {
                //creamos un dataset
                DataSet dts = new DataSet();
                cnx.ConnectionString = MiConexion.GetCnx();
                cmd.Connection = cnx;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ListarProfesional";
                cmd.Parameters.Clear();

                //creamos un adaptador 
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                //toma la foto
                ada.Fill(dts,"Profesionales");
                return dts.Tables["Profesionales"];
               
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
