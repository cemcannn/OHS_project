using Business.Abstract.OccupationalHealth;
using DTO.OccupationalHealth.HealthPersonnel;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalHealth;

namespace OHSProgramApi.Controllers.OccupationalHealth
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthPersonnelController : ControllerBase
    {
        private readonly IHealthPersonnelService _service;

        public HealthPersonnelController(IHealthPersonnelService service)
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
        public IActionResult Insert(HealthPersonnelInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(HealthPersonnelUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(HealthPersonnel healthPersonnel)
        {
            var response = _service.Delete(healthPersonnel);
            return Ok(response);
        }
    }
}
