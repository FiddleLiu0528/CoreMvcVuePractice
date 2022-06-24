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
            var targetPath = $"ClientApp/{pageName}/dist/index";

            var res = File.ReadAllText(targetPath);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(res);

            var scripts = htmlDoc.DocumentNode.SelectNodes(".//script[@src]");

            foreach (var script in scripts)
            {
                var temp = script.GetAttributeValue("src", "");
                var setValue = temp.Replace($"/{pageName}/", $"/ClientApp/{pageName}/dist/");
                script.SetAttributeValue("src", setValue);
            }

            var links = htmlDoc.DocumentNode.SelectNodes(".//link[@href]");

            foreach (var link in links)
            {
                var temp = link.GetAttributeValue("href", "");
                var setValue = temp.Replace($"/{pageName}/", $"/ClientApp/{pageName}/dist/");
                link.SetAttributeValue("href", setValue);
            }

            return htmlDoc.DocumentNode.OuterHtml;
        }
#else
        public readonly static string loginPage = File.ReadAllText("wwwroot/login/index");
        public readonly static string mainPage = File.ReadAllText("wwwroot/main/index");
#endif
    }
}
