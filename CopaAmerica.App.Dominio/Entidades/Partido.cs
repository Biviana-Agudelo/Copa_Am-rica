using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Partido
    {
        public int PartidoId {get; set;}
        public int Equipo1EqipoId {get; set;}
        public virtual Equipo Equipo1 {get; set;}
        public int Equipo2EqipoId {get; set;}
        public virtual Equipo Equipo2 {get; set;}
        public string GolesE1 {get; set;}
        public string GolesE2 {get; set;}
        public string TirosArcoE1 {get; set;}
        public string TirosArcoE2 {get; set;}
        public string TirosEsquinaE1 {get; set;}
        public string TirosEsquinaE2 {get; set;}
        public string TarjetasAmarillasE1 {get; set;}
        public string TarjetasAmarillasE2 {get; set;}
        public string TarjetasRojasE1 {get; set;}
        public string TarjetasRojasE2 {get; set;}
        public string PosecionPelotaE1 {get; set;}
        public string PosecionPelotaE2 {get; set;}
    }
}