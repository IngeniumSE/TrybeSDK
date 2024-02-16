// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OfferingSummary : Model<OfferingSummary>
{
	/// <summary>
	/// The ID of the offering.
	/// </summary>
	/// <value>The ID of the offering.</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The type of the offering.
	/// </summary>
	/// <value>The type of the offering.</value>
	[JsonPropertyName("type")]
	public string Type { get; set; }

	/// <summary>
	/// The name of the offering.
	/// </summary>
	/// <value>The name of the offering.</value>
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
