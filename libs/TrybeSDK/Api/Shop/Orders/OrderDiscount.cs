// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderDiscount : Model<OrderDiscount>
{
	/// <summary>
	/// The ID of the order discount
	/// </summary>
	/// <value>The ID of the order discount</value>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The type of the amount this discount describes.
	/// </summary>
	/// <value>The type of the amount this discount describes.</value>	
	[JsonPropertyName("amount_type")]
	public string? AmountType { get; set; }

	/// <summary>
	/// The amount of the discount if the type is `monetary`.
	/// </summary>
	/// <value>The amount of the discount if the type is `monetary`.</value>	
	[JsonPropertyName("fixed_amount")]
	public int? FixedAmount { get; set; }

	/// <summary>
	/// The amount of the discount if the type is `percentage`.
	/// </summary>
	/// <value>The amount of the discount if the type is `percentage`.</value>	
	[JsonPropertyName("percentage")]
	public int? Percentage { get; set; }

	/// <summary>
	/// The total calculated amount of this discount.
	/// </summary>
	/// <value>The total calculated amount of this discount.</value>	
	[JsonPropertyName("calculated_amount")]
	public int? CalculatedAmount { get; set; }

	/// <summary>
	/// The currency code for the discount.
	/// </summary>
	/// <value>The currency code for the discount.</value>	
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The ID of the discount type being used, if applicable.
	/// </summary>
	/// <value>The ID of the discount type being used, if applicable.</value>	
	[JsonPropertyName("discount_type_id")]
	public string? DiscountTypeId { get; set; }

	/// <summary>
	/// True if the discount amount should be taken from this model rather than the related discount type.
	/// </summary>
	/// <value>True if the discount amount should be taken from this model rather than the related discount type.</value>	
	[JsonPropertyName("is_custom_amount")]
	public bool? IsCustomAmount { get; set; }

	/// <summary>
	/// The ID of the coupon code used to add this discount, if applicable.
	/// </summary>
	/// <value>The ID of the coupon code used to add this discount, if applicable.</value>	
	[JsonPropertyName("coupon_code_id")]
	public string? CouponCodeId { get; set; }

	/// <summary>
	/// Gets or Sets Coupon
	/// </summary>	
	[JsonPropertyName("coupon")]
	public BasketCouponSummary? Coupon { get; set; }

	/// <summary>
	/// A code to describe the reason for the discount.
	/// </summary>
	/// <value>A code to describe the reason for the discount.</value>

	[JsonPropertyName("reason_code")]
	public string? ReasonCode { get; set; }
	/// <summary>
	/// The ID of the user who added the discount.
	/// </summary>
	/// <value>The ID of the user who added the discount.</value>	
	[JsonPropertyName("added_by_id")]
	public string? AddedById { get; set; }

	/// <summary>
	/// The code for the discount type.
	/// </summary>
	/// <value>The code for the discount type.</value>	
	[JsonPropertyName("discount_type_code")]
	public string? DiscountTypeCode { get; set; }

	/// <summary>
	/// Where this discount type is able to be applied.
	/// </summary>
	/// <value>Where this discount type is able to be applied.</value>	
	[JsonPropertyName("applicable_for")]
	public string? ApplicableFor { get; set; }

	/// <summary>
	/// The value of the discount to be applied when a discount type is used. This can be used as a monetary or percentage value for an in-app discount type and is set to percentage for a promo code. 
	/// </summary>
	/// <value>The value of the discount to be applied when a discount type is used. This can be used as a monetary or percentage value for an in-app discount type and is set to percentage for a promo code. </value>	
	[JsonPropertyName("discount_amount")]
	public int? DiscountAmount { get; set; }

	/// <summary>
	/// The date and time that the discount was applied.
	/// </summary>
	/// <value>The date and time that the discount was applied.</value>	
	[JsonPropertyName("applied_at")]
	public DateTime? AppliedAt { get; set; }

	/// <summary>
	/// The ID of the site the discount is associated with.
	/// </summary>
	/// <value>The ID of the site the discount is associated with.</value>

	[JsonPropertyName("site_id")]
	public string? SiteId { get; set; }
}
