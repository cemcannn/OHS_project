using Business.Abstract.OccupationalHealth;
using DTO.OccupationalHealth.HealthSurveillance;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalHealth;

namespace OHSProgramApi.Controllers.OccupationalHealth
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthSurveillanceController : ControllerBase
    {
        private readonly IHealthSurveillanceService _service;

        public HealthSurveillanceController(IHealthSurveillanceService service)
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
        public IActionResult Insert(HealthSurveillanceInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(HealthSurveillanceUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(HealthSurveillance healthSurveillance)
        {
            var response = _service.Delete(healthSurveillance);
            return Ok(response);
        }
    }
}
