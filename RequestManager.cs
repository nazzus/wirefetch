using System.Net;
using System.Net.Http;
using System.Web;
using System.Text;

namespace Wirefetch;

public class HttpRequestManager
{
	private HttpClient _httpClient;
	private HttpMethod _method;
	private string _endpointUrl;
	private Dictionary<string, string> _headers;
	private Dictionary<string, string> _queryParameters;
	private HttpContent _body;

	public HttpRequestManager()
	{
		_httpClient = new HttpClient();

		_httpClient.DefaultRequestHeaders.Add("User-Agent", "Wirefetch/1.0");
		_httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

		_method = HttpMethod.Get;
		_headers = new Dictionary<string, string> { };
		_body = new StringContent("");
		_queryParameters = new Dictionary<string, string> { };
		_endpointUrl = "";
	}
}