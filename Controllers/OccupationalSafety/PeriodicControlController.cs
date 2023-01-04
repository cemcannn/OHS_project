using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.PeriodicControl;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodicControlController : ControllerBase
    {
        private readonly IPeriodicControlService _service;

        public PeriodicControlController(IPeriodicControlService service)
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
        public IActionResult Insert(PeriodicControlInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(PeriodicControlUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(PeriodicControl periodicControl)
        {
            var response = _service.Delete(periodicControl);
            return Ok(response);
        }
    }
}
