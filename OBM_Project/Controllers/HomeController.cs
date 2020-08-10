using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Contato;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;

namespace OBM_Project.Controllers
{
    public class HomeController : Controller

    {
        private readonly ContatoServices _ContatoServices;
        public HomeController(ContatoServices contatoServices)
        {
            _ContatoServices = contatoServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            var areas = _ContatoServices.ListarAreas();
            var viewModel = new ContatosViewModel { Areas = areas };
            return View(viewModel);
        }
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            //logica para validar login
            return RedirectToAction("Index", "PainelControle");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
