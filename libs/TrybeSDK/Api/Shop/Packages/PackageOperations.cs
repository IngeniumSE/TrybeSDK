// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface IShopOperations
{
	/// <summary>
	/// Gets the /shop/pacakges operations.
	/// </summary>
	IPackageOperations Packages { get; }
}

partial class ShopOperations
{
	Lazy<IPackageOperations> _packages;
	public IPackageOperations Packages => (_packages ??= client.Defer<IPackageOperations>(
		c => new PackageOperations(path + "/packages", client))).Value;
}

public interface IPackageOperations
{
	/// <summary>
	/// Gets package offering with the given ID.
	/// HTTP GET /shop/packages/{offeringId}
	/// </summary>
	/// <param name="offeringId">The offering ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The package instance.</returns>
	Task<TrybeResponse<Package>> GetPackageAsync(
		string offeringId,
		CancellationToken cancellationToken = default);
}

public class PackageOperations(PathString path, ApiClient client) : IPackageOperations
{
	public async Task<TrybeResponse<Package>> GetPackageAsync(
		string offeringId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(offeringId, nameof(offeringId));

		var request = new TrybeRequest(HttpMethod.Get, path + $"/{offeringId}");

		return await client.FetchAsync<Package>(request, cancellationToken)
			.ConfigureAwait(false);
	}
}
