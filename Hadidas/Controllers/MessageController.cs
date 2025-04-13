using Hadidas.Data;
using Hadidas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;

namespace Hadidas.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        private static readonly HttpClient client = new HttpClient();
        public MessageController(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }


        public IActionResult Create()
        {
            ViewBag.Groups = new SelectList(_context.Groups, "GroupId", "GroupName");
            ViewBag.MessageUsers = new SelectList(_context.MessageUsers, "MessageUserId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string content, int? groupId, int? messageUserId)
        {
            var message = new Message { Content = content, GroupId = groupId, MessageUserId = messageUserId };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Hämta telefonnummer från användare
            var user = await _context.MessageUsers.FirstOrDefaultAsync(u => u.MessageUserId == messageUserId);
            if (user != null && !string.IsNullOrEmpty(user.PhoneNumber))
            {
                await SendSmsAsync(user.PhoneNumber, content);
            }

            return RedirectToAction("Index");
        }

        public async Task SendSmsAsync(string toPhoneNumber, string messageText)
        {
            var username = _config["Elks:Username"];
            var password = _config["Elks:Password"];


            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var form = $"from=Hadi&to={toPhoneNumber}&message={Uri.EscapeDataString(messageText)}";
            var content = new StringContent(form, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await client.PostAsync("https://api.46elks.com/a1/SMS", content);
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString); // Du kan logga detta eller spara till databas
        }


        public IActionResult Index()
        {
            var messages = _context.Messages
                .Include(m => m.MessageUser)
                .Include(m => m.Group)
                .OrderByDescending(m => m.SentAt)
                .ToList();
            return View(messages);
        }
    }

}
