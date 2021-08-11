using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Infrasturcture.Context;
using Library.Domain.Models;
using Library.Application;
using Library.Application.Dto;

namespace LibraryASPNET_Core.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _Ibook;

        public BooksController(IBookService Ibook)
        {
            _Ibook = Ibook;
        }

        // GET: Books
        public IActionResult Index()
        {
            var books = _Ibook.GetAll();

            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            var book =_Ibook.GetByID(id);
            ViewBag.PhotoPath = book.PhotoPath;
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
                      
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookDTO booksDTO)
        {
            _Ibook.Create(booksDTO);
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            var book = _Ibook.GetByID(id);
            ViewBag.PhotoPath = book.PhotoPath;
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookDTO booksDTO)
        {
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int id)
        {
            _Ibook.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Books/Delete/5
        /*[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var books =  _context.Books_.FindAsync(id);
            _context.Books_.Remove(books);
             _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return _context.Books_.Any(e => e.Id == id);
        }*/
    }
}
