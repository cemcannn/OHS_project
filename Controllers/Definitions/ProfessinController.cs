using Business.Abstract.Definitions;
using DTO.Definitions.Profession;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Definitions;

namespace OHSProgramApi.Controllers.Definitions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessinController : ControllerBase
    {
        private readonly IProfessionService _service;

        public ProfessinController(IProfessionService service)
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
        public IActionResult Insert(ProfessionInsertRequest request)
        {
            var response = _service.Insert(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(ProfessionUpdateRequest request)
        {
            var response = _service.Update(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Profession profession)
        {
            var response = _service.Delete(profession);
            return Ok(response);
        }
    }
}
