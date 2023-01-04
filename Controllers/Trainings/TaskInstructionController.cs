using Business.Abstract.Trainings;
using DTO.Trainings.TaskInstruction;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Trainings;

namespace OHSProgramApi.Controllers.Trainings
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskInstructionController : ControllerBase
    {
        private readonly ITaskInstructionService _service;

        public TaskInstructionController(ITaskInstructionService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert(TaskInstructionInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TaskInstructionUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TaskInstruction taskInstruction)
        {
            var response = _service.Delete(taskInstruction);
            return Ok(response);
        }
    }
}
