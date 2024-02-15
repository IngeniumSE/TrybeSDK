// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class BookableAreaSummary : Model<BookableAreaSummary>
{
	/// <summary>
	/// The ID of the area.
	/// </summary>
	/// <value>The ID of the area.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The name of the area.
	/// </summary>
	/// <value>The name of the area.</value>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
