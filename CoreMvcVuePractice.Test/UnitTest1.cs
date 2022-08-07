using CoreMvcVuePractice.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using static CoreMvcVuePractice.Models.TextCaptchaTool;

namespace CoreMvcVuePractice.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = new DirectoryInfo(currentDirectory)
                ?.Parent
                ?.Parent
                ?.Parent
                ?.Parent
                ?.GetDirectories(@"CoreMvcVuePractice\Resources\SliderCaptcha")
                .First()
                .GetFiles()
                .First()
                ?.FullName;

            Image<Rgb24> image = (Image<Rgb24>)Image.Load(path);

            FontCollection fonts = new FontCollection();
            FontFamily fontfamily = fonts.Add(@"C:\Users\AJuA\Documents\CoreMvcVuePractice\CoreMvcVuePractice\Resources\Fonts\holomdl2.ttf"); //�r�骺���|
            Font font = new Font(fontfamily, 8);

            image.Mutate(x => x.DrawText(
                "���դ�r",//��r���e
                font,
                Color.Black,//��r�C��
                new PointF(100, 100))//���Ц�m�]�B�I�^
            );

            var distPath = new DirectoryInfo(currentDirectory)
            ?.Parent
            ?.Parent
            ?.Parent
            ?.Parent
            ?.GetDirectories(@"CoreMvcVuePractice\Resources\Result")
            .First()
            .FullName;

            image.Save($@"{distPath}\test.jpg");
            
        }


        [TestMethod]
        public void TestMethod2()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = new DirectoryInfo(currentDirectory)
                ?.Parent
                ?.Parent
                ?.Parent
                ?.Parent
                ?.GetDirectories(@"CoreMvcVuePractice\Resources\SliderCaptcha")
                .First()
                .GetFiles()
                .First()
                ?.FullName;

            Image<Rgb24> image = (Image<Rgb24>)Image.Load(path);

            FontCollection fonts = new FontCollection();
            FontFamily fontfamily = fonts.Add(@"D:\Project\CoreMvcVuePractice\CoreMvcVuePractice\Resources\Fonts\holomdl2.ttf"); 
            Font font = new Font(fontfamily, 20);

            image.Mutate(x => x.DrawText(
                "�yԇ",
                font,
                Color.Black,
                new PointF(100, 100))
            );

            image.Mutate(x => x.DrawImage(image, new Point(100, 100), 1));

            var distPath = new DirectoryInfo(currentDirectory)
            ?.Parent
            ?.Parent
            ?.Parent
            ?.Parent
            ?.GetDirectories(@"CoreMvcVuePractice\Resources\Result")
            .First()
            .FullName;

            image.Save($@"{distPath}\{DateTime.Now.Ticks}.jpg");

        }


        [TestMethod]
        public void TestMethod3()
        {
            var textCaptchaTypeList = new List<TextCaptchaType>() { TextCaptchaType.number };

            (Image? image, string? result) = TextCaptchaTool.GetTextCaptchaImage(textCaptchaTypeList);

            Console.WriteLine(result);

            var distPath = new DirectoryInfo(Directory.GetCurrentDirectory())
            ?.Parent
            ?.Parent
            ?.Parent
            ?.Parent
            ?.GetDirectories(@"CoreMvcVuePractice\Resources\Result")
            .First()
            .FullName;

            image.Save($@"{distPath}\{DateTime.Now.Ticks}.jpg");

        }

        //[TestMethod]
        //public void MyTestMethod()
        //{
        //    SliderCaptchaTool.GenerateBase64(280, 150);

        //}
    }
}