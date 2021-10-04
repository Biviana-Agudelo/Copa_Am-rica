using CopaAmerica.App.Dominio;
using System.Collections.Generic;

namespace CopaAmerica.App.Persistencia
{
    public interface IRepositorioEquipos
    {
        IEnumerable<Equipo> BuscarEquipos();

        Equipo CrearEquipo(Equipo Equipo);

        Equipo ActualizarEquipo(Equipo Equipo);

        void EliminarEquipo(int Id);

        Equipo BuscarEquipo(int Id);

        Equipo BuscarEquipo(string NombreEquipo);
    }
}