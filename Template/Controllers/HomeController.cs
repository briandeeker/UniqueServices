using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Template.Models;
using Template.Services.Interfaces;
using Template.Services.Types;

namespace Template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        // return the views
        public IActionResult Index()
        {
            EmailMessageViewModel vm = new EmailMessageViewModel() { RedirectUrl = "Index" };

            return View(vm);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Blog()
        {
            EmailMessageViewModel vm = new EmailMessageViewModel() { RedirectUrl = "Blog" };

            return View(vm);
        }

        public IActionResult Contact()
        {
            EmailMessageViewModel vm = new EmailMessageViewModel() { RedirectUrl = "Contact" };

            return View(vm);
        }

        public IActionResult EmailSent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailMessageViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm.RedirectUrl, vm);
            }

            var messageToSend = new EmailMessage()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                EmailAddress = vm.EmailAddress,
                Phone = vm.Phone,
                Message = vm.Message
            };

            try
            {
                await _emailService.SendEmailAsync(messageToSend);

                return RedirectToAction("EmailSent");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}