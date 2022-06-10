using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cshape_MVC_sample.Controllers
{
    public class HelloController : Controller
    {

        // GET: /<controller>/
        [HttpGet("Hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            ViewData["QueryMessage"] = "id=" + id + ", name=" + name;
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);
            ViewData["Message"] = "SessionにIDとNameを保存しました。";
            return View();
        }

        [HttpGet]
        public IActionResult Other()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["name"] = HttpContext.Session.GetString("name");
            ViewData["message"] = "保管されたセッションの値が表示されます。";
            return View("Index");
        }
    }
}

