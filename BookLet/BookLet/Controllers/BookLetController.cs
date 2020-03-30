using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookLet.Services;
using BookLet.ViewModel;

namespace Task.Controllers
{
    public class BookLetController : Controller
    {
        private readonly BookLetServices bookLetServices;
        public BookLetController(BookLetServices _bookLetServices)
        {
            bookLetServices = _bookLetServices;
        }
  
        public ActionResult Index()
        {
            List<BookLetViewModel> bookList = new List<BookLetViewModel>();
            bookList = bookLetServices.GetAllBookLet();
            return View(bookList);
        }

        public ActionResult Create()
        {
            List<SelectListItem> activity = new List<SelectListItem>();
            activity.Add(new SelectListItem { Text = "Commerical", Value = "0" });
            activity.Add(new SelectListItem { Text = "Agriculture", Value = "1" });
            activity.Add(new SelectListItem { Text = "Other", Value = "2" });
            ViewBag.activity = activity;
            BookLetViewModel book = new BookLetViewModel();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookLetViewModel model)
        {
            try
            {
                bookLetServices.AddBookLet(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BookLetViewModel book = new BookLetViewModel();
            book = bookLetServices.GetBookLetById(id);
            if (book == null)
            {
                return NotFound();
            }
            List<SelectListItem> activity = new List<SelectListItem>();
            activity.Add(new SelectListItem { Text = "Commerical", Value = "0" });
            activity.Add(new SelectListItem { Text = "Agriculture", Value = "1" });
            activity.Add(new SelectListItem { Text = "Other", Value = "2" });
            ViewBag.activity = new SelectList(activity, "Value", "Text", book.Activity);
           
            return View(book);
        }      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookLetViewModel model)
        {
            try
            {
                bookLetServices.UpdateBookLet(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            if (id != null)
            {
                bookLetServices.DeleteBookLet(id.Value);
            }
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }
    }
}