// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OrderServiceCharge
{
	/// <summary>
	/// The amount of the service charge, in minor units.
	/// </summary>
	/// <value>The amount of the service charge, in minor units.</value>	
	[JsonPropertyName("amount")]
	public int? Amount { get; set; }

	/// <summary>
	/// The percentage of the service charge.
	/// </summary>
	/// <value>The percentage of the service charge.</value>	
	[JsonPropertyName("percentage")]
	public decimal? Percentage { get; set; }

	/// <summary>
	/// Gets or Sets ItemAmounts
	/// </summary>	
	[JsonPropertyName("item_amounts")]
	public List<OrderItemServiceCharge>? ItemAmounts { get; set; }
}

public class OrderItemServiceCharge
{
	/// <summary>
	/// The ID of the basket item.
	/// </summary>
	/// <value>The ID of the basket item.</value>

	[JsonPropertyName("item_id")]
	public required string ItemId { get; set; }

	/// <summary>
	/// The amount of the service charge, in minor units.
	/// </summary>
	/// <value>The amount of the service charge, in minor units.</value>	
	[JsonPropertyName("amount")]
	public int? Amount { get; set; }

	/// <summary>
	/// The percentage of the service charge.
	/// </summary>
	/// <value>The percentage of the service charge.</value>	
	[JsonPropertyName("percentage")]
	public decimal? Percentage { get; set; }
}
