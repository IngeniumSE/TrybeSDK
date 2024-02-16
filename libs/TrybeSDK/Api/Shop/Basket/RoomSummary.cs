// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class RoomSummary : Model<RoomSummary>
{
	/// <summary>
	/// The ID of the room.
	/// </summary>
	/// <value>The ID of the room.</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The name of the room.
	/// </summary>
	/// <value>The name of the room.</value>
	[JsonPropertyName("name")]
	public string Name { get; set; }
}
