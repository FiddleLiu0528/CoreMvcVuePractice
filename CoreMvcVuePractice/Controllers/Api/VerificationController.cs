
using Microsoft.AspNetCore.Mvc;
using static CoreMvcVuePractice.Models.Dtos.VerificationControllerDtos;

namespace CoreMvcVuePractice.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VerificationController : ControllerBase
    {

        /// <summary>
        /// 使用者登入驗證
        /// </summary>
        [HttpPost]
        public bool VerifyLogin(VerifyLogin_Dto request)
        {
            try
            {
                return request.Name is not null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
