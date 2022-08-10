using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CoreMvcVuePractice.Models
{
    public static class TextCaptchaTool
    {
        private static readonly List<char> numberCharactors = "0123456789".ToList();
        private static readonly List<char> uppercaseEnglishCharactor = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();
        private static readonly List<char> lowercaseEnglishCharactor = "abcdefghijklmnopqrstuvwxyz".ToList();

        private static readonly int interferenceLineAmount = 10;

        private static readonly List<FontFamily> fontFamilyList;

        static TextCaptchaTool()
        {
            fontFamilyList = new DirectoryInfo(Directory.GetCurrentDirectory())
                ?.GetDirectories(@"Resources\Fonts")
                .First()
                .GetFiles()
                .Select(s => new FontCollection().Add(s.FullName))
                .ToList() ?? new();
        }

        public static (Image? image, string? result) GetTextCaptchaImage(
                List<TextCaptchaType> textCaptchaType,
                byte generateLength = 6,
                int width = 150,
                int height = 50)
        {
            try
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
                var resultImage = new Image<Rgba32>(width, height, Color.White);

                var step = 0;
                foreach (var item in resultList)
                {
                    // 依序隨機擺放文字
                    var target = fontFamilyList[rand.Next(0, fontFamilyList.Count)];

                    Font font = new(target, rand.Next(16, 48));

                    resultImage.Mutate(x => x.DrawText(
                        new string(item.ToString()),
                        font,
                        Color.Black,
                        new PointF(step * 20, 0))
                    );

                    step++;
                }

                // 產生干擾線條
                int startX, startY, endX, endY;
                for (int i = 0; i < interferenceLineAmount; i++)
                {
                    startX = rand.Next(0, width);
                    startY = rand.Next(0, height);
                    endX = rand.Next(0, width);
                    endY = rand.Next(0, height);

                    var lineColor = Color.FromRgba(
                       r: (byte)rand.Next(255),
                       g: (byte)rand.Next(255),
                       b: (byte)rand.Next(255),
                       a: (byte)rand.Next(255));

                    float lineWidth = rand.Next(1, 10);

                    resultImage.Mutate(x => x.DrawLines(lineColor, lineWidth, new PointF[]
                        {
                        new PointF(startX, startY),
                        new PointF(endX, endY),
                        }));
                }

                return (resultImage, new string(resultList.ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); //TODO: log
                return (null, null);
            }
        }

        public enum TextCaptchaType
        {
            number,
            UppercaseEnglish,
            LowercaseEnglish,
        }
    }
}