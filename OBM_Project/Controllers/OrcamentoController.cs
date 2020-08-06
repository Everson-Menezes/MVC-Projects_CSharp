using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Orcamento;
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
            return View(tipoServico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SolicitarOrcamento()
        {
            return Content("Orçamento enviado com sucesso.");
        }
    }
}
