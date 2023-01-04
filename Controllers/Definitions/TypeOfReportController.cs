using Business.Abstract.Definitions;
using DTO.Definitions.TypeOfReport;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfREportController : ControllerBase
    {
        private readonly ITypeOfReportService _service;

        public TypeOfREportController(ITypeOfReportService service)
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
        public IActionResult Insert(TypeOfReportInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TypeOfReportUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TypeOfReport typeOfReport)
        {
            var response = _service.Delete(typeOfReport);
            return Ok(response);
        }
    }
}
