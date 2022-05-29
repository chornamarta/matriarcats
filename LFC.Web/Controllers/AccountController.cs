using LFC.DAL;
using LFC.DAL.Models;
using LFC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LFC.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly LFCDbContext _db;
        public AccountController(LFCDbContext db)
        {
            _db = db;
        }
        //public async Task<IActionResult> Register()
        //{
        //    return View(await _db.Courses.Include(c => c.Teachers).ToListAsync());
        //}

        // public IActionResult Register()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}