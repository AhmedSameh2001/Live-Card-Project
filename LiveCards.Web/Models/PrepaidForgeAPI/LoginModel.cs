namespace LiveCards.Models.PrepaidForgeAPI
{
    public class LoginResponseModel
    {
        public string ApiToken { get; set; }
        public Int64 TokenValidUntil { get; set; }
    }

    public class LoginModel
    {
        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
