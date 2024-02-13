// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderTotals
{
	/// <summary>
	/// The total cost of all items in the order. Item-level discounts are applied before this total is calculated.
	/// </summary>
	/// <value>The total cost of all items in the order. Item-level discounts are applied before this total is calculated.</value>	
	[JsonPropertyName("subtotal")]
	public int? Subtotal { get; set; }

	/// <summary>
	/// The total of all order-level discounts.
	/// </summary>
	/// <value>The total of all order-level discounts.</value>	
	[JsonPropertyName("order_discount")]
	public int? OrderDiscount { get; set; }

	/// <summary>
	/// The total amount to be paid for the order, after any discounts have been applied and tip and service charge amounts added. 
	/// </summary>
	/// <value>The total amount to be paid for the order, after any discounts have been applied and tip and service charge amounts added. </value>	
	[JsonPropertyName("total")]
	public int? Total { get; set; }
}
