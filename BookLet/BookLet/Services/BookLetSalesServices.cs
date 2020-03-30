using BookLet.Models;
using BookLet.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookLet.Services
{
    public class BookLetSalesServices
    {
        private readonly BookLetContext db;
        public BookLetSalesServices(BookLetContext _db)
        {
            db = _db;
        }
        public List<BookLetSalesViewModel> GetAllBookLetSales()
        {
            List<BookLetSalesViewModel> bookList = db.BookLetSales.Select(x => new BookLetSalesViewModel
            {
                Serial = x.Serial,
                Date = x.Date,
                BookLetId = x.BookLetId,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName
            }).ToList();
            return bookList;
        }
        public void SaleBook(BookLetSalesViewModel model)
        {
            BookLetSales book = new BookLetSales { Date = model.Date, BookLetId =model.BookLetId, CustomerId = model.CustomerId,CustomerName = model.CustomerName };
            db.BookLetSales.Add(book);
            db.SaveChanges();
            BookLetTable oldBook = db.BookLet.Find(model.BookLetId);
            db.Entry(oldBook).State = EntityState.Modified;
            oldBook.Status = 1;
            db.SaveChanges();

        }
        public List<BookLetViewModel> GetAllBookLetAvaliable()
        {
            List<BookLetViewModel> bookList = db.BookLet.Where(x=>x.Status == 0).Select(x => new BookLetViewModel
            {
                Id = x.Id,
                Activity = x.Activity,
            }).ToList();
            return bookList;
        }
        public void DeleteBookLetSales(int? id)
        {
            //make book avaliable then delete sale
            BookLetSales bookSale = db.BookLetSales.Find(id);
            BookLetTable book = db.BookLet.Find(bookSale.BookLetId);
            db.Entry(book).State = EntityState.Modified;
            book.Status = 0;
           
            db.BookLetSales.Remove(bookSale);
            db.SaveChanges();   
        }
        public void UpdateBookLetSale(BookLetSalesViewModel model)
        {
            BookLetSales bookSale = db.BookLetSales.Find(model.Serial);
            BookLetTable oldbook = db.BookLet.Find(bookSale.BookLetId);
            db.Entry(oldbook).State = EntityState.Modified;
            oldbook.Status = 0;
          
            db.Entry(bookSale).State = EntityState.Modified;
            bookSale.Date = model.Date;
            bookSale.BookLetId = model.BookLetId;
            bookSale.CustomerId = model.CustomerId;
            bookSale.CustomerName = model.CustomerName;
           
            BookLetTable newbook = db.BookLet.Find(model.BookLetId);
            db.Entry(newbook).State = EntityState.Modified;
            newbook.Status = 1;

            db.SaveChanges();

        }
        public BookLetSalesViewModel GetBookLetSaleById(int? Id)
        {
            BookLetSalesViewModel book = db.BookLetSales.Where(x => x.Serial == Id.Value).Select(x => new BookLetSalesViewModel
            {
                Serial = x.Serial,
                Date = x.Date,
                BookLetId = x.BookLetId,
                CustomerId  = x.CustomerId,
                CustomerName = x.CustomerName
            }).FirstOrDefault();
            return book;
        }

    }
}
