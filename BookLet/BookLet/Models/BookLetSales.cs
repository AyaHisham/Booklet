using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLet.Models
{
    public class BookLetSales
    {
        [Key]
        public int Serial { get; set; }
        public DateTime Date { get; set; }
        public int BookLetId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual BookLetTable BookLet { get; set; }
    }
}
