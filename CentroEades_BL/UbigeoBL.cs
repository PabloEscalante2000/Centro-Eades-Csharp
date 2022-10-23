using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ensamblado..
using CentroEades_ADO;
using System.Data;
using CentroEades_BE;

namespace CentroEades_BL
{
    internal class UbigeoBL
    {
        UbigeoADO objUbigeoADO = new UbigeoADO();
        public DataTable Ubigeo_Departamentos()
        {
            return objUbigeoADO.Ubigeo_Departamentos();
        }
        public DataTable Ubigeo_ProvinciasDepartamento(String strIdDepartamento)
        {
            return objUbigeoADO.Ubigeo_ProvinciasDepartamento(strIdDepartamento);
        }
        public DataTable Ubigeo_DistritosProvinciaDepartamento(String strIdDepartamento, String strIdProvincia)
        {
            return objUbigeoADO.Ubigeo_DistritosProvinciaDepartamento(strIdDepartamento, strIdProvincia);
        }
    }
}
