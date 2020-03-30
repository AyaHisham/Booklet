using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLet.Models;
using BookLet.ViewModel;
using BookLet.Services;
using Microsoft.EntityFrameworkCore;

namespace BookLet.Services
{
    public class BookLetServices
    {
        private readonly BookLetContext db;
        public BookLetServices(BookLetContext _db)
        {
            db = _db;
        }
        public List<BookLetViewModel> GetAllBookLet()
        {
            List<BookLetViewModel> bookList = db.BookLet.Select(x => new BookLetViewModel
            {
                Id = x.Id,
                Activity = x.Activity,
                Status = x.Status 
            }).ToList();
            return bookList;
        }
        public void AddBookLet(BookLetViewModel model)
        {
            BookLetTable book = new BookLetTable { Activity = model.Activity,Status = 0};
            db.BookLet.Add(book);
            db.SaveChanges();
        }
        public void UpdateBookLet(BookLetViewModel model)
        {
            BookLetTable book = db.BookLet.Find(model.Id);
            db.Entry(book).State = EntityState.Modified;
            book.Activity = model.Activity;
            db.SaveChanges();
        }
        public void DeleteBookLet(int? id)
        {
            BookLetTable book = db.BookLet.Find(id);
            db.BookLet.Remove(book);
            db.SaveChanges();
        }
        public BookLetViewModel GetBookLetById(int? Id)
        {
            BookLetViewModel book = db.BookLet.Where(x => x.Id == Id.Value).Select(x => new BookLetViewModel
            {
                Id = x.Id,
                Activity = x.Activity,
                Status = x.Status
            }).FirstOrDefault();
            return book;
        }
    }
}
