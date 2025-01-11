using System.Text.Json;

namespace Admin.Shared.Config;

public class HttpClientWithOptions
{
    public HttpClient HttpClient { get; }
    public JsonSerializerOptions JsonSerializerOptions { get; }

    public HttpClientWithOptions(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
    {
        HttpClient = httpClient;
        JsonSerializerOptions = jsonSerializerOptions;
    }
}