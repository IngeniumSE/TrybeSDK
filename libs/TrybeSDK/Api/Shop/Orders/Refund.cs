// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class Refund
{
	/// <summary>
	/// The ID of the refund.
	/// </summary>
	/// <value>The ID of the refund.</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The ID of the payment that was refunded.
	/// </summary>
	/// <value>The ID of the payment that was refunded.</value>	
	[JsonPropertyName("payment_id")]
	public required string PaymentId { get; set; }

	/// <summary>
	/// The amount of the refund.
	/// </summary>
	/// <value>The amount of the refund.</value>	
	[JsonPropertyName("amount")]
	public int? Amount { get; set; }

	/// <summary>
	/// The currency code of the refund.
	/// </summary>
	/// <value>The currency code of the refund.</value>	
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Notes that were added against the refund.
	/// </summary>
	/// <value>Notes that were added against the refund.</value>

	[JsonPropertyName("notes")]
	public string? Notes { get; set; }

	/// <summary>
	/// The current status of the refund
	/// </summary>
	/// <value>The current status of the refund</value>	
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// A dictionary of processor-specific data
	/// </summary>
	/// <value>A dictionary of processor-specific data</value>

	[JsonPropertyName("processor_data")]
	public ObjectDictionary? ProcessorData { get; set; }

	/// <summary>
	/// The date and time that the refund was created.
	/// </summary>
	/// <value>The date and time that the refund was created.</value>	
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }
}
