using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.Train;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainService _trainService;
        private readonly IMapper _mapper;
        
        public TrainController(ITrainService trainService, IMapper mapper)
        {
            _trainService = trainService;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetTrains()
        {
            var result = await _trainService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetTrainById(int id)
        {
            var result = await _trainService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpGet("get-by-number/{number}")]
        public async Task<IActionResult> GetTrainByNumber(string number)
        {
            var result = await _trainService.GetByNumberAsync(number);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTrain(CreateTrainDto trainRequest)
        {
            var result = await _trainService.CreateAsync(_mapper.Map<Train>(trainRequest));
            return Ok(result);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTrain(UpdateTrainDto trainRequest)
        {
            var result = await _trainService.UpdateAsync(_mapper.Map<Train>(trainRequest));
            return Ok(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTrain(int id)
        {
            await _trainService.DeleteAsync(id);
            return NoContent();
        }
    }
}
