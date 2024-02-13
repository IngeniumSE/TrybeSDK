// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

namespace TrybeSDK.Api;

partial interface ITrybeApiClient
{
	/// <summary>
	/// Gets the /site operations.
	/// </summary>
	ISiteOperations Sites { get; }
}

partial class TrybeApiClient
{
	Lazy<ISiteOperations>? _sites;
	public ISiteOperations Sites => (_sites ??= Defer<ISiteOperations>(
		c => new SiteOperations(new("/sites"), c))).Value;
}

/// <summary>
/// Provides operations for operating on the /sites endpoint.
/// </summary>
public partial interface ISiteOperations
{
	/// <summary>
	/// Deletes the site with the given ID.
	/// HTTP DELETE /site/{siteId}
	/// </summary>
	/// <param name="siteId">The site ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The Trybe response.</returns>
	Task<TrybeResponse> DeleteSiteAsync(
		string siteId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Gets the site with the given ID.
	/// HTTP GET /site/{siteId}
	/// </summary>
	/// <param name="siteId">The site ID.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The site instance.</returns>
	Task<TrybeResponse<Site>> GetSiteAsync(
		string siteId,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Gets all sites.
	/// HTTP GET /sites?page={page}&page_per={page_per}&organisationId={organisationId}
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The set of sites.</returns>
	Task<TrybeResponse<Site[]>> GetSitesAsync(
		int? page = null,
		int? pageSize = null,
		string? organisationId = default,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Updates the given site.
	/// HTTP PUT /sites/{siteId}
	/// </summary>
	/// <param name="siteId">The site ID.</param>
	/// <param name="site">The site instance.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>The updated site instance.</returns>
	Task<TrybeResponse<Site>> UpdateSiteAsync(
		string siteId,
		Site site,
		CancellationToken cancellationToken = default);
}

public partial class SiteOperations(PathString path, ApiClient client) : ISiteOperations
{
	public async Task<TrybeResponse> DeleteSiteAsync(
		string siteId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(siteId, nameof(siteId));
		var request = new TrybeRequest(HttpMethod.Delete, path + $"/{siteId}");

		return await client.SendAsync(request, cancellationToken);
	}

	public async Task<TrybeResponse<Site>> GetSiteAsync(
		string siteId,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(siteId, nameof(siteId));
		var request = new TrybeRequest(HttpMethod.Get, path + $"/{siteId}");

		return await client.FetchAsync<Site>(request, cancellationToken);
	}

	public async Task<TrybeResponse<Site[]>> GetSitesAsync(
		int? page = null,
		int? pageSize = null,
		string? organisationId = default,
		CancellationToken cancellationToken = default)
	{
		var query = new QueryStringBuilder()
			.AddParameter("page", page)
			.AddParameter("page_per", pageSize)
			.AddParameter("organisationId", organisationId)
			.Build();

		var request = new TrybeRequest(HttpMethod.Get, path, query);

		return await client.FetchAsync<Site[]>(request, cancellationToken);
	}

	public async Task<TrybeResponse<Site>> UpdateSiteAsync(
		string siteId,
		Site site,
		CancellationToken cancellationToken = default)
	{
		Ensure.IsNotNullOrEmpty(siteId, nameof(siteId));
		Ensure.IsNotNull(site, nameof(site));

		var request = new TrybeRequest<Site>(HttpMethod.Put, path + $"/{siteId}", site);

		return await client.FetchAsync<Site>(request, cancellationToken);
	}
}

