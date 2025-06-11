using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TodoListApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TodoListApi.Data
{
    public class TodoListDbContext : IdentityDbContext<User,Role,Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

       public DbSet<Taskss> Tasksses { get; set; }
    }
}
