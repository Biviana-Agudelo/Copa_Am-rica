using CopaAmerica.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace CopaAmerica.App.Persistencia
{
    public class RepositorioJugadores:IRepositorioJugadores
    {
        private readonly AppContext _AppContext;

        public RepositorioJugadores(AppContext appContext)
        {
            _AppContext = appContext;
        }

        Jugador IRepositorioJugadores.CrearJugador(Jugador Jugador)
        {
            var JugadorEncontrado = _AppContext.Jugadores.Add(Jugador);
            _AppContext.SaveChanges();
            return JugadorEncontrado.Entity;
        }

        void IRepositorioJugadores.EliminarJugador(int Id)
        {
            var JugadorEncontrado = _AppContext.Jugadores.FirstOrDefault(p => p.JugadorId == Id);
            if(JugadorEncontrado == null)
            {
                return;
            }
            _AppContext.Jugadores.Remove(JugadorEncontrado);
            _AppContext.SaveChanges();
        }

        Jugador IRepositorioJugadores.BuscarJugador(int Id)
        {
            Jugador jugador = _AppContext.Jugadores.FirstOrDefault(j => j.JugadorId == Id);
            Persona persona = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == jugador.PersonaId);
            Equipo equipo = _AppContext.Equipos.FirstOrDefault(e => e.EquipoId == jugador.EquipoId);
            jugador.Persona = persona;
            jugador.Equipo = equipo;
            return jugador;
        }

        Jugador IRepositorioJugadores.ActualizarJugador(Jugador Jugador){
            var JugadorEncontrado = _AppContext.Jugadores.FirstOrDefault(j => j.JugadorId == Jugador.JugadorId);
            var PersonaEncontrada = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == Jugador.PersonaId);
            if (JugadorEncontrado!=null && PersonaEncontrada!=null)
            {
                PersonaEncontrada.Nombre = Jugador.Persona.Nombre;
                PersonaEncontrada.Apellido = Jugador.Persona.Apellido;
                JugadorEncontrado.Posicion = Jugador.Posicion;
                JugadorEncontrado.NumeroEquipo = Jugador.NumeroEquipo;
                _AppContext.SaveChanges();
            }
            return JugadorEncontrado;
        }

        IEnumerable<Jugador> IRepositorioJugadores.BuscarJugadores(Equipo equipo)
        {
            var listaJugadores = _AppContext.Jugadores.Where(j => j.EquipoId == equipo.EquipoId).ToList();
            foreach (var item in listaJugadores)
            {
                item.Persona = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == item.PersonaId);
            }
            return listaJugadores;
            //return _AppContext.Jugadores.Where(j => j.EquipoId == equipo.EquipoId).ToList();
        }
    }
}