using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Evento
    {
        public int EventoId {get; set;}
        public int EquipoId {get; set;}
        public virtual Equipo Equipo {get; set;}
        public int JugadorId {get; set;}
        public virtual Jugador Jugadores {get; set;}
        public int PartidoId {get; set;}
        public virtual Partido Partidos {get; set;}
        public string Accion {get; set;}
        public string Tiempo {get; set;}
    }
}