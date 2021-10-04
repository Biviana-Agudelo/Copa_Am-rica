using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Persona
    {
        public int PersonaId {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
    }
}
