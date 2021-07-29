using EduPlatform.Data;
using EduPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.Message = "Kaka";
            Console.WriteLine("1  @@@@@@@@");
            if (User.Identity.IsAuthenticated)
            {
                TempData["CurrentUser"] = User.Identity.Name;
                TempData.Keep("CurrentUser");
                Console.WriteLine(User.Identity.Name + "  @@@@@@@@");
                return View(await db.users.ToListAsync());
            }
            else
            {
                TempData["CurrentUser"] = "Not authorized";
                TempData.Keep("CurrentUser");
                Console.WriteLine("Not authorized" + "  @@@@@@@@");
                return View(await db.users.ToListAsync());
            }
        }

        public async Task<IActionResult> CreateCourse()
        {
            return View(await db.subjects.ToListAsync());
        }

        public async Task<IActionResult> AddCourse(string Name, string Description, string Img, int Price, int Subject)
        {
            Subject sub = db.subjects.Find(Subject);
            Course course = new Course();
            course.CourseName = Name;
            course.Description = Description;   
            course.Img = Img;
            course.Price = Price;
            course.Subject = sub;
            db.courses.Add(course);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchName)
        {
            ViewData["GetCourseByName"] = searchName;

            var emprtyQuery = from x in db.courses select x;
            if (!String.IsNullOrEmpty(searchName))
            {
                emprtyQuery = emprtyQuery.Where(x=>x.CourseName.Contains(searchName));
            }
            return View(await emprtyQuery.AsNoTracking().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> BuyCourse(int id)
        {
            Course course = db.courses.Find(id);
            Basket basket = new Basket();
            basket.Course = course;
            basket.bought = true;
            db.baskets.Add(basket);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Course course = await db.courses.FirstOrDefaultAsync(p => p.Id == id);
                if (course != null)
                    return View(course);
            }
            return NotFound();
        }

        /*
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}
