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
}