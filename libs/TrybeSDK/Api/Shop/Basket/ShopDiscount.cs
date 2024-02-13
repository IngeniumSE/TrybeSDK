// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A shop discount instance.
/// </summary>
public class ShopDiscount
{
	/// <summary>
	/// The ID of the discount.
	/// </summary>
	/// <value>The ID of the discount.</value>
	[JsonPropertyName("id")]
	public required string Id { get; init; }

	/// <summary>
	/// A name associated with the discount.
	/// </summary>
	/// <value>A name associated with the discount.</value>
	[JsonPropertyName("name")]
	public required string Name { get; init; }

	/// <summary>
	/// The type of the discount amount.
	/// </summary>
	/// <value>The type of the discount amount.</value>
	[JsonPropertyName("amount_type")]
	public required string AmountType { get; init; }

	/// <summary>
	/// A calculated amount of the discount.
	/// </summary>
	/// <value>A calculated amount of the discount.</value>
	[JsonPropertyName("calculated_amount")]
	public required int CalculatedAmount { get; init; }

	/// <summary>
	/// The ID of the coupon code that applied the discount, if applicable.
	/// </summary>
	/// <value>The ID of the coupon code that applied the discount, if applicable.</value>
	[JsonPropertyName("coupon_code_id")]
	public string? CouponCodeId { get; init; }

	/// <summary>
	/// The currency code of the amount of the discount.
	/// </summary>
	/// <value>The currency code of the amount of the discount.</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; init; }

	/// <summary>
	/// The amount of the discount, if the type is `fixed_amount`.
	/// </summary>
	/// <value>The amount of the discount, if the type is `fixed_amount`.</value>
	[JsonPropertyName("fixed_amount")]
	public int? FixedAmount { get; init; }

	/// <summary>
	/// The percentage of the discount, if the type is `percentage`.
	/// </summary>
	/// <value>The percentage of the discount, if the type is `percentage`.</value>
	[JsonPropertyName("percentage")]
	public int? Percentage { get; init; }

	/// <summary>
	/// A code for the reason the discount was applied.
	/// </summary>
	/// <value>A code for the reason the discount was applied.</value>
	[JsonPropertyName("reason_code")]
	public string? ReasonCode { get; init; }

	/// <summary>
	/// Gets or Sets Coupon
	/// </summary>
	[JsonPropertyName("coupon")]
	public BasketCouponSummary? Coupon { get; init; }

	/// <summary>
	/// Where this discount is able to be applied.
	/// </summary>
	/// <value>Where this discount is able to be applied.</value>
	[JsonPropertyName("applicable_for")]
	public string? ApplicableFor { get; init; }

}
