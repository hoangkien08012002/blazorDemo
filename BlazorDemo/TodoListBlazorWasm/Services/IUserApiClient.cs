using TodoListModel;

namespace TodoListBlazorWasm.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneDto>> GetAssigne();
    }
}
