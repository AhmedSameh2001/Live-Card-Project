using RestSharp;
using LiveCards.Models;
using LiveCards.Data;

namespace LiveCards.Web.Models.TalTelecom
{
    public class TalTelecomBot
    {
        private const string BaseUrl = "https://mtopup.taltelecom.com/VpcPrepaidServices/";
        private readonly string PhoneNumber;
        private readonly string Year;
        private readonly ApplicationDbContext _context;

        ICollection<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string> ( "Host","mtopup.taltelecom.com" ) ,
            new KeyValuePair<string, string> ( "Connection","keep-alive"),
            new KeyValuePair<string, string> ( "sec-ch-ua","\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"101\", \"Opera\";v=\"87\""),
            new KeyValuePair<string, string> ( "Accept","application/json, text/plain, */*"),
            new KeyValuePair<string, string> ( "Content-Type","application/json"),
            new KeyValuePair<string, string> ( "sec-ch-ua-mobile","?0"),
            new KeyValuePair<string, string> ( "User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36 OPR/87.0.4390.45"),
            new KeyValuePair<string, string> ( "X-Forwarded-For","371671ac8dc0fe"),
            new KeyValuePair<string, string> ( "sec-ch-ua-platform","\"Windows\""),
            new KeyValuePair<string, string> ( "Sec-Fetch-Site","same-origin"),
            new KeyValuePair<string, string> ( "Sec-Fetch-Mode","cors"),
            new KeyValuePair<string, string> ( "Sec-Fetch-Dest","empty"),
            new KeyValuePair<string, string> ( "Referer","https://mtopup.taltelecom.com/prepaid"),
            new KeyValuePair<string, string> ( "Accept-Encoding","gzip, deflate, br"),
            new KeyValuePair<string, string> ( "Accept-Language","en-US,en;q=0.9"),
        };

        public TalTelecomBot(ApplicationDbContext context)
        {
            _context = context;

            //SettingsManager.GetSetting()
            //PhoneNumber = getSetting(SettingsKeys.TalTelecom_PhoneNumber.ToString());
            //Year = getSetting(SettingsKeys.TalTelecom_Year.ToString()); 
        }

        public async Task<RefreshTokenResponse> RefreshToken()
        {
            //signInWithApi
            try
            {
                var client = new RestClient(BaseUrl + "account/refresh-token");

                var refreshToken = SettingsManager.GetSetting(_context, SettingsKeys.TalTelecom_RefreshToken);

                //LoginModel data = new LoginModel(Email, Password);

                var request = new RestRequest()
                    .AddHeaders(headers)
                    .AddHeader("Cookie", "refreshToken=" + refreshToken)
                    .AddHeader("Origin", "https://mtopup.taltelecom.com");


                var response = await client.PostAsync<RefreshTokenResponse>(request);

                SettingsManager.SetSetting(_context, SettingsKeys.TalTelecom_RefreshToken,
                    response?.RefreshToken);

                SettingsManager.SetSetting(_context, SettingsKeys.TalTelecom_Jwt,
                    response?.JwtToken);

                return response;
            }
            catch (Exception ex)
            {
                return new RefreshTokenResponse();
            }
        }


        public async Task<List<GetProductsResponse>> GetProducts(int id)
        {
            try
            {
                var client = new RestClient(BaseUrl + "Site/GetProducts/" + id);

                var refreshToken = SettingsManager.GetSetting(_context, SettingsKeys.TalTelecom_RefreshToken);
                var JwtToken = SettingsManager.GetSetting(_context, SettingsKeys.TalTelecom_Jwt);

                //LoginModel data = new LoginModel(Email, Password);

                var request = new RestRequest()
                    .AddHeaders(headers)
                    .AddHeader("Cookie", "refreshToken=" + refreshToken)
                    .AddHeader("Authorization", "Bearer " + JwtToken);

                var response = await client.GetAsync<List<GetProductsResponse>>(request);

                return response;
            }
            catch (Exception ex)
            {
                return new List<GetProductsResponse>();
            }
        }
    }
}
