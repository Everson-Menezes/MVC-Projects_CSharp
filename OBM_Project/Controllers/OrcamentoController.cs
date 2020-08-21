using Rotativa.AspNetCore;
using System;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

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
            orcamentos.DataGeracao = DateTime.Now;
            _orcamentoServices.AdicionarOrcamento(orcamentos);
            Orcamentos ultimo = _orcamentoServices.SolicitarOrcamento();
            return Content("Seu orçamento gerou a numeração: " + ultimo.Id);
        }

        public IActionResult Visualizar(Orcamentos orcamentos)
        {
            var obj = _orcamentoServices.VisualizarOrcamento(orcamentos);
            if (obj.Valor > 0)
            {
                TempData["Orcamento"] = JsonConvert.SerializeObject(obj);
                return View(obj);
            }
            else
            {
                return Content("Seu orçamento está em cotação, por favor aguarde!");
            }
        }
        public IActionResult Imprimir()
        {
            var obj = JsonConvert.DeserializeObject<Orcamentos>((string)TempData["Orcamento"]);
            return new ViewAsPdf("Visualizar", obj);
        }
        [HttpPost]
        public IActionResult FindOrcamento(int idDemanda)
        {
            Orcamentos orcamento = _orcamentoServices.FindById(idDemanda);
            if (orcamento.Valor != 0)
            {
                orcamento.Valor.ToString().Replace(".", ",");
            }

            return Json(orcamento);
        }
        public IActionResult EditarOrcamento(int id)
        {

            var obj = _orcamentoServices.FindById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AlterarOrcamento(int id, double valor)
        {
            _orcamentoServices.AlterarValor(id, valor);
            return RedirectToAction("OrcamentosPendentes", "PainelControle");
        }
    }
}
