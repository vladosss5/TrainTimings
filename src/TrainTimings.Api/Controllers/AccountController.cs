using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTimings.Api.DTOs.Account;
using TrainTimings.Application.Interfaces.IServices;

namespace TrainTimings.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await _accountService.LoginAsync(loginRequestDto.Login, loginRequestDto.Password);
            return Ok(result);
        }
    }
}