using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.Timing;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingControlle : ControllerBase
    {
        private readonly ITimingService _timingService;
        private readonly IMapper _mapper;
        
        public TimingControlle(ITimingService timingService, IMapper mapper)
        {
            _timingService = timingService;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var timings = await _timingService.GetAllTimingsAsync();
            return Ok(timings);
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var timing = await _timingService.GetTimingByIdAsync(id);
            return Ok(timing);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTimingDto timing)
        {
            var createdTiming = await _timingService.CreateTimingAsync(_mapper.Map<Timing>(timing));
            return Ok(createdTiming);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateTimingDto timing)
        {
            var updatedTiming = await _timingService.UpdateTimingAsync(_mapper.Map<Timing>(timing));
            return Ok(updatedTiming);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _timingService.DeleteTimingAsync(id);
            return NoContent();
        }
    }
}
