namespace TrainTimings.Persistence.Helpers;

public class HttpClientHelper
{
    private static HttpClient _httpClient;
    public static HttpClient GetHttpClient() => 
        _httpClient ??= new HttpClient();
}