using Business.Abstract.Definitions;
using DTO.Definitions.Unit;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _service;

        public UnitController(IUnitService service)
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
        public IActionResult Insert(UnitInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(UnitUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Unit accident)
        {
            var response = _service.Delete(accident);
            return Ok(response);
        }
    }
}
