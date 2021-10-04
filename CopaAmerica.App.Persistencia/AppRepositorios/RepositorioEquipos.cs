using CopaAmerica.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace CopaAmerica.App.Persistencia
{
    public class RepositorioEquipos:IRepositorioEquipos
    {
        private readonly AppContext _AppContext;

        public RepositorioEquipos(AppContext appContext)
        {
            _AppContext = appContext;
        }

        Equipo IRepositorioEquipos.CrearEquipo(Equipo Equipo)
        {
            var EquipoEncontrado = _AppContext.Equipos.Add(Equipo);
            _AppContext.SaveChanges();
            return EquipoEncontrado.Entity;
        }

        void IRepositorioEquipos.EliminarEquipo(int Id)
        {
            var EquipoEncontrado = _AppContext.Equipos.FirstOrDefault(p => p.EquipoId == Id);
            if(EquipoEncontrado == null)
            {
                return;
            }
            _AppContext.Equipos.Remove(EquipoEncontrado);
            _AppContext.SaveChanges();
        }

        Equipo IRepositorioEquipos.BuscarEquipo(int Id)
        {
            return _AppContext.Equipos.FirstOrDefault(p => p.EquipoId == Id);
        }

        Equipo IRepositorioEquipos.BuscarEquipo(string NombreEquipo)
        {
            return _AppContext.Equipos.FirstOrDefault(p => p.NombreEquipo == NombreEquipo);
        }

        Equipo IRepositorioEquipos.ActualizarEquipo(Equipo Equipo){
            var EquipoEncontrado = _AppContext.Equipos.FirstOrDefault(p => p.EquipoId == Equipo.EquipoId);
            if (EquipoEncontrado!=null)
            {
                EquipoEncontrado.NombreEquipo = Equipo.NombreEquipo;
                _AppContext.SaveChanges();
            }
            return EquipoEncontrado;
        }

        IEnumerable<Equipo> IRepositorioEquipos.BuscarEquipos()
        {
            return _AppContext.Equipos;
        }
    }
}