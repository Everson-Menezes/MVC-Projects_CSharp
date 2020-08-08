using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Services;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;

namespace OBM_Project.Controllers
{
    public class PainelControleController : Controller
    {
        private readonly PainelControleServices _painelControleServices;
        public PainelControleController (PainelControleServices painelControleServices)
        {
            _painelControleServices = painelControleServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TipoServico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarTipoServico(TipoServico tipoServico)
        {
            _painelControleServices.AdicionarTipoServico(tipoServico);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SubTipoServico()
        {
            var tipoServico = _painelControleServices.ListarTipoServicos();
            var viewModel = new SubTipoServicoViewModel { TipoServicos = tipoServico };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarSubTipoServico(SubTipoServico subTipoServico)
        {
            _painelControleServices.AdicionarSubTipoServico(subTipoServico);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Necessidade()
        {
            return View();
        }
        public IActionResult AdicionarNecessidade(Necessidade necessidade)
        {
            _painelControleServices.AdicionarNecessidade(necessidade);
            return RedirectToAction(nameof(Index));
        }
    }
}
