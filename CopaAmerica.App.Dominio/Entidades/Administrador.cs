using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Administrador
    {
        public int AdministradorId {get; set;}
        public Persona Persona {get; set;}
        public string Cedula {get; set;}
        public string CodigoEmpleado {get; set;}

    }
}