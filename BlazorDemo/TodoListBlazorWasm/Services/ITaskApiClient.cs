using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList( TaskListSearch taskListSearch);
        Task<TaskDto> GetTaskById(string taskId);
        Task<bool> Create(TaskCreateRequest task);
    }
}
