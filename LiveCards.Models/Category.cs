namespace LiveCards.Models
{ 
    using System.Collections.Generic;
    
    public partial class Category
    {

    public Category()
        {
            this.Brands = new HashSet<Brand>();
        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameHe { get; set; }
        public int Order { get; set; }
        public bool ShowInMenu { get; set; }
        public  bool  IsActive { get; set; }


    

        public virtual ICollection<Brand>? Brands { get; set; }
    }
}
