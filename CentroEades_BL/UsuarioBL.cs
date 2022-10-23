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
        //Se drea una instancia de UsuarioADO
        UsuarioADO objUsuarioADO = new UsuarioADO();

        //la funcion nos retorna un objeto tipo UsuarioBE
        public UsuarioBE ConsultarUsuarioLogin(String strLogiin)
        {
            //lo que se retorna sera igual a la consulta del objUsuarioADO
            return objUsuarioADO.ConsultarUsuario(strLogiin);
        }
    }
}
