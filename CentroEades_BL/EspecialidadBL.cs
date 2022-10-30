using CentroEades_ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BL
{
    public class EspecialidadBL
    {
        EspecialidadADO objEspecialidadADO = new EspecialidadADO();

        public DataTable Listar_Ubigeo()
        { 
            return objEspecialidadADO.Listar_Ubigeo();
        }
    }
}
