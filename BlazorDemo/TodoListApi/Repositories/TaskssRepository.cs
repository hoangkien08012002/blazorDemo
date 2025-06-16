using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoListApi.Data;
using TodoListApi.Entities;
using TodoListModel;

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

        public async Task<IEnumerable<Taskss>> GetTaskssList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasksses.Include(x => x.Assigne).AsQueryable();
            if (!string.IsNullOrEmpty(taskListSearch.Name))
            {
                query = query.Where(x => x.Name.Contains(taskListSearch.Name));
            }
            if (taskListSearch.AssigneId.HasValue)
            {
                query = query.Where(x => x.AssigneId == taskListSearch.AssigneId.Value);
            }
            if (taskListSearch.priority.HasValue)
            {
                query = query.Where(x => x.Priority == taskListSearch.priority.Value);
            }
            return await query.OrderBy(x=>x.CreateDate).ToListAsync();
        }

        public async Task<Taskss> UpdateTaskss(Taskss taskss)
        {
            _context.Tasksses.Update(taskss);
            await _context.SaveChangesAsync();
            return taskss;
        }
    }
}
