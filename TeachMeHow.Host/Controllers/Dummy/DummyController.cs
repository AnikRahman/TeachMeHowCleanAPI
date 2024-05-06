using Microsoft.AspNetCore.Mvc;
using TeachMeHow.Application.Dtos;
using TeachMeHow.Domain;
using TeachMeHow.Persistence.Services;

namespace TeachMeHow.Host.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class DummyController : ControllerBase
        {
            private readonly DummyService _dummyService;

            public DummyController(DummyService dummyService)
            {
                _dummyService = dummyService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<DummyDto>>> GetAllDummies()
            {
                var dummies = await _dummyService.GetAllDummiesAsync();
                return Ok(dummies);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<DummyDto>> GetDummyById(int id)
            {
                var dummy = await _dummyService.GetDummyByIdAsync(id);
                if (dummy == null)
                {
                    return NotFound();
                }
                return Ok(dummy);
            }

            [HttpPost]
            public async Task<ActionResult<DummyDto>> CreateDummy(DummyDto dummyDto)
            {
                await _dummyService.CreateDummyAsync(dummyDto);
                return CreatedAtAction(nameof(GetDummyById), new { id = dummyDto.Id }, dummyDto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateDummy(int id, DummyDto dummyDto)
            {
                if (id != dummyDto.Id)
                {
                    return BadRequest();
                }

                await _dummyService.UpdateDummyAsync(dummyDto);

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteDummy(int id)
            {
                await _dummyService.DeleteDummyAsync(id);
                return NoContent();
            }
        }
    }
