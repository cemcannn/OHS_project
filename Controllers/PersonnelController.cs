using Business.Abstract;
using DTO.Personnel;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace OHSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _service;

        public PersonnelController(IPersonnelService service)
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
        public IActionResult Insert(PersonnelInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(PersonnelUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Personnel personnel)
        {
            var response = _service.Delete(personnel);
            return Ok(response);
        }
    }
}
