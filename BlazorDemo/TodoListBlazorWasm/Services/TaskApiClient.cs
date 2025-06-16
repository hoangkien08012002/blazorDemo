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

        public async Task<bool> Create(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Tasksss", request);
            return result.IsSuccessStatusCode? true : false;
        }

        public async Task<TaskDto> GetTaskById(string taskId)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/tasksss/{taskId}");
            return result;
        }

        public async Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            string url = $"/api/Tasksss?Name={taskListSearch.Name}&AssigneId={taskListSearch.AssigneId}&priority={taskListSearch.priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return result;
        }
    }
}
