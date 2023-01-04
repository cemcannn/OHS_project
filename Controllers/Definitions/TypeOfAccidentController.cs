using Business.Abstract.Definitions;
using DTO.Definitions.TypeOfAccident;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfAccidentController : ControllerBase
    {
        private readonly ITypeOfAccidentService _service;

        public TypeOfAccidentController(ITypeOfAccidentService service)
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
        public IActionResult Insert(TypeOfAccidentInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TypeOfAccidentUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TypeOfAccident typeOfAccident)
        {
            var response = _service.Delete(typeOfAccident);
            return Ok(response);
        }
    }
}
