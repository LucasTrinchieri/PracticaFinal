using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Ingrediente() { }

        public Ingrediente(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Ingrediente Modificar(string nombre)
        {
            Nombre = nombre;

            return this;
        }
    }
}
