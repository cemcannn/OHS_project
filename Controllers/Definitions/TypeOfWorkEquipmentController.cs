using Business.Abstract.Definitions;
using DTO.Definitions.TypeOfWorkEquipment;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfWorkEquipmentController : ControllerBase
    {
        private readonly ITypeOfWorkEquipmentService _service;

        public TypeOfWorkEquipmentController(ITypeOfWorkEquipmentService service)
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
        public IActionResult Insert(TypeOfWorkEquipmentInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TypeOfWorkEquipmentUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TypeOfWorkEquipment typeOfWorkEquipment)
        {
            var response = _service.Delete(typeOfWorkEquipment);
            return Ok(response);
        }
    }
}
