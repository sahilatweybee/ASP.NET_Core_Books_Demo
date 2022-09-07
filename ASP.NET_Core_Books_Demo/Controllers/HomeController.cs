using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using ASPNET_Core_Books_Demo.Models;

namespace ASPNET_Core_Books_Demo.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title {get; set;}
        public ViewResult Index()
        {
            /*dynamic userData = new ExpandoObject();
            userData.id = 1;
            userData.name = "sahil";
            ViewBag.Data = userData;
            ViewData["book"] = new BookModel() {Author="Georde R. R. Martin", id=1, Name="A dance with the Dragons" };*/
            Title = "Home";
            return View();
        }

        public ViewResult About()
        {
            Title = "About Us";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contact Us";
            return View();
        }
    }
}
