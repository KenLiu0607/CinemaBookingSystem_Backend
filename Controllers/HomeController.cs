//using Backend.Attributes;
//using Backend.Data;
//using Backend.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Diagnostics;

//namespace Backend.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;
//        private readonly CinemaDbContext _db;

//        public HomeController(ILogger<HomeController> logger, CinemaDbContext context)
//        {
//            _logger = logger;
//            _db = context;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }

//        [AuditLog]
//        public void CreateUser(string user)
//        {
//            // Logic to create a user
//        }

//    }
//}
