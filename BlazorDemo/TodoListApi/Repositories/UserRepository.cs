using TodoListApi.Data;
using TodoListApi.Entities;
using TodoListModel;

namespace TodoListApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDbContext _dbContext;
        public UserRepository(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
