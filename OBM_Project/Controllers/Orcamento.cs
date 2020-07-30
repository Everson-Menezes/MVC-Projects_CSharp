using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class Orcamento : Controller
    {
        public IActionResult Orcar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GerarOrcamento()
        {
            ViewBag.Messages = "Seu orçamento ficara pronto em até 60 minutos!";
            return View("Orcar");
        }
    }
}
