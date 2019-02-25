using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);

            return View(book);
        }
        public ActionResult Create()
        {
           // Book book = new Book();
           //// book.BookId = repository.Books.Count() + 1;
           //repository.SaveBook(book);
            return View();
        }
       
        public ViewResult Delete(int? bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            // Book book = new Book();
            //// book.BookId = repository.Books.Count() + 1;
            //repository.SaveBook(book);
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int bookId)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            //Book book = repository.Books.FirstOrDefault(b => b.BookId == bookId);
            // Book book = new Book();
            //// book.BookId = repository.Books.Count() + 1;
            repository.Del(book);
            
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены", book.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                //book.BookId = 66;
                repository.SaveBook(book);
            //    repository.SaveBook(book);
                //TempData["message"] = string.Format("Изменение информации о книге \"{0}\" сохранены");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            //repository.Add(book);            
            //     repository.SaveBook(book);
            return View("Index");
        }
    }
}