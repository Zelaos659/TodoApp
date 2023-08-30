using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    //[Authorize]
    public class TaskController : Controller
    {
        private readonly AppDbContext db;
        public TaskController(AppDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await db.todoTasks.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoTask task)
        {
            db.todoTasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await db.todoTasks.FindAsync(id);
            db.todoTasks.Remove(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> Complete(int id)
        {
            var task = await db.todoTasks.FindAsync(id);
            task.IsCompleted = true;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
