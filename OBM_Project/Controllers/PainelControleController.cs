using Microsoft.AspNetCore.Mvc;
using OBM_Project.Services;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Models.Contato;

namespace OBM_Project.Controllers
{
    public class PainelControleController : Controller
    {
        private readonly PainelControleServices _painelControleServices;
        private readonly ContatoServices _ContatoServices;
        public PainelControleController (PainelControleServices painelControleServices, ContatoServices contatoServices)
        {
            _painelControleServices = painelControleServices;
            _ContatoServices = contatoServices;
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
        public IActionResult AdicionarArea(Area area)
        {
            _ContatoServices.AdicionarArea(area);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Area()
        {
            return View();
        }
    }
}
