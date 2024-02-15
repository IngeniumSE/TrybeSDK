// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class SalesChannel : Model<SalesChannel>
{
	/// <summary>
	/// The ID of the sales channel.
	/// </summary>
	/// <value>The ID of the sales channel.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The ID of the organisation the sales channel belongs to.
	/// </summary>
	/// <value>The ID of the organisation the sales channel belongs to.</value>
	[JsonPropertyName("organisation_id")]
	public string? OrganisationId { get; set; }

	/// <summary>
	/// The name of the sales channel.
	/// </summary>
	/// <value>The name of the sales channel.</value>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
