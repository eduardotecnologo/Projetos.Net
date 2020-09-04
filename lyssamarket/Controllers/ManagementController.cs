using System;
using Microsoft.AspNetCore.Mvc;

namespace lyssamarket.Controllers
{
    public class ManagementController : Controller //Gestão Controller
    {
        public IActionResult Index(){
            return View();
        }
    }
}