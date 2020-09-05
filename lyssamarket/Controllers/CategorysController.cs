using System;
using lyssamarket.DTO;
using Microsoft.AspNetCore.Mvc;

namespace lyssamarket.Controllers
{
    public class CategorysController : Controller
    {
        [HttpPost]
        public IActionResult Save(CategoryDTO categorytemporary){
            return Content("Opa!");
        }
    }
}