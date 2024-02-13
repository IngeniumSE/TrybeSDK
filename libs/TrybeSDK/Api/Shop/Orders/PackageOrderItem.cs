// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PackageOrderItem
{
	/// <summary>
	/// Gets or Sets Id
	/// </summary>	
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// The type of item (offering) this order item is for.
	/// </summary>
	/// <value>The type of item (offering) this order item is for.</value>	
	[JsonPropertyName("item_type")]
	public string? ItemType { get; set; }

	/// <summary>
	/// The ID of the offering.
	/// </summary>
	/// <value>The ID of the offering.</value>	
	[JsonPropertyName("type_id")]
	public string? TypeId { get; set; }

	/// <summary>
	/// The name of the offering.
	/// </summary>
	/// <value>The name of the offering.</value>	
	[JsonPropertyName("type_name")]
	public string? TypeName { get; set; }

	/// <summary>
	/// The product code of the offering.
	/// </summary>
	/// <value>The product code of the offering.</value>	
	[JsonPropertyName("type_product_code")]
	public string? TypeProductCode { get; set; }

	/// <summary>
	/// Gets or Sets Guest
	/// </summary>	
	[JsonPropertyName("guest")]
	public Guest? Guest { get; set; }

	/// <summary>
	/// Gets or Sets Guests
	/// </summary>

	[JsonPropertyName("guests")]
	public GuestList? Guests { get; set; }

	/// <summary>
	/// the total cost of this booking order item
	/// </summary>
	/// <value>the total cost of this booking order item</value>	
	[JsonPropertyName("total_cost")]
	public int? TotalCost { get; set; }

	/// <summary>
	/// the total cost of this booking order item
	/// </summary>
	/// <value>the total cost of this booking order item</value>	
	[JsonPropertyName("price")]
	public int? Price { get; set; }

	/// <summary>
	/// If the price has been modified, this value contains the original unit price
	/// </summary>
	/// <value>If the price has been modified, this value contains the original unit price</value>	
	[JsonPropertyName("base_price")]
	public int? BasePrice { get; set; }

	/// <summary>
	/// the total cost of this booking order item
	/// </summary>
	/// <value>the total cost of this booking order item</value>	
	[JsonPropertyName("discount_amount")]
	public int? DiscountAmount { get; set; }

	/// <summary>
	/// The date of the item, if applicable
	/// </summary>
	/// <value>The date of the item, if applicable</value>	
	[JsonPropertyName("date")]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Whether this item was added to the basket by the customer
	/// </summary>
	/// <value>Whether this item was added to the basket by the customer</value>	
	[JsonPropertyName("added_by_customer")]
	public bool? AddedByCustomer { get; set; }

	/// <summary>
	/// The date and time the booking was created.
	/// </summary>
	/// <value>The date and time the booking was created.</value>	
	[JsonPropertyName("created_at")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The date and time the booking was last updated.
	/// </summary>
	/// <value>The date and time the booking was last updated.</value>	
	[JsonPropertyName("updated_at")]
	public DateTime? UpdatedAt { get; set; }

	/// <summary>
	/// The confirmation status of the item.
	/// </summary>
	/// <value>The confirmation status of the item.</value>	
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// If the item is a package, this will contain an array of chosen items within the package.
	/// </summary>
	/// <value>If the item is a package, this will contain an array of chosen items within the package.</value>	
	[JsonPropertyName("package_items")]
	public List<BasketPackageItem>? PackageItems { get; set; }

	/// <summary>
	/// An array of discounts applied to the item
	/// </summary>
	/// <value>An array of discounts applied to the item</value>	
	[JsonPropertyName("discounts")]
	public List<ShopDiscount>? Discounts { get; set; }

	/// <summary>
	/// Determines if the item is modifiable. A package item is modifiable if its in the future
	/// </summary>
	/// <value>Determines if the item is modifiable. A package item is modifiable if its in the future</value>
	[JsonPropertyName("is_modifiable")]
	public bool? IsModifiable { get; set; }

	/// <summary>
	/// Gets or Sets OptionBudgets
	/// </summary>
	[JsonPropertyName("option_budgets")]
	public List<BasketItemOptionBudget> OptionBudgets { get; set; }
}
