// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class BookingSummary
{
	/// <summary>
	/// Gets or Sets Id
	/// </summary>
	[JsonPropertyName("id")]
	public required string Id { get; init; }

	/// <summary>
	/// The date and time the booking starts.
	/// </summary>
	/// <value>The date and time the booking starts.</value>
	[JsonPropertyName("start_time")]
	public DateTime? StartTime { get; init; }

	/// <summary>
	/// The date and time the booking ends.
	/// </summary>
	/// <value>The date and time the booking ends.</value>
	[JsonPropertyName("end_time")]
	public DateTime? EndTime { get; init; }

	/// <summary>
	/// The duration of this booking.
	/// </summary>
	/// <value>The duration of this booking.</value>
	[JsonPropertyName("duration")]
	public int? Duration { get; init; }

	/// <summary>
	/// The IDs of practitioners who will carry out this booking.
	/// </summary>
	/// <value>The IDs of practitioners who will carry out this booking.</value>
	[JsonPropertyName("practitioner_ids")]
	public List<string>? PractitionerIds { get; init; }

	/// <summary>
	/// Gets or Sets Practitioners
	/// </summary>
	[JsonPropertyName("practitioners")]
	public List<PractitionerSummary>? Practitioners { get; init; }

	/// <summary>
	/// The ID of the room where booking is taking place
	/// </summary>
	/// <value>The ID of the room where booking is taking place</value>
	[JsonPropertyName("room_id")]
	public string? RoomId { get; init; }

	/// <summary>
	/// Gets or Sets Room
	/// </summary>
	[JsonPropertyName("room")]
	public RoomSummary? Room { get; init; }

	/// <summary>
	/// The IDs of areas that this booking is for
	/// </summary>
	/// <value>The IDs of areas that this booking is for</value>
	[JsonPropertyName("area_ids")]
	public List<string>? AreaIds { get; init; }

	/// <summary>
	/// Gets or Sets Areas
	/// </summary>
	[JsonPropertyName("areas")]
	public List<BookableAreaSummary>? Areas { get; init; }

	/// <summary>
	/// The IDs of equipment allocated to this booking.
	/// </summary>
	/// <value>The IDs of equipment allocated to this booking.</value>
	[JsonPropertyName("equipment_ids")]
	public List<string>? EquipmentIds { get; init; }

	/// <summary>
	/// Gets or Sets Equipment
	/// </summary>
	[JsonPropertyName("equipment")]
	public List<EquipmentSummary>? Equipment { get; init; }

	/// <summary>
	/// The ID of the session if this is a session booking.
	/// </summary>
	/// <value>The ID of the session if this is a session booking.</value>
	[JsonPropertyName("session_id")]
	public string? SessionId { get; init; }

	/// <summary>
	/// The date and time the booking was created.
	/// </summary>
	/// <value>The date and time the booking was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; init; }

	/// <summary>
	/// The date and time the booking was last updated.
	/// </summary>
	/// <value>The date and time the booking was last updated.</value>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; init; }

	/// <summary>
	/// The status of the booking
	/// </summary>
	/// <value>The status of the booking</value>
	[JsonPropertyName("status")]
	public string? Status { get; init; }

	/// <summary>
	/// Gets or Sets Offering
	/// </summary>
	[JsonPropertyName("offering")]
	public OfferingSummary? Offering { get; init; }

}
