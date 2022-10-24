using CentroEades_ADO;
using CentroEades_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BL
{
    public class ProfesionalBL
    {
        //Creamos una instancia de la clse ProfesionalADO para invocar sus metodos.
        ProfesionalADO objProfesionalADO = new ProfesionalADO();

        public Boolean InsertarProfesional(ProfesionalBE objProfesionalBE)
        {
            return objProfesionalADO.InsertarProfesional(objProfesionalBE);
        }
        public Boolean ActualizarProfesional(ProfesionalBE objProfesionalBE)
        {
            return objProfesionalADO.ActualizarProfesional(objProfesionalBE);
        }
        public Boolean EliminarProfesional(String strcod ,String strUsuario)
        {
            return objProfesionalADO.EliminarProfesional(strcod , strUsuario);
        }

        public ProfesionalBE ConsultarProfesional(String strcod)
        {
            return objProfesionalADO.ConsultarProfesional(strcod);
        }

        public DataTable ListarProfesional()
        {
            return objProfesionalADO.ListarProfesional();
        }
    }
}
