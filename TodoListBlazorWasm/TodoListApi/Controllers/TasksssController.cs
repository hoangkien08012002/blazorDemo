using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Entities;
using TodoListApi.Repositories;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksssController : ControllerBase
    {
        private readonly ITaskssRepository _taskRepository;
        public TasksssController(ITaskssRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _taskRepository.GetTaskssList();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Taskss task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createTask = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById), createTask);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> update(Guid id, Taskss task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taskOld = await _taskRepository.GetTaskssById(id);

            if (taskOld == null)
            {
                return NotFound($"{id} not found");
            }


            var ta = await _taskRepository.Create(task);
            return Ok(ta);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {

            var getById = await _taskRepository.GetTaskssById(Id);
            if (getById == null)
            {
                return NotFound($"{Id} not found");
            }
            return Ok(getById);
        }
    }
}
