// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class EquipmentSummary : Model<EquipmentSummary>
{
	/// <summary>
	/// The ID of the equipment.
	/// </summary>
	/// <value>The ID of the equipment.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The name of the equipment.
	/// </summary>
	/// <value>The name of the equipment.</value>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
