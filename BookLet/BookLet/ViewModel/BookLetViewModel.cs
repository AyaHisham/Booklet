using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLet.ViewModel
{
    public class BookLetViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Field is required")]
        public int Activity { get; set; }
        [Required(ErrorMessage = "The Field is required")]
        public int Status { get; set; }
    }
}
