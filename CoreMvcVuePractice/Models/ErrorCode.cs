namespace CoreMvcVuePractice.Models
{
    public enum ErrorCode
    {
        Unknown = -1,
        Success = 0,
        Fail = 1,
        AccountError = 2,
        PwError = 3,
        ParameterError = 3,
        TimeoutError = 4,
        OtherError = 5,
    }
}
