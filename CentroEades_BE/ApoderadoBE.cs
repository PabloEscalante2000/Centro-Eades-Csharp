using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BE
{
    public class ApoderadoBE
    {
        // Definimos la entidad de negocio ApoderadosBE, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Apoderados
        public String Cod_apo { get; set; }
        public String Id_Ubigeo { get; set; }
        public String Nom_apo { get; set; }
        public String Ape_apo { get; set; }
        public String Dir_apo { get; set; }
        public String Dni_apo { get; set; }
        public String Tel_apo { get; set; }
        public DateTime Fec_reg { get; set; }
        public String  Usu_Registro { get; set; }
        public DateTime Fech_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public Int16 Est_apo { get; set; }
        public String Estado { get; set; }

    }
}
