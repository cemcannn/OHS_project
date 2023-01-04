using Business.Abstract.OccupationalHealth;
using DTO.OccupationalHealth.OccupationalDisease;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalHealth;

namespace OHSProgramApi.Controllers.OccupationalHealth
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationalDiseaseController : ControllerBase
    {
        private readonly IOccupationalDiseaseService _service;

        public OccupationalDiseaseController(IOccupationalDiseaseService service)
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
        public IActionResult Insert(OccupationalDiseaseInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(OccupationalDiseaseUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(OccupationalDisease occupationalDisease)
        {
            var response = _service.Delete(occupationalDisease);
            return Ok(response);
        }
    }
}
