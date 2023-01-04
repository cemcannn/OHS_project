using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.SafetyEquipment;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafetyEquipmentController : ControllerBase
    {
        private readonly ISafetyEquipmentService _service;

        public SafetyEquipmentController(ISafetyEquipmentService service)
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
        public IActionResult Insert(SafetyEquipmentInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(SafetyEquipmentUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(SafetyEquipment safetyEquipment)
        {
            var response = _service.Delete(safetyEquipment);
            return Ok(response);
        }
    }
}
