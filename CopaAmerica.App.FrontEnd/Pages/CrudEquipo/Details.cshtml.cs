using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CopaAmerica.App.Dominio;
using CopaAmerica.App.Persistencia.AppRepositorios;

namespace CopaAmerica.App.FrontEnd.Pages.CrudEquipo
{
    public class DetailsModel : PageModel
    {
        private readonly CopaAmerica.App.Persistencia.AppRepositorios.AppContext _context;
        private readonly IRepositorioPersonas repoPersona;
        private readonly IRepositorioEquipos repoEquipo;
        private readonly IRepositorioDirectoresTecnicos repoDT;
        private readonly IRepositorioJugadores repoJugador;

        public DetailsModel(CopaAmerica.App.Persistencia.AppRepositorios.AppContext context,
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

        public Equipo Equipo { get; set; }
        public DirectorTecnico DT { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equipos.FirstOrDefaultAsync(m => m.EquipoId == id);
            DT = repoDT.BuscarDT(Equipo);

            if (Equipo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
