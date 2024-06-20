using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.TypeTrain;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeTrainController : ControllerBase
    {
        private readonly ITypeTrainService _typeTrainService;
        private readonly IMapper _mapper;   
        
        public TypeTrainController(ITypeTrainService typeTrainService, IMapper mapper)
        {
            _typeTrainService = typeTrainService;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await _typeTrainService.GetAllTypesAsync();
            return Ok(result);
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var result = await _typeTrainService.GetTypeByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateType(CreateTypeTrainDto typeRequest)
        {
            var type = _mapper.Map<TypeTrain>(typeRequest);
            var result = await _typeTrainService.AddTypeAsync(type);
            return Ok(result);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateType(UpdateTypeTrainDto typeRequest)
        {
            var type = _mapper.Map<TypeTrain>(typeRequest);
            var result = await _typeTrainService.UpdateTypeAsync(type);
            return Ok(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            await _typeTrainService.DeleteTypeAsync(id);
            return NoContent();
        }
    }
}
