using CopaAmerica.App.Dominio;
using System.Collections.Generic;

namespace CopaAmerica.App.Persistencia
{
    public interface IRepositorioPersonas
    {
        IEnumerable<Persona> BuscarPersonas();

        Persona CrearPersona(Persona Persona);

        Persona ActualizarPersona(Persona Persona);

        void EliminarPersona(int Id);

        Persona BuscarPersona(int Id);
    }
}