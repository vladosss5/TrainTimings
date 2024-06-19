using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.City;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _cityService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var result = await _cityService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCity(CreateCityDto cityRequest)
        {
            var city = _mapper.Map<City>(cityRequest);
            var result = await _cityService.CreateAsync(city);
            return Ok(result);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateCity(UpdateCityDto cityRequest)
        {
            var city = _mapper.Map<City>(cityRequest);
            var result = await _cityService.UpdateAsync(city);
            return Ok(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await _cityService.DeleteAsync(id);
            return NoContent();
        }
    }
}
