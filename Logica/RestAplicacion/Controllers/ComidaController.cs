using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Entidades;

namespace RestAplicacion.Controllers
{
    [RoutePrefix("api/Comida")]
    public class ComidaController : ApiController
    {
        Restaurante.Agregar agregarDelegate;
        Restaurante.Modificar modificarDelegate; // estan al pedo para tirar facha
        Restaurante.Eliminar eliminarDelegate;

        public IHttpActionResult Get(int id)
        {
            ComidaServicio comida = Restaurante.Instancia.ObtenerComida(id).Convertir();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (comida.EsNull())
            {
                return NotFound();
            }

            return Ok(comida);
        }

        public IHttpActionResult Get(string nombre)
        {
            List<ComidaServicio> lista = Restaurante.Instancia.ObtenerComidas()
                                        .Select( x => x.Convertir())
                                        .ToList();

            if (!string.IsNullOrEmpty(nombre))
            {
                lista = lista.Where(x => x.Nombre == nombre).ToList();

                if (lista.EsNull())
                {
                    return NotFound();
                }
            }

            return Ok(lista);
        }

        public IHttpActionResult Post(string nombre)
        {
            Restaurante.Instancia.objetoAgregado += AgregarHandler;

            ComidaServicio comida = Restaurante.Instancia.AgregarComida(nombre).Convertir();

            if (comida.EsNull())
            {
                return BadRequest();
            }

            return Created("", comida);
        }

        public IHttpActionResult Put(int id, string nombre)
        {
            ComidaServicio coSer = Restaurante.Instancia.ModificarComida(id, nombre).Convertir();

            return Ok(coSer);
        }

        public IHttpActionResult Delete(int id)
        {
            ComidaServicio co = Restaurante.Instancia.EliminarComida(id).Convertir();

            return Ok(co);
        }

        public static void AgregarHandler(object o, Eventos.AgragarEvento e)
        {
            Console.WriteLine($" Se agrego el objeto ID: {e.Id}, Nombre: {e.Nombre}");
        }
    }
}
