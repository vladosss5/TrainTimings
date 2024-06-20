using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using TrainTimings.Application.Exceptions;
using TrainTimings.Application.Interfaces.IServices;
using TrainTimings.Persistence.Helpers;

namespace TrainTimings.Persistence.Services;

public class AccountService : IAccountService
{
    private static HttpClient client = HttpClientHelper.GetHttpClient();
    
    private readonly IConfiguration _configuration;
    
    public AccountService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<string> LoginAsync(string username, string password)
    {
        var reqestKeycloak = new Dictionary<string, string>
        {
            {"grant_type", _configuration["KeycloakLoginRequest:grant_type"]},
            {"client_id", _configuration["KeycloakLoginRequest:client_id"]},
            {"username", username},
            {"password", password},
            {"client_secret", _configuration["KeycloakLoginRequest:client_secret"]},
            {"scope", _configuration["KeycloakLoginRequest:scope"]}
        };
            
        var response = await client.PostAsync(_configuration["KeycloakLoginRequest:url"],
            new FormUrlEncodedContent(reqestKeycloak));
            
        var responseString = JObject.Parse(await response.Content.ReadAsStringAsync());
        var token = (string)responseString["access_token"];

        return token;
    }

    public async Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
    {
        if (oldPassword == newPassword)
            throw new LoginException();
        
        var keycloakService = new KeycloakService();
        await keycloakService.ChangeUserPassword(username, oldPassword);
    }
}