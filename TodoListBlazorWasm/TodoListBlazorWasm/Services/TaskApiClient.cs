using System.Net.Http.Json;
using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;

        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskDto> GetTaskById(string taskId)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/tasksss/{taskId}");
            return result;
        }

        public async Task<List<TaskDto>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>("/api/tasksss");
            return result;
        }
    }
}
