// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderPayment : PaymentSummary
{
	/// <summary>
	/// The amount of the payment that may be refunded.
	/// </summary>
	/// <value>The amount of the payment that may be refunded.</value>	
	[JsonPropertyName("refundable_amount")]
	public decimal? RefundableAmount { get; set; }

	/// <summary>
	/// Gets or Sets Refunds
	/// </summary>	
	[JsonPropertyName("refunds")]
	public List<Refund>? Refunds { get; set; }
}
