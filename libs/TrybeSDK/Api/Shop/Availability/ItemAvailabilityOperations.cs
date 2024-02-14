// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

partial interface IShopOperations
{
	/// <summary>
	/// Gets the /shop/item-availability operations.
	/// </summary>
	IItemAvailabilityOperations ItemAvailability { get; }
}

partial class ShopOperations
{
	Lazy<IItemAvailabilityOperations> _itemAvailability;
	public IItemAvailabilityOperations ItemAvailability => (_itemAvailability ??= client.Defer<IItemAvailabilityOperations>(
		c => new ItemAvailabilityOperations(path + $"/item-availability", c))).Value;
}

public interface IItemAvailabilityOperations
{
	Task<TrybeResponse<OfferingDateAvailability[]>> GetOfferingDates(
		GetOfferingDatesRequest request,
		CancellationToken cancellationToken = default);
}

public class ItemAvailabilityOperations(PathString path, ApiClient client) : IItemAvailabilityOperations
{
	public async Task<TrybeResponse<OfferingDateAvailability[]>> GetOfferingDates(
		GetOfferingDatesRequest datesRequest,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNull(datesRequest, nameof(datesRequest));

		var query = new QueryStringBuilder()
			.AddParameter("offering_type", datesRequest.OfferingType)
			.AddParameter("offering_id", datesRequest.OfferingId)
			.AddParameter("date_from", datesRequest.DateFrom.ToString("yyyy-MM-dd"))
			.AddParameter("date_to", datesRequest.DateTo.ToString("yyyy-MM-dd"))
			.AddParameter("quantity", datesRequest.Quantity)
			.Build();

		var request = new TrybeRequest(HttpMethod.Get, path + "/offering-dates", query);

		return await client.FetchAsync<OfferingDateAvailability[]>(request, cancellationToken);
	}
}

public class GetOfferingDatesRequest
{
	[JsonPropertyName("offering_type")]
	public required string OfferingType { get; set; }

	[JsonPropertyName("offering_id")]
	public required string OfferingId { get; set; }

	[JsonPropertyName("date_from")]
	public required DateTime DateFrom { get; set; }

	[JsonPropertyName("date_to")]
	public required DateTime DateTo { get; set; }

	[JsonPropertyName("quantity")]
	public required int Quantity { get; set; }
}
