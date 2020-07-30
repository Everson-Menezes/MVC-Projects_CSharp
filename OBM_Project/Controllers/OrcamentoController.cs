using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class OrcamentoController : Controller
    {
        public IActionResult Orcar()
        {
            return View("CadastrarOrcamento");
        }
        [HttpPost]
        public IActionResult SolicitarOrcamento()
        {
            return Content("Teste");
        }
    }
}
