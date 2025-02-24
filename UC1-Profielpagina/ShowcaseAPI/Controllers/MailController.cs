using Microsoft.AspNetCore.Mvc;
using ShowcaseAPI.Models;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        // POST api/<MailController>
        [HttpPost]
        public ActionResult Post([Bind("FirstName, LastName, Email, Phone, Subject, Message")] Contactform form)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("81ea129c34384a", "273021a495869a"),
                EnableSsl = true
            };

            var toAddress = new MailAddress("s1204257@student.windesheim.nl", "Roey Langbroek");
            var fromAddress = new MailAddress(form.Email, $"{form.FirstName} {form.LastName}");
            var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = form.Subject,
                Body = $"{form.Message} \nTelefoonnummer: {form.Phone}",
                IsBodyHtml = false
            };

            client.Send(mailMessage);
            System.Console.WriteLine("Sent");

            return Ok();
        }
    }
}
