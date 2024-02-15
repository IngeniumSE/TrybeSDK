// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class BasketVoucherSummary : Model<BasketVoucherSummary>
{
	/// <summary>
	/// The ID of the voucher.
	/// </summary>
	/// <value>The ID of the voucher.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The code of the voucher.
	/// </summary>
	/// <value>The code of the voucher.</value>
	[JsonPropertyName("code")]
	public required string Code { get; set; }

	/// <summary>
	/// The ID of the voucher type this voucher was created from
	/// </summary>
	/// <value>The ID of the voucher type this voucher was created from</value>
	[JsonPropertyName("voucher_type_id")]
	public string? VoucherTypeId { get; set; }

	/// <summary>
	/// The ID of the coupon code that was applied by this voucher code, if applicable
	/// </summary>
	/// <value>The ID of the coupon code that was applied by this voucher code, if applicable</value>
	[JsonPropertyName("coupon_code_id")]
	public string? CouponCodeId { get; set; }

	/// <summary>
	/// The name of the voucher.
	/// </summary>
	/// <value>The name of the voucher.</value>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// A description of the voucher.
	/// </summary>
	/// <value>A description of the voucher.</value>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The type of the voucher, i.e. monetary or 'free item'
	/// </summary>
	/// <value>The type of the voucher, i.e. monetary or 'free item'</value>
	[JsonPropertyName("amount_type")]
	public string? AmountType { get; set; }

	/// <summary>
	/// Whether this voucher code has been redeemed yet
	/// </summary>
	/// <value>Whether this voucher code has been redeemed yet</value>
	[JsonPropertyName("is_redeemed")]
	public bool? IsRedeemed { get; set; }
}
