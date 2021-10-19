using CopaAmerica.App.Dominio;
using System.Collections.Generic;

namespace CopaAmerica.App.Persistencia.AppRepositorios
{
    public interface IRepositorioJugadores
    {
        IEnumerable<Jugador> BuscarJugadores(Equipo equipo);

        Jugador CrearJugador(Jugador Jugador);

        Jugador ActualizarJugador(Jugador Jugador);

        void EliminarJugador(int Id);

        Jugador BuscarJugador(int Id);
    }
}