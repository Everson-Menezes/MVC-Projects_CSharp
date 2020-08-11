using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;

namespace OBM_Project.Controllers
{
    public class OrcamentoController : Controller
    {
        private readonly PainelControleServices _painelControleServices;
        public OrcamentoController(PainelControleServices painelControleServices)
        {
            _painelControleServices = painelControleServices;
        }
        public IActionResult CadastrarOrcamento()
        {
            var tipoServico = _painelControleServices.ListarTipoServicos();
            var necessidade = _painelControleServices.ListarNecessidade();
            var viewModel = new CadastrarOrcamentoViewModel { TipoServicos = tipoServico, Necessidades = necessidade };
             
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult VincularSubtipo(int idTipo)
        {
            var subTipoServicos = _painelControleServices.ListarSubTipoServicosPorTipo(idTipo);
            return Json(subTipoServicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SolicitarOrcamento(Orcamentos orcamentos)
        {
            _painelControleServices.AdicionarOrcamento(orcamentos);
            return Content("Orçamento enviado com sucesso.");
        }
    }
}
