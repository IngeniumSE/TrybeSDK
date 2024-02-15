// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class Package : ShopOffering<Package>
{
	/// <summary>
	/// A custom product code for the package.
	/// </summary>
	/// <value>A custom product code for the package.</value>	
	[JsonPropertyName("product_code")]
	public string? ProductCode { get; set; }

	/// <summary>
	/// The ID of the site the package belongs to.
	/// </summary>
	/// <value>The ID of the site the package belongs to.</value>	
	[JsonPropertyName("site_id")]
	public string? SiteId { get; set; }

	/// <summary>
	/// The rules defining periods during which this package is available
	/// </summary>
	/// <value>The rules defining periods during which this package is available</value>	
	[JsonPropertyName("availability_rules")]
	public List<AvailabilityRule>? AvailabilityRules { get; set; }

	/// <summary>
	/// The maximum amount of time between the start of the first and end of the last item on each day of a package, in minutes.
	/// </summary>
	/// <value>The maximum amount of time between the start of the first and end of the last item on each day of a package, in minutes.</value>	
	[JsonPropertyName("max_daily_duration")]
	public int? MaxDailyDuration { get; set; }

	/// <summary>
	/// Whether to prevent booking choices in this package from overlapping times.
	/// </summary>
	/// <value>Whether to prevent booking choices in this package from overlapping times.</value>	
	[JsonPropertyName("prevent_choice_overlaps")]
	public bool? PreventChoiceOverlaps { get; set; }

	/// <summary>
	/// The maximum time before the package's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations
	/// </summary>
	/// <value>The maximum time before the package's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations</value>	
	[JsonPropertyName("max_advance_bookings_interval")]
	public string? MaxAdvanceBookingsInterval { get; set; }

	/// <summary>
	/// The minimum time before the package's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations
	/// </summary>
	/// <value>The minimum time before the package's start time that it may be booked, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations</value>	
	[JsonPropertyName("min_advance_bookings_interval")]
	public string? MinAdvanceBookingsInterval { get; set; }

	/// <summary>
	/// The rules defining prices for this package
	/// </summary>
	/// <value>The rules defining prices for this package</value>	
	[JsonPropertyName("price_rules")]
	public List<PackagePriceRule>? PriceRules { get; set; }

	/// <summary>
	/// Gets or Sets Meta
	/// </summary>	
	[JsonPropertyName("meta")]
	public AppointmentTypeMeta? Meta { get; set; }

	/// <summary>
	/// Gets or Sets UpsellOfferings
	/// </summary>	
	[JsonPropertyName("upsell_offerings")]
	public List<OfferingIdentifier>? UpsellOfferings { get; set; }

	/// <summary>
	/// Gets or Sets CrossSellOfferings
	/// </summary>	
	[JsonPropertyName("cross_sell_offerings")]
	public List<OfferingIdentifier>? CrossSellOfferings { get; set; }

	/// <summary>
	/// Gets or Sets RelatedRetailOfferings
	/// </summary>	
	[JsonPropertyName("related_retail_offerings")]
	public List<OfferingIdentifier>? RelatedRetailOfferings { get; set; }

	/// <summary>
	/// Whether this session type is bookable online
	/// </summary>
	/// <value>Whether this session type is bookable online</value>

	[JsonPropertyName("offered_online")]
	public bool? OfferedOnline { get; set; }

	/// <summary>
	/// Whether this is private. When private, it is accessible from the URL but doesn't appear on category pages and isn't indexed on search engines.
	/// </summary>
	/// <value>Whether this is private. When private, it is accessible from the URL but doesn't appear on category pages and isn't indexed on search engines.</value>

	[JsonPropertyName("private")]
	public bool? Private { get; set; }

	/// <summary>
	/// Whether this package requires an active membership in order to book.
	/// </summary>
	/// <value>Whether this package requires an active membership in order to book.</value>	
	[JsonPropertyName("members_only")]
	public bool? MembersOnly { get; set; }

	/// <summary>
	/// If this package is for members only, this property may be used to restrict the offering further so it may only be purchased by active members with of one of the given membership types. 
	/// </summary>
	/// <value>If this package is for members only, this property may be used to restrict the offering further so it may only be purchased by active members with of one of the given membership types. </value>	
	[JsonPropertyName("permitted_membership_type_ids")]
	public List<string>? PermittedMembershipTypeIds { get; set; }

	/// <summary>
	/// Whether membership-specific booking windows should be enabled for this package.
	/// </summary>
	/// <value>Whether membership-specific booking windows should be enabled for this package.</value>	
	[JsonPropertyName("membership_booking_windows_enabled")]
	public bool? MembershipBookingWindowsEnabled { get; set; }

	/// <summary>
	/// Gets or Sets MembershipBookingWindows
	/// </summary>	
	[JsonPropertyName("membership_booking_windows")]
	public List<MembershipBookingWindow>? MembershipBookingWindows { get; set; }

	/// <summary>
	/// Whether bookings of this type may be cancelled online by customers. A value of `unpaid` means this booking my be cancelled only if no payments have been recorded against the order it is part of.
	/// </summary>
	/// <value>Whether bookings of this type may be cancelled online by customers. A value of `unpaid` means this booking my be cancelled only if no payments have been recorded against the order it is part of.</value>	
	[JsonPropertyName("customer_cancellation_permitted")]
	public string? CustomerCancellationPermitted { get; set; }

	/// <summary>
	/// The minimum duration that must be left before the booking in order for the customer to cancel, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations
	/// </summary>
	/// <value>The minimum duration that must be left before the booking in order for the customer to cancel, as an ISO8601 string. See https://en.wikipedia.org/wiki/ISO_8601#Durations</value>	
	[JsonPropertyName("customer_cancellation_min_duration")]
	public string? CustomerCancellationMinDuration { get; set; }

	/// <summary>
	/// The category IDs associated with this package type
	/// </summary>
	/// <value>The category IDs associated with this package type</value>	
	[JsonPropertyName("category_ids")]
	public List<string>? CategoryIds { get; set; }

	/// <summary>
	/// The default revenue centre to fall back to to balance allocations
	/// </summary>
	/// <value>The default revenue centre to fall back to to balance allocations</value>	
	[JsonPropertyName("default_revenue_centre")]
	public string? DefaultRevenueCentre { get; set; }

	/// <summary>
	/// Gets or Sets EmailOptions
	/// </summary>	
	[JsonPropertyName("email_options")]
	public OfferingEmailOptions? EmailOptions { get; set; }

	/// <summary>
	/// The time and date that the appointment type was last updated.
	/// </summary>
	/// <value>The time and date that the appointment type was last updated.</value>	
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The time and date that the appointment type was archived.
	/// </summary>
	/// <value>The time and date that the appointment type was archived.</value>	
	[JsonPropertyName("deleted_at")]
	public DateTime? DeletedAt { get; set; }
}
