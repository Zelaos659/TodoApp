using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не может быть пустым")]
        [Display(Name = "Задача")]
        public string? TaskName { get; set; }
        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        //public TaskType TaskType { get; set; }
    }
    public enum TaskType
    {
        Single,
        Multi,
        UntilDay
    }
}
