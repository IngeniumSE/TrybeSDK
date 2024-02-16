// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

using TrybeSDK.Primitives;

namespace TrybeSDK.Api;

partial interface IBasketOperations
{
	/// <summary>
	/// Adds an item to the basket.
	/// HTTP POST /shop/basket/{basketId}/items
	/// </summary>
	/// <param name="basketId">The ID of the basket.</param>
	/// <param name="request">The request representing the add operation.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated basket instance.</returns>
	Task<TrybeResponse<Basket>> AddBasketItemAsync(
		string basketId,
		AddBasketItemRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Deletes an item to the basket.
	/// HTTP DELETE /shop/basket/{basketId}/items/{basketItemId}
	/// </summary>
	/// <param name="basketId">The ID of the basket.</param>
	/// <param name="basketItemId">The ID of the basket item.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated basket instance.</returns>
	Task<TrybeResponse<Basket>> DeleteBasketItemAsync(
		string basketId,
		string basketItemId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Updates an item to the basket.
	/// HTTP PUT /shop/basket/{basketId}/items/{basketItemId}
	/// </summary>
	/// <param name="basketId">The ID of the basket.</param>
	/// <param name="basketItemId">The ID of the basket item.</param>
	/// <param name="request">The request representing the update operation.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated basket instance.</returns>
	Task<TrybeResponse<Basket>> UpdateBasketItemAsync(
		string basketId,
		string basketItemId,
		UpdateBasketItemRequest request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Updates guests on the basket.
	/// HTTP POST /shop/basket/{basketId}/update-guests
	/// </summary>
	/// <param name="basketId">The ID of the basket.</param>
	/// <param name="request">The request representing the update operation.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated basket instance.</returns>
	Task<TrybeResponse<Basket>> UpdateBasketGuestsAsync(
		string basketId,
		UpdateBasketGuestsRequest request,
		CancellationToken cancellationToken = default);
}

partial class BasketOperations
{
	public async Task<TrybeResponse<Basket>> AddBasketItemAsync(
		string basketId,
		AddBasketItemRequest itemRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));
		Ensure.IsNotNull(itemRequest, nameof(itemRequest));

		var request = new TrybeRequest<AddBasketItemRequest>(HttpMethod.Post, path + $"/{basketId}/items", itemRequest);

		return await client.FetchAsync<AddBasketItemRequest, Basket>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<TrybeResponse<Basket>> DeleteBasketItemAsync(
		string basketId,
		string basketItemId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));
		Ensure.IsNotNullOrEmpty(basketItemId, nameof(basketItemId));

		var request = new TrybeRequest(HttpMethod.Delete, path + $"/{basketId}/items/{basketItemId}");

		return await client.FetchAsync<Basket>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<TrybeResponse<Basket>> UpdateBasketItemAsync(
		string basketId,
		string basketItemId,
		UpdateBasketItemRequest itemRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));
		Ensure.IsNotNullOrEmpty(basketItemId, nameof(basketItemId));
		Ensure.IsNotNull(itemRequest, nameof(itemRequest));

		var request = new TrybeRequest<UpdateBasketItemRequest>(HttpMethod.Put, path + $"/{basketId}/items/{basketItemId}", itemRequest);

		return await client.FetchAsync<UpdateBasketItemRequest, Basket>(request, cancellationToken)
			.ConfigureAwait(false);
	}

	public async Task<TrybeResponse<Basket>> UpdateBasketGuestsAsync(
		string basketId,
		UpdateBasketGuestsRequest guestsRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(basketId, nameof(basketId));
		Ensure.IsNotNull(guestsRequest, nameof(guestsRequest));

		var request = new TrybeRequest<UpdateBasketGuestsRequest>(HttpMethod.Post, path + $"/{basketId}/update-guests", guestsRequest);

		return await client.FetchAsync<UpdateBasketGuestsRequest, Basket>(request, cancellationToken)
			.ConfigureAwait(false);
	}
}

/// <summary>
/// Represents a request to add a new basket item.
/// </summary>
public class AddBasketItemRequest
{
	/// <summary>
	/// The date selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("date")]
	public DateTime? Date { get; set; }

	/// <summary>
	/// The duration selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// The set of guests associated with this offering.
	/// </summary>
	[JsonPropertyName("guests")]
	public GuestList? Guests { get; set; }

	/// <summary>
	/// The set of custom item configuration settings.
	/// </summary>
	[JsonPropertyName("item_configuration")]
	public ObjectDictionary? ItemConfiguration { get; set; }

	/// <summary>
	/// The ID of the offering.
	/// </summary>
	[JsonPropertyName("offering_id")]
	public string OfferingId { get; set; }

	/// <summary>
	/// The type of item being added.
	/// </summary>
	[JsonPropertyName("offering_type")]
	public string OfferingType { get; set; }

	/// <summary>
	/// The overriden price, if applicable.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The quantity required of the offering, if applicable.
	/// </summary>
	[JsonPropertyName("quantity")]
	public int? Quantity { get; set; }

	/// <summary>
	/// The time selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("time")]
	public TimeSpan? Time { get; set; }
}

/// <summary>
/// Represents a request to add a new basket item.
/// </summary>
public class UpdateBasketItemRequest
{
	/// <summary>
	/// The date selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("date")]
	public DateTime? Date { get; set; }

	/// <summary>
	/// The duration selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// The set of guests associated with this offering.
	/// </summary>
	[JsonPropertyName("guests")]
	public GuestList? Guests { get; set; }

	/// <summary>
	/// The set of custom item configuration settings.
	/// </summary>
	[JsonPropertyName("item_configuration")]
	public ObjectDictionary? ItemConfiguration { get; set; }

	/// <summary>
	/// The overriden price, if applicable.
	/// </summary>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The quantity required of the offering, if applicable.
	/// </summary>
	[JsonPropertyName("quantity")]
	public int? Quantity { get; set; }

	/// <summary>
	/// The time selected for the offering, if applicable.
	/// </summary>
	[JsonPropertyName("time")]
	public TimeSpan? Time { get; set; }
}

/// <summary>
/// Represents a request to update guests for the basket.
/// </summary>
public class UpdateBasketGuestsRequest
{
	/// <summary>
	/// The set of guests for the basket.
	/// </summary>
	[JsonPropertyName("guests")]
	public GuestList Guests { get; set; }
}
