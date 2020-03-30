using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLet.Models
{
    public class BookLetTable
    {
        [Key]
        public int Id { get; set; }
        public int Activity { get; set; }
        public int Status { get; set; }
    }
}
