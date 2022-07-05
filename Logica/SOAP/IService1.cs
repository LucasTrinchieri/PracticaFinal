using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SOAP
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Respuesta Agregar(string nombre);
        [OperationContract]
        Respuesta Eliminar(int id);
        [OperationContract]
        Respuesta Modificar(int id, string nombre);
        [OperationContract]
        Respuesta ObtenerLista();
        [OperationContract]
        Respuesta ObtenerElemento(int id);
    }

    [DataContract]
    public class ComidaServicio
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public List<Ingrediente> Ingredientes { get; set; }
        public DateTime UltimaInteraccion
        {
            get
            {
                return DateTime.Now;
            }
        }

        public ComidaServicio()
        {

        }

        public ComidaServicio(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;

            Ingredientes = new List<Ingrediente>()
            {
                new Ingrediente(1,"Tomate"),
                new Ingrediente(2, "Cebolla"),
                new Ingrediente(3, "Hamburguesa"),
            };
        }
    }

    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public object Objeto { get; set; }
        [DataMember]
        public bool SeCompleto { get { return Objeto != null; } }
        [DataMember]
        public string Mensaje { get { return SeCompleto == true ? " Solicitud Satisafactoria" : " Solicitud Erronea"; } }

        public Respuesta()
        {

        }

        public Respuesta(object o)
        {
            Objeto = o;
        }
    }

    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Ingrediente()
        {

        }

        public Ingrediente(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
