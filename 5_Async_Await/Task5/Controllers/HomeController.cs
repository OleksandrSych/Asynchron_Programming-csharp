using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Task5.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            News news = await Task.Run(() => { return (new News()).Get(); });
            return View(news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}