using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Grupo
    {
        public int GrupoId {get; set;}
        public string NombreGrupo {get; set;}
        public int Equipo1EquipoId {get; set;}
        public virtual Equipo Equipo1 {get; set;}
        public int Equipo2EquipoId {get; set;}
        public virtual Equipo Equipo2 {get; set;}
        public int Equipo3EquipoId {get; set;}
        public virtual Equipo Equipo3 {get; set;}
    }
}