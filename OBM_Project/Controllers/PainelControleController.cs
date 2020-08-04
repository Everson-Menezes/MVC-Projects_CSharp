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
        public IActionResult TipoServico()
        {
            return View();
        }
        public IActionResult AdicionarTipoServico()
        {
            //logica para add informacoes banco
            return View();
        }
        public IActionResult SubTipoServico()
        {
            return View();
        }
        public IActionResult AdicionarSubTipoServico()
        {
            //logica para add informacoes banco
            return View();
        }
        public IActionResult Necessidade()
        {
            return View();
        }
        public IActionResult AdicionarNecessidade()
        {
            //logica para add informacoes banco
            return View();
        }
    }
}
