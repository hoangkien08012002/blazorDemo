﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Entities;
using Todo.Repositories;
using TodoListModel;
using TodoListModel.Enums;

namespace Todo.Controllers
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
            var task = await _taskRepository.GetTaskssList();
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

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createTask = await _taskRepository.Create( new Taskss()
            {
                Name = request.Name,
                Priority = request.Priority,
                Status = Status.Open,
                Id = request.Id,
            });


            return CreatedAtAction(nameof(GetById), new { id = createTask.Id }, createTask);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> update(Guid id, TaskUpdateRequest request )
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
            // Cập nhật thuộc tính từ task mới
            taskOld.Name = request.Name;
            taskOld.Priority = request.Priority;

            var taskResult = await _taskRepository.UpdateTaskss(taskOld);
            return Ok(new TaskDto()
            {
                Name= taskResult.Name,
                Status= taskResult.Status,
                Id= taskResult.Id,
                AssigneId= taskResult.AssigneId,
                Priority= taskResult.Priority,
                CreateDate= taskResult.CreateDate
            });
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var getById = await _taskRepository.GetTaskssById(id);
            if (getById == null)
            {
                return NotFound($"{id} not found");
            }
            return Ok(getById);
        }
    }
}
