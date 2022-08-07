using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Runtime.InteropServices;

namespace CoreMvcVuePractice.Models
{
    public static class TextCaptchaTool
    {
        private static readonly List<char> numberCharactors = "0123456789".ToList();
        private static readonly List<char> uppercaseEnglishCharactor = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
        private static readonly List<char> lowercaseEnglishCharactor = " abcdefghijklmnopqrstuvwxyz".ToList();
        private static readonly int interferenceLineAmount = 100;


        public static (Image? image, string? result) GetTextCaptchaImage(
                List<TextCaptchaType> textCaptchaType,
                byte generateLength = 6,
                int width = 300,
                int height = 150)
        {
            if (textCaptchaType.Count == 0) return (null, null);

            var tempList = new List<char>();
            var resultList = new List<char>();

            if (textCaptchaType.Contains(TextCaptchaType.number)) tempList.AddRange(numberCharactors);
            if (textCaptchaType.Contains(TextCaptchaType.UppercaseEnglish)) tempList.AddRange(uppercaseEnglishCharactor);
            if (textCaptchaType.Contains(TextCaptchaType.LowercaseEnglish)) tempList.AddRange(lowercaseEnglishCharactor);

            Random rand = new();

            // 生成資料
            for (int i = 0; i < generateLength; i++) resultList = resultList.Append(tempList[rand.Next(0, tempList.Count)]).ToList();

            // 生成空白圖
            var resultImage = new Image<Rgb24>(width, height);

            // 依序隨機擺放文字
            FontCollection fonts = new FontCollection();
            FontFamily fontfamily = fonts.Add(@"D:\Project\CoreMvcVuePractice\CoreMvcVuePractice\Resources\Fonts\holomdl2.ttf");
            Font font = new(fontfamily, 20);

            resultImage.Mutate(x => x.DrawText(
                resultList.ToString(),
                font,
                Color.Black,
                new PointF(100, 100))
            );

            // 產生干擾線條
            //int startX, startY, endX, endY;
            //for (int i = 0; i < interferenceLineAmount; i++)
            //{
            //    startX = rand.Next(0, width);
            //    startY = rand.Next(0, height);
            //    endX = rand.Next(0, width);
            //    endY = rand.Next(0, height);
            //    g.DrawLine(new Pen(Brushes.Red), startX, startY, endX, endY);
            //}

            return (resultImage, resultList.ToString());
        }

        public enum TextCaptchaType
        {
            number,
            UppercaseEnglish,
            LowercaseEnglish,
        }
    }
}
