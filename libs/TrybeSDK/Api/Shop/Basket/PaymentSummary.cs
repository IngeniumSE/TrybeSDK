// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PaymentSummary
{
	/// <summary>
	/// The ID of the item to be added.
	/// </summary>
	/// <value>The ID of the item to be added.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The payment processor to be used for the payment
	/// </summary>
	/// <value>The payment processor to be used for the payment</value>
	[JsonPropertyName("processor")]
	public string? Processor { get; set; }

	/// <summary>
	/// The payment processor data.
	/// </summary>
	[JsonPropertyName("processor_data")]
	public ObjectDictionary? ProcessorData { get; set; }

	/// <summary>
	/// At what point the payment amount will be captured
	/// </summary>
	/// <value>At what point the payment amount will be captured</value>
	[JsonPropertyName("capture_method")]
	public string? CaptureMethod { get; set; }

	/// <summary>
	/// The amount of the payment, in the lowest denomination
	/// </summary>
	/// <value>The amount of the payment, in the lowest denomination</value>
	[JsonPropertyName("amount")]
	public int? Amount { get; set; }

	/// <summary>
	/// The currency code for the amount
	/// </summary>
	/// <value>The currency code for the amount</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The current status of the payment
	/// </summary>
	/// <value>The current status of the payment</value>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// How the payment method will be entered
	/// </summary>
	/// <value>How the payment method will be entered</value>
	[JsonPropertyName("details_source")]
	public string? DetailsSource { get; set; }

	/// <summary>
	/// If present, provides a human-readable explanation for the failure.
	/// </summary>
	/// <value>If present, provides a human-readable explanation for the failure.</value>
	[JsonPropertyName("failure_reason")]
	public string? FailureReason { get; set; }

	/// <summary>
	/// The time and date that the payment was paid.
	/// </summary>
	/// <value>The time and date that the payment was paid.</value>
	[JsonPropertyName("paid_at")]
	public DateTime? PaidAt { get; set; }

	/// <summary>
	/// The time and date that the payment was created.
	/// </summary>
	/// <value>The time and date that the payment was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }
}
