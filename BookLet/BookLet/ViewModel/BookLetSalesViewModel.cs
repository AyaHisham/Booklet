using BookLet.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLet.ViewModel
{
    public class BookLetSalesViewModel
    {
        public int Serial { get; set; }
        [Required(ErrorMessage = "The field is required")]
        [CheckDateRangeAttribute]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Booklet ID")]
        public int BookLetId { get; set; }
        [Required(ErrorMessage = "The field is required")]
        [Display(Name = "Customer ID")]
        [MaxLength(14,ErrorMessage = "Please enter 14 digits"), MinLength(14, ErrorMessage = "Please enter 14 digits")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "The field is required")]
        public string CustomerName { get; set; }

        public string FormattedDate => Date.ToString("dd/MM/yyyy HH:mm");
    }
}
