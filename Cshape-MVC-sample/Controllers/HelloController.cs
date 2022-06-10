using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cshape_MVC_sample.Controllers
{
    public class HelloController : Controller
    {
        public List<string> list;

        public HelloController()
        {
            list = new List<string>();
            list.Add("AM");
            list.Add("PM");
        }


        // GET: /<controller>/
        [Route("Hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            ViewData["QueryMessage"] = "id=" + id + ", name=" + name;
            ViewData["Message"] = "Hello! this is sample message!";
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["prof"] = "";
            ViewData["list"] = "";
            ViewData["listdata"] = list;
            return View();
        }

        //POST :
        [HttpPost]
        public IActionResult Form(string msg, string name, string mail, string prof)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["prof"] = prof;
            ViewData["list"] = Request.Form["list"];
            ViewData["listdata"] = list;
            ViewData["Message"] = msg + "," + ViewData["name"] + "," + ViewData["mail"] + "," + ViewData["prof"] + "," + Request.Form["list"] + " Selected.";
            return View("Index");
        }
    }
}

