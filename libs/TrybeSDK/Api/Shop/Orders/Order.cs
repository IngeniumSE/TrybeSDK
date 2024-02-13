// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class Order
{
	/// <summary>
	/// The ID of the basket this order represents.
	/// </summary>
	/// <value>The ID of the basket this order represents.</value>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The ID of the organisation the order belongs to.
	/// </summary>
	/// <value>The ID of the organisation the order belongs to.</value>
	[JsonPropertyName("organisation_id")]
	public string? OrganisationId { get; set; }

	/// <summary>
	/// The ID of the site the order belongs to.
	/// </summary>
	/// <value>The ID of the site the order belongs to.</value>
	[JsonPropertyName("site_id")]
	public string? SiteId { get; set; }

	/// <summary>
	/// The order reference associated with this booking.
	/// </summary>
	/// <value>The order reference associated with this booking.</value>
	[JsonPropertyName("order_ref")]
	public string? OrderRef { get; set; }

	/// <summary>
	/// The status of the order
	/// </summary>
	/// <value>The status of the order</value>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// The current stage of the order
	/// </summary>
	/// <value>The current stage of the order</value>
	[JsonPropertyName("stage")]
	public string? Stage { get; set; }

	/// <summary>
	/// Gets or Sets SalesChannel
	/// </summary>
	[JsonPropertyName("sales_channel")]
	public SalesChannel? SalesChannel { get; set; }

	/// <summary>
	/// The ID of the customer the order belongs to.
	/// </summary>
	/// <value>The ID of the customer the order belongs to.</value>
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
	/// Gets or Sets Labels
	/// </summary>
	[JsonPropertyName("labels")]
	public List<OrderLabel>? Labels { get; set; }

	/// <summary>
	/// Gets or Sets Guests
	/// </summary>
	[JsonPropertyName("guests")]
	public GuestList? Guests { get; set; }

	/// <summary>
	/// Gets or Sets Visit
	/// </summary>
	[JsonPropertyName("visit")]
	public Visit? Visit { get; set; }

	/// <summary>
	/// Gets or Sets BookingItems
	/// </summary>
	[JsonPropertyName("booking_items")]
	public List<BookingOrderItem>? BookingItems { get; set; }

	/// <summary>
	/// If the item is a package, this will contain an array of chosen items within the package.
	/// </summary>
	/// <value>If the item is a package, this will contain an array of chosen items within the package.</value>
	[JsonPropertyName("package_items")]
	public List<PackageOrderItem>? PackageItems { get; set; }

	/// <summary>
	/// The date the earliest item starts.
	/// </summary>
	/// <value>The date the earliest item starts.</value>
	[JsonPropertyName("booking_items_start_date")]
	public DateTime? BookingItemsStartDate { get; set; }

	/// <summary>
	/// The date the earliest item ends.
	/// </summary>
	/// <value>The date the earliest item ends.</value>
	[JsonPropertyName("booking_items_end_date")]
	public DateTime? BookingItemsEndDate { get; set; }

	/// <summary>
	/// Whether the items spans multiple days
	/// </summary>
	/// <value>Whether the items spans multiple days</value>
	[JsonPropertyName("booking_items_span_multiple_days")]
	public bool? BookingItemsSpanMultipleDays { get; set; }

	/// <summary>
	/// Gets or Sets PurchaseItems
	/// </summary>
	[JsonPropertyName("purchase_items")]
	public List<PurchaseOrderItem>? PurchaseItems { get; set; }

	/// <summary>
	/// A summary of the confirmation status of items within the order.
	/// </summary>
	/// <value>A summary of the confirmation status of items within the order.</value>
	[JsonPropertyName("items_status")]
	public string? ItemsStatus { get; set; }

	/// <summary>
	/// An array of notes relating to the order
	/// </summary>
	/// <value>An array of notes relating to the order</value>
	[JsonPropertyName("order_notes")]
	public List<OrderNote>? OrderNotes { get; set; }

	/// <summary>
	/// The ISO-4217 currency code in lower case
	/// </summary>
	/// <value>The ISO-4217 currency code in lower case</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The total cost of all items in the order
	/// </summary>
	/// <value>The total cost of all items in the order</value>
	[JsonPropertyName("total_cost")]
	public int? TotalCost { get; set; }

	/// <summary>
	/// The total tax amount of all items in the order
	/// </summary>
	/// <value>The total tax amount of all items in the order</value>
	[JsonPropertyName("total_tax")]
	public int? TotalTax { get; set; }

	/// <summary>
	/// The net total of all items in the order
	/// </summary>
	/// <value>The net total of all items in the order</value>
	[JsonPropertyName("net_total")]
	public int? NetTotal { get; set; }

	/// <summary>
	/// The total amount to be paid in order to complete the order
	/// </summary>
	/// <value>The total amount to be paid in order to complete the order</value>
	[JsonPropertyName("submit_payment_amount")]
	public int? SubmitPaymentAmount { get; set; }

	/// <summary>
	/// The total amount to be authorised in order to complete the order
	/// </summary>
	/// <value>The total amount to be authorised in order to complete the order</value>
	[JsonPropertyName("submit_auth_amount")]
	public int? SubmitAuthAmount { get; set; }

	/// <summary>
	/// The total amount to be paid in order to settle the order
	/// </summary>
	/// <value>The total amount to be paid in order to settle the order</value>
	[JsonPropertyName("outstanding_payment_amount")]
	public int? OutstandingPaymentAmount { get; set; }

	/// <summary>
	/// The total amount of paid and chargable payments. This includes claimable and settled charges.
	/// </summary>
	/// <value>The total amount of paid and chargable payments. This includes claimable and settled charges.</value>
	[JsonPropertyName("total_paid_or_authed")]
	public int? TotalPaidOrAuthed { get; set; }

	/// <summary>
	/// Gets or Sets ServiceCharge
	/// </summary>
	[JsonPropertyName("service_charge")]
	public OrderServiceCharge? ServiceCharge { get; set; }

	/// <summary>
	/// The total amount of tip against the order.
	/// </summary>
	/// <value>The total amount of tip against the order.</value>
	[JsonPropertyName("tip_amount")]
	public int? TipAmount { get; set; }

	/// <summary>
	/// Gets or Sets Totals
	/// </summary>
	[JsonPropertyName("totals")]
	public OrderTotals? Totals { get; set; }

	/// <summary>
	/// Gets or Sets PaymentTotals
	/// </summary>
	[JsonPropertyName("payment_totals")]
	public OrderPaymentTotals? PaymentTotals { get; set; }

	/// <summary>
	/// A list of all payments against this order.
	/// </summary>
	/// <value>A list of all payments against this order.</value>
	[JsonPropertyName("payments")]
	public List<OrderPayment>? Payments { get; set; }

	/// <summary>
	/// A list of all applied order-level discounts.
	/// </summary>
	/// <value>A list of all applied order-level discounts.</value>
	[JsonPropertyName("discounts")]
	public List<OrderDiscount>? Discounts { get; set; }

	/// <summary>
	/// The ID of the promo code applied to an order.
	/// </summary>
	/// <value>The ID of the promo code applied to an order.</value>
	[JsonPropertyName("applied_promo_code_id")]
	public string? AppliedPromoCodeId { get; set; }

	/// <summary>
	/// Gets or Sets AppliedPromoCode
	/// </summary>
	[JsonPropertyName("applied_promo_code")]
	public BasketPromoCodeSummary? AppliedPromoCode { get; set; }

	/// <summary>
	/// The total discount from the applied promo code on the order.
	/// </summary>
	/// <value>The total discount from the applied promo code on the order.</value>
	[JsonPropertyName("applied_promo_code_discount_total")]
	public int? AppliedPromoCodeDiscountTotal { get; set; }

	/// <summary>
	/// The date and time the promo code was applied
	/// </summary>
	/// <value>The date and time the promo code was applied</value>
	[JsonPropertyName("promo_code_applied_at")]
	public DateTime? PromoCodeAppliedAt { get; set; }

	/// <summary>
	/// An array of coupon codes applied to the order.
	/// </summary>
	/// <value>An array of coupon codes applied to the order.</value>
	[JsonPropertyName("coupon_codes")]
	public List<BasketCouponSummary>? CouponCodes { get; set; }

	/// <summary>
	/// An array of discount-type voucher codes applied to the basket. Monetary vouchers are included as payments.
	/// </summary>
	/// <value>An array of discount-type voucher codes applied to the basket. Monetary vouchers are included as payments.</value>
	[JsonPropertyName("voucher_codes")]
	public List<BasketVoucherSummary>? VoucherCodes { get; set; }

	/// <summary>
	/// The total value of all applied order-level discounts.
	/// </summary>
	/// <value>The total value of all applied order-level discounts.</value>
	[JsonPropertyName("discount_total")]
	public int? DiscountTotal { get; set; }

	/// <summary>
	/// Any customer requests relating to the order
	/// </summary>
	/// <value>Any customer requests relating to the order</value>
	[JsonPropertyName("special_requests")]
	public string? SpecialRequests { get; set; }

	/// <summary>
	/// The ID of the guest intake form for this order, if applicable
	/// </summary>
	/// <value>The ID of the guest intake form for this order, if applicable</value>
	[JsonPropertyName("intake_form_id")]
	public string? IntakeFormId { get; set; }

	/// <summary>
	/// The ID of the submission for the customer
	/// </summary>
	/// <value>The ID of the submission for the customer</value>
	[JsonPropertyName("customer_intake_form_submission_id")]
	public string? CustomerIntakeFormSubmissionId { get; set; }

	/// <summary>
	/// The url for the intake form for this order. Only returned on show and submission.
	/// </summary>
	/// <value>The url for the intake form for this order. Only returned on show and submission.</value>
	[JsonPropertyName("intake_form_url")]
	public string? IntakeFormUrl { get; set; }

	/// <summary>
	/// The new url for the intake form for this order. Only returned on show and submission.
	/// </summary>
	/// <value>The new url for the intake form for this order. Only returned on show and submission.</value>
	[JsonPropertyName("new_intake_form_url")]
	public string? NewIntakeFormUrl { get; set; }

	/// <summary>
	/// Whether all intake forms for the order have been completed.
	/// </summary>
	/// <value>Whether all intake forms for the order have been completed.</value>
	[JsonPropertyName("intake_forms_complete")]
	public bool? IntakeFormsComplete { get; set; }

	/// <summary>
	/// Whether the order is locked
	/// </summary>
	/// <value>Whether the order is locked</value>
	[JsonPropertyName("is_locked")]
	public bool? IsLocked { get; set; }

	/// <summary>
	/// The date the order was locked at
	/// </summary>
	/// <value>The date the order was locked at</value>
	[JsonPropertyName("locked_at")]
	public DateTime? LockedAt { get; set; }

	/// <summary>
	/// Whether the order has been posted
	/// </summary>
	/// <value>Whether the order has been posted</value>
	[JsonPropertyName("has_posted")]
	public bool? HasPosted { get; set; }

	/// <summary>
	/// The time and date that the basket was created.
	/// </summary>
	/// <value>The time and date that the basket was created.</value>
	[JsonPropertyName("posted_at")]
	public DateTime? PostedAt { get; set; }

	/// <summary>
	/// The time and date that the basket was last updated.
	/// </summary>
	/// <value>The time and date that the basket was last updated.</value>
	[JsonPropertyName("last_post_attempt")]
	public DateTime? LastPostAttempt { get; set; }

	/// <summary>
	/// True if a customer needs to be set for this order.
	/// </summary>
	/// <value>True if a customer needs to be set for this order.</value>
	[JsonPropertyName("is_customer_required")]
	public bool? IsCustomerRequired { get; set; }

	/// <summary>
	/// The time and date that the basket was created.
	/// </summary>
	/// <value>The time and date that the basket was created.</value>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The ID of the integration config associated with this order.
	/// </summary>
	/// <value>The ID of the integration config associated with this order.</value>
	[JsonPropertyName("integration_config_id")]
	public string? IntegrationConfigId { get; set; }

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
}
