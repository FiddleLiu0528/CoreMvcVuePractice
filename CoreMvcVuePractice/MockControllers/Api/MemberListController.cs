
using CoreMvcVuePractice.Models;
using Microsoft.AspNetCore.Mvc;
using static CoreMvcVuePractice.Models.Dtos.MemberListControllerDtos;

namespace CoreMvcVuePractice.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemberListController : ControllerBase
    {
        /// <summary>
        /// 取得 等級權限設定列表
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveMemberModeTypes()
        {
            try
            {
                return new ResponseResult<RetrieveMemberModeTypes_ResultDto>()
                {
                    ErrorCode = ErrorCode.Success,
                    Result = new RetrieveMemberModeTypes_ResultDto()
                    {
                        MemberModeList = new List<MemberMode>() {
                             new MemberMode()
                            {
                                 SerialNumber = 1,
                                 Sort = 1,
                                 Type = 0,
                                 CreateDateTime = DateTime.Now,
                                 GiftSettingIds = null,
                                 IsMute = false,
                                 Name = "name",
                                 Remark = null
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {

                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }

        /// <summary>
        /// 取得 禁言原因列表
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveBanReasonTypes()
        {
            try
            {
                return new ResponseResult<RetrieveBanReasonTypes_ResultDto>()
                {
                    ErrorCode = ErrorCode.Success,
                    Result = new RetrieveBanReasonTypes_ResultDto()
                    {
                        BanReasonList = new List<BanReason>() {
                             new BanReason()
                             {
                                CreateDateTime = DateTime.Now,
                                Day = 1,
                                Reason = "",
                                SerialNumber = 1,
                                Sort = 1,
                             }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                //this.serverSideLogger.Error(ex, $"{this.GetType().Name} {MethodBase.GetCurrentMethod().Name} Exception");

                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }

        /// <summary>
        /// 取得 所有會員及禁言 的數量
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveMemberSum()
        {
            try
            {
                return new ResponseResult<RetrieveMemberSum_ResultDto>()
                {
                    ErrorCode = ErrorCode.Success,
                    Result = new RetrieveMemberSum_ResultDto
                    {
                        MemberAmount = 10,
                        BanAmount = 10,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }

        /// <summary>
        /// 取得 查詢條件的會員列表
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveMemberList(RetrieveMemberList_Dto request)
        {
            try
            {
                return new ResponseResult<RetrieveMemberList_ResultDto>()
                {
                    ErrorCode = ErrorCode.Success,
                    Result = new RetrieveMemberList_ResultDto
                    {
                        MemberAmount = 1000,
                        MemberList = new List<Member>()
                        {
                            new Member(){
                                SerialNumber =1,
                                CreateDateTime = DateTime.Now,
                                MemberAccount = "account",
                                MemberLevel =1,
                                MuteReasonId = 0,
                                NickName = "",
                                OtherMuteReasonRemark = "",
                            }
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }

        /// <summary>
        /// 取得 特定會員的修改紀錄
        /// </summary>
        [HttpPost]
        public ResponseResult RetrieveMemberModifyRecord(RetrieveMemberModifyRecord_Dto request)
        {
            try
            {
                return new ResponseResult<RetrieveMemberModifyRecord_ResultDto>
                {
                    ErrorCode = ErrorCode.Success,
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }

        /// <summary>
        /// 修改會員等級
        /// </summary>
        [HttpPost]
        public ResponseResult UpdateMemberLevel(UpdateMemberLevel_Dto request)
        {
            try
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Success
                };
            }
            catch (Exception ex)
            {
                return new ResponseResult()
                {
                    ErrorCode = ErrorCode.Fail
                };
            }
        }
    }
}
