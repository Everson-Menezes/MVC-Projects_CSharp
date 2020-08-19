using Microsoft.AspNetCore.Mvc;
using OBM_Project.Services;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.ViewModels;
using OBM_Project.Models.Contato;
using OBM_Project.Models.Usuario;
using Newtonsoft.Json;
using System.Collections.Generic;
using OBM_Project.Models.Cliente;
using OBM_Project.Models.Demanda;
using System.Globalization;

namespace OBM_Project.Controllers
{
    public class PainelControleController : Controller
    {
        private readonly PainelControleServices _painelControleServices;
        private readonly ContatoServices _contatoServices;
        private readonly OrcamentoServices _orcamentoServices;
        public PainelControleController(PainelControleServices painelControleServices, ContatoServices contatoServices, OrcamentoServices orcamentoServices)
        {
            _painelControleServices = painelControleServices;
            _contatoServices = contatoServices;
            _orcamentoServices = orcamentoServices;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Usuarios obj)
        {
            TempData["Usuario"] = JsonConvert.SerializeObject(obj);
            if (_painelControleServices.ValidarUsuario(obj))
            {
                var model = _orcamentoServices.ListarOrcamentosPendentes();
                return View("Index", model);
            }
            //Caixa de dialogo login invalido
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName("Retorno")]
        public IActionResult Index()
        {
            var obj = JsonConvert.DeserializeObject<Usuarios>((string)TempData["Usuario"]);
            if (_painelControleServices.ValidarUsuario(obj))
            {
                return View("Index", "PainelControle");
            }
            //Caixa de dialogo login invalido
            return RedirectToAction("Index", "Home");
        }
        public IActionResult OrcamentosPendentes()
        {
            var orcamentosPendentes = _orcamentoServices.ListarOrcamentosPendentes();
            return View(orcamentosPendentes);
        }
        public IActionResult TipoServico()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarTipoServico(TipoServico tipoServico)
        {
            //var obj = JsonConvert.DeserializeObject<Usuarios>((string)TempData["Usuario"]);
            _painelControleServices.AdicionarTipoServico(tipoServico);

            return RedirectToAction("Retorno");
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
            return RedirectToAction("Retorno");
        }
        public IActionResult Necessidade()
        {
            return View();
        }
        public IActionResult AdicionarNecessidade(Necessidade necessidade)
        {
            _painelControleServices.AdicionarNecessidade(necessidade);
            return RedirectToAction("Retorno");
        }
        public IActionResult AdicionarArea(Area area)
        {
            _contatoServices.AdicionarArea(area);
            return RedirectToAction("Retorno");
        }
        public IActionResult Area()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarCliente(Clientes clientes)
        {
            clientes.Nome = string.Format(clientes.Nome.ToUpper());
            _painelControleServices.AdicionarCliente(clientes);

            return RedirectToAction("Retorno");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarDemanda(Demandas demanda)
        { 
            _painelControleServices.AdicionarDemanda(demanda);

            return RedirectToAction("Retorno");
        }
        public IActionResult Demanda()
        {
            var model = _painelControleServices.ListarDemandas();
            return View(model);
        }
        public IActionResult Cliente()
        {
            return View();
        }
        public IActionResult CreateDemanda()
        {
            var clientes = _painelControleServices.ListarClientes();
            var orcamentos = _orcamentoServices.ListarOrcamentos();
            var viewModel = new DemandaViewModel { Orcamento = orcamentos, Cliente = clientes };
            return View(viewModel);
        }
        public IActionResult CreateCliente()
        {
            return View();
        }
        [HttpPost]
        public Clientes FindCliente(string nomeCliente)
        {
            nomeCliente = string.Format(nomeCliente.ToUpper());
            Clientes retorno = _painelControleServices.BuscarCliente(nomeCliente);
            return retorno;
        }
    }
}
