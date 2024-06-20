using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.TypeFollowing;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Core.Models;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFollowingController : ControllerBase
    {
        private readonly ITypeFollowingService _typeFollowingService;
        private readonly IMapper _mapper;
        
        public TypeFollowingController(ITypeFollowingService typeFollowingService, IMapper mapper)
        {
            _typeFollowingService = typeFollowingService;
            _mapper = mapper;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await _typeFollowingService.GetAllTypesFollowing();
            return Ok(result);
        }
        
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var result = await _typeFollowingService.GetTypesFollowingById(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateType(CreateTypeFollowingDto typeRequest)
        {
            var type = _mapper.Map<TypesFollowing>(typeRequest);
            var result = await _typeFollowingService.AddTypesFollowing(type);
            return Ok(result);
        }
        
        [HttpPut("update")]
        public async Task<IActionResult> UpdateType(UpdateTypeFollowingDto typeRequest)
        {
            var type = _mapper.Map<TypesFollowing>(typeRequest);
            var result = await _typeFollowingService.UpdateTypesFollowing(type);
            return Ok(result);
        }
        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            await _typeFollowingService.DeleteTypesFollowing(id);
            return NoContent();
        }
    }
}
