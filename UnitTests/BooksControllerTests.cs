using Library.Application;
using LibraryASPNET_Core.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Book
{
    public class BooksControllerTests
    {
        private readonly Mock<IBookService> _mockRepo;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockRepo = new Mock<IBookService>();
            _controller = new BooksController(_mockRepo.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {                  
            var result = _controller.Index();
            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        }

       //arrange

       //act

       //assert

    }
}
