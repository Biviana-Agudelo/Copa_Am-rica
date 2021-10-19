using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Administrador
    {
        public int AdministradorId {get; set;}
        public int PersonaId {get; set;}
        public virtual Persona Persona {get; set;}
        public string Cedula {get; set;}
        public string CodigoEmpleado {get; set;}

    }
}