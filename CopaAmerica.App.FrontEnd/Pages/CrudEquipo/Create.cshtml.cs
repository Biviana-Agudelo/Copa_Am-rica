using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CopaAmerica.App.Dominio;
using CopaAmerica.App.Persistencia.AppRepositorios;


namespace CopaAmerica.App.FrontEnd.Pages.CrudEquipo
{
    public class CreateModel : PageModel
    {
        private readonly CopaAmerica.App.Persistencia.AppRepositorios.AppContext _context;
        private readonly IRepositorioPersonas repoPersona;
        private readonly IRepositorioEquipos repoEquipo;
        private readonly IRepositorioDirectoresTecnicos repoDT;
        private readonly IRepositorioJugadores repoJugador;

        public CreateModel(CopaAmerica.App.Persistencia.AppRepositorios.AppContext context,
                           IRepositorioPersonas repoPersona,
                           IRepositorioEquipos repoEquipo,
                           IRepositorioDirectoresTecnicos repoDT,
                           IRepositorioJugadores repoJugador)
        {
            _context = context;
            this.repoPersona = repoPersona;
            this.repoEquipo = repoEquipo;
            this.repoDT = repoDT;
            this.repoJugador = repoJugador;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Equipo Equipo { get; set; }
        [BindProperty]
        public DirectorTecnico DT { get; set; }
        [BindProperty]
        public string[] ListaNombresJugadores { get; set; }
        [BindProperty]
        public string[] ListaApellidosJugadores  { get; set; }
        [BindProperty]
        public string[] ListaPosicionesJugadores { get; set; }
        [BindProperty]
        public string[] ListaNumerosJugadores { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Equipos.Add(Equipo);
            await _context.SaveChangesAsync();
            var nuevoEquipo = repoEquipo.BuscarEquipo(Equipo.NombreEquipo);
            DT.EquipoId = nuevoEquipo.EquipoId;
            repoDT.CrearDT(DT);
            var NuevaPersona = new Persona {Nombre = null,
                                            Apellido = null};
            var NuevoJugador = new Jugador {Posicion = null,
                                            NumeroEquipo = null};
            for (int i=0; i<ListaNombresJugadores.Length; i++)
            {
                NuevaPersona.Nombre = ListaNombresJugadores[i];
                NuevaPersona.Apellido = ListaApellidosJugadores[i];
                NuevoJugador.Persona = NuevaPersona;
                NuevoJugador.Posicion = ListaPosicionesJugadores[i];
                NuevoJugador.NumeroEquipo = ListaNumerosJugadores[i];
                NuevoJugador.EquipoId = nuevoEquipo.EquipoId;
                repoJugador.CrearJugador(NuevoJugador);
            }

            return RedirectToPage("./Index");
        }
    }
}
