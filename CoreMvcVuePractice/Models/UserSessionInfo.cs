namespace CoreMvcVuePractice.Models
{
    [Serializable]
    public class UserSessionInfo
    {
        /// <summary>
        /// SessionID
        /// </summary>
        public string? SessionId { get; set; }
        /// <summary>
        /// IP
        /// </summary>
        public string? Ip { get; set; }
        /// <summary>
        /// 流水號
        /// </summary>
        public int SerialNumber { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string? Account { get; set; }
        /// <summary>
        /// 暱稱
        /// </summary>
        public string? Nickname { get; set; }

    }
}
