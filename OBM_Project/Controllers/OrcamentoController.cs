using Rotativa.AspNetCore;
using System;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OBM_Project.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly OrcamentoServices _orcamentoServices;
        public OrcamentoController(OrcamentoServices orcamentoServices)
        {
            _orcamentoServices = orcamentoServices;
        }
        public IActionResult CadastrarOrcamento()
        {
            var tipoServico = _orcamentoServices.ListarTipoServicos();
            var necessidade = _orcamentoServices.ListarNecessidade();
            var viewModel = new CadastrarOrcamentoViewModel { TipoServicos = tipoServico, Necessidades = necessidade };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult VincularSubtipo(int idTipo)
        {
            var subTipoServicos = _orcamentoServices.ListarSubTipoServicosPorTipo(idTipo);

            return Json(subTipoServicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Solicitar(Orcamentos orcamentos)
        {
            _orcamentoServices.AdicionarOrcamento(orcamentos);
            return Content("Orçamento enviado com sucesso.");
        }
        public IActionResult Visualizar(Orcamentos orcamentos)
        {
            var obj = _orcamentoServices.VisualizarOrcamento(orcamentos);
            return View(obj);
        }
        public IActionResult Imprimir(Orcamentos orcamentos)
        {
            _orcamentoServices.ImprimirOrcamento(orcamentos);
            return Content("Orçamento enviado com sucesso.");
        }

    }
}
