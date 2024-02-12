// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A site object.
/// </summary>
public class Site
{
	/// <summary>
	/// The date and time the site was created.
	/// </summary>
	/// <value>The date and time the site was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The id of the organisation this site belongs to
	/// </summary>
	/// <value>The id of the organisation this site belongs to</value>
	[JsonPropertyName("brand_id")]
	public string? BrandId { get; set; }

	/// <summary>
	/// The name of the organisation this site belongs to
	/// </summary>
	/// <value>The name of the organisation this site belongs to</value>
	[JsonPropertyName("brand_name")]
	public string? BrandName { get; set; }

	/// <summary>
	/// The ISO-4217 currency code in lower case
	/// </summary>
	/// <value>The ISO-4217 currency code in lower case</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The subdomain which this shop is accessible from on the .try.be domain.
	/// </summary>
	/// <value>The subdomain which this shop is accessible from on the .try.be domain.</value>
	[JsonPropertyName("frontend_subdomain")]
	public string? FrontendSubdomain { get; set; }

	/// <summary>
	/// The ID of the site.
	/// </summary>
	/// <value>The ID of the site.</value>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The default locale of the site
	/// </summary>
	/// <value>The default locale of the site</value>
	[JsonPropertyName("locale")]
	public string? Locale { get; set; }

	/// <summary>
	/// The name of the site
	/// </summary>
	/// <value>The name of the site</value>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The id of the organisation this site belongs to
	/// </summary>
	/// <value>The id of the organisation this site belongs to</value>
	[JsonPropertyName("organisation_id")]
	public string? OrganisationId { get; set; }

	/// <summary>
	/// The name of the organisation this site belongs to
	/// </summary>
	/// <value>The name of the organisation this site belongs to</value>
	[JsonPropertyName("organisation_name")]
	public string? OrganisationName { get; set; }

	/// <summary>
	/// The timezone of the site
	/// </summary>
	/// <value>The timezone of the site</value>
	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }
}
