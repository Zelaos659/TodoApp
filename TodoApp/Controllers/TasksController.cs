using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TasksController : Controller
    {
        AppDbContext db;
        public TasksController(AppDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.todoTasks.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoTask task)
        {
            db.todoTasks.Add(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Tasks");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await db.todoTasks.FindAsync(id);
            db.todoTasks.Remove(task);
            await db.SaveChangesAsync();
            return RedirectToAction("Tasks");
        }

        [HttpPut]
        public async Task<IActionResult> Complete(int id)
        {
            var task = await db.todoTasks.FindAsync(id);
            task.IsCompleted = true;
            await db.SaveChangesAsync();
            return RedirectToAction("Tasks");
        }
    }
}
