using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Repositories;
using TodoListApi.Repositories;
using TodoListModel;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userRepository.GetUserList();
            var listDto = user.Select(x => new AssigneDto()
            {
                Id = x.Id,
                FullName = x.FirstName + " " + x.LastName,
            });
            return Ok(listDto);
        }
    }
}
