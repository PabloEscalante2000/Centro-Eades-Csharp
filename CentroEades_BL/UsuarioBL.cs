using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ensamblado..
using CentroEades_ADO;
using CentroEades_BE;

namespace CentroEades_BL
{
    public class UsuarioBL
    {
        UsuarioADO objUsuarioADO = new UsuarioADO();

        public UsuarioBE ConsultarUsuarioLogin(String strLogiin)
        {
            return objUsuarioADO.ConsultarUsuario(strLogiin);
        }
    }
}
