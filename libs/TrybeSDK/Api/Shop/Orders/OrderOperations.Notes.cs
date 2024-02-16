// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface IOrderOperations
{
	/// <summary>
	/// Adds a note to an order.
	/// HTTP POST /shop/orders/{orderId}/notes
	/// </summary>
	/// <param name="orderId">The order ID.</param>
	/// <param name="content">The note content.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The Trybe response.</returns>
	Task<TrybeResponse<OrderNote>> AddNoteAsync(
		string orderId,
		string content,
		CancellationToken cancellationToken = default);
}

partial class OrderOperations
{
	public async Task<TrybeResponse<OrderNote>> AddNoteAsync(
		string orderId,
		string content,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(orderId, nameof(orderId));
		Ensure.IsNotNullOrEmpty(content, nameof(content));

		var note = new OrderNote { Id = "", OrderId = orderId, Content = content };

		var request = new TrybeRequest<OrderNote>(HttpMethod.Post, path + $"/{orderId}/notes", note);

		return await client.FetchAsync<OrderNote, OrderNote>(request, cancellationToken)
			 .ConfigureAwait(false);
	}
}
