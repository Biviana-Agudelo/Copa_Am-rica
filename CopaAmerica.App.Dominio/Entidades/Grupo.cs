using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Grupo
    {
        public int GrupoId {get; set;}
        public string NombreGrupo {get; set;}
        public Equipo Equipo1 {get; set;}
        public Equipo Equipo2 {get; set;}
        public Equipo Equipo3 {get; set;}
    }
}