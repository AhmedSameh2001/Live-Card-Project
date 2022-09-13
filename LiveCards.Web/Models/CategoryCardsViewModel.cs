
namespace LiveCards.Models
{
    public class CategoryCardsViewModel
    {
        public int? CategoryId { get; set; }
        public string Title  { get; set; }
        public string TitleEn  { get; set; }
        public string TitleHe  { get; set; }
 
         public IEnumerable<CardModel> Cards { get; set; }  

    }
}
