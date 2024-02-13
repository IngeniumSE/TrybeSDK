// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderLabel
{
	/// <summary>
	/// The ID of the label.
	/// </summary>
	/// <value>The ID of the label.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The name of this label.
	/// </summary>
	/// <value>The name of this label.</value>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// A hex code for the label.
	/// </summary>
	/// <value>A hex code for the label.</value>
	[JsonPropertyName("color")]
	public string? Color { get; set; }

	/// <summary>
	/// The order this label belongs to
	/// </summary>
	/// <value>The order this label belongs to</value>
	[JsonPropertyName("order_id")]
	public string? OrderId { get; set; }
}
