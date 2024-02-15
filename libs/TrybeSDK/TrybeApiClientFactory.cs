// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using TrybeSDK.Api;
using TrybeSDK.Frontend;

namespace TrybeSDK;

public interface ITrybeApiClientFactory
{
	ITrybeApiClient CreateApiClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeApiClient);

	ITrybeFrontendClient CreateFrontendClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeShopClient);
}

/// <summary>
/// Provides factory services for creating Trybe client instances.
/// </summary>
public class TrybeApiClientFactory : ITrybeApiClientFactory
{
	readonly ITrybeHttpClientFactory _httpClientFactory;

	public TrybeApiClientFactory(ITrybeHttpClientFactory httpClientFactory)
	{
		_httpClientFactory = Ensure.IsNotNull(httpClientFactory, nameof(httpClientFactory));
	}

	public ITrybeApiClient CreateApiClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeApiClient)
		=> new TrybeApiClient(_httpClientFactory.CreateHttpClient(name), settings);

	public ITrybeFrontendClient CreateFrontendClient(TrybeSettings settings, string name = TrybeApiConstants.DefaultTrybeShopClient)
		=> new TrybeFrontendClient(_httpClientFactory.CreateHttpClient(name), settings);
}
