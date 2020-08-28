using Rotativa.AspNetCore;
using System;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            var model = new CadastrarOrcamentoViewModel { TipoServicos = tipoServico, Necessidades = necessidade };
            return View(model);
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
            var tipoServico = _orcamentoServices.ListarTipoServicos();
            var necessidade = _orcamentoServices.ListarNecessidade();
            var viewModel = new CadastrarOrcamentoViewModel { TipoServicos = tipoServico, Necessidades = necessidade };
            if (orcamentos.NecessidadeId == 0 || orcamentos.Observacao == null || orcamentos.SubTipoServicoId == 0 || orcamentos.TipoServicoId == 0 || orcamentos.Solicitante == null || orcamentos.SolicitanteContato == null)
            {
                viewModel.JavascriptToRun = "Alerta()";
                return View("CadastrarOrcamento", viewModel);
            }
            else
            {
                orcamentos.DataGeracao = DateTime.Now;
                _orcamentoServices.AdicionarOrcamento(orcamentos);
                Orcamentos ultimo = _orcamentoServices.SolicitarOrcamento();
                viewModel.Orcamentos.Id = ultimo.Id;
                viewModel.JavascriptToRun = "Sucesso()";
                return View("CadastrarOrcamento", viewModel);
            }
            
        }

        public IActionResult Visualizar(Orcamentos orcamentos)
        {
            var obj = _orcamentoServices.VisualizarOrcamento(orcamentos);
            if (obj.Valor > 0 )
            {
                if(obj.Solicitante.ToLower() == orcamentos.Solicitante.ToLower())
                {
                    TempData["Orcamento"] = JsonConvert.SerializeObject(obj);
                    return View(obj);
                }
                return Content("Solicitante informado está divergente");
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
