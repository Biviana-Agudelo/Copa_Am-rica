using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class DirectorTecnico
    {
        public int DirectorTecnicoId {get; set;}
        public Persona Persona {get; set;}
        public Equipo Equipo {get; set;}
        public string Nacionalidad {get; set;}
    }
}