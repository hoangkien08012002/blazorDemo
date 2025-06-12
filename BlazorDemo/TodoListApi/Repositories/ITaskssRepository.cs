using TodoListApi.Entities;
using TodoListModel;

namespace Todo.Repositories
{
    public interface ITaskssRepository
    {

        Task<IEnumerable<Taskss>> GetTaskssList();
        Task<Taskss> Create(Taskss taskss);
        Task<Taskss> UpdateTaskss( Taskss taskss);
        Task<Taskss> DeleteTaskss(Taskss taskss);
        Task<Taskss> GetTaskssById(Guid id);
    }
}
