﻿// <auto-generated />
using System;
using CopaAmerica.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CopaAmerica.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210919185333_entidades5")]
    partial class entidades5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CopaAmerica.App.Dominio.Administrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoEmpleado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("AdministradorId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.DirectorTecnico", b =>
                {
                    b.Property<int>("DirectorTecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("DirectorTecnicoId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("PersonaId");

                    b.ToTable("DirectoresTecnicos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Equipo", b =>
                {
                    b.Property<int>("EquipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NombreEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EquipoId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Accion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<int?>("JugadoresJugadorId")
                        .HasColumnType("int");

                    b.Property<int?>("PartidosPartidoId")
                        .HasColumnType("int");

                    b.Property<string>("Tiempo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventoId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("JugadoresJugadorId");

                    b.HasIndex("PartidosPartidoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.FaseClasificacion", b =>
                {
                    b.Property<int>("FaseClasificacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EquiposEquipoId")
                        .HasColumnType("int");

                    b.Property<string>("GC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GruposGrupoId")
                        .HasColumnType("int");

                    b.Property<string>("PE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PTS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Posicion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaseClasificacionId");

                    b.HasIndex("EquiposEquipoId");

                    b.HasIndex("GruposGrupoId");

                    b.ToTable("Clasificaciones");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.FaseEliminacion", b =>
                {
                    b.Property<int>("FaseEliminacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GolesPenal")
                        .HasColumnType("int");

                    b.Property<int>("NumeroGoles")
                        .HasColumnType("int");

                    b.Property<bool>("Penal")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FaseEliminacionId");

                    b.ToTable("Eliminaciones");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Grupo", b =>
                {
                    b.Property<int>("GrupoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Equipo1EquipoId")
                        .HasColumnType("int");

                    b.Property<int?>("Equipo2EquipoId")
                        .HasColumnType("int");

                    b.Property<int?>("Equipo3EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("NombreGrupo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrupoId");

                    b.HasIndex("Equipo1EquipoId");

                    b.HasIndex("Equipo2EquipoId");

                    b.HasIndex("Equipo3EquipoId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Jugador", b =>
                {
                    b.Property<int>("JugadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroEquipo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<string>("Posicion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JugadorId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Partido", b =>
                {
                    b.Property<int>("PartidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Equipo1EquipoId")
                        .HasColumnType("int");

                    b.Property<int?>("Equipo2EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("GolesE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GolesE2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosecionPelotaE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosecionPelotaE2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetasAmarillasE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetasAmarillasE2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetasRojasE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TarjetasRojasE2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TirosArcoE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TirosArcoE2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TirosEsquinaE1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TirosEsquinaE2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PartidoId");

                    b.HasIndex("Equipo1EquipoId");

                    b.HasIndex("Equipo2EquipoId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.RelacionEquipoFase", b =>
                {
                    b.Property<int>("RelacionEquipoFaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoFase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FaseEliminacionId")
                        .HasColumnType("int");

                    b.HasKey("RelacionEquipoFaseId");

                    b.HasIndex("EquipoId");

                    b.HasIndex("FaseEliminacionId");

                    b.ToTable("RelacionEquipoFase");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Administrador", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.DirectorTecnico", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Equipo");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Evento", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Jugador", "Jugadores")
                        .WithMany()
                        .HasForeignKey("JugadoresJugadorId");

                    b.HasOne("CopaAmerica.App.Dominio.Partido", "Partidos")
                        .WithMany()
                        .HasForeignKey("PartidosPartidoId");

                    b.Navigation("Equipo");

                    b.Navigation("Jugadores");

                    b.Navigation("Partidos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.FaseClasificacion", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipos")
                        .WithMany()
                        .HasForeignKey("EquiposEquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Grupo", "Grupos")
                        .WithMany()
                        .HasForeignKey("GruposGrupoId");

                    b.Navigation("Equipos");

                    b.Navigation("Grupos");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Grupo", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo1")
                        .WithMany()
                        .HasForeignKey("Equipo1EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo2")
                        .WithMany()
                        .HasForeignKey("Equipo2EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo3")
                        .WithMany()
                        .HasForeignKey("Equipo3EquipoId");

                    b.Navigation("Equipo1");

                    b.Navigation("Equipo2");

                    b.Navigation("Equipo3");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Jugador", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId");

                    b.Navigation("Equipo");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.Partido", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo1")
                        .WithMany()
                        .HasForeignKey("Equipo1EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo2")
                        .WithMany()
                        .HasForeignKey("Equipo2EquipoId");

                    b.Navigation("Equipo1");

                    b.Navigation("Equipo2");
                });

            modelBuilder.Entity("CopaAmerica.App.Dominio.RelacionEquipoFase", b =>
                {
                    b.HasOne("CopaAmerica.App.Dominio.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("CopaAmerica.App.Dominio.FaseEliminacion", "FaseEliminacion")
                        .WithMany()
                        .HasForeignKey("FaseEliminacionId");

                    b.Navigation("Equipo");

                    b.Navigation("FaseEliminacion");
                });
#pragma warning restore 612, 618
        }
    }
}
