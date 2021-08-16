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
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            //arrange
            var mock = new Mock<IBookService>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestBooks());
            var controller = new BooksController(mock.Object);

            //act
            var result = controller.Index();

            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<BookDTO>>(viewResult.Model);
            Assert.Equal(GetTestBooks().Count, model.Count());
        }

        private List<BookDTO> GetTestBooks()
        {
            var books = new List<BookDTO>
            {
                  new BookDTO {Id=1, Title="Бесконечная шутка", ShelfId=1, ReaderId=1, TakeDate=new DateTime(2021,7,17), PhotoPath="infjoke.jpg" },
                  new BookDTO {Id=2, Title="Муму", ShelfId=1, ReaderId=2, TakeDate=new DateTime(2021,7,29), PhotoPath="mymy.jpg" }
            };
            return (books);
        }

        [Fact]
        public void AddBookReturnsViewResultWithBookModel()
        {
            //arrange
            var mock = new Mock<IBookService>();
            var controller = new BooksController(mock.Object);
            controller.ModelState.AddModelError("Title", "Required");
            BookDTO newBook = new BookDTO();

            //act
            var result = controller.AddBook(newBook);

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

            //act
            var result = controller.AddBook(newBook);

            //assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mock.Verify(r => r.Create(newBook));
        }

        [Fact]
        public void GetBookReturnsBadRequestResultWhenIdIsNull()
        {

        }
    }
}
