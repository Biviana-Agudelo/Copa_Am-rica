using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class FaseClasificacion
    {
        public int FaseClasificacionId {get; set;}
        public int EquipoId {get; set;}
        public virtual Equipo Equipos {get; set;}
        public int GrupoId {get; set;}
        public virtual Grupo Grupos {get; set;}
        public string Posicion {get; set;}
        public string PJ {get; set;}
        public string PG {get; set;}
        public string PE {get; set;}
        public string PP {get; set;}
        public string GF {get; set;}
        public string GC {get; set;}
        public string DG {get; set;}
        public string PTS {get; set;}
    }
}