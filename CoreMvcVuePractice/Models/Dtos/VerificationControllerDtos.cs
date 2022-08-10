namespace CoreMvcVuePractice.Models.Dtos
{
    public class VerificationControllerDtos
    {
        public class VerifyLogin_Dto
        {
            public string Account { get; set; } = string.Empty;
            public string Pw { get; set; } = string.Empty;
        }

        public class VerifySliderCaptcha_Dto
        {
            public List<int>? OperateArray { get; set; }
        }

        public class VerifyValidateTextImageResult_Dto
        {
            public string? TextResult { get; set; }
        }
    }
}
