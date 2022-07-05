using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public DateTime FechaAgregada { get; set; }

        public Comida() { }

        public Comida(int id, string nombre)
        {
            Id = Id;
            Nombre = nombre;
            FechaAgregada = DateTime.Now;
            Ingredientes = new List<Ingrediente>()
            {
                new Ingrediente() { Id = 1, Nombre = "Tomate" },
                new Ingrediente() { Id = 2, Nombre = "Lechuga" },
                new Ingrediente() { Id = 3, Nombre = "Cebolla" },
                new Ingrediente() { Id = 4, Nombre = "Hamburguesa" }
            };
        }

        public Comida Modificar(string nombre)
        {
            Nombre = nombre;

            return this;
        }
    }
}
