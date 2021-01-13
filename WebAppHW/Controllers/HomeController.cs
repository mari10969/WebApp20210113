using System;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHW.Controllers
{
    public class HomeController:Controller
    {
        [HttpGet("/")]
        public IActionResult Root()
        {
            return this.View();

        }
        [HttpGet("/Signup")]
        public IActionResult Signup()
        {
            return this.View();
        }
    }
}
