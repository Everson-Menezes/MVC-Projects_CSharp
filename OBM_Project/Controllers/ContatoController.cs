using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class ContatoController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Mensagem()
        {
            return Content("Contato recebido com sucesso.");
        }
        public IActionResult EnviarWhatsApp()
        {
            return Redirect("https://wa.me/5513996664409");
        }
        public IActionResult EnviarEmail()
        {
            return Redirect("https://wa.me/5513996664409");
        }
    }
}
