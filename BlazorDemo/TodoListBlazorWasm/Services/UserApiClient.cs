using System.Net.Http.Json;
using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public class UserApiClient : IUserApiClient
    {

        public HttpClient _httpClient;

        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssigneDto>> GetAssigne()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssigneDto>>("/api/users");
            return result;
        }
    }
}
