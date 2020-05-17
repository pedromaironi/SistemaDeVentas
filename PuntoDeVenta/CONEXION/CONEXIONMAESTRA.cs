
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.CONEXION
{
    class CONEXIONMAESTRA
    {
        public static string CONEXION = Convert.ToString(Desencryptacion.checkServer());
    }

}