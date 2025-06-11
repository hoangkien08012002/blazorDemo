using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoListApi.Data;
using TodoListApi.Entities;

namespace TodoListApi.Repositories
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
            return await _context.Tasksses.ToListAsync();
        }

        public async Task<Taskss> UpdateTaskss( Taskss taskss)
        {
            await _context.Tasksses.AddAsync(taskss);
            await _context.SaveChangesAsync();
            return taskss;
        }
    }
}
