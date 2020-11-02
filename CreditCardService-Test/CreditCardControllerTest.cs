using CreditCardService.Controllers;
using CreditCardService.IRepository;
using CreditCardService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace CreditCardService_Test
{
    public class CreditCardControllerTest
    {
        CreditCardController _controller;
        ICreditCardRepository _service;
        public CreditCardControllerTest()
        {
            _service = new CreditCardControllerFake();
            _controller = new CreditCardController(_service);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CreditCard>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        [Fact]
        public void GetById_UnknownCardIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get("333");
            // Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get("101");
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void GetById_ExistingCardIdPassed_ReturnsRightItem()
        {

            // Act
            var okResult = _controller.Get("101").Result as OkObjectResult;
            // Assert
            Assert.IsType<CreditCard>(okResult.Value);
            Assert.Equal("101", (okResult.Value as CreditCard).CardId);
        }
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var invalidCardNumber = new CreditCard()
            {
                CardId = "132",
                CardNumber = "666666666666",
                AccountNumber = "1234567890"
            };
            _controller.ModelState.AddModelError("CardNumber", "Please Enter 16 digit card number");
            // Act
            var badResponse = _controller.Post(invalidCardNumber);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            CreditCard testItem = new CreditCard()
            {
                CardId = "101",
                CardNumber = "1234567890123456",
                InitialBalance = 1234,
                AccountNumber = "1234567890"
            };
            // Act
            var createdResponse = _controller.Post(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse.Result);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new CreditCard()
            {
                CardId = "101",
                CardNumber = "1234567890123456",
                InitialBalance = 1234,
                AccountNumber = "1234567890"
            };
            // Act
            var createdResponse = _controller.Post(testItem) as Task<ActionResult>;
            var item = createdResponse.Result;
            //// Assert
            Assert.IsType<OkObjectResult>(item);

        }
    }
}