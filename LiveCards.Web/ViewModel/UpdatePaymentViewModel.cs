namespace LiveCards.Web.ViewModel
{
    public class UpdatePaymentViewModel
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal ExhangeRate { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
    }
}
