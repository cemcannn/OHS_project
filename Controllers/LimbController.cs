using Business.Abstract.Definitions;
using DTO.Definitions.Limb;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimbController : ControllerBase
    {
        private readonly ILimbService _service;

        public LimbController(ILimbService service)
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
        public IActionResult Insert(LimbInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(LimbUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Limb limb)
        {
            var response = _service.Delete(limb);
            return Ok(response);
        }
    }
}
