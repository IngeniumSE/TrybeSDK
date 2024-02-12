// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

public partial interface ITrybeApiClient
{

}

public partial class TrybeApiClient : ApiClient, ITrybeApiClient
{
	public TrybeApiClient(HttpClient http, TrybeSettings settings)
		: base(http, settings, UrlMap.MapApiUrl(settings.Environment)) { }
}
