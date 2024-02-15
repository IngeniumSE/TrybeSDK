// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class PurchaseOrderItem : Model<PurchaseOrderItem>
{
	/// <summary>
	/// Gets or Sets Id
	/// </summary>	
	[JsonPropertyName("id")]
	public required string Id { get; set; }

	/// <summary>
	/// The type of item (purchasable) this order item is for.
	/// </summary>
	/// <value>The type of item (purchasable) this order item is for.</value>	
	[JsonPropertyName("item_type")]
	public string? ItemType { get; set; }

	/// <summary>
	/// The ID of the purchaseable item.
	/// </summary>
	/// <value>The ID of the purchaseable item.</value>	
	[JsonPropertyName("type_id")]
	public string? TypeId { get; set; }

	/// <summary>
	/// The name of the purchaseable item.
	/// </summary>
	/// <value>The name of the purchaseable item.</value>	
	[JsonPropertyName("type_name")]
	public string? TypeName { get; set; }

	/// <summary>
	/// The product code of the purchaseable item.
	/// </summary>
	/// <value>The product code of the purchaseable item.</value>	
	[JsonPropertyName("type_product_code")]
	public string? TypeProductCode { get; set; }

	/// <summary>
	/// The quantity purchased
	/// </summary>
	/// <value>The quantity purchased</value>	
	[JsonPropertyName("quantity")]
	public int? Quantity { get; set; }

	/// <summary>
	/// The unit price of this purchase order item
	/// </summary>
	/// <value>The unit price of this purchase order item</value>	
	[JsonPropertyName("unit_price")]
	public int? UnitPrice { get; set; }

	/// <summary>
	/// If the price has been modified, this value contains the original unit price
	/// </summary>
	/// <value>If the price has been modified, this value contains the original unit price</value>	
	[JsonPropertyName("base_price")]
	public int? BasePrice { get; set; }

	/// <summary>
	/// the total cost of this purchase order item
	/// </summary>
	/// <value>the total cost of this purchase order item</value>	
	[JsonPropertyName("total_cost")]
	public int? TotalCost { get; set; }

	/// <summary>
	/// The confirmation status of the item.
	/// </summary>
	/// <value>The confirmation status of the item.</value>	
	[JsonPropertyName("status")]
	public string? Status { get; set; }

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
	[JsonPropertyName("discount_amount")]
	public int? DiscountAmount { get; set; }

	/// <summary>
	/// An array of discounts applied to the item.
	/// </summary>
	/// <value>An array of discounts applied to the item.</value>	
	[JsonPropertyName("discounts")]
	public List<ShopDiscount>? Discounts { get; set; }

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
	/// Gets or Sets ItemConfiguration
	/// </summary>

	[JsonPropertyName("item_configuration")]
	public ObjectDictionary? ItemConfiguration { get; set; }

	/// <summary>
	/// Gets or Sets PurchasableDetails
	/// </summary>

	[JsonPropertyName("purchasable_details")]
	public ObjectDictionary? PurchasableDetails { get; set; }

	/// <summary>
	/// Determines if the item is modifiable. A purchase item is modifiable if it was created today
	/// </summary>
	/// <value>Determines if the item is modifiable. A purchase item is modifiable if it was created today</value>	
	[JsonPropertyName("is_modifiable")]
	public bool? IsModifiable { get; set; }
}
