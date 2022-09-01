using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Books_Demo.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "BookStoreApp";
        }
    }
}
