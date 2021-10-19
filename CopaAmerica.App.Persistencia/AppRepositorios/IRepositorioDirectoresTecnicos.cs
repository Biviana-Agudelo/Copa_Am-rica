using CopaAmerica.App.Dominio;
using System.Collections.Generic;

namespace CopaAmerica.App.Persistencia.AppRepositorios
{
    public interface IRepositorioDirectoresTecnicos
    {
        IEnumerable<DirectorTecnico> BuscarDTs(Equipo equipo);

        DirectorTecnico CrearDT(DirectorTecnico DT);

        DirectorTecnico ActualizarDT(DirectorTecnico DT);

        void EliminarDT(int Id);

        DirectorTecnico BuscarDT(int Id);

        DirectorTecnico BuscarDT(Equipo Equipo);
    }
}