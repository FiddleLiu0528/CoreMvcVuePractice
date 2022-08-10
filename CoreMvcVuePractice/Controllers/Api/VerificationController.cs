
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

                // 設定驗證為拼圖
                if (VersionHelper.LoginValidateType == LoginValidateType.Captcha)
                {
                    object value = HttpContext.Current.Session["Session_CaptchaCode"];
                    var isValid = value != null ? (bool)value : false;

                    if (!isValid)
                    {
                        LogTool.Logger(loggerName: loggerName,
                            logLevel: LogLevel.Warn,
                            device: device,
                            ip: ip,
                            requestSid: requestSid,
                            accessControllerPath: accessControllerPath,
                            detail: $"圖形驗證失敗 (請求帳號[{request.Account}])");

                        return new ResultResponse()
                        {
                            ErrorCode = ErrorCode.EmptyError
                        };
                    }
                }
                // 設定驗證為字串驗證
                else if (VersionHelper.LoginValidateType == LoginValidateType.TextImg)
                {
                    var parsedToken = MD5Helper.ComposeToMD5(string.Format($"{request.ValidateText}{ConfigHelper.LoginValidateTextKey}"));
                    if (parsedToken != request.ValidateTextToken)
                    {
                        LogTool.Logger(loggerName: loggerName,
                            logLevel: LogLevel.Warn,
                            device: device,
                            ip: ip,
                            requestSid: requestSid,
                            accessControllerPath: accessControllerPath,
                            detail: $"圖形驗證失敗 (請求帳號[{request.Account}])");

                        return new ResultResponse()
                        {
                            ErrorCode = ErrorCode.EmptyError,
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


    }
}
