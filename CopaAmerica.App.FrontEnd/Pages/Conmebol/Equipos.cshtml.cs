using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CopaAmerica.App.Dominio;
using CopaAmerica.App.Persistencia.AppRepositorios;
//using System.Collections.Generic;

namespace CopaAmerica.App.FrontEnd.Pages
{
    public class EquiposModel : PageModel
    {
        private readonly IRepositorioEquipos repositorioEquipos;
        public IEnumerable<Equipo> ListaEquipos {get;set;}

        public EquiposModel(IRepositorioEquipos repositorioEquipos)
        {
            this.repositorioEquipos = repositorioEquipos;
        }

        public void OnGet()
        {
            ListaEquipos = repositorioEquipos.BuscarEquipos();
        }
    }
}
