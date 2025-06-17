using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList( TaskListSearch taskListSearch);
        Task<TaskDto> GetTaskById(string taskId);
        Task<bool> Create(TaskCreateRequest task);

        Task<bool> Update(Guid id, TaskUpdateRequest request); 
        Task<bool> Delete(Guid id);
    }
}
