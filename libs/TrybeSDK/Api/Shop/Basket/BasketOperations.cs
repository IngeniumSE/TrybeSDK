// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface IShopOperations
{
	/// <summary>
	/// Gets the /shop/basket operations.
	/// </summary>
	IBasketOperations Baskets { get; }
}

partial class ShopOperations
{
	Lazy<IBasketOperations> _baskets;
	public IBasketOperations Baskets => (_baskets ??= client.Defer<IBasketOperations>(
		c => new BasketOperations(path + "/basket", c))).Value;
}

/// <summary>
/// Provides operations for operating on the /shop/basket endpoint.
/// </summary>
public partial interface IBasketOperations
{
	/// <summary>
	/// Gets the basket with the given ID.
	/// HTTP GET /shop/basket/{basketId}
	/// </summary>
	/// <param name="basketId">The basket ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The basket instance.</returns>
	Task<TrybeResponse<Basket>> GetBasketAsync(
		string basketId,
		CancellationToken cancellationToken = default);
}

public partial class BasketOperations(PathString path, ApiClient client): IBasketOperations
{
	public async Task<TrybeResponse<Basket>> GetBasketAsync(
		string basketId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));

		var request = new TrybeRequest(HttpMethod.Get, path + $"/{basketId}");

		return await client.FetchAsync<Basket>(request, cancellationToken);
	}
}
