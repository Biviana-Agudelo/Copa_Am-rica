using CopaAmerica.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace CopaAmerica.App.Persistencia.AppRepositorios
{
    public class RepositorioPersonas:IRepositorioPersonas
    {
        private readonly AppContext _AppContext;

        public RepositorioPersonas(AppContext appContext)
        {
            _AppContext = appContext;
        }
        
        Persona IRepositorioPersonas.CrearPersona(Persona Persona)
        {
            var personaEncontrada = _AppContext.Personas.Add(Persona);
            _AppContext.SaveChanges();
            return personaEncontrada.Entity;
        }

        void IRepositorioPersonas.EliminarPersona(int Id)
        {
            var personaEncontrada = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == Id);
            if(personaEncontrada == null)
            {
                return;
            }
            _AppContext.Personas.Remove(personaEncontrada);
            _AppContext.SaveChanges();
        }

        Persona IRepositorioPersonas.BuscarPersona(int Id)
        {
            return _AppContext.Personas.FirstOrDefault(p => p.PersonaId == Id);
        }

        Persona IRepositorioPersonas.ActualizarPersona(Persona Persona){
            var personaEncontrada = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == Persona.PersonaId);
            if (personaEncontrada!=null)
            {
                personaEncontrada.Nombre = Persona.Nombre;
                personaEncontrada.Apellido = Persona.Apellido;
                _AppContext.SaveChanges();
            }
            return personaEncontrada;
        }

        IEnumerable<Persona> IRepositorioPersonas.BuscarPersonas()
        {
            return _AppContext.Personas;
        }
    }
}