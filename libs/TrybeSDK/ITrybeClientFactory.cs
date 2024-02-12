// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using TrybeSDK.Api;
using TrybeSDK.Frontend;

namespace TrybeSDK;

public interface ITrybeClientFactory
{
	ITrybeApiClient CreateApiClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeApiClient);

	ITrybeFrontendClient CreateShopClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeShopClient);
}

/// <summary>
/// Provides factory services for creating Trybe client instances.
/// </summary>
public class TrybeClientFactory : ITrybeClientFactory
{
	readonly IHttpClientFactory _httpClientFactory;

	public TrybeClientFactory(IHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = Ensure.IsNotNull(httpClientFactory, nameof(httpClientFactory));
	}

	public ITrybeApiClient CreateApiClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeApiClient)
		=> new TrybeApiClient(_httpClientFactory.CreateClient(name), settings);

	public ITrybeFrontendClient CreateShopClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeShopClient)
		=> new TrybeFrontendClient(_httpClientFactory.CreateClient(name), settings);
}
