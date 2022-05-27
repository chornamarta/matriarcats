//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace LFC.Web.Controllers
//{
//    public class ProfileController : Controller
//    {
//        // GET: ProfileController
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: ProfileController/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: ProfileController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ProfileController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: ProfileController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: ProfileController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: ProfileController/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: ProfileController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
using LFC.DAL;
using LFC.DAL.Models;
using LFC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LFC.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly LFCDbContext _db;
        public ProfileController(LFCDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> ListStudent()
        {
            return View(await _db.Courses.Include(c => c.Students).ToListAsync());
        }

        public async Task<IActionResult> MyCourses()
        {
            return View(await _db.Courses.Include(c => c.Teachers).ToListAsync());
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
