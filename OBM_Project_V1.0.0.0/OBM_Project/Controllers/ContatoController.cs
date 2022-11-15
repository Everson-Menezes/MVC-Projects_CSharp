using Microsoft.AspNetCore.Mvc;
using OBM_Project.Data;
using OBM_Project.Models.Contato;
using OBM_Project.Models.ViewModels;
using OBM_Project.Services;

namespace OBM_Project.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ContatoServices _ContatoServices;

        public ContatoController(ContatoServices contatoServices)
        {
            _ContatoServices = contatoServices;
        }
        public IActionResult EnviarWhatsApp()
        {
            return Redirect("https://wa.me/5513996664409");
        }
        public IActionResult EnviarEmail()
        {
            return Redirect("https://wa.me/5513996664409");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Mensagem(Contatos contatos)
        {
            var areas = _ContatoServices.ListarAreas();
            var viewModel = new ContatosViewModel { Areas = areas };
            
            if (contatos.Conteudo == null || contatos.AreaId == 0 || contatos.Assunto == null || contatos.Email == null || contatos.Nome == null || contatos.Telefone == null)
            {
                viewModel.JavascriptToRun = "Alerta()";
                viewModel.Alertas = "Por favor preencha todos os campos!";
                return View("Contact", viewModel);
            }
            _ContatoServices.AdicionarContato(contatos);
            viewModel.JavascriptToRun = "Alerta()";
            viewModel.Alertas = "Contato recebido com sucesso.!";
            
            return View("Contact", viewModel);
        }

        public IActionResult Contact()
        {
            var areas = _ContatoServices.ListarAreas();
            var viewModel = new ContatosViewModel { Areas = areas };
            
            return View(viewModel);
        }
    }
}
