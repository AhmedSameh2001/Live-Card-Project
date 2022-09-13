namespace LiveCards.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Brand
    {
        public Brand()
        {
            this.Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameHe { get; set; }
        public bool ShowInMenu { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public  bool  IsActive { get; set; }
        public int Order { get; set; }
        public bool IsPopular { get; set; }

        public string? ApiId { get; set; }
        public string? ApiName { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Brands")]
        public virtual  Category? Category { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
