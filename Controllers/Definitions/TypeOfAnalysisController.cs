using Business.Abstract.Definitions;
using DTO.Definitions.TypeOfAnalysis;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfAnalysisController : ControllerBase
    {
        private readonly ITypeOfAnalysisService _service;

        public TypeOfAnalysisController(ITypeOfAnalysisService service)
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
        public IActionResult Insert(TypeOfAnalysisInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TypeOfAnalysisUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(TypeOfAnalysis typeOfAnalysis)
        {
            var response = _service.Delete(typeOfAnalysis);
            return Ok(response);
        }
    }
}
