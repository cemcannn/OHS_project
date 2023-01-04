using Business.Abstract.OccupationalHealth;
using DTO.OccupationalHealth.WorkplaceTestAndAnalysis;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalHealth;

namespace OHSProgramApi.Controllers.OccupationalHealth
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceTestAndAnalysisController : ControllerBase
    {
        private readonly IWorkplaceTestAndAnalysisService _service;

        public WorkplaceTestAndAnalysisController(IWorkplaceTestAndAnalysisService service)
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
        public IActionResult Insert(WorkplaceTestAndAnalysisInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(WorkplaceTestAndAnalysisUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(WorkplaceTestAndAnalysis workplaceTestAndAnalysis)
        {
            var response = _service.Delete(workplaceTestAndAnalysis);
            return Ok(response);
        }
    }
}
