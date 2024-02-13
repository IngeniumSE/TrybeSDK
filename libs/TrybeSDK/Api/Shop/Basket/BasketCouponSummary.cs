// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket coupon summary instance.
/// </summary>
public class BasketCouponSummary
{
	/// <summary>
	/// The ID of the coupon.
	/// </summary>
	/// <value>The ID of the coupon.</value>
	[JsonPropertyName("id")]
	public required string Id { get; init; }

	/// <summary>
	/// The code of the coupon.
	/// </summary>
	/// <value>The code of the coupon.</value>
	[JsonPropertyName("code")]
	public string? Code { get; init; }

	/// <summary>
	/// The name of the coupon.
	/// </summary>
	/// <value>The name of the coupon.</value>
	[JsonPropertyName("name")]
	public string? Name { get; init; }

	/// <summary>
	/// A description of the coupon.
	/// </summary>
	/// <value>A description of the coupon.</value>
	[JsonPropertyName("description")]
	public string? Description { get; init; }

	/// <summary>
	/// The customer credit this coupon relates to, if applicable.
	/// </summary>
	/// <value>The customer credit this coupon relates to, if applicable.</value>
	[JsonPropertyName("customer_credit_id")]
	public Guid? CustomerCreditId { get; init; }
}
