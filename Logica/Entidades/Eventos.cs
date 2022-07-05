using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Eventos
    {
        public class AgragarEvento : EventArgs
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}
