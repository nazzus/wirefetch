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

	private string ConvertToParameters(Dictionary<string, string> parameters)
	{
		var query = new StringBuilder();

		if (parameters.Count == 0)
			return string.Empty;

		query.Append('?', 0);

		foreach (var param in parameters)
		{
			if (query.Length > 0)
			{
				query.Append('&');
			}

			query.Append(HttpUtility.UrlEncode(param.Key));
			query.Append('=');
			query.Append(HttpUtility.UrlEncode(param.Value));
		}

		return query.ToString();
	}

	public void SetMethod(HttpMethod method)
	{
		_method = method;
	}

	public void SetUri(string url)
	{
		_endpointUrl = url;
	}

	public void SetBody(string body)
	{
		_body = new StringContent(body);
	}

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