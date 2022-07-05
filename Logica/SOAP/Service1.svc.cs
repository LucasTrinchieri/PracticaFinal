using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Logica;
using Entidades;

namespace SOAP
{
    public class Service1 : IService1
    {
        public Respuesta Agregar(string nombre)
        {
            ComidaServicio co = Restaurante.Instancia.AgregarComida(nombre).Convertir();

            return new Respuesta(co);
        }

        public Respuesta Eliminar(int id)
        {
            ComidaServicio co = Restaurante.Instancia.EliminarComida(id).Convertir();

            return new Respuesta(co);
        }

        public Respuesta Modificar(int id, string nombre)
        {
            ComidaServicio co = Restaurante.Instancia.ModificarComida(id, nombre).Convertir();

            return new Respuesta(co);
        }

        public Respuesta ObtenerElemento(int id)
        {
            ComidaServicio co = Restaurante.Instancia.ObtenerComida(id).Convertir();

            return new Respuesta(co);
        }

        public Respuesta ObtenerLista()
        {
            List<ComidaServicio> lista = Restaurante.Instancia.ObtenerComidas()
                                        .Select( x => x.Convertir())
                                        .ToList();

            return new Respuesta(lista);
        }
    }

    public static class Extensiones
    {
        public static ComidaServicio Convertir(this Comida co)
        {
            if (co.EsNull())
            {
                return null;
            }
            return new ComidaServicio() { Id = co.Id, Nombre = co.Nombre };
        }
    }
}
