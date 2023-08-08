using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Test() 
        {
            List<TodoTask> tasks = new List<TodoTask>()
            {
                new TodoTask { Id = 1, TaskName = "Убраться", isCompleted = true},
                new TodoTask { Id = 2, TaskName = "Помыться"},
                new TodoTask { Id = 3, TaskName = "Постираться"},
            };
            return View(tasks); 
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