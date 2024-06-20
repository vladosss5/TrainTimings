using System.Net;
using System.Text;
using Newtonsoft.Json;
using TrainTimings.Application.Exceptions;
using TrainTimings.Core.DtoClasses;
using TrainTimings.Persistence.Helpers;

namespace TrainTimings.Persistence.Services;

public class KeycloakService
{
    private readonly HttpClient _httpClient = HttpClientHelper.GetHttpClient();
    private readonly string _keycloakUrl;
    private readonly string _realm;
    private  string _adminUsername;
    private  string _adminPassword;

    public KeycloakService()
    {
        _keycloakUrl = "http://keycloak:8080";
        _realm = "MyRealm";
    }

    public async Task<bool> ChangeUserPassword(string userId, string newPassword)
    {
        var request = new PasswordChangeRequest
        {
            Value = newPassword
        };
        
        _adminUsername = userId;
        _adminPassword = newPassword;

        var jsonRequest = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var token = await GetAdminToken();
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PutAsync($"{_keycloakUrl}/admin/realms/{_realm}/users/{userId}/reset-password", content);

        if (!response.IsSuccessStatusCode)
            throw new LoginException();

        return true;
    }

    private async Task<string> GetAdminToken()
    {
        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, $"{_keycloakUrl}/realms/{_realm}/protocol/openid-connect/token");
        var formData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "admin-cli"),
            new KeyValuePair<string, string>("username", "admin-cli"),
            new KeyValuePair<string, string>("client_secret", "VcREM0TcaIQRKS5nOON3VjswneNZzOs8"),
            new KeyValuePair<string, string>("grant_type", "password")
        });

        tokenRequest.Content = formData;

        var tokenResponse = await _httpClient.SendAsync(tokenRequest);
        var tokenResponseContent = await tokenResponse.Content.ReadAsStringAsync();
        var tokenData = JsonConvert.DeserializeObject<dynamic>(tokenResponseContent);

        return tokenData.access_token;
    }
}