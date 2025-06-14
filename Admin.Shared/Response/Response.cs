using System.Text.Json.Serialization;

namespace Admin.Shared.Response;

public class Response<TData>
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
        => _code = 200;

    public Response(
        TData? data,
        int code = 200,
        string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }

    
    public bool IsSuccess
        => _code is >= 200 and <= 299;
}