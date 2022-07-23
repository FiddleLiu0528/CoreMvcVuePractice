using HtmlAgilityPack;

namespace CoreMvcVuePractice.Models
{
    public static class StaticFrontEndPages
    {
#if DEBUG
        public readonly static string loginPage = DirectoryConvert("login");
        public readonly static string mainPage = DirectoryConvert("main");

        static string DirectoryConvert(string pageName)
        {
            var targetPath = $"ClientApp/{pageName}/dist/template";

            var res = File.ReadAllText(targetPath);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(res);

            return htmlDoc.DocumentNode.OuterHtml;
        }
#else
        public readonly static string loginPage = File.ReadAllText("wwwroot/login/template");
        public readonly static string mainPage = File.ReadAllText("wwwroot/main/template");
#endif
    }
}
