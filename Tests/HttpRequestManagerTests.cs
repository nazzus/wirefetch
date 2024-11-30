using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Wirefetch;

namespace Tests;

public class HttpRequestManagerTests
{
    private readonly HttpRequestManager _requestManager;

    [Fact]
    public async Task GetRequestWithQueryParams()
    {
        _requestManager.SetUri("https://postman-echo.com/get");
        _requestManager.AddQueryParameter("hello", "world");
        _requestManager.AddQueryParameter("this", "is a message");
        HttpResponseMessage resp = await _requestManager.MakeRequest();

        Debug.WriteLine(await resp.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public async Task PostRequestWithBody()
    {
        var body = new
        {
            hello = "world"
        };

        _requestManager.SetUri("https://postman-echo.com/post");
        _requestManager.SetMethod(HttpMethod.Post);
        _requestManager.SetBody(JsonSerializer.Serialize(body));
        HttpResponseMessage resp = await _requestManager.MakeRequest();

        Debug.WriteLine(await resp.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    public HttpRequestManagerTests()
    {
        _requestManager = new();
    }
}