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
    public class ApoderadoBL
    {
        //Creamos una instancia de la clse ApoderadoADO para invocar sus metodos.
        ApoderadoADO objApoderadoADO = new ApoderadoADO();

        public Boolean InsertarApoderado(ApoderadoBE objApoderadoBE)
        {
            return objApoderadoADO.InsertarApoderado(objApoderadoBE);
        }
        public Boolean ActualizarApoderado(ApoderadoBE objApoderadoBE)
        {
            return objApoderadoADO.ActualizarApoderado(objApoderadoBE);
        }
        public Boolean EliminarApoderado(String strcod)
        {
            return objApoderadoADO.EliminarApoderado(strcod);
        }

        public ApoderadoBE ConsultarApoderado(String strcod)
        {
            return objApoderadoADO.ConsultarApoderado(strcod);
        }

        public DataTable ListarApoderado()
        {
            return objApoderadoADO.ListarApoderado();
        }
    }
}
