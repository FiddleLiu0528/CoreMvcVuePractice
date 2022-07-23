using HtmlAgilityPack;

namespace CoreMvcVuePractice.Models
{
    public static class StaticFrontEndPages
    {
        public readonly static string loginPage = File.ReadAllText("wwwroot/login/template");
        public readonly static string mainPage = File.ReadAllText("wwwroot/main/template");
    }
}
