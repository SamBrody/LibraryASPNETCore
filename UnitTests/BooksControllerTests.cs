using Library.Application;
using Library.Application.Dto;
using Library.Domain.Models;
using LibraryASPNET_Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Xunit;
using System.Linq;

namespace UnitTests
{
    public class BooksControllerTests
    {
        #region IndexTest
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //arrange
            var mock = new Mock<IBookService>();
            mock.Setup(repo => repo.GetAllBooks()).Returns(GetTestBooks());
            var controller = new BooksController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookDTO>>(viewResult.Model);
            Assert.Equal(GetTestBooks().Count, model.Count());
        }

        #endregion

        #region AddTests
        [Fact]
        public void AddBookReturnsViewResultWithBookModel()
        {
            //arrange
            var mock = new Mock<IBookService>();
            var controller = new BooksController(mock.Object);
            controller.ModelState.AddModelError("Title", "Required");
            BookDTO newBook = new BookDTO();
            int[] authors = { 1 };
            int[] categories = { 1, 3 };
            int[] tags = { 2, 3 };
            int shelf = 2;
            int reader = 1;

            //act
            var result = controller.AddBook(newBook, authors, categories, tags, shelf, reader);

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(newBook, viewResult?.Model);
        }

        [Fact]
        public void AddBookReturnsARedirectAndAddBook()
        {
            //arrange
            var mock = new Mock<IBookService>();
            var controller = new BooksController(mock.Object);
            var newBook = new BookDTO()
            {
                Title = "Тест"
            };
            int[] authors = { 1 };
            int[] categories = { 1, 3 };
            int[] tags = { 2, 3 };
            int shelf = 2;
            int reader = 1;

            //act
            var result = controller.AddBook(newBook, authors, categories, tags, shelf, reader);

            //assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.AddBook(newBook, authors, categories, tags, shelf, reader));
        }

        #endregion

        #region GetTests
        [Fact]
        public void GetBookReturnsBadRequestResultWhenIdIsNull()
        {
            //arange
            var mock = new Mock<IBookService>();
            var controller = new BooksController(mock.Object);

            //act
            var result = controller.Details(null);

            //assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GetBookReturnsNotFoundResultWhenBookNotFound()
        {
            //arange
            int testBookId = 1;
            var mock = new Mock<IBookService>();
            mock.Setup(repo => repo.GetByID(testBookId)).Returns(null as BookDTO);
            var controller = new BooksController(mock.Object);

            //act
            var result = controller.Details(testBookId);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetBookReturnsViewResultWithBook()
        {
            //arange
            int testBookId = 1;
            var mock = new Mock<IBookService>();
            mock.Setup(repo => repo.GetByID(testBookId)).Returns(GetTestBooks().FirstOrDefault(p => p.Id==testBookId));
            var controller = new BooksController(mock.Object);

            //act
            var result = controller.Details(testBookId);

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<BookDTO>(viewResult.ViewData.Model);
            Assert.Equal("Бесконечная шутка", model.Title);
            Assert.Equal(1, model.ShelfId);
            Assert.Equal(1, model.ReaderId);
            Assert.Equal(new DateTime(2021, 7, 17), model.TakeDate);
            Assert.Equal("infjoke.jpg", model.PhotoPath);
        }
        #endregion

        #region EditTests
        //public void EditBookReturnsViewResultWithBookModel()
        //{

        //}
        #endregion

        private List<BookDTO> GetTestBooks()
        {
            var books = new List<BookDTO>
            {
                  new BookDTO {Id=1, Title="Бесконечная шутка", ShelfId=1, ReaderId=1, TakeDate=new DateTime(2021,7,17), PhotoPath="infjoke.jpg" },
                  new BookDTO {Id=2, Title="Муму", ShelfId=1, ReaderId=2, TakeDate=new DateTime(2021,7,29), PhotoPath="mymy.jpg" }
            };
            return (books);
        }
    }
}
