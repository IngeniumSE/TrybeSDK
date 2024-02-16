// This work is licensed under the terms of the MIT license.
// For a copy, see <https://opensource.org/licenses/MIT>.

using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TrybeSDK.Api;

[DebuggerDisplay("{Offering.ToDebuggerString(),nq}")]
public class PackageItemChoiceOption : Model<PackageItemChoiceOption>
{
	/// <summary>
	/// The ID of the item type.
	/// </summary>
	/// <value>The ID of the item type.</value>	
	[JsonPropertyName("id")]
	public string Id { get; set; }

	/// <summary>
	/// The type of item this option represents.
	/// </summary>
	/// <value>The type of item this option represents.</value>	
	[JsonPropertyName("item_type")]
	public string? ItemType { get; set; }

	/// <summary>
	/// A currency amount that this option would increase the package price by.
	/// </summary>
	/// <value>A currency amount that this option would increase the package price by.</value>	
	[JsonPropertyName("price_change")]
	public int? PriceChange { get; set; }

	/// <summary>
	/// Gets or Sets Offering
	/// </summary>

	[JsonPropertyName("offering")]
	public ShopOffering? Offering { get; set; }
}
