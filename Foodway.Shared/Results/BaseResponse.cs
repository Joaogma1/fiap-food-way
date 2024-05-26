using System.Net;

namespace Foodway.Shared.Results;

public class BaseResponse<T>
{
    public T? Data { get; set; }

    public HttpStatusCode StatusCode { get; set; }

    public string? Content { get; set; }

    public bool IsSuccessStatusCode { get; set; }

    public bool ResponseIsUnauthorized => StatusCode == HttpStatusCode.Unauthorized;

    public string? Request { get; set; }

    public string? Response { get; set; }
}