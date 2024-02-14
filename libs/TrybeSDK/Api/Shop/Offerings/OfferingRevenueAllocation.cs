// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

public class OfferingRevenueAllocation
{
	/// <summary>
	/// The identifier of the revenue centre.
	/// </summary>
	/// <value>The identifier of the revenue centre.</value>	
	[JsonPropertyName("revenue_centre")]
	public string? RevenueCentre { get; set; }

	/// <summary>
	/// The amount to be allocated
	/// </summary>
	/// <value>The amount to be allocated</value>	
	[JsonPropertyName("amount")]
	public int? Amount { get; set; }
}
