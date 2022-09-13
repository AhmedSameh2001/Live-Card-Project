using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LiveCards.Models
{
    public class SMSSender
    {
        private readonly string username;
        private readonly string pass;
        public string Username { get { return username; } }
        public string Pass { get { return pass; } }
        public SMSSender()
        {
            username = "davidi";
            pass = "Ddai2100";
        }

        public async Task<string> SendAsync(string mobile, string text,string sender)
        {
            string url = "https://019sms.co.il/api";
            string xml = $"<?xml version='1.0' encoding='UTF-8'?>" +
                $"<sms>" +
                $"<user>" +
                $"<username>{username}</username>" +
                $"<password>{pass}</password>" +
                $"</user>" +
                $"<source>{sender}</source>" +
                $"<destinations>{GenerateNumbersToXML(mobile)}</destinations>" +
                $"<message>{text}</message>" +
                $"</sms>";
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(xml);
            webRequest.ContentType = "application/xml";
            webRequest.ContentLength = (long)bytes.Length;
            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            WebResponse response = await webRequest.GetResponseAsync();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            response.Close();
            return result;
        }
        string GenerateNumbersToXML(params string[] nums)
        {
            StringBuilder st = new StringBuilder("");
            foreach (var item in nums)
            {
                st.Append($"<phone>{item}</phone>");
            }
            return st.ToString();
        }

        private String Result(string message)
        {
            string returnMessage = "";
            switch (message)
            {
                case "-1":
                    returnMessage = "נשלח-ללא אישור מסירה";
                    break;
                case "0":
                    returnMessage = "done";
                    break;
                case "1":
                    returnMessage = "נכשל";
                    break;
                case "2":
                    returnMessage = "Timeout";
                    break;
                case "3":
                    returnMessage = "נכשל";
                    break;
                case "4":
                    returnMessage = "נכשל סלולר";
                    break;
                case "5":
                    returnMessage = "נכשל";
                    break;
                case "6":
                    returnMessage = "נכשל";
                    break;
                case "7":
                    returnMessage = "אין יתרה";
                    break;
                case "14":
                    returnMessage = "נכשל סלולר -עבר תהליך שלstore & forward";
                    break;
                case "15":
                    returnMessage = "מספר כשר";
                    break;
                case "16":
                    returnMessage = "אין הרשאת שעת שליחה";
                    break;
                case "17":
                    returnMessage = "חסום להודעות פירסומיות";
                    break;
                case "101":
                    returnMessage = "לא הגיע ליעד";
                    break;
                case "102":
                    returnMessage = "הגיע ליעד";
                    break;
                case "103":
                    returnMessage = "פג תוקף";
                    break;
                case "104":
                    returnMessage = "נמחק";
                    break;
                case "105":
                    returnMessage = "לא הגיע ליעד";
                    break;
                case "106":
                    returnMessage = "לא הגיע ליעד";
                    break;
                case "107":
                    returnMessage = "לא הגיע ליעד";
                    break;

                default:
                    returnMessage = "اسl هرسل غير هقبول";
                    break;
            }

            return returnMessage;
        }

        public async Task<string> SendSMSAsync(string mobile, string text,string sender)
        {
            var a = await SendAsync(mobile, text,sender);
            a = a.Split('>')[3];
            a = a.Split('<')[0];


            return Result(a);
        }

    }
}
