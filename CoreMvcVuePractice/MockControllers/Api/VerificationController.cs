
using CoreMvcVuePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static CoreMvcVuePractice.Models.Dtos.VerificationControllerDtos;

namespace CoreMvcVuePractice.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VerificationController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public VerificationController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 使用者登入驗證
        /// </summary>
        [HttpPost]
        public ResponseResult VerifyLogin(VerifyLogin_Dto request)
        {
            try
            {
                var EngineerAccount = Configuration["EngineerInfo:Account"];
                var EngineerPw = Configuration["EngineerInfo:Pw"];

                var PwEncryptCode = Configuration["FrontEnd:Login:PwEncryptCode"];

                if (request.Account.ToUpper() != EngineerAccount.ToUpper() ||
                    request.Pw.ToUpper() != Tools.Md5Hash($"{PwEncryptCode}{EngineerPw}"))
                {
                    return new ResponseResult()
                    {
                        ErrorCode = ErrorCode.Fail,
                    };
                }

                UserSessionInfo info = new UserSessionInfo()
                {
                    SessionId = HttpContext.Session.Id,
                    Ip = HttpContext.Request.Host.Host,
                    Account = request.Account.ToUpper(),
                    Nickname = EngineerAccount.ToUpper()
                };

                HttpContext.Session.SetString("UserSessionInfo", JsonConvert.SerializeObject(info));

                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Success,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail,
                };
            }
        }

        ///// <summary>
        ///// 取得滑動驗證碼圖案
        ///// </summary>
        //[HttpPost]
        //public ResponseResult GetSliderCaptcha(int w, int h)
        //{
        //    var sliderCaptcha = SliderCaptchaTool.GenerateBase64(w, h);
        //    if (sliderCaptcha is null)
        //    {
        //        return new ResponseResult()
        //        {
        //            ErrorCode = ErrorCode.Fail,
        //        };
        //    }

        //    // 把答案（sliderCaptcha.X）存进session内用以验证
        //    HttpContext.Session.SetString("SliderCaptchaResult", sliderCaptcha.X.ToString());

        //    return new ResponseResult<object>()
        //    {
        //        ErrorCode = ErrorCode.Success,
        //        Result = new
        //        {
        //            Slider = sliderCaptcha.Slide,
        //            sliderCaptcha.Background
        //        }
        //    };
        //}

        ///// <summary>
        ///// 驗證滑動驗證碼圖案
        ///// </summary>
        //[HttpPost]
        //public ResponseResult VerifySliderCaptcha(VerifySliderCaptcha_Dto request)
        //{
        //    var sliderCaptchaResultString = HttpContext.Session.GetString("SliderCaptchaResult");
        //    if (sliderCaptchaResultString is null)
        //    {
        //        return new ResponseResult()
        //        {
        //            ErrorCode = ErrorCode.Fail,
        //        };
        //    }

        //    _ = int.TryParse(sliderCaptchaResultString, out int sliderCaptchaResult);

        //    bool isSuccess = SliderCaptchaTool.CheckIsSliderCaptchaVerifySuccess(request.OperateArray, sliderCaptchaResult);
        //    HttpContext.Session.SetString("IsVerifySliderCaptcha", isSuccess.ToString());

        //    return new ResponseResult<object>()
        //    {
        //        ErrorCode = ErrorCode.Success,
        //        Result = isSuccess
        //    };
        //}

        /*
        /// <summary>
        /// 取得文字驗證資訊
        /// </summary>
        [HttpPost]
        public JsonResult RetrieveValidateTextInfo()
        {
            string code = RandomCode(5);

            //定義一個畫板
            MemoryStream ms = new MemoryStream();
            using (Bitmap map = new Bitmap(160, 40))
            {
                //畫筆,在指定畫板畫板上畫圖
                using (Graphics g = Graphics.FromImage(map))
                {
                    g.Clear(Color.White);
                    g.DrawString(code, new Font("黑體", 18.0F), Brushes.Blue, new Point(50, 8));
                    //繪製干擾線(數字代表幾條)
                    PaintInterLine(g, 10, map.Width, map.Height);
                }
                map.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            return Json(new
            {
                img = Convert.ToBase64String(ms.ToArray()),
                token = MD5Helper.ComposeToMD5(string.Format($"{code}{ConfigHelper.LoginValidateTextKey}"))
            });
        }
        */
    }
}
