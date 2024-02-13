// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class BasketTotals
{
	/// <summary>
	/// The total cost of the basket before tax.
	/// </summary>
	/// <value>The total cost of the basket before tax.</value>
	[JsonPropertyName("net_total")]
	public int? NetTotal { get; init; }

	/// <summary>
	/// The total cost of the basket including tax.
	/// </summary>
	/// <value>The total cost of the basket including tax.</value>
	[JsonPropertyName("gross_total")]
	public int? GrossTotal { get; init; }

	/// <summary>
	/// The total amount of tax that applies to the basket.
	/// </summary>
	/// <value>The total amount of tax that applies to the basket.</value>
	[JsonPropertyName("tax")]
	public int? Tax { get; init; }

	/// <summary>
	/// The total amount that needs to be paid for the basket.
	/// </summary>
	/// <value>The total amount that needs to be paid for the basket.</value>
	[JsonPropertyName("payment_required")]
	public int? PaymentRequired { get; init; }

	/// <summary>
	/// The total payment amount that needs to be authorised for the basket.
	/// </summary>
	/// <value>The total payment amount that needs to be authorised for the basket.</value>
	[JsonPropertyName("auth_required")]
	public int? AuthRequired { get; init; }

	/// <summary>
	/// The total value of all basket- and item-level discounts applied.
	/// </summary>
	/// <value>The total value of all basket- and item-level discounts applied.</value>
	[JsonPropertyName("discounts")]
	public int? Discounts { get; init; }

	/// <summary>
	/// The total value of all vouchers applied to the basket.
	/// </summary>
	/// <value>The total value of all vouchers applied to the basket.</value>
	[JsonPropertyName("applied_vouchers")]
	public int? AppliedVouchers { get; init; }
}
