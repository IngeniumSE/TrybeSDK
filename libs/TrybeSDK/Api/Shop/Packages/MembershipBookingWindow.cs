// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class MembershipBookingWindow
{
	/// <summary>
	/// The ID of the membership type this booking window applies to.
	/// </summary>
	/// <value>The ID of the membership type this booking window applies to.</value>	
	[JsonPropertyName("membership_type_id")]
	public required string MembershipTypeId { get; set; }

	/// <summary>
	/// The maximum time before a booking's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations
	/// </summary>
	/// <value>The maximum time before a booking's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations</value>	
	[JsonPropertyName("max_advance_bookings_interval")]
	public string? MaxAdvanceBookingsInterval { get; set; }

	/// <summary>
	/// The minimum time before a booking's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations
	/// </summary>
	/// <value>The minimum time before a booking's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations</value>	
	[JsonPropertyName("min_advance_bookings_interval")]
	public string? MinAdvanceBookingsInterval { get; set; }
}
