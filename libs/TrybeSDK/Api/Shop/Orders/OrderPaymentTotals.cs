// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderPaymentTotals : Model<OrderPaymentTotals>
{
	/// <summary>
	/// The total of payments in a paid status.
	/// </summary>
	/// <value>The total of payments in a paid status.</value>	
	[JsonPropertyName("paid")]
	public int? Paid { get; set; }

	/// <summary>
	/// The total of payments that are still processing.
	/// </summary>
	/// <value>The total of payments that are still processing.</value>	
	[JsonPropertyName("pending")]
	public int? Pending { get; set; }

	/// <summary>
	/// The total of payments that are ready to be charged when required.
	/// </summary>
	/// <value>The total of payments that are ready to be charged when required.</value>	
	[JsonPropertyName("chargeable")]
	public int? Chargeable { get; set; }

	/// <summary>
	/// The total of payments that have been added to the order, equal to the total of all paid, pending and chargeable payments. 
	/// </summary>
	/// <value>The total of payments that have been added to the order, equal to the total of all paid, pending and chargeable payments. </value>	
	[JsonPropertyName("provided")]
	public int? Provided { get; set; }

	/// <summary>
	/// The balance of payments still needing to be added to the order, equal to the total cost of the order minus any paid, pending and chargeable payments. 
	/// </summary>
	/// <value>The balance of payments still needing to be added to the order, equal to the total cost of the order minus any paid, pending and chargeable payments. </value>	
	[JsonPropertyName("missing")]
	public int? Missing { get; set; }

	/// <summary>
	/// The balance of payments that still need to be paid, equal to the total cost of the order minus any paid payments. 
	/// </summary>
	/// <value>The balance of payments that still need to be paid, equal to the total cost of the order minus any paid payments. </value>	
	[JsonPropertyName("unpaid")]
	public int? Unpaid { get; set; }
}
