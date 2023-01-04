using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.Accident;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidentController : ControllerBase
    {
        private readonly IAccidentService _service;

        public AccidentController(IAccidentService service)
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
        public IActionResult Insert(AccidentInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(AccidentUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Accident accident)
        {
            var response = _service.Delete(accident);
            return Ok(response);
        }
    }
}
