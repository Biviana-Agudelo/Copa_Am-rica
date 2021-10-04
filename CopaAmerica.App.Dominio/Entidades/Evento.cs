using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class Evento
    {
        public int EventoId {get; set;}
        public Equipo Equipo {get; set;}
        public Jugador Jugadores {get; set;}
        public Partido Partidos {get; set;}
        public string Accion {get; set;}
        public string Tiempo {get; set;}
    }
}