using CoreMvcVuePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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

                if (!isExist) return RedirectToAction("Index", "Login"); // 使用者資訊不存在(未登入)，則返回首頁

                ViewBag.Account = userSessionInfo?.Account;
                ViewBag.SessionId = userSessionInfo?.SessionId;

                // 轉導頁面
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
}