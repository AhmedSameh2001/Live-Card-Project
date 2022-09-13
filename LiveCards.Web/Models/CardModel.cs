namespace LiveCards.Models
{
    public class CardModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string Image { get; set; }
        public int? BrandId { get; set; }
        public decimal Cost { get; set; }

        public bool Active { get; set; }
        public decimal AgentPercent { get; set; }
        public decimal SellerPercent { get; set; }
        public decimal CustomerPercent { get; set; }


        public decimal Price { get; set; }

    }
}
