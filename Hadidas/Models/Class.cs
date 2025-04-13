//using Hadidas.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace Hadidas.Models
//{
//    // Projektstruktur:
//    // - Controllers
//    //     - MessagesController.cs
//    // - Models
//    //     - Group.cs, Recipient.cs, Message.cs, MessageRecipient.cs
//    // - Views
//    //     - Messages
//    //         - Index.cshtml, Create.cshtml
//    // - Data
//    //     - AppDbContext.cs

//    // --- Models/Group.cs ---
//    public class Group
//    {
//        public int GroupId { get; set; }
//        public string GroupName { get; set; } = string.Empty;
//        public List<Recipient> Recipients { get; set; } = new();
//    }

//    // --- Models/Recipient.cs ---
//    public class Recipient
//    {
//        public int RecipientId { get; set; }
//        public string Name { get; set; } = string.Empty;
//        public string PhoneNumber { get; set; } = string.Empty;

//        public int? GroupId { get; set; }
//        public Group? Group { get; set; }
//    }

//    // --- Models/Message.cs ---
//    public class Message
//    {
//        public int MessageId { get; set; }
//        public string Content { get; set; } = string.Empty;
//        public DateTime SentAt { get; set; } = DateTime.Now;

//        public List<MessageRecipient> MessageRecipients { get; set; } = new();
//    }

//    // --- Models/MessageRecipient.cs ---
//    public class MessageRecipient
//    {
//        public int MessageRecipientId { get; set; }
//        public int MessageId { get; set; }
//        public Message? Message { get; set; }

//        public int RecipientId { get; set; }
//        public Recipient? Recipient { get; set; }
//    }

//    // --- Data/AppDbContext.cs ---
//    public class AppDbContext : DbContext
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        public DbSet<Group> Groups => Set<Group>();
//        public DbSet<Recipient> Recipients => Set<Recipient>();
//        public DbSet<Message> Messages => Set<Message>();
//        public DbSet<MessageRecipient> MessageRecipients => Set<MessageRecipient>();
//    }

//    // --- Controllers/MessagesController.cs ---
//    public class MessagesController : Controller
//    {
//        private readonly AppDbContext _context;
//        public MessagesController(AppDbContext context) => _context = context;

//        public IActionResult Create()
//        {
//            ViewBag.Groups = new SelectList(_context.Groups.Include(g => g.Recipients), "GroupId", "GroupName");
//            ViewBag.Recipients = new SelectList(_context.Recipients, "RecipientId", "Name");
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(string content, int? groupId, int? recipientId)
//        {
//            var message = new Message { Content = content };
//            _context.Messages.Add(message);

//            List<Recipient> recipients = new();

//            if (groupId.HasValue)
//            {
//                recipients = _context.Recipients.Where(r => r.GroupId == groupId).ToList();
//            }
//            else if (recipientId.HasValue)
//            {
//                var recipient = await _context.Recipients.FindAsync(recipientId);
//                if (recipient != null) recipients.Add(recipient);
//            }

//            foreach (var r in recipients)
//            {
//                _context.MessageRecipients.Add(new MessageRecipient
//                {
//                    Message = message,
//                    Recipient = r
//                });

//                // Här skulle SMS-funktionen anropas, ex. Twilio.Send(r.PhoneNumber, content);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Index()
//        {
//            var messages = _context.Messages
//                .Include(m => m.MessageRecipients).ThenInclude(mr => mr.Recipient)
//                .OrderByDescending(m => m.SentAt)
//                .ToList();
//            return View(messages);
//        }
//    }

//// --- Views/Messages/Create.cshtml ---
//@{
//    ViewData["Title"] = "Skicka Meddelande";
//}
//< h2 > Skicka Meddelande </ h2 >
//< form method = "post" >
//    < div >
//        < label > Meddelande:</ label >
//        < textarea name = "content" required ></ textarea >
//    </ div >
//    < div >
//        < label > Skicka till grupp:</ label >
//        < select name = "groupId" >
//            < option value = "" > --Välj grupp-- </ option >
//            @foreach(var g in (SelectList)ViewBag.Groups)
//            {
//                < option value = "@g.Value" > @g.Text </ option >
//            }
//        </ select >
//    </ div >
//    < div >
//        < label > Eller till en person:</ label >
//        < select name = "recipientId" >
//            < option value = "" > --Välj person-- </ option >
//            @foreach(var r in (SelectList)ViewBag.Recipients)
//            {
//                < option value = "@r.Value" > @r.Text </ option >
//            }
//        </ select >
//    </ div >
//    < button type = "submit" > Skicka </ button >
//</ form >

//// --- Views/Messages/Index.cshtml ---
//@model List<Message>
//< h2 > Skickade Meddelanden </ h2 >
//< ul >
//@foreach(var m in Model)
//{
//    < li >
//        < b > @m.SentAt.ToString("g") </ b > -@m.Content < br />
//        Till: @string.Join(", ", m.MessageRecipients.Select(mr => mr.Recipient?.Name))
//    </ li >
//}
//</ ul >

//}
