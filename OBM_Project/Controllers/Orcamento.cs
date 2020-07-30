using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class Orcamento : Controller
    {
        public IActionResult CadastrarOrcamento()
        {
            return View();
        }
        public IActionResult SolicitarOrcamento()
        {
            return Content("Orçamento enviado com sucesso.");
        }
    }
}
