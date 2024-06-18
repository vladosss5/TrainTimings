using Microsoft.Extensions.Configuration;
using TrainTimings.Application.Interfaces.IServices;

namespace TrainTimings.Persistence.Services;

public class AccountService : IAccountService
{
    static HttpClient client = new HttpClient();
    
    private readonly IConfiguration _configuration;
    
    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<string> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}