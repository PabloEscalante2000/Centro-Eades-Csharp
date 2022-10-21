using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEades_BE
{
    public class ProfesionalBE
    {
        // Definimos la entidad de negocio ProfesionalBE, con todas las propiedades de acuerdo a la estructura 
        // de la tabla Tb_Profesional
        public String Cod_pro { get; set; }
        public Int16 Id_Espec { get; set; }
        public String Nom_pro { get; set; }
        public String Ape_pro { get; set; }
        public Single Sue_pro { get; set; }
        public DateTime Fech_ing { get; set; }
        public String Dni_pro { get; set; }
        public String Email_pro { get; set; }
        public DateTime Fech_Registro { get; set; }
        public String  Usu_Registro { get; set; }
        public DateTime Fech_Ult_Mod { get; set; }
        public String Usu_Ult_Mod { get; set; }
        public Int16 Est_pro { get; set; }
    }
}
