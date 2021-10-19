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
    public class DeleteModel : PageModel
    {
        private readonly CopaAmerica.App.Persistencia.AppRepositorios.AppContext _context;
        private readonly IRepositorioPersonas repoPersona;
        private readonly IRepositorioEquipos repoEquipo;
        private readonly IRepositorioDirectoresTecnicos repoDT;
        private readonly IRepositorioJugadores repoJugador;

        public DeleteModel(CopaAmerica.App.Persistencia.AppRepositorios.AppContext context,
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

        [BindProperty]
        public Equipo Equipo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equipos.FirstOrDefaultAsync(m => m.EquipoId == id);

            if (Equipo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Equipo = await _context.Equipos.FindAsync(id);

            if (Equipo != null)
            {
                var DT = repoDT.BuscarDT(Equipo);
                var Persona = DT.Persona;
                repoDT.EliminarDT(DT.DirectorTecnicoId);
                repoPersona.EliminarPersona(Persona.PersonaId);
                _context.Equipos.Remove(Equipo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
