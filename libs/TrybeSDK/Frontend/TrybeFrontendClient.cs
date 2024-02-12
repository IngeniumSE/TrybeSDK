// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Frontend;

public partial interface ITrybeFrontendClient
{

}

public partial class TrybeFrontendClient : ApiClient, ITrybeFrontendClient
{
	public TrybeFrontendClient(HttpClient http, TrybeSettings settings)
		: base(http, settings, UrlMap.MapFrontendUrl(settings.Environment, settings.FrontendSubdomain)) { }
}
