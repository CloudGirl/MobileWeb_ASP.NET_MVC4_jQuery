using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "ようこそ！";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "WDD session サイト説明ページ";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "コンタクト情報ページ";

            return View();
        }
    }
}
