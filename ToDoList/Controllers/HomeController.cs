using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger ,ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }
       
        //returns all entries which havent expired yet
        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);
            return View(_db.entries.Where(c=>c.currentUserId==userId).OrderBy(c=>c.Expires));
        }
        //returns all entries that arent completed yet
        public IActionResult NotFinished()
        {
            return View(_db.entries.Where(c => c.Completed == false).OrderBy(c=>c.Expires));
        }

       public IActionResult Create()
        {
            string userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Entry entry)
        {
            if (ModelState.IsValid)
            {
                string userId = _userManager.GetUserId(User);
                entry.currentUserId = userId;   
                _db.Add(entry);
                await _db.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }
            return View(entry);
        }
        public IActionResult Edit(int? id)
        {
            string userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            if (id == null) 
            {
                return NotFound();
            }
            var entry = _db.entries.Find(id);
            if (entry== null)
            {
                return NotFound();
            }
            return View(entry);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Entry entry)
        {
            if (ModelState.IsValid)
            {
                _db.Update(entry);
                await _db.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }
            return View(entry);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entry = _db.entries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        public IActionResult Delete (int? id)
        {
            string userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            if (id == null)
            {
                return NotFound();
            }
            var entry = _db.entries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEntry(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            var entry = _db.entries.Find(id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.Remove(entry);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
