

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace CoreMvcVuePractice.Models
{
    //public static class SliderCaptchaTool
    //{
    //    #region Private Fields

    //    /// <summary>
    //    /// 矩形寬
    //    /// </summary>
    //    private static readonly int _l = 42;

    //    /// <summary>
    //    /// 圓形半徑
    //    /// </summary>
    //    private static readonly int _r = 9;

    //    /// <summary>
    //    /// 圓形直徑
    //    /// </summary>
    //    private static readonly int _d = _r * 2;

    //    /// <summary>
    //    /// 計算圓形與矩形交接三角形邊
    //    /// </summary>
    //    private static readonly int _a = (int)(_r * Math.Sin(Math.PI * (50 / 180f)));
    //    private static readonly int _b = (int)(_r * Math.Cos(Math.PI * (50 / 180f)));
    //    private static readonly int _c = _a - _b;

    //    /// <summary>
    //    /// 滑塊邊框大小
    //    /// </summary>
    //    private static readonly int _blod = 4;

    //    private static readonly string _imageSourcePath = "/Resources/SliderCaptcha/{0}.jpg";

    //    private static readonly int _imageSourceCount = 137;
    //    #endregion

    //    #region Private Methods
    //    /// <summary>
    //    /// 產生亂數
    //    /// </summary>
    //    /// <param name="min"></param>
    //    /// <param name="max"></param>
    //    /// <returns></returns>
    //    private static int RandomNext(int min, int max)
    //    {
    //        Random random = new(Guid.NewGuid().GetHashCode());
    //        return random.Next(min, max);
    //    }

    //    /// <summary>
    //    /// 取得原始背景底圖
    //    /// </summary>
    //    /// <returns></returns>
    //    private static Image BgImage(int customWidth, int customHeight)
    //    {
    //        int num = RandomNext(0, _imageSourceCount - 1);


    //        using (Image<Rgb24> image = (Image<Rgb24>)Image.Load(_imageSourcePath))
    //        {



    //            if (customWidth > 0 || customHeight > 0)
    //            {
    //                int width = customWidth > 0 ? customWidth : bitmap.Width;
    //                int height = customHeight > 0 ? customHeight : bitmap.Height;
    //                bitmap = new Image(bitmap, new Size(width, height));
    //            }
    //            return bitmap;
    //        }

    //    }

    //    /// <summary>
    //    /// 取得底圖圖片 Graphics
    //    /// </summary>
    //    /// <param name="image"></param>
    //    /// <returns></returns>
    //    private static Graphics GetGraphics(Image image)
    //    {
    //        Graphics g = Graphics.FromImage(image);
    //        g.SmoothingMode = SmoothingMode.HighQuality;
    //        g.CompositingQuality = CompositingQuality.HighQuality;
    //        g.InterpolationMode = InterpolationMode.High;
    //        return g;
    //    }

    //    /// <summary>
    //    /// 取得滑塊路徑
    //    /// </summary>
    //    private static GraphicsPath GetSliderPath(int x, int y)
    //    {
    //        GraphicsPath path = new GraphicsPath(FillMode.Winding);
    //        Point Pa = new Point(x, y);
    //        Point Pb = new Point(x + _l / 2 - _b, y - _c + _blod);
    //        Point Pd = new Point(x + _l, y);
    //        Point Pe = new Point(Pd.X + _c - _blod, y + _l / 2 - _b);
    //        Point Pg = new Point(Pd.X, y + _l);
    //        Point Ph = new Point(x, y + _l);
    //        Point Pj = new Point(x + _c - _blod, Pe.Y);
    //        path.AddLine(Pa, Pb);
    //        path.AddArc(x + _l / 2 - _r, y - _d, _d, _d, 130f, 280f);
    //        path.AddLines(new Point[] { Pd, Pe });
    //        path.AddArc(x + _l, y + _l / 2 - _r, _d, _d, 220f, 280f);
    //        path.AddLines(new Point[] { Pg, Ph });
    //        path.AddArc(x, y + _l / 2 - _r, _d, _d, 140f, -280f);
    //        path.AddLine(Pj, Pa);
    //        return path;
    //    }

    //    /// <summary>
    //    /// 裁切圖片
    //    /// </summary>
    //    /// <param name="fromImage"></param>
    //    /// <param name="offsetX"></param>
    //    /// <param name="height"></param>
    //    /// <returns></returns>
    //    private static Image CaptureImage(Image fromImage, int offsetX, int height)
    //    {
    //        int width = _l + _d + _blod;
    //        Bitmap bitmap = new Bitmap(width, height);
    //        Graphics g = GetGraphics(bitmap);
    //        g.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, 0, width, height), GraphicsUnit.Pixel);
    //        g.Dispose();
    //        return bitmap;
    //    }

    //    /// <summary>
    //    /// 取得滑塊的區域圖
    //    /// </summary>
    //    /// <param name="image"></param>
    //    /// <param name="path"></param>
    //    /// <param name="x"></param>
    //    /// <param name="width"></param>
    //    /// <param name="height"></param>
    //    /// <returns></returns>
    //    private static Image CaptureSlider(Image image, GraphicsPath path, int x, int width, int height)
    //    {
    //        Bitmap concave = new(image.Width, image.Height);

    //        using (Graphics g = GetGraphics(concave))
    //        {
    //            TextureBrush brush = new TextureBrush(image);
    //            g.Clear(Color.Transparent);
    //            g.FillPath(brush, path);
    //            return CaptureImage(concave, x, height);
    //        }
    //    }

    //    /// <summary>
    //    /// 產生驗證碼圖片
    //    /// </summary>
    //    /// <returns></returns>
    //    private static SliderCaptchaModel? Generate(int customWidth, int customHeight)
    //    {
    //        Bitmap image = BgImage(customWidth, customHeight);
    //        if (image is null) return null;

    //        int l = _l;
    //        int d = _d;
    //        int width = image.Width;
    //        int height = image.Height;
    //        int x = RandomNext(width / 3, width - d - l - 10); // 初始x
    //        int y = RandomNext(10 + d, height - l - 10); ; // 初始y

    //        Graphics g = GetGraphics(image);
    //        GraphicsPath path = GetSliderPath(x, y);

    //        Pen pen = new Pen(Color.FromArgb(200, 255, 255, 255), 2);
    //        g.DrawPath(pen, path);
    //        Image slider = CaptureSlider(image, path, x, width, height);
    //        SolidBrush brush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
    //        g.FillPath(brush, path);
    //        g.Save();
    //        g.Dispose();

    //        return new SliderCaptchaModel()
    //        {
    //            X = x,
    //            Y = y,
    //            Background = image,
    //            Slide = slider
    //        };
    //    }

    //    #endregion

    //    #region Public Methods

    //    /// <summary>
    //    /// 取得 Base64 字串格式圖片
    //    /// </summary>
    //    public static SliderCaptchaB64Model? GenerateBase64(int customWidth, int customHeight)
    //    {
    //        SliderCaptchaModel? model = Generate(customWidth, customHeight);
    //        if (model is null || model.Background is null || model.Slide is null) return null;

    //        return new SliderCaptchaB64Model()
    //        {
    //            X = model.X,
    //            Y = model.Y,
    //            Background = model.Background.ToBase64String(JpegFormat.Instance),
    //            Slide = model.Slide.ToBase64String(PngFormat.Instance)
    //        };
    //    }

    //    /// <summary>
    //    /// 滑塊驗證碼驗證是否成功
    //    /// </summary>
    //    public static bool CheckIsSliderCaptchaVerifySuccess(List<int>? operateArray, int storedCaptchaX)
    //    {
    //        if (operateArray is null || operateArray.Count <= 1) return false;

    //        // 取得 X 的位置
    //        var captchaX = operateArray[0];
    //        operateArray.RemoveAt(0);

    //        // 計算手動滑行軌跡
    //        var sum = operateArray.Sum();
    //        var avg = sum * 1.0 / (operateArray.Count);
    //        var stddev = operateArray.Select(v => Math.Pow(v - avg, 2)).Sum() / (operateArray.Count);

    //        // 軌跡不符合則代表非人工操作
    //        if (stddev == 0) return false;

    //        int difX = storedCaptchaX - captchaX;

    //        return difX >= (0 - _blod) && (difX <= _blod);
    //    }

    //    #endregion

    //    /// <summary>
    //    /// SliderCaptchaModel
    //    /// </summary>
    //    public class SliderCaptchaModel
    //    {
    //        public int X { get; set; }
    //        public int Y { get; set; }
    //        public Image? Background { get; set; }
    //        public Image? Slide { get; set; }
    //    }

    //    /// <summary>
    //    /// SliderCaptchaB64Model
    //    /// </summary>
    //    public class SliderCaptchaB64Model
    //    {
    //        public int X { get; set; }
    //        public int Y { get; set; }
    //        public string? Background { get; set; }
    //        public string? Slide { get; set; }
    //    }
    //}
}
