using Business.Abstract.OccupationalSafety;
using DTO.OccupationalSafety.ActualWageAndPersonnelNumber;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.OccupationalSafety;

namespace OHSProgramApi.Controllers.OccupationalSafety
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualWageAndPersonnelNumberController : ControllerBase
    {
        private readonly IActualWageAndPersonnelNumberService _service;

        public ActualWageAndPersonnelNumberController(IActualWageAndPersonnelNumberService service)
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
        public IActionResult Insert(ActualWageAndPersonnelNumberInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(ActualWageAndPersonnelNumberUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(ActualWageAndPersonnelNumber actualWageAndPersonnelNumber)
        {
            var response = _service.Delete(actualWageAndPersonnelNumber);
            return Ok(response);
        }
    }
}
