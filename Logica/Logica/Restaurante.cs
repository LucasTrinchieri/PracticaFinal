using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public sealed class Restaurante
    {
        private static Restaurante instance;

        private Restaurante() { }

        public static Restaurante Instancia
        {
            get
            {
                if (instance == null)
                {
                    instance = new Restaurante();
                }
                return instance;
            }
        }

        private List<Comida> Comidas = new List<Comida>()
        {
            new Comida(1, "Simple"),
            new Comida(2, "Media"),
            new Comida(3, "Completa")
        };
        private List<Ingrediente> Ingredientes = new List<Ingrediente>()
        {
            new Ingrediente(1, "Tomate"),
            new Ingrediente(2, "Lechuga"),
            new Ingrediente(3, "Cebolla"),
            new Ingrediente(4, "Hamburguesa")
        };

        public delegate object Agregar(string nombre);
        public delegate object Modificar(int id, string nombre);
        public delegate object Eliminar(int id);

        public EventHandler<Eventos.AgragarEvento> objetoAgregado;

        #region Obtener
        public Comida ObtenerComida(int id)
        {
            return Comidas.FirstOrDefault( x => x.Id == id);
        }

        public Ingrediente ObtenerIngrediente(int id)
        {
            return Ingredientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Comida> ObtenerComidas()
        {
            return Comidas;
        }

        public List<Ingrediente> ObtenerIngredientes()
        {
            return Ingredientes;
        }
        #endregion
        #region Modificar

        public Comida ModificarComida(int id, string nombre)
        {
            Comida comida = ObtenerComida(id);

            if (Utilidades.ValidarStrings(nombre) && !comida.EsNull())
            {
                return comida.Modificar(nombre);
            }
            throw new Excepciones.NombreVacioExpecion(" El nombre no puede estar vacio");
        }

        public Ingrediente ModificarIngrediente(int id, string nombre)
        {
            Ingrediente ing = ObtenerIngrediente(id);

            if (Utilidades.ValidarStrings(nombre))
            {
                return ing.Modificar(nombre);
            }
            throw new Excepciones.NombreVacioExpecion(" El nombre no puede estar vacio");
        }

        #endregion
        #region Eliminar

        public Comida EliminarComida(int id)
        {
            Comida comida = ObtenerComida(id);

            if (!comida.EsNull())
            {
                Comidas = Comidas.Where(x => x != comida).ToList();
            }

            return comida;
        }

        public Ingrediente EliminarIngrediente(int id)
        {
            Ingrediente ing = ObtenerIngrediente(id);

            if (!ing.EsNull())
            {
                Ingredientes = Ingredientes.Where(x => x != ing).ToList();
            }

            return ing;
        }

        #endregion
        #region Agregar

        public Comida AgregarComida(string nombre)
        {
            Comida comida = new Comida(Comidas.Last().Id + 1, nombre);

            if (!comida.EsNull())
            {
                Comidas.Add(comida);
            }

            if (objetoAgregado != null)
            {
                this.objetoAgregado(
                                this, new Eventos.AgragarEvento()
                                {
                                    Id = comida.Id,
                                    Nombre = comida.Nombre
                                }
                                );
            }
            
            return comida;
        }

        public Ingrediente AgregarIngrediente(string nombre)
        {
            Ingrediente ing = new Ingrediente(Ingredientes.Last().Id + 1, nombre);

            if (!ing.EsNull())
            {
                Ingredientes.Add(ing);
            }

            if (objetoAgregado != null)
            {
                this.objetoAgregado(
                                this, new Eventos.AgragarEvento()
                                {
                                    Id = ing.Id,
                                    Nombre = ing.Nombre
                                }
                                );
            }

            return ing;
        }

        #endregion
    }
}
