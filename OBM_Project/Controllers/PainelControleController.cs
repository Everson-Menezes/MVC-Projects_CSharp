using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class PainelControleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdicionarTipoServico()
        {
            return View();
        }
        public IActionResult AdicionarSubTipoServico()
        {
            return View();
        }
        public IActionResult AdicionarNecessidade()
        {
            return View();
        }
    }
}
