using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BookLet.Models
{
    public class BookLetContext : DbContext
    {
        public BookLetContext(DbContextOptions<BookLetContext> options): base(options) { }
        public DbSet<BookLetTable> BookLet { get; set; }
        public DbSet<BookLetSales> BookLetSales { get; set; }
    }
}
