using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Excepciones
    {
        [Serializable]
        public class NombreVacioExpecion : Exception
        {
            public NombreVacioExpecion() { }

            public NombreVacioExpecion(string mensaje) : base(mensaje) { }
        }
    }
}
