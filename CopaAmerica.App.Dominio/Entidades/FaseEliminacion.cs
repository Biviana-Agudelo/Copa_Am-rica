using System;
using Microsoft.EntityFrameworkCore;

namespace CopaAmerica.App.Dominio
{
    public class FaseEliminacion
    {
        public int FaseEliminacionId {get; set;}
        public int NumeroGoles {get; set;}
        public bool Penal {get; set;}
        public int GolesPenal {get; set;}
        public string Resultado {get; set;}
    }
}