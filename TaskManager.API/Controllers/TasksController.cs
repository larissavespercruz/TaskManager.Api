using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using TaskManager.API.Data.Repositories;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITasksRepository _taskRepository;

        public TasksController(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        //GET: api/tasks
        [HttpGet()]
        public IActionResult Get()
        {
            var response = _taskRepository.GetAll();
            return Ok(response);
        }

        //GET: api/tasks/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _taskRepository.GetById(id);

            if (response == null) return NotFound();

            return Ok(response);
        }

        //POST: api/tasks/
        [HttpPost()]
        public IActionResult Post([FromBody] TasksInputModel task)
        {
            var newTasks = new Tasks(task.Name, task.Details);

            _taskRepository.AddTasks(newTasks);
            return Created("", task);

        }

        //PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TasksInputModel newTask)
        {
            var task = _taskRepository.GetById(id);

            if (task == null) return NotFound();

            task.UpdateTasks(newTask.Name, newTask.Details, newTask.Done);

            _taskRepository.Update(id, task);
            return Ok(task);
        }

        //DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var task = _taskRepository.GetById(id);

            if (task == null) return NotFound();

            _taskRepository.DeleteById(id);
            return NoContent();
        }
    }
}
