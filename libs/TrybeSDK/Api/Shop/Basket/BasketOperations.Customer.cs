// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System;
using System.Collections.Generic;
using System.Text;

namespace TrybeSDK.Api;

partial interface IBasketOperations
{
	/// <summary>
	/// Sets the customer for the basket.
	/// </summary>
	/// <param name="basketId">The basket ID.</param>
	/// <param name="customer">The customer instance.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated basket instance.</returns>
	Task<TrybeResponse<Basket>> SetCustomerAsync(
		string basketId,
		Customer customer,
		CancellationToken cancellationToken = default);
}

partial class BasketOperations
{
	public async Task<TrybeResponse<Basket>> SetCustomerAsync(
		string basketId,
		Customer customer,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));
		Ensure.IsNotNull(customer, nameof(customer));

		var request = new TrybeRequest<Customer>(HttpMethod.Post, path + $"/{basketId}/customer", customer);

		return await client.FetchAsync<Customer, Basket>(request, cancellationToken);
	}
}
