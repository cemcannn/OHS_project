using Business.Abstract.Trainings;
using DTO.Trainings.Certificate;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Trainings;

namespace OHSProgramApi.Controllers.Trainings
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _service;

        public CertificateController(ICertificateService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Insert(CertificateInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(CertificateUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Certificate certificate)
        {
            var response = _service.Delete(certificate);
            return Ok(response);
        }
    }
}
