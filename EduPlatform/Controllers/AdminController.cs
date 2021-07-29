using EduPlatform.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        public AdminController(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> AdminIndex()
        {
            return View(await db.subjects.ToListAsync());
        }

        public async Task<IActionResult> AddSubject(string Name, string Description, string Img)
        {
            Subject subject = new Subject();
            subject.Name = Name;
            subject.Description = Description;
            subject.Img = Img;
            db.subjects.Add(subject);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminIndex");
        }

        public async Task<IActionResult> DeleteSubject(int Id)
        {
            Subject subject = await db.subjects.FirstOrDefaultAsync(s => s.Id == Id);
            db.subjects.Remove(subject);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminIndex");
        }
    }
}
