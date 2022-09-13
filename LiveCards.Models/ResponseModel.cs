
namespace LiveCards.Models
{
    public class ResponseModel
    {
        public int Status { get; set; }
        public int SubscriptionId { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}