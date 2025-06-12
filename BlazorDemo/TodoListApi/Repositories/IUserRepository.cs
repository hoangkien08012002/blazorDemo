using TodoListApi.Entities;
using TodoListModel;

namespace TodoListApi.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();
    }
}
