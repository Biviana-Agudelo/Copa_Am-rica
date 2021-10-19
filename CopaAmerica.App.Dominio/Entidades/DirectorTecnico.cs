using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class DirectorTecnico
    {
        public int DirectorTecnicoId {get; set;}
        public int PersonaId {get; set;}
        public virtual Persona Persona {get; set;}
        public int EquipoId {get; set;}
        public virtual Equipo Equipo {get; set;}
        public string Nacionalidad {get; set;}
    }
}