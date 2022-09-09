using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using ASPNET_Core_Books_Demo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ASPNET_Core_Books_Demo.Repository;
using Webgentle.BookStore.Models;

namespace ASPNET_Core_Books_Demo.Controllers
{
    [Route("[Controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly NewBookAlertConfig _newBookAlertconfiguration;
        private readonly NewBookAlertConfig _thirdPartyBookconfiguration;
        private readonly IMessageRepository _messageRepository;

        [ViewData]
        public string Title {get; set;}

        public HomeController(IConfiguration configuration, 
            IOptionsSnapshot<NewBookAlertConfig> newBookAlertconfiguration,
            IMessageRepository messageRepository)
        {
            _configuration = configuration;
            _newBookAlertconfiguration = newBookAlertconfiguration.Get("InternalBook");
            _thirdPartyBookconfiguration = newBookAlertconfiguration.Get("ThirdPartyBook");
            _messageRepository = messageRepository;
        }

        [Route("~/")]
        public ViewResult Index()
        {
            /*dynamic userData = new ExpandoObject();
            userData.id = 1;
            userData.name = "sahil";
            ViewBag.Data = userData;
            ViewData["book"] = new BookModel() {Author="Georde R. R. Martin", id=1, Name="A dance with the Dragons" };*/
            var result = _configuration["AppName"];
            Title = "Home";
            return View();
        }

        [Route("~/About-Us/")]
        public ViewResult About()
        {
            Title = "About Us";
            return View();
        }
        [Route("~/Contact-Us/")]
        public ViewResult ContactUs()
        {
            Title = "Contact Us";
            return View();
        }
    }
}
