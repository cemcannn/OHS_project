using Business.Abstract.Definitions;
using DTO.Definitions.TypeOfSafetyEquipment;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfSafetyEquipmentController : ControllerBase
    {
        private readonly ITypeOfSafetyEquipmentService _service;

        public TypeOfSafetyEquipmentController(ITypeOfSafetyEquipmentService service)
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
        public IActionResult Insert(TypeOfSafetyEquipmentInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TypeOfSafetyEquipmentUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TypeOfSafetyEquipment typeOfSafetyEquipment)
        {
            var response = _service.Delete(typeOfSafetyEquipment);
            return Ok(response);
        }
    }
}
