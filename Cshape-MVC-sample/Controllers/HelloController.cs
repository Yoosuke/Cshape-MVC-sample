﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cshape_MVC_sample.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello! this is sample message!";
            return View();
        }

        //POST :
        [HttpPost]
        public IActionResult Form()
        {
            ViewData["Message"] = Request.Form["msg"];
            return View("Index");
        }
    }
}

