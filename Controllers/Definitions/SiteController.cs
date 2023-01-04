using Business.Abstract.Definitions;
using DTO.Definitions.Site;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteService _service;

        public SiteController(ISiteService service)
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
        public IActionResult Insert(SiteInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(SiteUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Site site)
        {
            var response = _service.Delete(site);
            return Ok(response);
        }
    }
}
