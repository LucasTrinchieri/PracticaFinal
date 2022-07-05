using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensiones
    {
        public static bool EsNull(this object objeto)
        {
            return objeto == null;
        }
    }
}
