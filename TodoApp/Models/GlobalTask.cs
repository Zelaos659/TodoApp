using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TodoApp.Models
{
    public class GlobalTask //: Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Задача")]
        public string? TaskName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
