using Microsoft.AspNetCore.Mvc;
using OBM_Project.Data;
using OBM_Project.Models.Contato;
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
            _ContatoServices.AdicionarContato(contatos);

            return Content("Contato recebido com sucesso.");
        }
    }
}
