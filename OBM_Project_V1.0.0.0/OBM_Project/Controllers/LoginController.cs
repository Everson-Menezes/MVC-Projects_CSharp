using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OBM_Project.Models.Usuario;
using OBM_Project.Services;

namespace OBM_Project.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RedefinirSenha()
        {
            return View();
        }
    }
}
