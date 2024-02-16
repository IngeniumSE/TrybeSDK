// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OfferingIdentifier : Model<OfferingIdentifier>
{
	/// <summary>
	/// The type of the offering.
	/// </summary>
	/// <value>The type of the offering.</value>	
	[JsonPropertyName("offering_type")]
	public string OfferingType { get; set; }

	/// <summary>
	/// The ID of the offering.
	/// </summary>
	/// <value>The ID of the offering.</value>	
	[JsonPropertyName("offering_id")]
	public string OfferingId { get; set; }

	/// <summary>
	/// The name of the offering.
	/// </summary>
	/// <value>The name of the offering.</value>	
	[JsonPropertyName("offering_name")]
	public string? OfferingName { get; set; }

	/// <summary>
	/// Any additional configuration for this offering such as a fixed duration.
	/// </summary>
	/// <value>Any additional configuration for this offering such as a fixed duration.</value>	
	[JsonPropertyName("offering_config")]
	public ObjectDictionary? OfferingConfig { get; set; }

	/// <summary>
	/// The name of the offering including any additional configuration.
	/// </summary>
	/// <value>The name of the offering including any additional configuration.</value>	
	[JsonPropertyName("display_name")]
	public string? DisplayName { get; set; }
}
