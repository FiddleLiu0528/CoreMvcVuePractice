
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
    }
}
