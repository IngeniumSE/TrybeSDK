// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK;

public partial interface ITrybeSiteClient
{

}

public partial class TrybeSiteClient : ApiClient, ITrybeSiteClient
{
	public TrybeSiteClient(HttpClient http, TrybeSettings settings)
		: base(http, settings, UrlMap.MapFrontendUrl(settings.Environment, settings.FrontendSubdomain)) { }
}
