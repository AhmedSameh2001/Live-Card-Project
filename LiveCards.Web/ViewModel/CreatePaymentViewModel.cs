using System.ComponentModel.DataAnnotations;

namespace LiveCards.Web.ViewModel
{
    public class CreatePaymentViewModel
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Required]
        [Display(Name = "ExhangeRate")]
        public decimal ExhangeRate { get; set; }
        [Display(Name = "Note")]
        public string Note { get; set; }
        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
