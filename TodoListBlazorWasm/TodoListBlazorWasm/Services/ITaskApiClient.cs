using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();
        Task<TaskDto> GetTaskById(string taskId);
    }
}
