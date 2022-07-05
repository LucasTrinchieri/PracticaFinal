using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades;

namespace RestAplicacion.Controllers
{
    public static class ExtensionesServicio
    {
        public static ComidaServicio Convertir(this Comida comida)
        {
            return new ComidaServicio() { Id = comida.Id, Nombre = comida.Nombre };
        }

        public static IngredienteServicio Convertir(this Ingrediente ing)
        {
            return new IngredienteServicio() { Id = ing.Id, Nombre = ing.Nombre };
        }
    }
}