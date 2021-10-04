using Microsoft.EntityFrameworkCore;
using CopaAmerica.App.Dominio;

namespace CopaAmerica.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Jugador> Jugadores {get; set;}
        public DbSet<Equipo> Equipos {get; set;}
        public DbSet<DirectorTecnico> DirectoresTecnicos {get; set;}
        public DbSet<Administrador> Administradores {get; set;}
        public DbSet<Grupo> Grupos {get; set;}
        public DbSet<FaseClasificacion> Clasificaciones {get; set;}
        public DbSet<Partido> Partidos {get; set;}
        public DbSet<Evento> Eventos {get; set;}
        public DbSet<FaseEliminacion> Eliminaciones {get; set;}
        public DbSet<RelacionEquipoFase> RelacionEquipoFase {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CopaAmericaData");
            }
        }

    }
}