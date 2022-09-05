using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Books_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //return View("~/Mypage.cshtml");
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}
