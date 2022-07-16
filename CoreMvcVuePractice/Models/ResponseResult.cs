namespace CoreMvcVuePractice.Models
{
    public class ResponseResult
    {
        public ErrorCode ErrorCode { get; set; }
    }

    public class ResponseResult<T> : ResponseResult
    {
        public T? Result { get; set; }
    }
}
