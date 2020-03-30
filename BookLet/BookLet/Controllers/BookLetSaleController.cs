using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLet.Services;
using BookLet.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rotativa.AspNetCore;

namespace BookLet.Controllers
{
    public class BookLetSaleController : Controller
    {
        private readonly BookLetSalesServices bookLetSaleServices;
        private readonly BookLetServices bookLetServices;

        public BookLetSaleController(BookLetSalesServices _bookLetSaleServices, BookLetServices _bookLetServices)
        {
            bookLetSaleServices = _bookLetSaleServices;
            bookLetServices = _bookLetServices;
        }

        public ActionResult Index()
        {
            List<BookLetSalesViewModel> bookList = new List<BookLetSalesViewModel>();
            bookList = bookLetSaleServices.GetAllBookLetSales().OrderByDescending(x => x.Date).ToList();
            return View(bookList);
        }

        public ActionResult Report()
        {
            List<BookLetSalesViewModel> bookList = new List<BookLetSalesViewModel>();
            bookList = bookLetSaleServices.GetAllBookLetSales().OrderByDescending(x=>x.Date).ToList();
            return new ViewAsPdf(bookList);
        }
        public ActionResult Create()
        {
            List<BookLetViewModel> bookList = bookLetSaleServices.GetAllBookLetAvaliable();
            var fullbookList = new SelectList(bookList, "Id", "Id");
            ViewBag.bookList = fullbookList;
            if (bookList.Count() == 0)
            {
                List<SelectListItem> emptyList = new List<SelectListItem>();
                emptyList.Add(new SelectListItem { Text = "-- No Book Is Avaliable --", Value = "" });
                ViewBag.bookList = emptyList;
            }     
            BookLetSalesViewModel book = new BookLetSalesViewModel();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookLetSalesViewModel model)
        {
            List<BookLetViewModel> bookList = bookLetSaleServices.GetAllBookLetAvaliable();
            var fullbookList = new SelectList(bookList, "Id", "Id");
            ViewBag.bookList = fullbookList;
            if (bookList.Count() == 0)
            {
                List<SelectListItem> emptyList = new List<SelectListItem>();
                emptyList.Add(new SelectListItem { Text = "-- No Book Is Avaliable --", Value = "" });
                ViewBag.bookList = emptyList;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    bookLetSaleServices.SaleBook(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BookLetSalesViewModel bookLetSale = new BookLetSalesViewModel();
            bookLetSale = bookLetSaleServices.GetBookLetSaleById(id);
            if (bookLetSale == null)
            {
                return NotFound();
            }
            List<BookLetViewModel> allBookAvailableIncludeCurrent = bookLetSaleServices.GetAllBookLetAvaliable();
            BookLetViewModel book = bookLetServices.GetBookLetById(bookLetSale.BookLetId);
            allBookAvailableIncludeCurrent.Add(book);
            ViewBag.bookList = new SelectList(allBookAvailableIncludeCurrent.OrderBy(x=>x.Id), "Id", "Id",book);
            return View(bookLetSale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookLetSalesViewModel model)
        {
            try
            {
                bookLetSaleServices.UpdateBookLetSale(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            if (id != null)
            {
                bookLetSaleServices.DeleteBookLetSales(id.Value);
            }
            return Json(new { success = true, responseText = "Deleted Scussefully" });
        }

    }
}