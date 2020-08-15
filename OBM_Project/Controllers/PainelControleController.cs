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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Usuarios obj)
        {
            TempData["Usuario"] = JsonConvert.SerializeObject(obj);
            if (_painelControleServices.ValidarUsuario(obj))
            {
                return View("Index", "PainelControle");
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
            _ContatoServices.AdicionarArea(area);
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
            _painelControleServices.AdicionarCliente(clientes);

            return RedirectToAction("Retorno");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarDemanda(Demanda demanda)
        {
            _painelControleServices.AdicionarDemanda(demanda);

            return RedirectToAction("Retorno");
        }
        public IActionResult Demanda()
        {
            return View();
        }
        public IActionResult Cliente()
        {
            return View();
        }
        public IActionResult CreateDemanda()
        {
            return View();
        }
        public IActionResult CreateCliente()
        {
            return View();
        }
    }
}
