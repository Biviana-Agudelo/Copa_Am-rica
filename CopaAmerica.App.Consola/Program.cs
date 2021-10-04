using System;
using System.Collections.Generic;
using System.Linq;
using CopaAmerica.App.Dominio;
using CopaAmerica.App.Persistencia;

namespace CopaAmerica.App.Consola
{
    class Program
    {
        private static IRepositorioPersonas _repoPersona = new RepositorioPersonas(new Persistencia.AppContext());
        private static IRepositorioJugadores _repoJugador = new RepositorioJugadores(new Persistencia.AppContext());
        private static IRepositorioEquipos _repoEquipo = new RepositorioEquipos(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("¡BIENVENID@ A COPA AMÉRICA!\n");
            Console.WriteLine("1 - Equipo");
            Console.WriteLine("2 - Jugador");
            Console.WriteLine("3 - DT");
            Console.WriteLine("4 - Admin");
            Console.WriteLine("Ingrese opción: ");
            string A = Console.ReadLine();
            switch (A)
            {
                case "1":
                    Console.WriteLine("\nEQUIPO\n");
                    string B = listarCRUD();
                    switch (B)
                    {
                        case "1":
                            CrearEquipo();
                            break;
                        case "2":
                            BuscarEquipo();
                            break;
                        case "3":
                            ActualizarEquipo();
                            break;
                        case "4":
                            EliminarEquipo();
                            break;
                        case "5":
                            ListarEquipos();
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("\nJUGADOR\n");
                    B = listarCRUD();
                    switch (B)
                    {
                        case "1":
                            CrearJugador();
                            break;
                        case "2":
                            BuscarJugador();
                            break;
                        case "3":
                            ActualizarJugador();
                            break;
                        case "4":
                            EliminarJugador();
                            break;
                        case "5":
                            ListarJugadores();
                            break;
                        default:
                            break;
                    }
                    break;
                
                default:
                    break;
            }
        }

        private static string listarCRUD()
        {
            Console.WriteLine("1 - Crear");
            Console.WriteLine("2 - Buscar");
            Console.WriteLine("3 - Actualizar");
            Console.WriteLine("4 - Eliminar");
            Console.WriteLine("5 - Listar");
            Console.WriteLine("Ingrese opción: ");
            string B = Console.ReadLine();
            return B;
        }

        private static void CrearEquipo()
        {
            Console.WriteLine("Ingrese nombre del equipo: ");
            string NombreEquipo = Console.ReadLine();
            var Equipo = new Equipo {NombreEquipo = NombreEquipo};
            _repoEquipo.CrearEquipo(Equipo);
        }

        private static void BuscarEquipo()
        {
            Console.WriteLine("Ingrese nombre del equipo: ");
            string NombreEquipo = Console.ReadLine();
            var EquipoEncontrado = _repoEquipo.BuscarEquipo(NombreEquipo);
            Console.WriteLine(EquipoEncontrado.EquipoId);
        }

        private static void ActualizarEquipo()
        {
            Console.WriteLine("Ingrese nombre del equipo a actualizar: ");
            string NombreEquipo = Console.ReadLine();
            var EquipoEncontrado = _repoEquipo.BuscarEquipo(NombreEquipo);

            Console.WriteLine("Ingrese nuevo nombre del equipo: ");
            EquipoEncontrado.NombreEquipo = Console.ReadLine();
            var EquipoActualizado = _repoEquipo.ActualizarEquipo(EquipoEncontrado);
        }

        private static void EliminarEquipo()
        {
            Console.WriteLine("Ingrese nombre del equipo a eliminar: ");
            string NombreEquipo = Console.ReadLine();
            var EquipoEncontrado = _repoEquipo.BuscarEquipo(NombreEquipo);

            _repoEquipo.EliminarEquipo(EquipoEncontrado.EquipoId);
        }

        private static void ListarEquipos()
        {
            IEnumerable<Equipo> Equipos = _repoEquipo.BuscarEquipos();
            foreach (var item in Equipos)
            {
                Console.WriteLine(item.NombreEquipo);
            }
        }


        private static void CrearJugador()
        {
            Console.WriteLine("Ingrese nombre del jugador: ");
            string Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido del jugador: ");
            string Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese posición del jugador: ");
            string Posicion = Console.ReadLine();
            Console.WriteLine("Ingrese número del jugador: ");
            string NumeroEquipo = Console.ReadLine();
            Console.WriteLine("Ingrese equipo del jugador: ");
            string NombreEquipo = Console.ReadLine();
            var Persona = new Persona {Nombre = Nombre, Apellido = Apellido};
            var EquipoBuscado = _repoEquipo.BuscarEquipo(NombreEquipo);
            Console.WriteLine(EquipoBuscado.EquipoId);
            var Jugador = new Jugador {Posicion = Posicion, NumeroEquipo = NumeroEquipo, Persona = Persona, EquipoId = EquipoBuscado.EquipoId};

            _repoJugador.CrearJugador(Jugador);
        }

        private static void BuscarJugador()
        {
            Console.WriteLine("Ingrese id del jugador: ");
            int JugadorId = Int32.Parse(Console.ReadLine());
            var JugadorEncontrado = _repoJugador.BuscarJugador(JugadorId);
            Console.WriteLine(JugadorEncontrado.Persona.Nombre + " " + JugadorEncontrado.Persona.Apellido);
            Console.WriteLine("Posicion: " + JugadorEncontrado.Posicion);
            Console.WriteLine("Numero de equipo: " + JugadorEncontrado.NumeroEquipo);
            Console.WriteLine("Equipo: " + JugadorEncontrado.Equipo.NombreEquipo);
        }

        private static void ActualizarJugador()
        {
            Console.WriteLine("Ingrese id del jugador: ");
            int JugadorId = Int32.Parse(Console.ReadLine());
            var JugadorEncontrado = _repoJugador.BuscarJugador(JugadorId);
            
            Console.WriteLine("Ingrese nuevo nombre del Jugador: ");
            JugadorEncontrado.Persona.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo apellido del Jugador: ");
            JugadorEncontrado.Persona.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nueva posición del Jugador: ");
            JugadorEncontrado.Posicion = Console.ReadLine();
            Console.WriteLine("Ingrese nuevo numero del Jugador: ");
            JugadorEncontrado.NumeroEquipo = Console.ReadLine();
            var jugadorActualizado = _repoJugador.ActualizarJugador(JugadorEncontrado);
        }

        private static void EliminarJugador()
        {
            Console.WriteLine("Ingrese id del jugador: ");
            int JugadorId = Int32.Parse(Console.ReadLine());
            var JugadorEncontrado = _repoJugador.BuscarJugador(JugadorId);
            
            _repoJugador.EliminarJugador(JugadorEncontrado.JugadorId);
            _repoPersona.EliminarPersona(JugadorEncontrado.PersonaId);
        }

        private static void ListarJugadores()
        {
            Console.WriteLine("Ingrese id del Equipo: ");
            int EquipoId = Int32.Parse(Console.ReadLine());
            var equipoEncontrado = _repoEquipo.BuscarEquipo(EquipoId);
            var listaJugadores = _repoJugador.BuscarJugadores(equipoEncontrado);
            foreach (var item in listaJugadores)
            {
                Console.WriteLine(item.Persona.Nombre + " " + item.Persona.Apellido);
            }
        }
        
    }
}
