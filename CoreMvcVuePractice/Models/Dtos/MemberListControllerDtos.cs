namespace CoreMvcVuePractice.Models.Dtos
{
    public class MemberListControllerDtos
    {
        public class RetrieveMemberModeTypes_ResultDto
        {
            public IEnumerable<MemberMode>? MemberModeList { get; set; }
        }

        public class RetrieveBanReasonTypes_ResultDto
        {
            public IEnumerable<BanReason>? BanReasonList { get; set; }
        }

        public class RetrieveMemberSum_ResultDto
        {
            /// <summary>
            /// 會員總數量
            /// </summary>
            public long MemberAmount { get; set; }

            /// <summary>
            /// 黑名單會員總數量
            /// </summary>
            public long BanAmount { get; set; }
        }

        public class RetrieveMemberList_Dto
        {
            /// <summary>
            /// 查詢開始日期
            /// </summary>
            public DateTime? StartDateTime { get; set; }

            /// <summary>
            /// 查詢結束日期
            /// </summary>
            public DateTime? EndDateTime { get; set; }

            /// <summary>
            /// 會員ID
            /// </summary>
            public string? MemberAccount { get; set; }

            /// <summary>
            /// 禁言原因ID
            /// </summary>
            public int? MuteReasonId { get; set; }

            /// <summary>
            /// 會員等級
            /// </summary>
            public byte? MemberLevel { get; set; }

            /// <summary>
            /// 當前頁面索引
            /// </summary>
            public int NowPageIndex { get; set; }

            /// <summary>
            /// 當前頁面共幾筆
            /// </summary>
            public int PerpageRowAmount { get; set; }
        }

        public class RetrieveMemberList_ResultDto
        {
            /// <summary>
            /// 會員總數量
            /// </summary>
            public long MemberAmount { get; set; }

            /// <summary>
            /// 會員列表
            /// </summary>
            public IEnumerable<Member>? MemberList { get; set; }
        }

        public class RetrieveMemberModifyRecord_Dto
        {
            /// <summary>
            /// 會員流水號
            /// </summary>
            public long SerialNumber { get; set; }
        }

        public class RetrieveMemberModifyRecord_ResultDto
        {

        }

        public class UpdateMemberLevel_Dto
        {
            public int SerialNumber { get; set; }

            public int MemberLevel { get; set; }
        }

        public class MemberMode
        {
            /// <summary>
            /// 會員模式代號
            /// </summary>
            public int SerialNumber { get; set; }
            /// <summary>
            /// 模式名稱
            /// </summary>
            public string? Name { get; set; }
            /// <summary>
            /// 排序
            /// </summary>
            public int Sort { get; set; }
            /// <summary>
            /// 備註
            /// </summary>
            public string? Remark { get; set; }
            /// <summary>
            /// 禮物ID集合
            /// </summary>
            public IEnumerable<int>? GiftSettingIds { get; set; }
            /// <summary>
            /// 建立日期
            /// </summary>
            public DateTime CreateDateTime { get; set; }
            /// <summary>
            /// 是否禁言
            /// </summary>
            public bool IsMute { get; set; }
            /// <summary>
            /// 類型
            /// </summary>
            public byte Type { get; set; }
        }

        public class BanReason
        {
            /// <summary>
            /// 流水號
            /// </summary>
            public int SerialNumber { get; set; }
            /// <summary>
            /// 禁言原因
            /// </summary>
            public string? Reason { get; set; }
            /// <summary>
            /// 天數
            /// </summary>
            public int Day { get; set; }
            /// <summary>
            /// 排序
            /// </summary>
            public int Sort { get; set; }
            /// <summary>
            /// 建立日期
            /// </summary>
            public DateTime CreateDateTime { get; set; }
        }

        public class Member
        {
            /// <summary>
            /// 查詢修改紀錄用
            /// </summary>
            public int SerialNumber { get; set; }

            /// <summary>
            /// 會員帳號
            /// </summary>
            public string? MemberAccount { get; set; }

            /// <summary>
            /// 暱稱
            /// </summary>
            public string? NickName { get; set; }

            /// <summary>
            /// 等級
            /// </summary>
            public int MemberLevel { get; set; }

            /// <summary>
            /// 產生時間
            /// </summary>
            public DateTime CreateDateTime { get; set; }

            /// <summary>
            /// 禁言原因ID
            /// </summary>
            public int? MuteReasonId { get; set; }

            /// <summary>
            /// 其他禁言原因備註
            /// </summary>
            public string? OtherMuteReasonRemark { get; set; }
        }
    }
}
