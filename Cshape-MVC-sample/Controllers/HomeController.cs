using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cshape_MVC_sample.Models;

namespace Cshape_MVC_sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); //Viewsフォルダに用意されたcshtmlファイルを元にクライアントへ返送内容を生成する
            //Viewsフォルダ内にあるコントローラー名フォルダからアクション名.cshtmlファイルを読み込む仕様になっている
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });//例外処理 Viewメソッドの戻り値を返す。
        }
    }
}

