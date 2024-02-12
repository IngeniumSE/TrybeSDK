// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK;

/// <summary>
/// Provides methods for mapping Trybe environments to their corresponding URLs.
/// </summary>
public static class UrlMap
{
	public const string ProductionApiUrl = "https://api.try.be";
	public const string ProductionFrontendUrlFormat = "https://{0}.try.be";

	public const string PlaygroundApiUrl = "https://api.playground.try.be";
	public const string PlaygroundFrontendUrlFormat = "https://{0}.playground.try.be";

	/// <summary>
	/// Maps a Trybe environment to an API URL.
	/// </summary>
	/// <param name="environment">The Trybe environment.</param>
	/// <returns>The mapped API url.</returns>
	/// <exception cref="ArgumentException">When the provided environment is not a valid value.</exception>
	public static string MapApiUrl(TrybeEnvironment environment)
	{
		switch (environment)
		{
			case TrybeEnvironment.Production:
				return ProductionApiUrl;
			case TrybeEnvironment.Playground:
				return PlaygroundApiUrl;

			default:
				throw new ArgumentException(Resources.UrlMap_Environment_ValidationMessage);
		}
	}

	/// <summary>
	/// Maps a Trybe environment to an Frontend URL.
	/// </summary>
	/// <param name="environment">The Trybe environment.</param>
	/// <param name="frontendSubdomain">The Trybe frontend subdomain.</param>
	/// <returns>The mapped Frontend url.</returns>
	/// <exception cref="ArgumentException">When the provided environment is not a valid value.</exception>
	public static string MapFrontendUrl(TrybeEnvironment environment, string frontendSubdomain)
	{
		Ensure.IsNotNullOrEmpty(frontendSubdomain, nameof(frontendSubdomain));

		switch (environment)
		{
			case TrybeEnvironment.Production:
				return string.Format(ProductionFrontendUrlFormat, frontendSubdomain);
			case TrybeEnvironment.Playground:
				return string.Format(PlaygroundFrontendUrlFormat, frontendSubdomain);

			default:
				throw new ArgumentException(Resources.UrlMap_Environment_ValidationMessage);
		}
	}
}
