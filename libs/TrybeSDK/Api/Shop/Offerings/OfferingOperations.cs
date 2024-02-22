// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface IShopOperations
{
	/// <summary>
	/// Gets the /shop/shop/offerings operations.
	/// </summary>
	IOfferingOperations Offerings { get; }
}

partial class ShopOperations
{
	Lazy<IOfferingOperations> _offerings;
	public IOfferingOperations Offerings => (_offerings ??= client.Defer<IOfferingOperations>(
		c => new OfferingOperations(path + "/shop/offerings", client))).Value;
}

public interface IOfferingOperations
{
	/// <summary>
	/// Gets the offerings available for the given partner.
	/// HTTP GET /shop/shop/offerings
	/// </summary>
	/// <param name="siteId">The site ID.</param>
	/// <param name="partnerId">The partner ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The set of offerings.</returns>
	Task<TrybeResponse<ShopOffering[]>> GetPartnerOfferingsAsync(
		string siteId,
		string partnerId,
		CancellationToken cancellationToken = default);
}

public class OfferingOperations(PathString path, ApiClient client) : IOfferingOperations
{
	public async Task<TrybeResponse<ShopOffering[]>> GetPartnerOfferingsAsync(
		string siteId,
		string partnerId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(siteId, nameof(siteId));
		Ensure.IsNotNullOrEmpty(partnerId, nameof(partnerId));

		var query = new QueryStringBuilder()
			.AddParameter("site_id", siteId)
			.AddParameter("partner_id", partnerId)
			.Build();

		var request = new TrybeRequest(HttpMethod.Get, path, query);

		return await client.FetchAsync<ShopOffering[]>(request)
			.ConfigureAwait(false);
	}
}
