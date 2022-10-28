using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BE
{
    public class PacienteBE
    {
        public String Cod_pac { get; set; }
        public String Cod_apo { get; set; }
        public String Id_Ubigeo { get; set; }
        public String Nom_pac { get; set; }
        public String Ape_pac { get; set; }
        public String Dir_pac { get; set; }
        public String Dni_pac { get; set; }
        public String Tel_pac { get; set; }
        public String Sexo { get; set; }
        public DateTime Fec_nac { get; set; }
        public byte[] Foto_pac { get; set; }
        public DateTime Fec_reg { get; set; }
        public String Usu_Registro {get; set;}
        public DateTime Fech_Ult_Mod { get; set; }
        public DateTime Usu_Ult_Mod { get; set; }
        public Int16 Est_pac { get; set; }
    }
}
