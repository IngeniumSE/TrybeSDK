// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK;

public partial interface ITrybeShopClient
{

}

public partial class TrybeShopClient : ApiClient, ITrybeShopClient
{
	public TrybeShopClient(HttpClient http, TrybeSettings settings)
		: base(http, settings, settings.ShopUrl) { }
}
