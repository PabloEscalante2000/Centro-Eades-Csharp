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
    public class PacienteBL
    {
        //Creamos una instancia de la clse ApoderadoADO para invocar sus metodos.
        PacienteADO objPacienteADO = new PacienteADO();

        public Boolean InsertarPaciente(PacienteBE objPacienteBE)
        {
            return objPacienteADO.InsertarPaciente(objPacienteBE);
        }
        public Boolean ActualizarPaciente(PacienteBE objPacienteBE)
        {
            return objPacienteADO.ActualizarPaciente(objPacienteBE);
        }
        public Boolean EliminarPaciente(String strcod, String strUsuario)
        {
            return objPacienteADO.EliminarPaciente(strcod, strUsuario);
        }

        public PacienteBE ConsultarPaciente(String strcod)
        {
            return objPacienteADO.ConsultarPaciente(strcod);
        }

        public DataTable ListarPaciente()
        {
            return objPacienteADO.ListarPaciente();
        }
    }
}
