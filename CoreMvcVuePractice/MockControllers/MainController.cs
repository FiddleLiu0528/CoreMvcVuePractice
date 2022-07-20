using CoreMvcVuePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace CoreMvcVuePractice.Controllers
{
    public class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var userSessionInfoString = HttpContext.Session.GetString("UserSessionInfo") ?? string.Empty;
                var userSessionInfo = JsonConvert.DeserializeObject<UserSessionInfo>(userSessionInfoString);
                var isExist = userSessionInfo != null;

                if (isExist)
                {
                    ViewBag.userInfo = new
                    {
                        account = userSessionInfo?.Account,
                        nickname = userSessionInfo?.Nickname,
                    };

                    return View();
                }

                string file = @".\ClientApp\main\src\mock\FrontEndTestSetting.json";

                StreamReader r = new StreamReader(file);
                string jsonString = r.ReadToEnd();
                var Rootobject = JsonConvert.DeserializeObject<Rootobject>(jsonString);

                ViewBag.userInfo = Rootobject?.userInfo;

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Rootobject
    {
        public Userinfo? userInfo { get; set; }
    }

    public class Userinfo
    {
        public string? account { get; set; }
        public string? nickname { get; set; }
        public object[]? permission { get; set; }
    }
}


