// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket object.
/// </summary>
public class Basket : Model<Basket>
{
	/// <summary>
	/// The ID of the basket.
	/// </summary>
	/// <value>The ID of the basket.</value>
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The order reference of the completed basket.
	/// </summary>
	/// <value>The order reference of the completed basket.</value>
	[JsonPropertyName("order_ref")]
	public required string OrderRef { get; set; }

	/// <summary>
	/// The status of the basket (e.g. in progress or complete)
	/// </summary>
	/// <value>The status of the basket (e.g. in progress or complete)</value>
	[JsonPropertyName("status")]
	public required string Status { get; set; }

	/// <summary>
	/// The ID of the organisation owning the items to be added to the basket.
	/// </summary>
	/// <value>The ID of the organisation owning the items to be added to the basket.</value>
	[JsonPropertyName("organisation_id")]
	public string? OrganisationId { get; set; }

	/// <summary>
	/// The ID of the site owning the items to be added to the basket.
	/// </summary>
	/// <value>The ID of the site owning the items to be added to the basket.</value>
	[JsonPropertyName("site_id")]
	public string? SiteId { get; set; }

	/// <summary>
	/// The ID of the customer this basket belongs to.
	/// </summary>
	/// <value>The ID of the customer this basket belongs to.</value>
	[JsonPropertyName("customer_id")]
	public string? CustomerId { get; set; }

	/// <summary>
	/// The first name of the customer.
	/// </summary>
	/// <value>The first name of the customer.</value>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// The last name of the customer.
	/// </summary>
	/// <value>The last name of the customer.</value>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// The email address of the customer.
	/// </summary>
	/// <value>The email address of the customer.</value>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// The customer's phone number.
	/// </summary>
	/// <value>The customer's phone number.</value>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	/// <summary>
	/// Gets or Sets Items
	/// </summary>
	[JsonPropertyName("items")]
	public List<BasketItem>? Items { get; set; }

	/// <summary>
	/// Gets or Sets Guests
	/// </summary>
	[JsonPropertyName("guests")]
	public List<Guest>? Guests { get; set; }

	/// <summary>
	/// The total cost of all items in the basket
	/// </summary>
	/// <value>The total cost of all items in the basket</value>
	[JsonPropertyName("total_cost")]
	public int? TotalCost { get; set; }

	/// <summary>
	/// The total of all applied basket-level discounts.
	/// </summary>
	/// <value>The total of all applied basket-level discounts.</value>
	[JsonPropertyName("discount_total")]
	public int? DiscountTotal { get; set; }

	/// <summary>
	/// The total tax amount of all items in the basket
	/// </summary>
	/// <value>The total tax amount of all items in the basket</value>
	[JsonPropertyName("total_tax")]
	public int? TotalTax { get; set; }

	/// <summary>
	/// The net total of all items in the basket
	/// </summary>
	/// <value>The net total of all items in the basket</value>
	[JsonPropertyName("net_total")]
	public int? NetTotal { get; set; }

	/// <summary>
	/// The total amount to be paid in order to complete the checkout
	/// </summary>
	/// <value>The total amount to be paid in order to complete the checkout</value>
	[JsonPropertyName("submit_payment_amount")]
	public int? SubmitPaymentAmount { get; set; }

	/// <summary>
	/// The total amount to be authorised in order to complete the checkout
	/// </summary>
	/// <value>The total amount to be authorised in order to complete the checkout</value>
	[JsonPropertyName("submit_auth_amount")]
	public int? SubmitAuthAmount { get; set; }

	/// <summary>
	/// The total amount to be paid in order to settle the basket
	/// </summary>
	/// <value>The total amount to be paid in order to settle the basket</value>
	[JsonPropertyName("outstanding_payment_amount")]
	public int? OutstandingPaymentAmount { get; set; }

	/// <summary>
	/// The total amount of paid and chargable payments. This includes claimable and settled charges.
	/// </summary>
	/// <value>The total amount of paid and chargable payments. This includes claimable and settled charges.</value>
	[JsonPropertyName("total_paid_or_authed")]
	public int? TotalPaidOrAuthed { get; set; }

	/// <summary>
	/// Gets or Sets Totals
	/// </summary>
	[JsonPropertyName("totals")]
	public BasketTotals? Totals { get; set; }

	/// <summary>
	/// The payments created for the basket
	/// </summary>
	/// <value>The payments created for the basket</value>
	[JsonPropertyName("payments")]
	public List<PaymentSummary>? Payments { get; set; }

	/// <summary>
	/// An array of coupon codes applied to the basket.
	/// </summary>
	/// <value>An array of coupon codes applied to the basket.</value>
	[JsonPropertyName("coupon_codes")]
	public List<BasketCouponSummary>? CouponCodes { get; set; }

	/// <summary>
	/// An array of voucher codes applied to the basket.
	/// </summary>
	/// <value>An array of voucher codes applied to the basket.</value>
	[JsonPropertyName("voucher_codes")]
	public List<BasketVoucherSummary>? VoucherCodes { get; set; }

	/// <summary>
	/// The currency of the price for the item.
	/// </summary>
	/// <value>The currency of the price for the item.</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The time and date that the items in the basket are reserved until.
	/// </summary>
	/// <value>The time and date that the items in the basket are reserved until.</value>
	[JsonPropertyName("items_reserved_until")]
	public DateTime? ItemsReservedUntil { get; set; }

	/// <summary>
	/// Any customer requests relating to the basket
	/// </summary>
	/// <value>Any customer requests relating to the basket</value>
	[JsonPropertyName("special_requests")]
	public string? SpecialRequests { get; set; }

	/// <summary>
	/// The time and date that the basket was created.
	/// </summary>
	/// <value>The time and date that the basket was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The time and date that the basket was last updated.
	/// </summary>
	/// <value>The time and date that the basket was last updated.</value>
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The time and date that the basket was completed.
	/// </summary>
	/// <value>The time and date that the basket was completed.</value>
	[JsonPropertyName("submitted_at")]
	public DateTime? SubmittedAt { get; set; }

	/// <summary>
	/// The url for the intake form for this basket. This is only available when a basket is submitted
	/// </summary>
	/// <value>The url for the intake form for this basket. This is only available when a basket is submitted</value>
	[JsonPropertyName("intake_form_url")]
	public string? IntakeFormUrl { get; set; }
}
