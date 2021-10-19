using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class RelacionEquipoFase
    {
        public int RelacionEquipoFaseId {get; set;}
        public int EquipoId {get; set;}
        public virtual Equipo Equipo {get; set;}
        public int FaseEliminacionId {get; set;}
        public virtual FaseEliminacion FaseEliminacion {get; set;}
        public string EstadoFase {get; set;}
    }
}
