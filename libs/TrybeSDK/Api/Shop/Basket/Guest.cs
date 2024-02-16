// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A guest instance.
/// </summary>
public class Guest : Model<Guest>
{
	/// <summary>
	/// The ID of the guest.
	/// </summary>
	/// <value>The ID of the guest.</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The guest's full name.
	/// </summary>
	/// <value>The guest's full name.</value>
	[JsonPropertyName("name")]
	public string Name { get; set; }

	/// <summary>
	/// Whether this guest is the lead booker
	/// </summary>
	/// <value>Whether this guest is the lead booker</value>
	[JsonPropertyName("is_lead_booker")]
	public bool? IsLeadBooker { get; set; }

	/// <summary>
	/// The ID of the submission for the guest.
	/// </summary>
	/// <value>The ID of the submission for the guest.</value>
	[JsonPropertyName("intake_form_submission_id")]
	public string? IntakeFormSubmissionId { get; set; }

	/// <summary>
	/// True if the guest has completed their intake form.
	/// </summary>
	/// <value>True if the guest has completed their intake form.</value>
	[JsonPropertyName("intake_form_complete")]
	public bool? IntakeFormComplete { get; set; }

	/// <summary>
	/// The date and time the intake form was submitted.
	/// </summary>
	/// <value>The date and time the intake form was submitted.</value>
	[JsonPropertyName("intake_form_submitted_at")]
	public DateTime? IntakeFormSubmittedAt { get; set; }

}
