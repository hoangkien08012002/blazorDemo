using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Entities;
using TodoList.Model;

namespace Todo.Repositories
{
    public class TaskssRepository : ITaskssRepository
    {
        private readonly TodoListDbContext _context;
        public TaskssRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<Taskss> Create(Taskss taskss)
        {
            await _context.Tasksses.AddAsync(taskss);
            await _context.SaveChangesAsync();
            return taskss;
        }

        public async Task<Taskss> DeleteTaskss(Taskss taskss)
        {
            _context.Tasksses.Remove(taskss);
            await _context.SaveChangesAsync();
            return taskss;
        }

        public async Task<Taskss> GetTaskssById(Guid id)
        {
            return await _context.Tasksses.FindAsync(id);
        }

        public async Task<IEnumerable<Taskss>> GetTaskssList()
        {

            return await _context.Tasksses
                .Include(x => x.Assigne)
                .ToListAsync();
        }

        public async Task<Taskss> UpdateTaskss(Taskss taskss)
        {
            _context.Tasksses.Update(taskss);
            await _context.SaveChangesAsync();
            return taskss;
        }
    }
}
