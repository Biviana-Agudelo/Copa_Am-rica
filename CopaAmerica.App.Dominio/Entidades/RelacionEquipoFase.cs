using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class RelacionEquipoFase
    {
        public int RelacionEquipoFaseId {get; set;}
        public Equipo Equipo {get; set;}
        public FaseEliminacion FaseEliminacion {get; set;}
        public string EstadoFase {get; set;}
    }
}
