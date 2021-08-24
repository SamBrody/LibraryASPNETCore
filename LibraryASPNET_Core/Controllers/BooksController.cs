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
using Library.Application.ViewModels;

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
            var books = _Ibook.GetAllBooks();

            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var book = _Ibook.GetByID(id.Value);
            if (book == null)
                return NotFound();
            ViewBag.PhotoPath = book.PhotoPath;
            return View(book);
        }

        // GET: Books/AddBook
        public IActionResult AddBook()
        {
                      
            return View();
        }

        // POST: Books/AddBook
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(BookDTO booksDTO)
        {
            if (ModelState.IsValid)
            {
                _Ibook.Create(booksDTO);
                return RedirectToAction("Index");
            }
            return View(booksDTO);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            
            var viewmodel = new BookEditVM();
            viewmodel.book = _Ibook.GetByID(id.Value);
            ViewBag.PhotoPath = viewmodel.book.PhotoPath;

            viewmodel.authors = _Ibook.GetAllAuthors();
            viewmodel.tags = _Ibook.GetAllTags();
            viewmodel.categories = _Ibook.GetAllCategories();
            viewmodel.shelves = _Ibook.GetAllShelves();
            viewmodel.readers = _Ibook.GetAllReaders();

            return View(viewmodel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookEditVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            _Ibook.Update(bookVM);
            return RedirectToAction("Index");
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            _Ibook.Delete(id.Value);
            return RedirectToAction("Index");
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
