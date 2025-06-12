using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using TodoListApi.Entities;
using TodoListModel.Enums;

namespace TodoListApi.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {
            User user = null;
            if (!context.Users.Any())
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "mr ",
                    LastName = "A",
                    Email = "admin@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName = "admin",

                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");
                context.Users.Add(user);
            }
            else
            {
                user = context.Users.First(); // Lấy user đầu tiên nếu đã tồn tại
            }
            if (!context.Tasksses.Any())
            {
                context.Tasksses.Add(new Entities.Taskss()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample tasks 1",
                    CreateDate = DateTime.Now,
                    Priority = Priority.High,
                    Status = Status.Open,
                    AssigneId = user.Id
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
