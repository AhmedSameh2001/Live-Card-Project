namespace LiveCards.Web.Models.TalTelecom
{
 
    public class GetProductsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public string NameHe { get; set; }
        public string NameAr { get; set; }
        public string DescHe1 { get; set; }
        public string DescHe2 { get; set; }
        public string DescHe3 { get; set; }
        public string DescAr1 { get; set; }
        public string DescAr2 { get; set; }
        public string DescAr3 { get; set; }
        public string Picture { get; set; }
        public int PictureWidth { get; set; }
        public int PictureHeight { get; set; }
        public string LineText1 { get; set; }
        public string LineText2 { get; set; }
        public int Sort { get; set; }
        public bool IsAmountFree { get; set; }
        public bool IsDefineToSpecificResellers { get; set; }
        public object DefinedResellers { get; set; }
    }

}
