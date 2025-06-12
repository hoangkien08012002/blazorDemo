using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Repositories;
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
            var task = await _userRepository.GetTaskssList();
            var listDto = task.Select(x => new TaskDto()
            {
                Status = x.Status,
                Name = x.Name,
                AssigneId = x.AssigneId,
                CreateDate = DateTime.Now,
                Priority = x.Priority,
                Id = x.Id,
                AssigneName = x.Assigne?.FirstName + " " + x.Assigne?.LastName
            });
            return Ok(listDto);
        }
    }
}
