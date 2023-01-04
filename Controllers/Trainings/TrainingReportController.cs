using Business.Abstract.Trainings;
using Microsoft.AspNetCore.Mvc;

namespace OHSProgramApi.Controllers.Trainings
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingReportController : ControllerBase
    {
        private readonly ICertificateService _service;

        public TrainingReportController(ICertificateService service)
        {
            _service = service;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var data = _service.GetById(id);
            return Ok(data);
        }

        [HttpGet("GetTrainingReport")]
        public IActionResult GetTrainingReport(int id)
        {
            var data = _service.GetTrainingReport(id);
            return Ok(data);
        }
    }
}
