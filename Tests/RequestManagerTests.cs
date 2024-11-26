using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Wirefetch;

namespace Tests;

public class RequestManagerTests
{
    private readonly HttpRequestManager _requestManager;

    [Fact]
    public async void GetRequest()
    {
        _requestManager.SetUri("https://postman-echo.com/get?hello=world");
        HttpResponseMessage resp = await _requestManager.MakeRequest();

        Debug.WriteLine(await resp.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }

    [Fact]
    public async void PostRequest()
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

    public RequestManagerTests()
    {
        _requestManager = new HttpRequestManager();
    }
}