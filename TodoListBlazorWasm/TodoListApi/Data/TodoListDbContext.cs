using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Todo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Todo.Data
{
    public class TodoListDbContext : IdentityDbContext<User,Role,Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

       public DbSet<Taskss> Tasksses { get; set; }
    }
}
