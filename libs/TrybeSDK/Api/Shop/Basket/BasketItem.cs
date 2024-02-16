// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

/// <summary>
/// A basket item instance.
/// </summary>
public class BasketItem : Model<BasketItem>
{
	/// <summary>
	/// A unique ID for the basket item
	/// </summary>
	/// <value>A unique ID for the basket item</value>
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The type of offering the item represents.
	/// </summary>
	/// <value>The type of offering the item represents.</value>
	[JsonPropertyName("offering_type")]
	public string? OfferingType { get; set; }

	/// <summary>
	/// The ID of the offering the item represents.
	/// </summary>
	/// <value>The ID of the offering the item represents.</value>
	[JsonPropertyName("offering_id")]
	public string? OfferingId { get; set; }

	/// <summary>
	/// The name of the offering the item represents.
	/// </summary>
	/// <value>The name of the offering the item represents.</value>
	[JsonPropertyName("offering_name")]
	public string? OfferingName { get; set; }

	/// <summary>
	/// Gets or Sets Guest
	/// </summary>
	[JsonPropertyName("guest")]
	public Guest? Guest { get; set; }

	/// <summary>
	/// Details of the guests this basket item belongs to.
	/// </summary>
	/// <value>Details of the guests this basket item belongs to.</value>
	[JsonPropertyName("guests")]
	public List<Guest>? Guests { get; set; }

	/// <summary>
	/// The base price of the item in the smallest denomination, e.g. pence
	/// </summary>
	/// <value>The base price of the item in the smallest denomination, e.g. pence</value>
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// The total of all applied discounts.
	/// </summary>
	/// <value>The total of all applied discounts.</value>
	[JsonPropertyName("discount_total")]
	public int? DiscountTotal { get; set; }

	/// <summary>
	/// The total cost of this line item after any discounts
	/// </summary>
	/// <value>The total cost of this line item after any discounts</value>
	[JsonPropertyName("total_cost")]
	public int? TotalCost { get; set; }

	/// <summary>
	/// The tax percentage for this line item
	/// </summary>
	/// <value>The tax percentage for this line item</value>
	[JsonPropertyName("tax_percent")]
	public float? TaxPercent { get; set; }

	/// <summary>
	/// The amount of tax for this line item
	/// </summary>
	/// <value>The amount of tax for this line item</value>
	[JsonPropertyName("tax_amount")]
	public float? TaxAmount { get; set; }

	/// <summary>
	/// The net amount for this line item
	/// </summary>
	/// <value>The net amount for this line item</value>
	[JsonPropertyName("net_total")]
	public float? NetTotal { get; set; }

	/// <summary>
	/// The currency of the price for the item.
	/// </summary>
	/// <value>The currency of the price for the item.</value>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// The date of the item, if applicable
	/// </summary>
	/// <value>The date of the item, if applicable</value>
	[JsonPropertyName("date")]
	public string? Date { get; set; }

	/// <summary>
	/// The start date and time of the item, if applicable.
	/// </summary>
	/// <value>The start date and time of the item, if applicable.</value>
	[JsonPropertyName("time")]
	public DateTime? Time { get; set; }

	/// <summary>
	/// The duration of the item being added, in minutes, if applicable.
	/// </summary>
	/// <value>The duration of the item being added, in minutes, if applicable.</value>
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }

	/// <summary>
	/// The quantity of items being added, if applicable.
	/// </summary>
	/// <value>The quantity of items being added, if applicable.</value>
	[JsonPropertyName("quantity")]
	public int? Quantity { get; set; }

	/// <summary>
	/// The date and time that this item is reserved until
	/// </summary>
	/// <value>The date and time that this item is reserved until</value>
	[JsonPropertyName("reserved_until")]
	public DateTime? ReservedUntil { get; set; }

	/// <summary>
	/// An array of discounts applied to the item.
	/// </summary>
	/// <value>An array of discounts applied to the item.</value>
	[JsonPropertyName("discounts")]
	public List<ShopDiscount>? Discounts { get; set; }

	/// <summary>
	/// True if this item will be placed on the waitlist when the order is submitted.
	/// </summary>
	/// <value>True if this item will be placed on the waitlist when the order is submitted.</value>
	[JsonPropertyName("will_be_waitlisted")]
	public bool? WillBeWaitlisted { get; set; }

	/// <summary>
	/// If the item is a package, this will contain an array of chosen items within the package.
	/// </summary>
	/// <value>If the item is a package, this will contain an array of chosen items within the package.</value>
	[JsonPropertyName("package_items")]
	public List<BasketPackageItem>? PackageItems { get; set; }

	/// <summary>
	/// Gets or Sets Validity
	/// </summary>
	[JsonPropertyName("validity")]
	public BasketItemValidity? Validity { get; set; }

	/// <summary>
	/// Gets or Sets OptionBudgets
	/// </summary>
	[JsonPropertyName("option_budgets")]
	public List<BasketItemOptionBudget>? OptionBudgets { get; set; }
}
