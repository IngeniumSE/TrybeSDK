// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Net.Http.Json;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml;

namespace TrybeSDK.Api;

public class Visit
{
	/// <summary>
	/// The ID of the visit.
	/// </summary>
	/// <value>The ID of the visit.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The reference code of the visit.
	/// </summary>
	/// <value>The reference code of the visit.</value>
	[JsonPropertyName("visit_ref")]
	public string? VisitRef { get; set; }

	/// <summary>
	/// Gets or Sets VisitType
	/// </summary>
	[JsonPropertyName("visit_type")]
	public VisitType? VisitType { get; set; }

	/// <summary>
	/// The status of the visit.
	/// </summary>
	/// <value>The status of the visit.</value>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// The date and time of arrival.
	/// </summary>
	/// <value>The date and time of arrival.</value>
	[JsonPropertyName("arrival_date")]
	public DateTime? ArrivalDate { get; set; }

	/// <summary>
	/// The date and time of departure.
	/// </summary>
	/// <value>The date and time of departure.</value>
	[JsonPropertyName("departure_date")]
	public DateTime? DepartureDate { get; set; }

	/// <summary>
	/// The first name of the guest.
	/// </summary>
	/// <value>The first name of the guest.</value>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// The last name of the guest.
	/// </summary>
	/// <value>The last name of the guest.</value>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// The email address of the guest.
	/// </summary>
	/// <value>The email address of the guest.</value>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// The phone number of the guest.
	/// </summary>
	/// <value>The phone number of the guest.</value>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// The date and time to send a reminder (if applicable).
	/// </summary>
	/// <value>The date and time to send a reminder (if applicable).</value>
	[JsonPropertyName("should_send_reminder_at")]
	public DateTime? ShouldSendReminderAt { get; set; }

	/// <summary>
	/// The date and time when the visit was created.
	/// </summary>
	/// <value>The date and time when the visit was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The date and time when the visit was last updated.
	/// </summary>
	/// <value>The date and time when the visit was last updated.</value>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }
}

public class VisitType
{
	/// <summary>
	/// The ID of the visit type.
	/// </summary>
	/// <value>The ID of the visit type.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The name of the visit type.
	/// </summary>
	/// <value>The name of the visit type.</value>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
