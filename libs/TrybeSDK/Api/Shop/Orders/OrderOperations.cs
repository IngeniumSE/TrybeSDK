// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface IShopOperations
{
	/// <summary>
	/// Gets the /shop/orders operations
	/// </summary>
	IOrderOperations Orders { get; }
}

partial class ShopOperations
{
	Lazy<IOrderOperations> _orders;
	public IOrderOperations Orders => (_orders ??= client.Defer<IOrderOperations>(
		c => new OrderOperations(path + "/orders", client))).Value;
}

public partial interface IOrderOperations
{
	/// <summary>
	/// Submits an order. The Order ID can also be a Basket ID.
	/// HTTP POST /shop/orders/{orderId}/submit
	/// </summary>
	/// <param name="orderId">The order ID, or the basket ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The order instance.</returns>
	Task<TrybeResponse<Order>> SubmitOrderAsync(
		string orderId,
		CancellationToken cancellationToken = default);
}

public partial class OrderOperations(PathString path, ApiClient client) : IOrderOperations
{
	public async Task<TrybeResponse<Order>> SubmitOrderAsync(
		string orderId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(orderId, nameof(orderId));

		var request = new TrybeRequest(HttpMethod.Post, path + $"/{orderId}/submit");

		return await client.FetchAsync<Order>(request, cancellationToken)
			.ConfigureAwait(false);
	}
}
