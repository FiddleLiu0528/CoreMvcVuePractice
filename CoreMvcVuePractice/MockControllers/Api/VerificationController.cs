
using CoreMvcVuePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using static CoreMvcVuePractice.Models.Dtos.VerificationControllerDtos;
using static CoreMvcVuePractice.Models.TextCaptchaTool;

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
                var LoginValidateTypeStr = Configuration["LoginValidateType"];

                // 設定驗證為文字圖片驗證
                if (LoginValidateTypeStr == LoginValidateType.TextCaptcha.ToString())
                {
                    var isVerifySuccess = HttpContext.Session.GetString("IS_VERIFY_SUCCESS");

                    var isValid = isVerifySuccess == true.ToString();

                    if (!isValid)
                    {
                        return new ResponseResult()
                        {
                            ErrorCode = ErrorCode.ParameterError,
                        };
                    }
                }

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

        /// <summary>
        /// 取得驗證文字圖片
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveValidateTextImage()
        {
            var textCaptchaTypeList = new List<TextCaptchaType>() { TextCaptchaType.number };

            (Image? image, string? result) = GetTextCaptchaImage(textCaptchaTypeList);

            if (result is null)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail,
                };
            }

            HttpContext.Session.SetString("TEXT_CAPTCHA_RESULT", result);

            return new ResponseResult<object>()
            {
                ErrorCode = ErrorCode.Success,
                Result = new
                {
                    TextImage = image.ToBase64String(PngFormat.Instance)
                }
            };
        }

        /// <summary>
        /// 檢查驗證文字圖片
        /// </summary>
        [HttpPost]
        public ResponseResult VerifyValidateTextImageResult(VerifyValidateTextImageResult_Dto request)
        {
            if (request.TextResult is null)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail,
                };
            }

            var textCaptchaResult = HttpContext.Session.GetString("TEXT_CAPTCHA_RESULT");
            if (textCaptchaResult is null)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail,
                };
            }

            if (request.TextResult != textCaptchaResult)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail,
                };
            }

            HttpContext.Session.SetString("IS_VERIFY_SUCCESS", true.ToString());

            return new ResponseResult<object>()
            {
                ErrorCode = ErrorCode.Success,
            };
        }
    }
}
