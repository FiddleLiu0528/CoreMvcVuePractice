namespace CoreMvcVuePractice.Models
{
    public static class StaticFrontEndPages
    {
#if DEBUG
        public readonly static string loginPage = File.ReadAllText("ClientApp/login/dist/index");
        public readonly static string mainPage = File.ReadAllText("ClientApp/main/dist/index");
#else
        public readonly static string loginPage = File.ReadAllText("wwwroot/login/index");
        public readonly static string mainPage = File.ReadAllText("wwwroot/main/index");
#endif
    }
}
