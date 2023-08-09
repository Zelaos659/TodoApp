namespace TodoApp.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        //public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        //public TaskType TaskType { get; set; }
    }
    public enum TaskType
    {
        Single,
        Multi,
        UntilDay
    }
}
