// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class AppointmentTypeMeta
{
	/// <summary>
	/// The meta title of this offering. If not specified, it falls back to the name of the offering.
	/// </summary>
	/// <value>The meta title of this offering. If not specified, it falls back to the name of the offering.</value>	
	[JsonPropertyName("title")]
	public required string Title { get; set; }

	/// <summary>
	/// The meta description of this offering. If not specified, it falls back to the description of the offering.
	/// </summary>
	/// <value>The meta description of this offering. If not specified, it falls back to the description of the offering.</value>	
	[JsonPropertyName("description")]
	public string? Description { get; set; }
}
