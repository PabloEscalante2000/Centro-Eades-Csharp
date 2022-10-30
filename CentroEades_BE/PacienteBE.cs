using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BE
{
    public class PacienteBE
    {
        // Definimos la entidad de negocio PacienteBE, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Paciente
        public String Cod_pac { get; set; }
        public String Cod_apo { get; set; }
        public String Id_Ubigeo { get; set; }
        public String Nom_pac { get; set; }
        public String Ape_pac { get; set; }
        public String Dir_pac { get; set; }
        public String Dni_pac { get; set; }
        public String Tel_pac { get; set; }
        public String Sexo { get; set; }
        public String Sexo_Pac { get; set; }
        public DateTime Fec_nac { get; set; }
        public Byte[]? Foto_pac { get; set; }
        public DateTime Fec_reg { get; set; }
        public String Usu_Registro { get; set; }
        public DateTime Fech_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public Int16 Est_pac { get; set; }
        public String Estado { get; set; }
        public String Departamento { get; set; }
        public String Provincia { get; set; }
        public String Distrito { get; set; }
    }
}
