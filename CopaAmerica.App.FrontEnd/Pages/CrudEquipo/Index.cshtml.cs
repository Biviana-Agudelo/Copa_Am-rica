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
    public class IndexModel : PageModel
    {
        private readonly CopaAmerica.App.Persistencia.AppRepositorios.AppContext _context;

        public IndexModel(CopaAmerica.App.Persistencia.AppRepositorios.AppContext context)
        {
            _context = context;
        }

        public IList<Equipo> Equipo { get;set; }

        public async Task OnGetAsync()
        {
            Equipo = await _context.Equipos.ToListAsync();
        }
    }
}
