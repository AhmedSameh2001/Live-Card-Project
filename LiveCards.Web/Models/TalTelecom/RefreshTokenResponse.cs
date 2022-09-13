namespace LiveCards.Web.Models.TalTelecom
{
    public class RefreshTokenResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Cellular { get; set; }
        public string Email { get; set; }
        public int TemplateId { get; set; }
        public int UserTypeId { get; set; }
        public int LangId { get; set; }
        public int ResellerId { get; set; }
        public int DealerId { get; set; }
        public string ClientName { get; set; }
        public int AccessFailedCount { get; set; }
        public object Otp { get; set; }
        public object OtpDate { get; set; }
        public bool IsActive { get; set; }
        public object RefreshTokens { get; set; }
        public string JwtToken { get; set; }
        public int ValidateOtp { get; set; }
        public int OtpValidPeriod { get; set; }
        public string RefreshToken { get; set; }
    }

     
}
