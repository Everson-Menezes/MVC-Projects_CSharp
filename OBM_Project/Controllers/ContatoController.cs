using Microsoft.AspNetCore.Mvc;

namespace OBM_Project.Controllers
{
    public class ContatoController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnviarEmail()
        {
            return Content("E-mail enviado com sucesso.");
        }
        public IActionResult EnviarWhatsApp()
        {
            return Redirect("https://wa.me/5513996664409");
        }
    }
}
