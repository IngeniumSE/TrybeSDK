// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderNote
{
	/// <summary>
	/// Gets or Sets Id
	/// </summary>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The order this note belongs too
	/// </summary>
	/// <value>The order this note belongs too</value>	
	[JsonPropertyName("order_id")]
	public string? OrderId { get; set; }

	/// <summary>
	/// The contents of the note.
	/// </summary>
	/// <value>The contents of the note.</value>	
	[JsonPropertyName("content")]
	public string? Content { get; set; }

	/// <summary>
	/// The ID of the user who added the note.
	/// </summary>
	/// <value>The ID of the user who added the note.</value>	
	[JsonPropertyName("created_by_id")]
	public string? CreatedById { get; set; }

	/// <summary>
	/// The date and time the note was created.
	/// </summary>
	/// <value>The date and time the note was created.</value>	
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }
}
