using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CopaAmerica.App.Dominio;
using CopaAmerica.App.Persistencia.AppRepositorios;

namespace CopaAmerica.App.FrontEnd.Pages.CrudEquipo
{
    public class EditModel : PageModel
    {
        private readonly CopaAmerica.App.Persistencia.AppRepositorios.AppContext _context;
        private readonly IRepositorioPersonas repoPersona;
        private readonly IRepositorioEquipos repoEquipo;
        private readonly IRepositorioDirectoresTecnicos repoDT;
        private readonly IRepositorioJugadores repoJugador;

        public EditModel(CopaAmerica.App.Persistencia.AppRepositorios.AppContext context,
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
        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Equipo).State = EntityState.Modified;
            

            try
            {
                await _context.SaveChangesAsync();
                repoDT.ActualizarDT(DT);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(Equipo.EquipoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.EquipoId == id);
        }
    }
}
