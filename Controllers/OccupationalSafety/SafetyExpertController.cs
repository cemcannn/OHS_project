using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.SafetyExpert;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafetyExpertController : ControllerBase
    {
        private readonly ISafetyExpertService _service;

        public SafetyExpertController(ISafetyExpertService service)
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
        public IActionResult Insert(SafetyExpertInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(SafetyExpertUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(SafetyExpert safetyExpert)
        {
            var response = _service.Delete(safetyExpert);
            return Ok(response);
        }
    }
}
