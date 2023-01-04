using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.OHSComittee;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class OHSComitteeController : ControllerBase
    {
        private readonly IOHSComitteeService _service;

        public OHSComitteeController(IOHSComitteeService service)
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
        public IActionResult Insert(OHSComitteeInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(OHSComitteeUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(OHSComittee oHSComittee)
        {
            var response = _service.Delete(oHSComittee);
            return Ok(response);
        }
    }
}
