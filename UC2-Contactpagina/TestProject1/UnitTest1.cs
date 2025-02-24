using Microsoft.AspNetCore.Mvc;
using ShowcaseAPI.Controllers;
using ShowcaseAPI.Models;
using System.Net;
using System.Net.Mail;
using Xunit;

namespace ShowcaseAPI.Tests
{
    public class MailControllerTest
    {
        [Fact]
        public void Post_ValidForm_ReturnsOk()
        {
            // Arrange
            var controller = new MailController();
            var form = new Contactform
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Subject = "Hallo",
                Message = "Dit is een testbericht"
            };

            // Act
            var result = controller.Post(form);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}