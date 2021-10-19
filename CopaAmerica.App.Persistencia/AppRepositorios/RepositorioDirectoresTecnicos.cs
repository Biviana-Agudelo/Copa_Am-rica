using CopaAmerica.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace CopaAmerica.App.Persistencia.AppRepositorios
{
    public class RepositorioDirectoresTecnicos:IRepositorioDirectoresTecnicos
    {
        private readonly AppContext _AppContext;

        public RepositorioDirectoresTecnicos(AppContext appContext)
        {
            _AppContext = appContext;
        }
      
        DirectorTecnico IRepositorioDirectoresTecnicos.CrearDT(DirectorTecnico DT)
        {
            var DTEncontrado = _AppContext.DirectoresTecnicos.Add(DT);
            _AppContext.SaveChanges();
            return DTEncontrado.Entity;
        }

        void IRepositorioDirectoresTecnicos.EliminarDT(int Id)
        {
            var DTEncontrado = _AppContext.DirectoresTecnicos.FirstOrDefault(d => d.DirectorTecnicoId == Id);
            if(DTEncontrado == null)
            {
                return;
            }
            _AppContext.DirectoresTecnicos.Remove(DTEncontrado);
            _AppContext.SaveChanges();
        }

        DirectorTecnico IRepositorioDirectoresTecnicos.BuscarDT(int Id)
        {
            DirectorTecnico DT = _AppContext.DirectoresTecnicos.FirstOrDefault(d => d.DirectorTecnicoId == Id);
            Persona persona = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == DT.PersonaId);
            Equipo equipo = _AppContext.Equipos.FirstOrDefault(e => e.EquipoId == DT.EquipoId);
            DT.Persona = persona;
            DT.Equipo = equipo;
            return DT;
        }

        DirectorTecnico IRepositorioDirectoresTecnicos.BuscarDT(Equipo equipoBuscado)
        {
            DirectorTecnico DT = _AppContext.DirectoresTecnicos.FirstOrDefault(d => d.EquipoId == equipoBuscado.EquipoId);
            Persona persona = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == DT.PersonaId);
            Equipo equipo = _AppContext.Equipos.FirstOrDefault(e => e.EquipoId == DT.EquipoId);
            DT.Persona = persona;
            DT.Equipo = equipo;
            return DT;
        }

        DirectorTecnico IRepositorioDirectoresTecnicos.ActualizarDT(DirectorTecnico DT){
            var DTEncontrado = _AppContext.DirectoresTecnicos.FirstOrDefault(d => d.DirectorTecnicoId == DT.DirectorTecnicoId);
            var PersonaEncontrada = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == DT.PersonaId);
            if (DTEncontrado!=null && PersonaEncontrada!=null)
            {
                PersonaEncontrada.Nombre = DT.Persona.Nombre;
                PersonaEncontrada.Apellido = DT.Persona.Apellido;
                DTEncontrado.Nacionalidad = DT.Nacionalidad;
                _AppContext.SaveChanges();
            }
            return DTEncontrado;
        }

        IEnumerable<DirectorTecnico> IRepositorioDirectoresTecnicos.BuscarDTs(Equipo equipo)
        {
            var listaDT = _AppContext.DirectoresTecnicos.Where(d => d.EquipoId == equipo.EquipoId).ToList();
            foreach (var item in listaDT)
            {
                item.Persona = _AppContext.Personas.FirstOrDefault(p => p.PersonaId == item.PersonaId);
            }
            return listaDT;
            //return _AppContext.Jugadores.Where(j => j.EquipoId == equipo.EquipoId).ToList();
        }
    }
}