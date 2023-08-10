using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;
        public HomeController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Tasks() 
        {
            //List<TodoTask> tasks = new List<TodoTask>()
            //{
            //    new TodoTask { Id = 1, TaskName = "Убраться", IsCompleted = true},
            //    new TodoTask { Id = 2, TaskName = "Помыться"},
            //    new TodoTask { Id = 3, TaskName = "Постираться"},
            //};
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
        public IActionResult Authorization() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}