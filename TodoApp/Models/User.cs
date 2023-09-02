using Microsoft.AspNetCore.Identity;

namespace TodoApp.Models
{
    public class User : IdentityUser
    {
        public ICollection<TodoTask> Tasks { get; set; }
    }
}
