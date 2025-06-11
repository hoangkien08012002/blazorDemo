using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Repositories;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksssController : ControllerBase
    {
        private readonly ITaskssRepository _taskRepository;
        public TasksssController(ITaskssRepository taskRepository) {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _taskRepository.GetTaskssList();
            return Ok(list);
        }
    }
}
